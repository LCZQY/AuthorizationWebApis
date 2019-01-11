import React, { Component } from 'react';
import { Table, Button, Icon, Select, Tooltip } from 'antd';
import {CollectionCreateForm} from './ModalFrom';
import { httpPost, messageWarn, messageSuccess, httpGet } from '../../utils/public';
import {TablePermission} from './table';



const searchInfo="";
class Permissionitems extends Component {

    constructor() {
        super();
        this.state = {
            visible: false,
            columns: [               
                {
                    title: '权限名',
                    dataIndex: 'name',
                    key: 'name'
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
                            <a href="##:;" className="ant-dropdown-link">
                                修改 <i className="anticon anticon-down"></i>
                            </a>                  
                        </span>;
                    }
                }],
            data:[],
            searchName:""
        }
    }

    componentDidMount()
    {
        this.Initialization();
    }
    
    handleSelect =(value) =>{
        alert(value);
        this.searchInfo = value;
        this.setState({
            searchName: value
        })
    }

    /**初始化权限列表 */
    Initialization = () =>{        

       let url="/api/Jurisdiction/getJurisdictionList/";
       var bodys={           
            pageIndex: 0,
            pageSize: 10
       }        
        httpPost(url, bodys).then(data => {
            if (data.code != "0") {
                messageWarn(data["message"]);
            }
            this.setState({
                data: data.extension
            })
     });
    }

    optionSelect =(value)=>{      
        this.setState({
            searchName: value
        })
    }

    /**搜索 */
    searchs =() =>{
        let url = "/api/Jurisdiction/getJurisdictionList/";
        var bodys = {
            pageIndex: 0,
            pageSize: 10,
            groups : this.state.searchName || "数据维护"
        }
        console.log(bodys,"这个数是");
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
    showModal = ()=>{       
        this.setState({
            visible:true    
        });
        

    }

    /**模态框关闭 */
    handleCancel = () => {
        this.setState({ visible: false });
    } 

    del =() =>{    
        let url = "/api/Token/get";
        httpPost(url,null).then(data=>{
                console.log(data,"携带Token是否成功~~");
                if(data.code == "10001")
                {                 
                    messageWarn("0");
                    return;
                }     
                messageSuccess("恭喜，Token携带过去了！！！！");                           
        });
    }
   
    /**添加权限 */
    handleCreate = () => {        
       
        const form = this.formRef.props.form;
        form.validateFields((err, values) => {
            if (err) {
                 return;               
            }                
            console.log(values,"传递的参数是");    
            let url="/api/Jurisdiction/add";           
            httpPost(url,values).then(data => {
                if(data.code != "0")
                {                 
                    messageWarn("0");
                }     
                messageSuccess("添加成功！");
                form.resetFields();                            
                this.setState({ visible: false });            
            });          
        });
    }
    saveFormRef = (formRef) => {
        this.formRef = formRef;
    }
    render() {
        return (
            <div>
                <div style={{ textAlign: "left" }}>
                     <Tooltip placement="top" title="新增权限">
                        <Button style={{ marginRight: "1%" }} type="primary" onClick={()=>{ this.showModal()}} shape="circle" size="default">
                            <Icon type="plus" />
                        </Button>
                    </Tooltip>
                    <CollectionCreateForm
                            wrappedComponentRef={this.saveFormRef}
                            visible={this.state.visible}
                            onCancel={this.handleCancel}
                            onCreate={this.handleCreate}
                            info={this.props.GuidAndName}
                    />
                    <Tooltip placement="top" title="删除权限">                   
                        <Button style={{ marginRight: "1%" }} type="primary" onClick={()=>{ this.del()}} shape="circle" size="default">
                            <Icon type="delete" />
                        </Button>
                    </Tooltip>
                </div>
                <div style={{width:"100%" }}>                    
                    <div style={{textAlign:"left", paddingTop:"0.5%",  width:"20%"}}>
                        <label>分组名：</label>
                        <Select defaultValue="数据维护" onSelect={this.optionSelect}>
                            <Select.Option value="数据维护">数据维护</Select.Option>
                            <Select.Option value="数据浏览">数据浏览</Select.Option>
                        </Select>
                        <Button  type="primary" onClick={() =>{ this.searchs()}} style={{float:"right"}} icon="search">查询</Button>
                    </div>                   
                </div>              
               <Table                 
                    columns={this.state.columns}
                    dataSource={this.state.data}
                />
            </div>
        );
    }
}
export default Permissionitems;