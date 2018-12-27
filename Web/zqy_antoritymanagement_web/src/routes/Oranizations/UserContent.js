import React, { Component } from 'react';
import { Table, Button, Icon} from 'antd';
import {CollectionCreateForm} from './ModelFrom';
import { httpPost, messageWarn } from '../../utils/public';



/**组织下的用户列表 */
class UserContent extends Component {

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
            visible: false,
            ButtonDisplay:false

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
            console.log(values,"传递的参数是");    
            let url="/api/User/addUser";            
            httpPost(url,values).then(data => {
                if(data.code != "0")
                {
                    messageWarn(data["message"]);
                }     
                form.resetFields();
                alert("添加成功！")                
                this.setState({ visible: false });            
            });          
        });
    }
    saveFormRef = (formRef) => {
        this.formRef = formRef;
    }
    render() {       
        return (          
            <div id="uses" >              
                <div style={{ float: "left", width: "100%", marginBottom: "0.5%", border: "none", background: "rgb(236, 236, 236)" }}>
                    <h2 style={{ textAlign: "left" }}>员工查询</h2>
                    <div style={{ textAlign: "left" }}>
                        <Button style={{ marginLeft: "0.5%",zIndex:"1" }} disabled={this.props.ButtonDisplay} onClick={()=>{this.showModel()}} type="primary" shape="circle" size="default">
                            <Icon type="plus" />
                        </Button>                   
                        <CollectionCreateForm
                            wrappedComponentRef={this.saveFormRef}
                            visible={this.state.visible}
                            onCancel={this.handleCancel}
                            onCreate={this.handleCreate}
                            info={this.props.GuidAndName}
                        />
                        <Button style={{ marginLeft: "0.5%",zIndex:"1" }} type="primary" shape="circle" size="default">
                            <Icon type="delete" />
                        </Button>
                    </div>
                </div>
                <Table
                    columns={this.state.columns}
                    dataSource={this.props.data}
                />
            </div>
        )
    }
}
export default UserContent;

