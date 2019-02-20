import React, { Component } from 'react';
import {Layout, Menu, Icon,Avatar, Button, Tooltip} from 'antd';
import Users from '../Users/';
import Oranizations from '../Oranizations/';
import Permissionitems from '../Permissionitems/';
import Roles from '../Roles';
import { httpGet } from '../../utils/public';
import  "./index.css";

const {
    Header, Content, Footer, Sider,
} = Layout;

export default class Homes extends Component {

    constructor(){
        super();
        this.state = {
            collapsed: false,
            content :"",
            title : "",
            token:"",
            Use_disabled:true,
            Ora_disabled :true,
            Per_disabled :true,
            Rol_disabled : true,
            userName:""
        };    
    }   
        
    componentDidMount()
    {                
        var  tokens = localStorage.getItem("id_token");        
        if(tokens == null)
        {
            window.location.href = "/";
            return;
        }        

         //根据该Token信息再请求一次，获取到该用户的所有所属权限项， 然后展示对应的菜单项
        let url = "/api/Token/listPermissionCheck";
        httpGet(url, null).then(data => {
            if (data.code != "0") {
                return;
            }
            this.setState({
                userName: data.extension.userName
            });          
            var Permiss = data.extension.permissionList;  
            console.log(Permiss,"00");               
            for (var i in Permiss) {
              //  Permiss[i]="Admin";
                if (Permiss[i] == "User_Query") {
                    this.setState({
                        Use_disabled: false
                    });
                }
                if (Permiss[i] == "Role_Query") {
                    this.setState({
                        Rol_disabled: false
                    });
                }
                if (Permiss[i] == "Organization_Query") {
                    this.setState({
                        Ora_disabled: false
                    });
                }
                if (Permiss[i] == "Permissionitem_Query") {
                    this.setState({
                        Per_disabled: false
                    });
                }
                if (Permiss[i] == "Admin") {
                    
                    this.setState({
                        Per_disabled: false,
                        Ora_disabled: false,
                        Rol_disabled: false,
                        Use_disabled: false
                    });
                }
            }
        });
    }

    
    onCollapse = (collapsed) => {
        console.log(collapsed);
        this.setState({ collapsed });
    }


    /**
     * 退出登陆
     */
    logOut = () =>{
        window.location.href = "/";
        localStorage.removeItem("id_token");
    }

    MenuClick = ({ item, key, keyPath }) => {
      
        switch (key) {
            case "1":
                this.setState({
                    content: <Users />,
                    title:"用户管理"
                })
                break;
            case "2":
                this.setState({
                    content: <Roles />,
                    title:"角色管理"
                })
                break;
            case "3":
                this.setState({
                    content: <Permissionitems />,
                    title:"权限管理"
                })
                break;
            case "4":
                this.setState({
                    content: <Oranizations />,
                    title:"组织管理"
                })
                break;
            default:
                break
        }        
    }

    render() {    
        return <Layout style={{ minHeight: "100vh" }}>
            <div className="headers" style={{ position: "fixed", width: "100%",  lineHeight:"80px",  marginBottom: "50%", height: "80px" }}>                     
                <div style={{ textAlign:"right",paddingRight:"5%" , width:"100%"}}>            
                <Avatar size="large" src="../../layouts/backgrounds.jpg" /> <label><strong>{this.state.userName}</strong></label>        
                <Tooltip placement="right" title={"退出"}  >
                    <Button type="primary" icon="logout" onClick={()=>this.logOut()} ></Button>
                </Tooltip>
                </div>
            </div>
            <Sider style={{marginTop:"4.5%"}} collapsible collapsed={this.state.collapsed} onCollapse={this.onCollapse}>          
                <Menu onClick={this.MenuClick} theme="dark" defaultSelectedKeys={["1"]} mode="inline">                
                    <Menu.Item key="1"  disabled={this.state.Use_disabled} >
                    <Icon type="user" />
                    <span>用户管理</span>
                    </Menu.Item >
                    <Menu.Item key="2" disabled={this.state.Rol_disabled}>
                    <Icon type="fire" />
                    <span>角色管理</span>
                    </Menu.Item>
                    <Menu.Item key="3" disabled={this.state.Per_disabled}>
                    <Icon type="deployment-unit" />
                    <span>权限管理</span>
                    </Menu.Item>
                    <Menu.Item key="4" disabled={this.state.Ora_disabled}>
                    <Icon type="usergroup-add" />
                    <span>组织管理</span>
                    </Menu.Item>
                </Menu>
            </Sider>
            <Layout style={{marginTop:"4.5%"}}>
            <Header  style={{  paddingLeft: "1%",  background:"#ececec", textAlign: "left" }}>
                    <h2> {this.state.title}</h2>                     
            </Header>
              <Content style={{ margin: "0 16px" }}>                           
                   {this.state.content}          
                
              </Content>
              <Footer style={{ textAlign: "center" }}>
                &copy;郑强勇2018
              </Footer>
            </Layout>
          </Layout>;
    }
}
