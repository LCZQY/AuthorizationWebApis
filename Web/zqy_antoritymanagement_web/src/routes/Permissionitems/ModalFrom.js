import React from 'react';
import { Modal, Form, Input } from 'antd';


export const CollectionCreateForm = Form.create()(

    class extends React.Component {   
        render() {
            const {
                visible, onCancel, onCreate, form,
            } = this.props;
            const { getFieldDecorator } = form;
            return (
                <Modal
                    visible={visible}
                    title="添加组织"
                    okText="确定"
                    cancelText="取消"
                    onCancel={onCancel}
                    onOk={onCreate}
                >
                    <Form layout="vertical">
                        <Form.Item label="权限编号：">
                            {getFieldDecorator('id', {
                                rules: [{ required: true, message: '请输入权限编号！' }],
                            })(
                                <Input />
                            )}
                        </Form.Item>
                        <Form.Item label="权限名称">
                            {getFieldDecorator('Name', {
                                rules: [{ required: true, message: '请输入权限名称！' }],
                            })(
                                <Input />
                            )}
                        </Form.Item>
                        <Form.Item label="分组">
                            {getFieldDecorator('Groups', {
                                rules: [{ required: true, message: '请输入分组名称！' }],
                            })(
                                <Input />
                            )}
                        </Form.Item>
                    </Form>
                </Modal>
            );
        }
    }
);
