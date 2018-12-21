import React, { Component } from 'react';
import { Table, Input, Button, Select, message } from 'antd';
import {  httpPost } from '../../utils/public';
import "./index.css";


//const : 一般在class外面定义的变量
const OPTIONS = ['Apples', 'Nails', 'Bananas', 'Helicopters'];
const Option = Select.Option;

function handleChange(value) {
    console.log(`selected ${value}`);
}

function handleBlur() {
    console.log('blur');
}

function handleFocus() {
    console.log('focus');
}
class Users extends Component {

    constructor() {
        super();
        this.state = {
            selectedItems: [],
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

    handleChange = selectedItems => {
        this.setState({ selectedItems });
    };
    //组件第一次渲染完成，此时dom节点已经生成，可以调用Ajax请求
    componentDidMount() {
        this.Initialization();
    }

    //员工列表查询
    Search = () => {
        alert(0);
    }
    //初始化用户列表
    Initialization = () => {
        var pages = {
            "pageIndex": 0,
            "pageSize": 10
        }
        // 获取用户信息
        let url = "/api/User/getUsersMessages";
        httpPost(url, pages).then(data => {
            if (data.code != 0) {
                message.error(data.message);
                return;
            }
            console.log(data.extension, "用户信息列表");
            var dataSources = data.extension;
            this.setState({
                data: dataSources
            })
        })       
    }

    //render 中尽量是Dom节点
    render() {
        const { selectedItems } = this.state;
        const filteredOptions = OPTIONS.filter(o => !selectedItems.includes(o));
        return (
            <div id="uses">
                <div style={{ float: "left", width: "100%", marginBottom: "0.5%", border: "none", background: "rgb(236, 236, 236)" }}>
                    <h2 style={{ textAlign: "left" }}>员工查询</h2>
                    {/* <div style={{ textAlign: "left" }}>
                        <Button style={{ marginLeft: "0.5%" }} type="primary" shape="circle" size="default">
                            <Icon type="plus" />
                        </Button>
                        <Button style={{ marginLeft: "0.5%" }} type="primary" shape="circle" size="default">
                            <Icon type="delete" />
                        </Button>
                    </div> */}
                    <talbe style={{ float: "left", width: "80%" }}>
                        <tr>
                            <td style={{ textAlign: "right" }}>用户名：</td>
                            <td><Input style={{ zIndex: "1" }} /></td>
                            <td style={{ textAlign: "right" }}>所属角色：</td>
                            <td> <Select
                                showSearch
                                style={{ width: 200, zIndex: "1" }}
                                placeholder="Select a person"
                                optionFilterProp="children"
                                onChange={handleChange}
                                onFocus={handleFocus}
                                onBlur={handleBlur}
                                filterOption={(input, option) => option.props.children.toLowerCase().indexOf(input.toLowerCase()) >= 0}
                            >
                                <Option value="jack">Jack</Option>
                                <Option value="lucy">Lucy</Option>
                                <Option value="tom">Tom</Option>
                            </Select>
                            </td>
                            <td style={{ textAlign: "right" }}>所属部门：</td>
                            <td>
                                <Select
                                    mode="multiple"
                                    placeholder="Inserted are removed"
                                    value={selectedItems}
                                    onChange={this.handleChange}
                                    style={{ width: '100%', zIndex: "1" }}
                                >
                                    {filteredOptions.map(item => (
                                        <Select.Option key={item} value={item}>
                                            {item}
                                        </Select.Option>
                                    ))}
                                </Select>
                            </td>
                            <td>   <Button type="primary" style={{ zIndex: "2" }} onClick={() => { this.Search() }} icon="search">查询</Button></td>
                        </tr>
                    </talbe>

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
