import React, { Component } from "react";
import { Button, Select ,TreeSelect} from "antd"; 
import "./index.css";
import UserTable from "./UserTable";
import { httpPost, messageError } from "../../utils/public";



/**
 * 筛选条件
 */
var obj = {};
class Users extends Component {
  constructor() {
    super();
    this.state = {    
      optionsData: [],
      UseData: [],
      treeData:[]
    };
  }

  handleChange = selectedItems => {
      this.setState({ selectedItems });
  };

  componentDidMount() {
    this.Initialization();
  }

  /**
   * 初始化数据
   */
  Initialization = () => {
    let url = "/api/Roles/ListRoles";
    httpPost(url, null).then(data => {
      if (data.code != "0") {
        messageError(data.message);
      }
      this.setState({ optionsData: data.extension });
    });

    url ="/api/Oranizations/TreeSelect/0";
    httpPost(url, null).then(data => {
      if (data.code != "0") {
        messageError(data.message);
      }
      this.setState({
        treeData: data.extension
      });
      //后台组件树
      console.log(data.extension,"选择下拉组织树  >>>");
    });

  };

  /** 
   * 用户列表查询
   */
  Search = () => {
    const inpVal = this.trueName.value;
    if (inpVal != "") {
      obj.trueName = inpVal;
    }
    this.child.Initialization(0, obj);
  };

  /**
   * 角色筛选
   */
  handleChange = (value) => {
    obj.roleId = value;
  }
  /**
   * 员工状态筛选
   */
  UserChange = (value) => {
    obj.isDelete = value;
  }
  /**
   * 调用子组件方法
   */
  onRef = (ref) => {
    this.child = ref
  }
  /**
   * 下拉树状组织
   */
  TreeonChange = (value) =>{    
    obj.oranizationId = value;    
  }

  //render 中尽量是Dom节点
  render() {

    const {  optionsData } = this.state;    
    return <div id="uses">
      <div style={{ float: "left", width: "100%", marginBottom: "0.5%", background: "#fff" }}>
        <h2 style={{ textAlign: "left" }}>员工查询</h2>
        <talbe style={{ float: "left", width: "80%" }}>
          <tr>
            <td style={{ textAlign: "right" }}>用户名：</td>
            <td>
              <input className="ant-input" ref={trueName => this.trueName = trueName} style={{ zIndex: "5" }} />
            </td>
            <td style={{ textAlign: "right" }}>所属角色：</td>
            <td>
              <Select showSearch style={{ width: 200, zIndex: "1" }} placeholder="筛选角色" optionFilterProp="children" onChange={this.handleChange} filterOption={(input, option) => option.props.children
                .toLowerCase()
                .indexOf(input.toLowerCase()) >= 0}>
                <Select.Option value="">&nbsp;</Select.Option>
                {Object.keys(optionsData || []).map(function (i) {
                  return <Select.Option value={optionsData[i].id}>
                    {optionsData[i].name}
                  </Select.Option>;
                })}
              </Select>
            </td>
            <td style={{ textAlign: "right" }}>所属部门：</td>
            <td>
              <TreeSelect
                  style={{ width: 200, zIndex: 5 }}
                  value={this.state.value}
                  dropdownStyle={{ maxHeight: 400, overflow: 'auto' }}
                  treeData={this.state.treeData}
                  placeholder="部门筛选"
                  treeDefaultExpandAll
                  autoExpandParent={true}
                  onChange={this.TreeonChange}               
              />
            </td>
            <td style={{ textAlign: "right" }}>员工状态：</td>
            <td>
              <Select style={{ width: 100, zIndex: "1" }} placeholder="员工状态" onChange={this.UserChange}>
                <Select.Option value={false}>{"在职"}</Select.Option>
                <Select.Option value={true}>{"离职"}</Select.Option>
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
      <UserTable
        onRef={this.onRef}
      />
    </div>;
  }
}

export default Users;
