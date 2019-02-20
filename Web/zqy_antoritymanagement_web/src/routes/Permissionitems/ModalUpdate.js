import React from "react";
import { Modal, Form, Input, Select } from "antd";

export const ModalUpdate = Form.create()(

  class extends React.Component {
    constructor() {
        super();
        this.state = {
          OptionsData: []
        };
    }
    render() {
      const {
        visible,
        onCancel,
        onCreate,
        form,
        data,
        SelectData
      } = this.props;
      const { getFieldDecorator } = form;
      return (
        <Modal
          visible={visible}
          title="修改权限"
          okText="确定"
          cancelText="取消"
          onCancel={onCancel}
          onOk={onCreate}
        >
          <Form layout="vertical">
            <Form.Item label="权限编号："  > 
                {getFieldDecorator("id", {
                  initialValue: data.id,
                  rules: [{ required: true, message: "请输入权限编号！" }]
                })(<Input disabled />)}
            </Form.Item>
            <Form.Item label="权限名称">
                {getFieldDecorator("Name", {
                  initialValue: data.name,
                  rules: [{ required: true, message: "请输入权限名称！" }]
                })(<Input />)}
            </Form.Item>
            <Form.Item label="权限分组">
                {getFieldDecorator("groups", {
                  initialValue: data.groups,
                  rules: [{ required: true, message: "请选择该权限分组！" }]
                })(
                  <Select style={{ width: "150px" }} onSelect={this.optionSelect}>
                    {Object.keys(SelectData).map(function(i) {
                      return (
                        <Select.Option value={SelectData[i]}>
                            {SelectData[i]}
                        </Select.Option>
                      );
                    })}
                  </Select>
                )}
            </Form.Item>
          </Form>
        </Modal>
      );
    }
  }
);
