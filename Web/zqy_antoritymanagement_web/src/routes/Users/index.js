import React, { Component } from "react";
import { Input, Button, Select } from "antd";
import "./index.css";
import UserTable from "./UserTable";

//const : 一般在class外面定义的变量
const OPTIONS = ["Apples", "Nails", "Bananas"];
const Option = Select.Option;

function handleChange(value) {
  console.log(`selected ${value}`);
}

function handleBlur() {
  console.log("blur");
}

function handleFocus() {
  console.log("focus");
}

class Users extends Component {
  constructor() {
    super();
    this.state = {
      selectedItems: [],
     
    };
  }

  handleChange = selectedItems => {
    this.setState({ selectedItems });
  };

  //组件第一次渲染完成，此时dom节点已经生成，可以调用Ajax请求
  componentDidMount() {
    //this.Initialization();
  }

  //员工列表查询
  Search = () => {
    alert(0);
  };
  Initialization = () => {};

  //render 中尽量是Dom节点
  render() {
    const { selectedItems } = this.state;
    const filteredOptions = OPTIONS.filter(o => !selectedItems.includes(o));
    return <div id="uses">
        <div style={{ float: "left", width: "100%", marginBottom: "0.5%", background: "#fff" }}>
          <h2 style={{ textAlign: "left" }}>员工查询</h2>
          <talbe style={{ float: "left", width: "80%" }}>
            <tr>
              <td style={{ textAlign: "right" }}>用户名：</td>
              <td>
                <Input style={{ zIndex: "1" }} />
              </td>
              <td style={{ textAlign: "right" }}>所属角色：</td>
              <td>
                <Select showSearch style={{ width: 200, zIndex: "1" }} placeholder="Select a person" optionFilterProp="children" onChange={handleChange} onFocus={handleFocus} onBlur={handleBlur} filterOption={(input, option) => option.props.children
                      .toLowerCase()
                      .indexOf(input.toLowerCase()) >= 0}>
                  <Option value="jack">Jack</Option>
                  <Option value="lucy">Lucy</Option>
                  <Option value="tom">Tom</Option>
                </Select>
              </td>
              <td style={{ textAlign: "right" }}>所属部门：</td>
              <td>
                <Select mode="multiple" placeholder="Inserted are removed" value={selectedItems} onChange={this.handleChange} style={{ width: "100%", zIndex: "1" }}>
                  {filteredOptions.map(item => (
                    <Select.Option key={item} value={item}>
                      {item}
                    </Select.Option>
                  ))}
                </Select>
              </td>
              <td>
                <Button type="primary" style={{ zIndex: "2" }} onClick={() => {
                    this.Search();
                  }} icon="search">
                  查询
                </Button>
              </td>
            </tr>
          </talbe>
        </div>
        <UserTable />
      </div>;
  }
}

export default Users;
