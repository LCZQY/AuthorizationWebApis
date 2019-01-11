import React, { Component } from 'react';
import {
    Layout, Menu, Icon,
} from 'antd';

import Users from '../Users/';
import Oranizations from '../Oranizations/';
import Permissionitems from '../Permissionitems/';
import Roles from '../Roles';
const {
    Header, Content, Footer, Sider,
} = Layout;

export default class Homes extends Component {

    constructor(){
        super();
        this.state = {
            collapsed: false,
            content :<Users />  ,
            title : "",
            token:""
        };    
    }   
        
    componentDidMount()
    {        
        //用携带的Token，请求后台判断是否过期和验证其角色和身份！！！！ 然后展示对应的菜单项
        var  tokens = localStorage.getItem("id_token");        
        if(tokens == null)
        {
            window.location.href = "/";
        }
    }
    
    onCollapse = (collapsed) => {
        console.log(collapsed);
        this.setState({ collapsed });
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
        return (
            <Layout style={{ minHeight: '100vh' }}>
                <Sider
                    collapsible
                    collapsed={this.state.collapsed}
                    onCollapse={this.onCollapse}
                >
                    <div className="logo" />
                    <Menu onClick={this.MenuClick} theme="dark" defaultSelectedKeys={['1']} mode="inline">
                        <Menu.Item key="1">
                            <Icon type="user" />
                            <span>用户管理</span>
                        </Menu.Item>
                        <Menu.Item key="2">
                            <Icon type="fire" />
                            <span>角色管理</span>
                        </Menu.Item>
                        <Menu.Item key="3">
                            <Icon type="deployment-unit" />
                            <span>权限管理</span>
                       </Menu.Item>
                        <Menu.Item key="4" >
                            <Icon type="usergroup-add" />
                            <span>组织管理</span>
                        </Menu.Item>
                    </Menu>
                </Sider>
                <Layout>
                    <Header style={{ background: 'rgb(236,236,236)', paddingLeft: "1%", textAlign: "left" }} >                                  <h2> {this.state.title}</h2>
                    </Header>
                    <Content style={{ margin: '0 16px' }}>                      
                         { this.state.content}                               
                    </Content>
                    <Footer style={{ textAlign: 'center' }}>
                        &copy;郑强勇2018
                  </Footer>
                </Layout>
            </Layout>
        );
    }
}
