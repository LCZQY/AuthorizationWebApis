import React, { Component } from 'react';
import {
    Layout, Menu, Breadcrumb, Icon,
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
            content : ""  ,
            title : "",
            token:""
        };    
    }   

    /**每次访问Home页面就检查该Token值是否存在，如果不存在就跳回从新登陆 ??*/
    componentDidMount()
    {

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
                            <Icon type="pie-chart" />
                            <span>用户管理</span>
                        </Menu.Item>
                        <Menu.Item key="2">
                            <Icon type="desktop" />
                            <span>角色管理</span>
                        </Menu.Item>
                        <Menu.Item key="3">
                            <Icon type="pie-chart" />
                            <span>权限管理</span>
                       </Menu.Item>
                        <Menu.Item key="4" >
                            <Icon type="desktop" />
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
