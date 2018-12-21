import React, { Component } from 'react';
import {
    Layout, Menu, Breadcrumb, Icon,
} from 'antd';

// import Users from '../Users/';
import Oranizations from '../Oranizations/';

const {
    Header, Content, Footer, Sider,
} = Layout;


 
export  default class Homes extends Component {
    state = {
        collapsed: false,
    };

    onCollapse = (collapsed) => {
        console.log(collapsed);
        this.setState({ collapsed });
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
                    <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
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
                        <Menu.Item key="4">
                            <Icon type="desktop" />
                            <span>组织管理</span>
                        </Menu.Item>                       
                    </Menu>
                </Sider>
                <Layout>
                    <Header style={{ background: '#fff', padding: 0 }} />
                    <Content style={{ margin: '0 16px' }}>
                        <Breadcrumb style={{ margin: '16px 0' }}>
                            <Breadcrumb.Item>User</Breadcrumb.Item>
                            <Breadcrumb.Item>Bill</Breadcrumb.Item>
                        </Breadcrumb>
                        <div style={{ padding: 24, background: '#fff', minHeight: 600 }}>
                            <Oranizations />
                       </div>
                    </Content>
                    <Footer style={{ textAlign: 'center' }}>
                        Ant Design ©2018 Created by Ant UED
            </Footer>
                </Layout>
            </Layout>
        );
    }
}
