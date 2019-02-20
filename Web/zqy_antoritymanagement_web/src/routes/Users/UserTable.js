import React, { Component } from 'react';
import { Table, message, Button, Tooltip } from 'antd';
import { httpPost, messageSuccess, messageError, messageWarn, httpGet } from '../../utils/public';
import { ModalUserRole } from './ModalUserRole';
import { ModalUserEdit } from './ModalUserEdit';

class UserTable extends Component {

    constructor() {
        super();
        this.state = {
            selectedItems: [],
            data: [],
            visible: false,
            Editvisible: false,
            EditData: [],
            User: [],
            SelectData: [],
            defaultOptions: [],
            totalCount: 0
        }
    }
    //组件第一次渲染完成，此时dom节点已经生成，可以调用Ajax请求
    componentDidMount() {
        this.props.onRef(this);
        this.Initialization(0);
        clearTimeout(this.myClear);
    }

    //初始化用户列表
    Initialization = (index, parameter = {}) => {
        parameter.pageIndex = index;
        parameter.pageSize = 10;
        console.log(parameter, "传入");
        /**获取用户信息 */
        let url = "/api/User/getUsersMessages";
        httpPost(url, parameter).then(data => {
            if (data.code != 0) {
                message.error(data.message);
                return;
            }
            this.setState({
                data: data.extension,
                EditData: [],
                totalCount: data.totalCount
            });
        });

        /**获取组织列表 */
        url = "/api/Oranizations/createTreeStructure/0";
        httpPost(url, null).then(data => {
            if (data.code != "0") {
                messageWarn(data["message"]);
                return;
            }
            this.setState({
                SelectData: data.extension
            });
        });
    }

    /**重置密码 */
    UserEdit = (texts) => {
        console.log(texts, "这个是个什么东东");
        this.setState({
            Editvisible: true,
            EditData: texts
        })
    }

    /**用户权限设置 */
    UserRoles = (objectkey) => {
        let url = "/api/Roles/getUserRolesList/" + objectkey.id;
        httpGet(url, null).then(data => {
            if (data.code != 0) {
                messageError(data.message);
                return;
            }
            this.setState({
                defaultOptions: data.extension
            });
        });
        this.setState({
            visible: true,
            User: objectkey,
            totalCount: 0
        });
    }

    /**模态框关闭 */
    handleCancel = () => {

        this.setState({
            visible: false,
            Editvisible: false
        });
    }

    /**添加用户角色数据 提交编辑 */
    handleCreate = () => {
        const form = this.formRefs.props.form;
        form.validateFields((err, values) => {
            if (err) {
                messageError(err);
                this.setState({
                    visible: false
                });
                return;
            }
            let url = "/api/Roles/add/UserRoles";
            var body = {
                userId: values.id,
                roleId: values.rolesID,
                userName: values.trueName
            }
            httpPost(url, body).then(data => {
                if (data.code != 0) {
                    this.setState({
                        visible: false
                    });
                    messageError(data.message);
                    return;
                }
                this.setState({
                    visible: false
                });
                messageSuccess("用户绑定角色成功！");
            });
        });
    }

    /**编辑用户信息 */
    userEditSubmit = () => {
        const form = this.formRef.props.form;
        form.validateFields((err, values) => {
            if (err) {
                messageError(err);
                this.setState({
                    Editvisible: false,
                });
                return;
            }
            console.log(values, "··");
            let url = "/api/User/addUser";
            httpPost(url, values).then(data => {
                if (data.code != "0") {
                    messageError(data.message);
                }
                this.Initialization(0)
                this.setState({
                    Editvisible: false
                });
                //清空表单
                this.myClear = setTimeout(this.formRef.props.form.resetFields, 2000);
                messageSuccess("修改用户信息成功！");
            });
        });
    }

    saveFormRef = (formRef) => {
        this.formRef = formRef;
    }
    saveFormRefs = (formRef) => {
        this.formRefs = formRef;
    }

    /**分页按钮 */
    handlePageChange = (pagination, filters, sorter) => {
        this.Initialization(pagination.current - 1);
    }

    render() {

        const _this = this;      //为了防止this的指向发生了变化，所以绑定不了，在render函数里面保存this值到局部变量。
        const paginationProps = {
            pageSize: 10,
            total: _this.state.totalCount,              //后台读取的total
        }
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
                            <Button type="primary" onClick={() => _this.UserEdit(record)} size="small" shape="circle" icon="edit" />
                        </Tooltip>
                        <Tooltip placement="top" title="用户权限设置">
                            <Button type="primary" onClick={() => _this.UserRoles(record)} size="small" shape="circle" icon="team" />
                        </Tooltip>
                    </span>
                }
            }];
        return (
            <div id="uses">
                <ModalUserRole
                    wrappedComponentRef={this.saveFormRefs}
                    visible={this.state.visible}
                    onCancel={this.handleCancel}
                    onCreate={this.handleCreate}
                    userName={this.state.User}
                    defaultOption={this.state.defaultOptions}
                />
                <ModalUserEdit
                    wrappedComponentRef={this.saveFormRef}
                    visible={this.state.Editvisible}
                    onCancel={this.handleCancel}
                    onCreate={this.userEditSubmit}
                    data={this.state.EditData}
                    OptionsData={this.state.SelectData}
                />
                <Table
                    columns={columns}
                    dataSource={this.state.data}
                    pagination={paginationProps}
                    onChange={this.handlePageChange}
                    rowKey="id"
                    bordered={false}
                />
            </div>
        )
    }
}

export default UserTable;
