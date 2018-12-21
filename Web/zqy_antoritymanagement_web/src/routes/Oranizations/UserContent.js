import React, { Component } from 'react';
import { Table, Input, Button, Select, message, Icon } from 'antd';
import { $Url } from '../../utils/public';
import "./index.css";


class Users extends Component {
    constructor() {
        super();
        this.state = {                       
            columns: [
                {
                    title: 'key',
                    dataIndex: 'id',
                    key: "id",
                    render: function (text) {
                        return <a href="##:;">{text}</a>;
                    }
                },
                {
                    title: '组织',
                    dataIndex: 'organizationId',
                    key: 'organizationId'
                },
                {
                    title: '父级ID',
                    dataIndex: 'parentId',
                    key: 'parentId'
                },
                {
                    title: '真实姓名',
                    dataIndex: 'trueName',
                    key: 'trueName'
                },
                {
                    title: '用户名',
                    dataIndex: 'userName',
                    key: 'userName'
                },
                {
                    title: '联系方式',
                    dataIndex: 'phoneNumber',
                    key: 'phoneNumber'
                },
                {
                    title: '性别',
                    dataIndex: 'sex',
                    key: 'sex'
                },
                {
                    title: '操作',
                    dataIndex: '',
                    render: function (text, record) {
                        return <span>
                            <a href="##:;">删除</a>
                            <span className="ant-divider"></span>
                            <a href="##:;">增加</a>
                            <span className="ant-divider"></span>
                            <a href="##:;" className="ant-dropdown-link">
                                修改 <i className="anticon anticon-down"></i>
                            </a>
                            <a href="##:;" className="ant-dropdown-link">
                                重置密码 <i className="anticon anticon-down"></i>
                            </a>
                        </span>;
                    }
                }],
            data: []
        }
    }

    //组件第一次渲染完成，此时dom节点已经生成，可以调用Ajax请求
    componentDidMount() {
        this.Initialization();
    }

    //初始化用户列表
    Initialization = () => {
        var pages = {
            "pageIndex": 0,
            "pageSize": 10
        }

        // 获取用户信息
            let url = $Url + "/api/User/GetUsersMessages";
            fetch(url, {
                method: 'POST',
                headers: { "Content-Type": "application/json", "Accept": "application/json" },
                body: JSON.stringify(pages)
            })
            .then(response => response.json())
            .then(
                data => {
                    if (data.code != 0) {
                        message.error(data.message);
                        return;
                    }
                    console.log(data.extension, "用户信息列表");
                    var dataSources = data.extension;
                    this.setState({
                        data: dataSources
                    })
                }
            ).catch((error) => {
                console.error(error, "获取用户信息报错。");
           });
    }

    //render 中尽量是Dom节点
    render() {           
        return (
            <div id="uses">                
                <div style={{ float: "left", width: "100%", marginBottom: "0.5%", border: "none", background: "rgb(236, 236, 236)" }}>
                    <h2 style={{ textAlign: "left" }}>员工查询</h2>
                    <div style={{ textAlign: "left" }}>
                        <Button style={{ marginLeft: "0.5%" }} type="primary" shape="circle" size="default">
                            <Icon type="plus" />
                        </Button>
                        <Button style={{ marginLeft: "0.5%" }} type="primary" shape="circle" size="default">
                            <Icon type="delete" />
                        </Button>
                    </div>                   
                </div>
                <Table
                    columns={this.state.columns}
                    dataSource={this.state.data}
                />
            </div>
        )
    }
}

export default Users;
