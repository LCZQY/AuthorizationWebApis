import React, { Component } from 'react';
import { Table, Button, Icon, Select, Tooltip,Modal} from 'antd';
import { ModalAdd } from './ModalAdd';
import { httpPost, messageWarn, messageSuccess, NoRepeat } from '../../utils/public';
import { ModalUpdate } from './ModalUpdate';


const confirm = Modal.confirm;
class Permissionitems extends Component {


    constructor() {
        super();
        this.state = {
            visible: false,
            EditVisible: false,
            data: [],
            searchName: "",
            optionsData: [],
            updateMsg: [],
            selectedRowKeys: [],
            totalCount:0            
        }
    }

    componentDidMount() {
        this.Initialization(0);
    }

    /**初始化权限列表 */
    Initialization = (pageSizeNumber) => {
        let url = "/api/Jurisdiction/getJurisdictionList/";
        var bodys = {
            pageIndex: pageSizeNumber,
            pageSize: 10
        }
        httpPost(url, bodys).then(data => {

            if (data.code != "0") {
                messageWarn(data["message"]);
            }
         
            var msg = [];
            for (var i in data.extension) {
                msg.push(data.extension[i].groups);
            }
            this.setState({
                data: data.extension,
                optionsData: NoRepeat(msg),
                totalCount: data.totalCount
            });        
        });
    }


    /**权限修改 */
    PermissionEdit = (records) => {
        console.log(records, "传递的参数是...");
        this.setState({
            EditVisible: true,
            updateMsg: records
        })
    }

    handleSelect = (value) => {
        alert(value);
        this.searchInfo = value;
        this.setState({
            searchName: value
        })
    }


    /**提交修改 */
    PermissionSubmit = () => {
        const form = this.formRef.props.form;
        form.validateFields((err, values) => {
            if (err) {
                this.setState({ EditVisible: false });
                return;
            }
       
            let url = "/api/Jurisdiction/add";
            httpPost(url, values).then(data => {
                if (data.code != "0") {
                    messageWarn(data.message);
                }
                form.resetFields();
                this.setState({ EditVisible: false });
                this.Initialization();
                messageSuccess("权限修改成功！");
               
            });
        });
    }

    optionSelect = (value) => {
        this.setState({
            searchName: value
        });
    }

    /**搜索 */
    searchs = () => {
        let url = "/api/Jurisdiction/getJurisdictionList/";
        var bodys = {
            pageIndex: 0,
            pageSize: 10,
            groups: this.state.searchName
        }
        console.log(bodys, "这个数是");
        httpPost(url, bodys).then(data => {
            if (data.code != "0") {
                messageWarn(data["message"]);
            }
            this.setState({
                data: data.extension
            })
        });
    }

    /**模态框打开 */
    showModal = () => {
        this.setState({
            visible: true
        });
    }

    /**模态框关闭 */
    handleCancel = () => {
        this.setState({
            visible: false,
            EditVisible: false
        });
    }
    
    /**权限的删除 */
    PermissionDelete = (record) => {
        confirm({
            title: '删除权限',
            content: '是否确认删除？',
            okText: '确认',
            okType: '取消',
            cancelText: '',
            onOk() {                  
                let url="/api/Jurisdiction/delete";
                var idlist={
                    id: [record.id]
                }
                console.log(idlist,"id");
                httpPost(url,idlist ).then(data=>{
                    if (data.code != "0") {
                        messageWarn(data["message"]);
                    }                                        
                    messageSuccess("删除权限成功");
                });
            },
            onCancel() {           
            },
          });        
    }


    /**添加权限 */
    handleCreate = () => {
        const form = this.formRef.props.form;
        form.validateFields((err, values) => {
            if (err) {
                return;
            }
            let url = "/api/Jurisdiction/add";
            httpPost(url, values).then(data => {
                if (data.code != "0") {
                    messageWarn("0");
                }
                messageSuccess("添加成功！");
                form.resetFields();
                this.setState({ visible: false });
                this.Initialization();
            });
        });
    }
    saveFormRef = (formRef) => {
        this.formRef = formRef;
    }

    /**权限项的删除 */
    onTableSelectChange = (selectedRowKeys) => {

        console.log('selectedRowKeys changed: ', selectedRowKeys);
        this.setState({ selectedRowKeys });
    }


    /**分页按钮 */
    handlePageChange = (pagination, filters, sorter) => {
       console.log(pagination.current,"第几页？？？？");
        let val = {
            rows: 10,
            page: pagination.current ? pagination.current : 1
        }
        this.Initialization(pagination.current-1);       
    }

 
    render() {
        var _this = this;
        var selectData = _this.state.optionsData || [];        
        ///申明变量后要
        const columns = [
            {
                title: '权限名',
                dataIndex: 'name',
                key: 'name',
            },
            {
                title: '分组名',
                dataIndex: 'groups',
                key: 'groups'
            },
            {
                title: '操作',
                dataIndex: '',
                render: function (text, record) {
                    return <span>
                        <Tooltip placement="top" title="编辑">
                            <Button type="primary" onClick={() => _this.PermissionEdit(record)} size="small" shape="circle" icon="edit" />     
                        </Tooltip>
                        <Tooltip placement="top" title="删除">
                            <Button type="primary" onClick={() => _this.PermissionDelete(record)} size="small" shape="circle" icon="delete" />
                        </Tooltip>
                    </span>
                }
            }];
        
        const paginationProps ={
            pageSize: 10,      
            total: _this.state.totalCount,              //后台读取的total
        }
        return (
            <div>
                <div style={{ textAlign: "left" }}>
                    <Tooltip placement="top" title="新增权限">
                        <Button style={{ marginRight: "1%" }} type="primary" onClick={() => { this.showModal() }} shape="circle" size="default">
                            <Icon type="plus" />
                        </Button>
                    </Tooltip>
                    <ModalAdd
                        wrappedComponentRef={this.saveFormRef}
                        visible={this.state.visible}
                        onCancel={this.handleCancel}
                        onCreate={this.handleCreate}
                        info={this.props.GuidAndName}
                    />
                    {console.log(selectData, "分组名称有不有")}
                    <ModalUpdate
                        wrappedComponentRef={this.saveFormRef}
                        visible={this.state.EditVisible}
                        onCancel={this.handleCancel}
                        onCreate={this.PermissionSubmit}
                        SelectData={selectData}
                        data={this.state.updateMsg}
                    />
                    {/* <Tooltip placement="top" title="删除权限">
                        <Button style={{ marginRight: "1%" }} type="primary" onClick={() => { this.del() }} shape="circle" size="default">
                            <Icon type="delete" />
                        </Button>
                    </Tooltip> */}
                </div>
                <div style={{ width: "100%" }}>
                    <div style={{ textAlign: "left", paddingTop: "0.5%", width: "20%" }}>

                        <label>分组名：</label>
                        {
                            <Select style={{ width: "150px" }} onSelect={this.optionSelect} >
                                {
                                    Object.keys(selectData).map(function (i) {
                                        return <Select.Option value={selectData[i]}>{selectData[i]}</Select.Option>
                                    })
                                }
                            </Select>
                        }
                        <Button type="primary" onClick={() => { this.searchs() }} style={{ float: "right" }} icon="search">查询</Button>
                    </div>
                </div>
                <Table
                    columns={columns}
                    dataSource={this.state.data}
                    rowKey="id"            
                    bordered={false}                     
                    pagination={paginationProps}                
                    onChange={this.handlePageChange}           
                />
                 
            </div>
        );
    }
}
export default Permissionitems;