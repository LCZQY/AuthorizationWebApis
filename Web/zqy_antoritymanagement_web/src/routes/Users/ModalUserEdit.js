import React from 'react';
import { Modal, Form, Input, Select,TreeSelect } from 'antd';
import { httpPost, messageWarn } from '../../utils/public';
const TreeNode = TreeSelect.TreeNode;
export const ModalUserEdit = Form.create()(

  class extends React.Component {
    constructor() {
      super();
      this.state = {
        OptionsData: []
      }
    }

    componentDidMount() {
     
    }

    /**选择框 */
    handleChange = (value) => {
      console.log(`selected ${value}`);
    }


    OnChange = (value,label,extra)  =>
    {
      console.log(value);
    }

    OnSelect =(selectedKeys ,e ) =>{
      console.log(selectedKeys,e);
    }

    renderTreeNode = (treeData) => {
      let treeNode = [];
      treeNode.map((ele, index) => {
        treeNode.push(
          <TreeNode value={ele.value} title={ele.title} key={ele.key} >
            {this.renderChild1(ele)}
          </TreeNode>
        );
      });
      return treeNode;
    }


    renderChild1 = element =>{
      let childLevel1 =[];
      if(element.childLevel1)      
      {
          element.childLevel1.map((item,i) =>{
            childLevel1.push(
              <TreeNode belongto = { item.value} grade={ item.grade} value= {  item.value}  title={ item.title} key={  item.key}>
                {this.renderChild2(item)}
              </TreeNode>
            )
          })
      }
      return childLevel1;
    }


    renderChild2 = item =>{
      let childLevel2 =[];
      if(item.childLevel2)      
      {
          item.childLevel2.map((child,i) =>{
            childLevel2.push(
              <TreeNode belongto = { item.value} grade={ item.grade} value= {  item.value}  title={ item.title} key={  item.key} />               
            )
          })
      }
      return childLevel2;
    }



    render() {      
      const { visible, onCancel, onCreate, form,OptionsData, data, titles } = this.props;    
      console.log(this.props.OptionsData,"===============================");      
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
                <Form.Item style={{ display: "none" }}>
                  {getFieldDecorator('id',
                    {
                      initialValue: data.id,
                    })(<Input />)
                  }
                </Form.Item>
                <Form.Item label="员工编号：">
                  {
                    getFieldDecorator('userName',
                      {
                        initialValue: data.userName,
                        rules: [{ required: true, message: '请输入员工编号！' }],
                      })(<Input />)
                  }
                </Form.Item>
                <Form.Item label="联系方式：">
                  {
                    getFieldDecorator('phoneNumber',
                      {
                        initialValue: data.phoneNumber,
                        rules: [{ required: true, message: '请输入联系方式！' }],
                      })(<Input />)
                  }
                </Form.Item>
                <Form.Item label="性别">
                {
                    getFieldDecorator('sex',
                      {
                        initialValue: data.sex,
                        rules: [{ required: true, message: '请选择所有性别！' }],
                      })(
                        <Select >
                          <Select.Option value={true}>男</Select.Option>
                          <Select.Option value={false}>女</Select.Option>
                        </Select>
                      )
                  }
                </Form.Item>
                <Form.Item label="姓名">
                  {
                     getFieldDecorator('trueName',
                      {
                        initialValue: data.trueName,
                        rules: [{ required: true, message: '请输入姓名！' }],
                      })(<Input />)
                  }
                </Form.Item>
                <Form.Item label="所属部门：">
                  {
                    getFieldDecorator('organizationId', {
                    initialValue: data.organizationId,
                    rules: [{ required: true, message: '请选择所属部门！' }],
                    })(
                   
                    <Select onChange={this.handleChange}>
                      {
                        Object.keys(OptionsData || []).map(function (i) {
                          return <Select.Option value={ OptionsData[i].key}>{ OptionsData[i].title}</Select.Option>
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
