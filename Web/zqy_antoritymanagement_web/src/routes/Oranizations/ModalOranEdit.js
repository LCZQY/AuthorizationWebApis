import React from 'react';
import { Modal, Form, Input } from 'antd';
import { httpGet, messageWarn } from '../../utils/public';

export const ModalOranEdit = Form.create()(

    class extends React.Component {
        constructor() {
            super();
            this.state = { data: [] };
        }

     
        componentDidMount() {
            this.props.onEditRef(this);
        }

        /**
         *查询该组织信息
         */
        OranizationMsg = (id) => {
            let url = "/api/Oranizations/GetOranization/" + id;
            httpGet(url, null).then(datas => {

                if (datas.code != "0") {
                    messageWarn(datas["message"]);
                    return;
                }   
                console.log(id);             
                this.setState({ data: datas.extension || [] });
            });

        }

        render() {
            const { data } = this.state;
            const { visible, onCancel, onCreate, form, titles } = this.props;
            const { getFieldDecorator } = form;
            return <Modal visible={visible} title={titles} okText="确定" cancelText="取消" onCancel={onCancel} onOk={onCreate}>
                <Form layout="vertical">
                  <Form.Item style={{ display: "none" }} label="id:">
                        {getFieldDecorator("id", {
                            initialValue: data.id
                        })(<Input />)}
                    </Form.Item>
                    <Form.Item style={{ display: "none" }} label="id:">
                        {getFieldDecorator("parentId", {
                            initialValue: data.parentId
                        })(<Input />)}
                    </Form.Item>
                    <Form.Item label="部门名称：">
                        {getFieldDecorator("organizationName", {
                            initialValue: data.organizationName,
                            rules: [
                                {
                                    required: true,
                                    message: "请输入部门名称！"
                                }
                            ]
                        })(<Input />)}
                    </Form.Item>
                    <Form.Item label="部门电话：">
                        {getFieldDecorator("phone", {
                            initialValue: data.phone,
                            rules: [
                                {
                                    required: true,
                                    message: "请输入部门电话！"
                                }
                            ]
                        })(<Input maxLength={11} />)}
                    </Form.Item>
                </Form>
            </Modal>;
        }
    });
