import React from 'react';
import { Modal, Form, Input, Select } from 'antd';
import './oranization.css';
import { isPhoneNumber } from '../../utils/public';

export const CollectionCreateForm = Form.create()(

    class extends React.Component {

        CheckPhone = (rule, value, callback) => {
            if (!isPhoneNumber(value)) {
                callback("请输入正确的联系方式");
                return;
            }
            //一定要回调一次
            callback();
        }
        render() {
            const {
                visible, onCancel, onCreate, form,
            } = this.props;
            const { getFieldDecorator } = form;
            return (
                <Modal
                    visible={visible}
                    title="添加员工"
                    okText="确定"
                    cancelText="取消"
                    onCancel={onCancel}
                    onOk={onCreate}
                >
                    <Form layout="vertical">
                        <Form.Item label="员工编号">
                            {getFieldDecorator('userName', {
                                rules: [{ required: true, message: '请输入员工编号！' }],
                            })(
                                <Input />
                            )}
                        </Form.Item>
                        <Form.Item label="员工姓名">
                            {getFieldDecorator('trueName', {
                                rules: [{ required: true, message: '请输入员工姓名！' }],
                            })(
                                <Input />
                            )}
                        </Form.Item>
                        <Form.Item label="联系方式：">
                            {getFieldDecorator('PhoneNumber', {
                                rules: [
                                    { validator: this.CheckPhone.bind(this) }
                                ],
                            })(
                                <Input />
                            )}
                        </Form.Item>
                        <Form.Item label="性别：">
                            {getFieldDecorator('sex', {
                                rules: [{ required: true, message: '请选择性别！' }],
                            })(
                                <Select initialValue="男" style={{ width: 120 }}>
                                    <Select.Option value="true">男</Select.Option>
                                    <Select.Option value="false">女</Select.Option>
                                </Select>
                            )}
                        </Form.Item>
                        <Form.Item label="初始密码：">
                            {getFieldDecorator('PasswordHash', {
                                initialValue: "123456",
                                rules: [{ required: false, message: '' }],
                            })(
                                <Input disabled type="password" />
                            )}
                        </Form.Item>
                        <Form.Item label="所在部门">
                            {getFieldDecorator('organizationId', {
                                initialValue: this.props.info.Name,
                                rules: [{ required: true, message: '请选择该员工所在部门' }],
                            })(
                                <Input disabled />
                            )}
                        </Form.Item>
                    </Form>
                </Modal>
            );
        }
    }
);
