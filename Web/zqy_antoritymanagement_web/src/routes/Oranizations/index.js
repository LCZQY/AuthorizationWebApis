import React, { Component } from 'react';
import { Layout, Button, Icon, Modal } from 'antd';
import { messageWarn, isPhoneNumber, httpPost } from '../../utils/public';
import Trees from './Ceishi';
import "./oranization.css";
const { Content, Sider } = Layout;
class Oranizations extends Component {
    state = {
        
        visible: false
    }

    //展示模态框
    showModel = () => {
        this.setState({
            visible: true
        })
    }
    //模态框确定
    handleOk = (e) => {
        console.log(e);
        //获取输入框的值
        let phone = this.refs.Phone.value;
        let oranizationName = this.refs.OrganizationName.value;
        if (phone != "" && oranizationName != "") {
            if (!isPhoneNumber(phone)) {
                messageWarn("手机号码错误");
                return;
            }
            //点击树状结构获取该数据的值如果没有值表示添加的是最顶级的部门
            //向后台传值！！！？？？ 添加组织和角色和权限和人员关联？？？
            // 获取用户信息
            let url = "/api/Oranizations/add";
            var parameter = {
                organizationName: oranizationName,
                phone: phone,
                parentId: "0"
            }
            httpPost(url, parameter).then(data => {
                console.log(data, "添加组织信息");
                switch (data.code) {
                    case "0":
                        alert("添加成功");
                        //关闭模态框            
                        this.setState({
                            visible: false
                        });
                        break;
                    default:
                        messageWarn(data.message || data["Phone"]);
                        break;
                }
            });
        } else {
            messageWarn("请填写组织信息！");
        }
    }

    //模态框退出    
    handleCancel = (e) => {
        console.log(e);
        this.setState({
            visible: false
        });
    }
    
    render() {
        return (
            <div className="organs">
                <Layout>
                    <Layout>
                        <Sider width={200} style={{ background: '#fff' }}>
                            <div className="siderTitle" style={{ border: "red solid thin" }}>
                                <h2 style={{ float: "left" }}>组织结构</h2>
                                <div style={{ textAlign: "right" }}>
                                    <Button style={{ marginRight: "1%" }} onClick={() => { this.showModel() }} type="primary" shape="circle" size="default">
                                        <Icon type="plus" />
                                    </Button>
                                    <Modal
                                        title="部门新增"
                                        visible={this.state.visible}
                                        onOk={this.handleOk}
                                        onCancel={this.handleCancel}
                                    >
                                        {/* 优化：模态框封装成单独的组件 ？？*/}
                                        <form>
                                            <div>
                                                <span>部门名称：</span>
                                                <input type="text" className="ant-input" ref={'OrganizationName'} placeholder="部门名称：" />
                                            </div>
                                            <div>
                                                <span>部门电话：</span>
                                                <input type="text" className="ant-input" ref={'Phone'} maxLength="11" placeholder="部门电话" />
                                            </div>
                                        </form>
                                    </Modal>
                                    <Button style={{ marginRight: "0.5%" }} type="primary" shape="circle" size="default">
                                        <Icon type="delete" />
                                    </Button>
                                    <Button style={{ marginRight: "0.5%" }} type="primary" shape="circle" size="default">
                                        <Icon type="edit" />
                                    </Button>
                                </div>
                            </div>
                            <div className="treesName">
                                <Trees />
                            </div>
                        </Sider>
                        <Layout style={{ padding: '0 24px 24px' }}>
                            <Content style={{ background: '#fff', padding: 24, margin: 0, minHeight: 280, }}>

                            </Content>
                        </Layout>
                    </Layout>
                </Layout>
            </div>
        );
    }
}

export default Oranizations;