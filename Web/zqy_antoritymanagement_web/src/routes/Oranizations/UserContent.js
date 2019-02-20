import React, { Component } from 'react';
import { Table, Button, Icon, Tooltip,Popconfirm, Alert } from 'antd';
import { CollectionCreateForm } from './ModelFrom';
import { httpPost, messageWarn, messageSuccess } from '../../utils/public';

/**组织下的用户列表 */
class UserContent extends Component {

    constructor() {
        super();
        this.state = {
            visible: false,
            ButtonDisplay: false,           
        }
    }
    showModel = () => {
        this.setState({
            visible: true
        })
    }
    handleCancel = () => {
        this.setState({ visible: false });
    }

    /**创建员工 */
    handleCreate = () => {
        const form = this.formRef.props.form;
        form.validateFields((err, values) => {            

            if (err) {
                return;
            }            
            values.organizationId = this.props.GuidAndName.Id;            
            let url = "/api/User/addUser";
            httpPost(url, values).then(data => {
                if (data.code != "0") {
                    messageWarn(data["message"]);
                    return;
                }
                form.resetFields();                
                this.setState({ visible: false });
                messageSuccess("员工添加成功");

            });
        });
    }
    saveFormRef = (formRef) => {
        this.formRef = formRef;
    }
    reset = (texts) => {
        console.log(texts, "这个是个什么东东");
        alert("事件绑定成功！");
    }

    /**
     * 删除用户
     */
    Delconfirm =(record)=>{      
         let url="/api/User/delete";
         httpPost(url,[record.id]).then(data=>{
            if (data.code != "0") {
                messageWarn(data["message"]);
                return;
            }                       
            messageSuccess("员工添加成功");
         });
        console.log(record,"删除信息是");
    }

    // /**选择表格的复选框样式始终不管怎么修改样式他的列永远都不动！！！！！！！！！！！！！！！！！！ */
    // rowSelection = {    
    //     onChange: (selectedRowKeys, selectedRows) => {
    //         console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows);
    //     },
    //     getCheckboxProps: record => ({
    //         disabled: record.name === 'Disabled User', 
    //     }),
    // };

    render() {
        
        const _this = this;
        const columns = [
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
                title: "员工状态",
                key: "isDeleted",
                dataIndex: "isDeleted",
                render: function (text) {
                    return text == true ? "离职" : "在职";
                }
            },
            {
                title: '性别',
                dataIndex: 'sex',
                key: 'sex',
                render: function (text) {
                    return text == true ? "男" : "女";
                }
            },
            {
                title: '操作',
                dataIndex: '',
                render: function (text, record) {
                    return <span>
                        <Tooltip placement="top" title="用户编辑">
                            <Button type="primary" onClick={() => _this.reset(record)} size="small" shape="circle" icon="edit" />
                        </Tooltip>
                        <Tooltip placement="top" title="用户权限设置">
                            <Button type="primary" onClick={() => _this.reset(record)} size="small" shape="circle" icon="team" />
                        </Tooltip>
                        <Popconfirm title="确认要删除吗？" onConfirm={()=> _this.Delconfirm(record)} okText="确定" cancelText="取消">
                            <Tooltip placement="top" title="删除">
                                <Button type="primary"  size="small" shape="circle" icon="delete" />
                            </Tooltip>
                        </Popconfirm>
                    </span>
                }
            }];
        return (
            <div id="uses" >
                <div style={{ float: "left", width: "100%", marginBottom: "0.5%", border: "none", background: "rgb(236, 236, 236)" }}>
                    <h2 style={{ textAlign: "left" }}>员工查询</h2>
                    <div style={{ textAlign: "left" }}>
                        <Button style={{ marginLeft: "0.5%", zIndex: "1" }} disabled={this.props.ButtonDisplay} onClick={() => { this.showModel() }} type="primary" shape="circle" size="default">
                            <Icon type="plus" />
                        </Button>
                        <CollectionCreateForm
                            wrappedComponentRef={this.saveFormRef}
                            visible={this.state.visible}
                            onCancel={this.handleCancel}
                            onCreate={this.handleCreate}
                            info={this.props.GuidAndName}
                        />                      
                    </div>
                </div>
                <Table
                    columns={columns}
                    dataSource={this.props.data}                  
                    ///rowSelection={this.rowSelection}//复选框
                />
            </div>
        )
    }
}
export default UserContent;

