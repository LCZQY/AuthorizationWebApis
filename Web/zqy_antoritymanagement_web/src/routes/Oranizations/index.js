import React, { Component } from 'react';
import { Layout, Button, Icon,  Tooltip, Popconfirm,  } from 'antd';
import { messageWarn, httpPost, messageSuccess } from '../../utils/public';
import Trees from './SearchTree';
import "./oranization.css";
import UserContent from './UserContent';
import {ModalOranEdit} from './ModalOranEdit';

const { Content, Sider } = Layout;

class Oranizations extends Component {

    constructor() {
        super();
        this.state = {
            visible: false,
            Editvisible: false,
            AddOrUpdate:"",
            dataSource: [],
            oranizationInfos: [],
            ButtonDisplay: true,
            oranizationGuid:"0",
            title:""
        }
    }

    /**按钮的显示和禁用 */
    DisplayFun = (key) => {
        this.setState({
            ButtonDisplay: key
        })
    }

    //用户信息
    changeHandler = (extension) => {
        
        this.setState({
            dataSource: extension
        });
    }

    //父组织ID
    getMsg = (data) => {
        this.setState({
            oranizationInfos: {
                Id: data.key,
                Name: data.value
            }
        });
    }

    /**
     * 组织的删除确定 
     */
    Delconfirm = () => {
        console.log(this.state.oranizationInfos, "组织信息");
        var id = this.state.oranizationInfos.Id;
        let url = "/api/Oranizations/delte/" + id;
        httpPost(url, null).then(data => {
            if (data.code != "0") {
                messageWarn(data["message"] || data["Phone"]);
                return;
            }
            messageSuccess("删除组织成功");
            this.child.Initialization("0");
        });
    }
    
    
     /**
     * 编辑
     */
    EditOrang = () => { 
        var id = this.state.oranizationInfos.Id;       
        this.childEdit.OranizationMsg(id);
        this.setState({
            visible: true,
            AddOrUpdate : id,
            title:"编辑组织"
        });
    }
    
    /**
     * 添加
     */
    showModel = () => {
        this.setState({
            visible: true,
            title:"添加组织"
        });
    }
    //模态框退出    
    handleCancel = (e) => {
        console.log(e);
        this.setState({
            visible: false
        });
    }

    /**
     * 获取子组件的所有方法（树状）
     */
    onRef = (ref) => {
        this.child = ref
    }

    onEditRef = (ref) =>{
        this.childEdit= ref;    
    }
    /**模态框关闭 */
    handleCancel = () => {
        this.setState({
            visible: false,           
        });
    }

    /**添加用户角色数据 提交编辑 */
    handleCreate = () => {
        const form = this.formRef.props.form;
        form.validateFields((err, values) => {
            if (err) {
                return;
            }
            let url = "/api/Oranizations/add";
            console.log(values,"修改前的值");
            if (values.parentId == undefined  )
             {
                 values.parentId = "0"; 
                 values.id="" ;
             }
             if(this.state.oranizationInfos != null )
             {              
                values.parentId =this.state.oranizationInfos.Id;
                console.log(values, "00");
             }           
            httpPost(url, values).then(data => {
                if (data.code != "0") {
                    messageWarn(data["message"] || data["Phone"]);
                    this.setState({
                        visible: false
                    });
                    return;
                }
                //关闭模态框                    
                this.setState({
                    visible: false
                });
                messageSuccess("操作组织成功");
                this.child.Initialization("0");
            });
        });
    }   
    saveFormRef = (formRef) => {
        this.formRef = formRef;
    }

    render() {
        return (
            <div className="organs">
                <Layout>
                    <Layout>
                        <Sider width={200} style={{ background: '#fff' }}>
                            <div className="siderTitle" >
                                <h2 style={{ float: "left", fontWeight: "520" }}>组织结构</h2>
                                <div style={{ textAlign: "right" }}>
                                    <Tooltip placement="top" title="组织添加">
                                        <Button style={{ marginRight: "1%" }} onClick={() => { this.showModel() }} type="primary" shape="circle" size="default">
                                            <Icon type="plus" />
                                        </Button>
                                    </Tooltip>

                                    <ModalOranEdit
                                        wrappedComponentRef={this.saveFormRef}
                                        visible={this.state.visible}
                                        onCancel={this.handleCancel}
                                        onCreate={this.handleCreate}   
                                        userName={this.state.User}  
                                        getId={this.state.AddOrUpdate}     
                                        titles={ this.state.title}   
                                        onEditRef={this.onEditRef}  
                                     />                                   
                                    <Tooltip placement="top" title="组织编辑">
                                        <Button style={{ marginRight: "0.5%" }} onClick={()=> this.EditOrang()} disabled={this.state.ButtonDisplay} type="primary" shape="circle" size="default">
                                            <Icon type="edit" />
                                        </Button>
                                    </Tooltip>
                                    <Popconfirm title="确认要删除该组织吗？" disabled={this.state.ButtonDisplay} onConfirm={this.Delconfirm} okText="确定" cancelText="取消">
                                        <Button style={{ marginRight: "0.5%" }} disabled={this.state.ButtonDisplay} type="primary" shape="circle" size="default">
                                            <Icon type="delete" />
                                        </Button>
                                    </Popconfirm>
                                </div>
                            </div>
                            <div className="treesName">
                                <Trees
                                    OangizChange={this.changeHandler}
                                    getMsg={this.getMsg}
                                    ButtonFun={this.DisplayFun}
                                    onRef={this.onRef}
                                />
                            </div>
                        </Sider>
                        <Layout style={{ padding: '0 24px 24px' }}>
                            <Content style={{ background: '#fff', padding: 24, margin: 0, minHeight: 280, }}>
                                <UserContent
                                    data={this.state.dataSource}
                                    GuidAndName={this.state.oranizationInfos}
                                    ButtonDisplay={this.state.ButtonDisplay}
                                />
                            </Content>
                        </Layout>
                    </Layout>
                </Layout>
            </div>
        );
    }
}

export default Oranizations;