import React, { Component } from 'react';
import { Table, message,Button,Tooltip } from 'antd';
import { httpPost } from '../../utils/public';
import {ModalUserRole} from './ModalUserRole';

 class UserTable extends Component {

     constructor() {
         super();
         this.state = {
             selectedItems: [],             
             data: [],
             visible: false,
             User:[]
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
         let url = "/api/User/getUsersMessages";
         httpPost(url, pages).then(data => {
             if (data.code != 0) {
                 message.error(data.message);
                 return;
             }
             this.setState({
                 data: data.extension
             })
         })
     }

     /**重置密码 */
     reset = (texts) => {
         console.log(texts, "这个是个什么东东");
         alert("事件绑定成功！");
     }

     /**用户权限设置 */
     UserRoles = (objectkey) => {

         console.log(objectkey, "对象是");
         this.setState({
             visible: true,
             User: objectkey
         });


     }

     /**模态框关闭 */
     handleCancel = () => {
         this.setState({ visible: false });
     }

     /**提交编辑 */
     handleCreate = () => {
         const form = this.formRef.props.form;
         form.validateFields((err, values) => {
             if (err) {
                 return;
             }
             console.log(values, "传递的参数是");
         });
     }
     saveFormRef = (formRef) => {
         this.formRef = formRef;
     }

    render() {        
        //为了防止this的指向发生了变化，所以绑定不了，在render函数里面保存this值到局部变量。
         const _this = this;
         const columns= [
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
                render: function (texts) {
                    return texts == true ? "离职" : "在职";
                }
            },
            {
                title: '性别',
                dataIndex: 'sex',
                key: 'sex',
                render: function (texts) {
                    return texts == true ? "男" : "女";
                }
            },
            {
                title: '操作',
                dataIndex: 'caozuo',
                render: function (texts, record) {
                    return <span>
                             <Tooltip placement="top" title="用户编辑">
                                <Button type="primary" onClick={() => _this.reset(record)} size="small" shape="circle" icon="edit" />
                            </Tooltip>                          
                            <Tooltip placement="top" title="用户权限设置">
                                <Button type="primary" onClick={() => _this.UserRoles(record)} size="small" shape="circle" icon="team" />
                            </Tooltip>    
                            <Tooltip placement="top" title="重置密码">
                                <Button type="primary" onClick={() => _this.reset(record)} size="small" shape="circle" icon="redo" />
                            </Tooltip>   
                    </span>
                }
            }];
        return (            
            <div id="uses">                  
                <ModalUserRole
                    wrappedComponentRef={this.saveFormRef}
                    visible={this.state.visible}
                    onCancel={this.handleCancel}
                    onCreate={this.handleCreate}   
                    userName={this.state.User}                                                                       
                />
                <Table
                    columns={columns}
                    dataSource={this.state.data}
                />
            </div>
        )
    }
}

export default UserTable;
