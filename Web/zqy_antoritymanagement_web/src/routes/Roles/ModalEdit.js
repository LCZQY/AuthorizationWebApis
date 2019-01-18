import React from 'react';
import { Modal, Form, Input,Select } from 'antd';

export const ModalEdit = Form.create()(

    class extends React.Component {
        constructor() {
            super();
            this.state = {
            }
        }                
        /**选择框 */
        handleChange= (value)=> {
            console.log(`selected ${value}`);
        }
        render() {
            const {  visible, onCancel, onCreate, form, data,optionsData, titles  } = this.props;
            const { getFieldDecorator } = form;
            return (
                <Modal
                    visible={visible}
                    title={titles}
                    okText="确定"
                    cancelText="取消"
                    onCancel={onCancel}
                    onOk={onCreate}
                >
                    <Form layout="vertical">
                    <Form.Item style={{display:"none"}} label="id:">
                            {getFieldDecorator('id',
                                {
                                    initialValue: data.id,                                    
                                })(<Input />)
                            }
                        </Form.Item>
                        <Form.Item label="角色名称：">
                            {getFieldDecorator('name',
                                {
                                    initialValue: data.name,
                                    rules: [{ required: true, message: '请输入角色名称！' }],
                                })(<Input />)
                            }
                        </Form.Item>
                        <Form.Item label="所属部门：">
                            {getFieldDecorator('organizationId', {
                                initialValue: data.organizationId,
                                rules: [{ required: true, message: '请选择所属部门！' }],
                            })(
                                <Select  onChange={this.handleChange}>
                                    {
                                        Object.keys(optionsData || []).map(function (i) {
                                            return <Select.Option value={optionsData[i].key}>{optionsData[i].title}</Select.Option>
                                        })
                                     }                                                                    
                               </Select>
                            )}
                        </Form.Item>
                    </Form>
                </Modal>
            );
        }
    }
);
