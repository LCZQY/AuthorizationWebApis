import React, { Component } from 'react';
import { Layout, Menu, Button, Tooltip, Collapse, Checkbox,Popconfirm } from 'antd';
import { httpPost, messageError, messageSuccess, messageWarn, httpGet } from '../../utils/public';
import "./roles.css";
import { ModalEdit } from './ModalEdit';
import SelectTree from "./SelectTree";


const CheckboxGroup = Checkbox.Group;
const { Content, Sider } = Layout;

const PermissionId = ""; //权限Id
let RolesId = ""; //角色Id
let OranizationId = {}; //组织ID
let endArray = []; //每个权限对应的组织范围

class Roles extends Component {

    constructor() {

        super();
        this.state = {
            RoleList: {}, //角色列表
            visible: false, //模态框状态
            datas: {}, //角色信息
            OptionsData: {}, //组织列表
            title: "", //模态框标题
            CollapseData: {}, //面板数据
            _checkState: false, //组织数的选择框
            _saveDisable: true,//工具权限保存按钮
            optionDisable: true, //多选框禁止
            _ResetKeys: [],//存放集合的key
            _OranizationScoed: [],
            defaultvaluePermiss:[], //角色的所有权限
            allOwn:true //选择全部或本组织
        }
        Object.assign(this.state, this.props);
    }

    componentDidMount() {
        clearTimeout(this.myClear);
        this.Initialization();
    }

    /**初始化数据 */
    Initialization = () => {
        /**角色列表数据 */
        let url = "/api/Roles/ListRoles";
        httpPost(url, null).then(data => {
            if (data.code != "0") {
                messageError(data["message"]);
                return;
            }
            this.setState({
                RoleList: data.extension
            })
        });

        /**顶级部门数据 */
        url = "/api/Oranizations/createTreeStructure/0";
        httpPost(url, null).then(data => {
            if (data.code != "0") {
                messageWarn(data["message"]);
                return;
            }
            this.setState({
                OptionsData: data.extension
            })
        });

        /**工具权限数据 */
        url = "/api/Jurisdiction/getGroupPermissionList/";
        var bodys = {
            pageIndex: 0,
            pageSize: 10
        }
        httpPost(url, bodys).then(data => {
            if (data.code != "0") {
                messageWarn(data["message"]);
            }            
            this.setState({
                CollapseData: data.extension
            });
        });
    }

    /**角色列表 */
    MenuClick = ({ item, key, keyPath }) => {
        
        ///点击该角色请问该角色的权限???   
        /**
         *  多选框默认选中后再次刷新后不能被赋值？？
         */
        var url ="/api/Roles/getRolePermisionList/"+key;
        httpGet(url,null).then(data =>{
            if (data.code != "0") {
                messageWarn(data["message"]);
            }            
            console.log("该角色id是"+key," ，拥有的权限是："+ data.extension);
           this.setState({
                defaultvaluePermiss: data.extension
           });
        });

        //选择角色后就启用保存按钮        
        this.setState({
            _saveDisable: false,
            optionDisable: false,
            allOwn:false
        });
        this.RolesId = key;
    }

    /**组织范围权限选择 */
    checkbox = (checkedValue,e) => {
      
        /// 如何展示该权限的组织范围？？？？？？？？【无法确定该权限是否处于选中状态】
        if (checkedValue[0] != null) {

             this.permissionsId = checkedValue[0];                                   
            this.setState({
                _checkState: true,
                _ResetKeys: []
            });
        } else {
            this.setState({
                _checkState: false,
                _ResetKeys: []
            });       
        }
    }
 
    /**组织范围Id */
    OranChecked = (arry) => {
        this.OranizationId = arry;           
        this.setState({
            _ResetKeys: arry,
            _OranizationScoed: arry
        })
    }


    /**组织权限保存 */
    save = () => {
        // 一个角色对应多个权限 该权限又有组织范围 ，保存该数据时只保留该组织的最高部门即可！ 判断该角色时只需要，在数据库中查询该组织Id有无子集组织既是权限范围..                        
        /** 优化方案： 这里的数组是记录的一个权限项对应的多个组织id，没有办法一次性提交多个，只能一次提交一个权限         **/                     
        endArray.push({
            permissionsId: this.permissionsId,
            organizationScope: this.OranizationId,        
        });      
        var body = {
            roledId: this.RolesId,
            permissionsScopes: endArray
        }      
        let url = "/api/Roles/add/RolePermissions";
        httpPost(url, body).then(data => {
            if (data.code != "0") {
                messageWarn(data.message);
                return;
            }
            messageSuccess("角色赋予权限成功.");
            window.location.reload();
        });
    }

    /**模态框打开，编辑角色 */
    showModal = (objectkey) => {
        console.log(objectkey, "对象是");
        this.setState({
            visible: true,
            datas: objectkey,
            title: "编辑角色"
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
            let url = "/api/Roles/add";
            httpPost(url, values).then(data => {
                if (data.code != "0") {
                    messageError(data["message"]);
                    return;
                }
                messageSuccess("操作成功");
                this.setState({
                    visible: false
                })
                this.Initialization();    
                //注意点：内部回调函数this.props.form.resetFields不要带括号，否则无效
                this.myClear = setTimeout(this.props.form.resetFields,2000);
            });
        });
    }
    saveFormRef = (formRef) => {
        this.formRef = formRef;
    }

    /**添加角色 */
    add = () => {
        this.setState({
            visible: true,
            datas: {},
            title: "添加角色"
        });
    }

    /**删除角色 */
    Delconfirm = (obj) =>{
        console.log(obj,"删除角色的ID是");
        var  url="/api/Roles/delete";      
        httpPost(url,[obj.id]).then(data =>{
            if (data.code != "0") {
                messageError(data["message"]);
                return;
            }            
            messageSuccess("角色删除成功");          
            this.Initialization();    
        });
    }
    
    /**全部或者本组织 */
    optionOranScope = (checkedValue) => {
        if (checkedValue[0] != null) {

            this.OranizationId = checkedValue;
       
            if (checkedValue == "all") {
                console.log(checkedValue, "全部或者本组织------------------");
                this.setState({
                    allOwn:false
                });
            }
            if (checkedValue == "own") {
                console.log(checkedValue, "全部或者本组织------------------");
            }
        }                
    }

    render() {

        var obj = this.state.RoleList
        var panel = this.state.CollapseData || [];
        var _this = this;
        console.log(_this.state.defaultvaluePermiss,"我默认选中的是》》》》》")
        let defaultValues= _this.state.defaultvaluePermiss || [];

        const options = [
            { label: '全部', value: 'all', disabled: _this.state.optionDisable},
            { label: '本组织', value: 'own', disabled: _this.state.allOwn },
        ];

        return (
            <div>
                <Content>
                    <table style={{ width: "100%" }}>
                        <tbody>
                            <tr style={{ background: "#FFF" }}>
                                <td style={{ textAlign: "left", width: "1.28%" }}>
                                    <h2 style={{ float: "left" }}>角色列表 </h2>
                                    <Tooltip placement="top" title="新增角色">
                                        <Button type="primary" onClick={() => _this.add()} size="default" shape="circle" icon="plus" />
                                    </Tooltip>
                                </td>
                                <td style={{ textAlign: "left" }}>
                                    <h2 style={{ float: "left" }}>工具权限 </h2>
                                    <Tooltip placement="top" title="保存工具权限">
                                        <Button disabled={this.state._saveDisable} type="primary" onClick={() => _this.save()} size="default" shape="circle" icon="save" />
                                    </Tooltip>
                                    <span style={{ color: "red" }}>&nbsp;请谨慎操作,报错请重试.</span>
                                </td>
                                <td style={{ textAlign: "center" }}>
                                    <h2 >组织权限 </h2>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    {/* 左侧角色列表 */}
                    <Layout>
                        <Sider
                        // collapsible
                        // collapsed={this.state.collapsed}
                        // onCollapse={this.onCollapse}
                        >
                            <Menu onClick={this.MenuClick} border="1" style={{maxHeight:"800px", overflow: "scroll" }} theme="light " mode="vertical">
                                {
                                    Object.keys(obj).map(function (i) {
                                        return <Menu.Item key={obj[i].id}>
                                            <span className="items">{obj[i].name}</span>
                                            <span className="Navicon" >
                                                <Tooltip placement="top" title="编辑角色">
                                                    <Button type="primary" onClick={() => _this.showModal(obj[i])} size="small" shape="circle" icon="edit" />
                                                </Tooltip>
                                                <Popconfirm title="确认要删除吗？" onConfirm={()=> _this.Delconfirm(obj[i])} okText="确定" cancelText="取消">
                                                    <Tooltip placement="top" title="删除角色">
                                                        <Button type="primary" size="small" shape="circle" icon="delete" />
                                                    </Tooltip>
                                                </Popconfirm>
                                            </span>
                                        </Menu.Item>
                                    })
                                }
                            </Menu>
                            <ModalEdit
                                wrappedComponentRef={this.saveFormRef}
                                visible={this.state.visible}
                                onCancel={this.handleCancel}
                                onCreate={this.handleCreate}
                                data={this.state.datas}
                                optionsData={this.state.OptionsData}
                                titles={this.state.title}
                            />
                        </Sider>
                        {/* 中间工具权限 */}
                        <div style={{ width: "100%", float: "left" }}>                
                            <Collapse bordered={false} defaultActiveKey={['0']}>                   
                            {                                                                     
                                    Object.keys(panel).map(function (i) {                                        
                                        var checkboxs = panel[i].permissionResponses
                                        
                                        return <Collapse.Panel header={panel[i].groups}>
                                            {
                                                Object.keys(checkboxs).map(function (j) {
                                                    let options = [
                                                        { label: checkboxs[j].name, value: checkboxs[j].id, disabled: _this.state.optionDisable }
                                                    ];            
                                                    return <CheckboxGroup defaultValue={defaultValues} options={options} onChange={checkedValue => _this.checkbox(checkedValue)} />;
                                                })
                                            }
                                        </Collapse.Panel>                                     
                                    })                                                            
                            }
                            </Collapse>
                        </div>
                        {/* 右边组织权限 */}
                        <div style={{ width: "40%", textAlign: "left", float: "left" }}>
                            <CheckboxGroup options={options} onChange={(checkedValue) => _this.optionOranScope(checkedValue)} />
                            <SelectTree
                                checkState={_this.state._checkState}
                                OranChecked={_this.OranChecked.bind(this)}
                                ResetKeys={this.state._ResetKeys}
                            />
                            <div>
                            </div>
                        </div>
                    </Layout>
                </Content>
            </div>
        );
    }
}

export default Roles;