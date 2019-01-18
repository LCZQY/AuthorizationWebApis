import React from 'react';
import { Modal, Form, Input, Checkbox } from 'antd';
import { httpPost, messageWarn } from '../../utils/public';

export const ModalUserRole = Form.create()(

  class extends React.Component {
    constructor() {
      super();
      this.state = {
        optionsData: []
      }
    }

    componentDidMount() {
      // 获取用户信息
      let url = "/api/Roles/ListRoles";
      httpPost(url, null).then(data => {
        if (data.code != 0) {
          messageWarn(data.message);
          return;
        }
        var option = []
        Object.keys(data.extension).map(i => {
          option.push({ label: data.extension[i].name, value: data.extension[i].id })
        });
        this.setState({
          optionsData: option
        })
      })
    }

    checkbox = (checkedValue) => {
      console.log(checkedValue, "选择的是！！");

    }
    
    render() {
      const { visible, onCancel, onCreate, form, userName } = this.props;
      const { getFieldDecorator } = form;
      return <Modal visible={visible} title="员工权限" okText="确定" cancelText="取消" onCancel={onCancel} onOk={onCreate}>
        <Form layout="vertical">
          <Form.Item style={{ display: "none" }} label="id:">
            {
              getFieldDecorator("id", {
                initialValue: userName.id,
              })(<Input />)}
          </Form.Item>
          <Form.Item label="用户名:">
            {
              getFieldDecorator("trueName", {
                initialValue: userName.trueName,
                rules: [
                  {
                    required: false,
                    message: ""
                  }
                ]
              })(<Input disabled={true} />)}
          </Form.Item>
          <Form.Item label="所属角色">
            {
              getFieldDecorator("rolesID", {
                rules: [
                  {
                    required: true,
                    message: "请勾选所属角色！"
                  }
                ]
              })(<Checkbox.Group options={this.state.optionsData} onChange={checkedValue => this.checkbox(checkedValue)} />)}
          </Form.Item>
        </Form>
      </Modal>;
    }
  }
);
