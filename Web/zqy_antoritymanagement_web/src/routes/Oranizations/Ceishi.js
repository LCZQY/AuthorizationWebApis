import React, { Component } from 'react';
import { Tree } from 'antd';
import {  messageWarn,  httpPost } from '../../utils/public';
const TreeNode = Tree.TreeNode;

const dataList = [];
const generateList = (data) => {
    for (let i = 0; i < data.length; i++) {
        const node = data[i];
        const key = node.key;
        dataList.push({ key, title: node.title });
        if (node.children) {
            generateList(node.children);
        }
    }
};

/*对于异步加载的子节点使用该key进行自增赋值*/
class SearchTree extends Component {

    
    state = {
        expandedKeys: ['1'],
        searchValue: '',
        autoExpandParent: true,
        gData: [],
    };
    
    //初始化树状结构
    componentDidMount(){
         this.Initialization("0"); 
    }

    //请求后台数据
    Initialization =(id) =>
    {
        let _url = '/api/Oranizations/createTreeStructure/'+id;         
        //所有的方法都要以 =>{} 表示 ！
        httpPost(_url,null).then(data =>{
            switch (data["code"]) {
                case "0":
                    console.log(data.extension,"初始化树状结构是！");
                    this.setState({
                        gData: data.extension
                    })
                    break;
                default:
                    messageWarn(data["message"]);
                    break;
            }
        });                               
    }


    onSelect = (selectedKeys, info) => {
        /*用于打开该节点的详细信息*/
        console.log('selected', selectedKeys, info);
        console.log(this.state.expandedKeys, "点击点击。.......");
    };

    onExpand = (expandedKeys) => {
        console.log(expandedKeys,"扩展.........");    
        this.setState({
            expandedKeys,
            autoExpandParent: false,         
        });
    };


    loop = data => data.map((item) => {
        let { searchValue } = this.state;
        const index = item.title.indexOf(searchValue);
        const beforeStr = item.title.substr(0, index);
        const afterStr = item.title.substr(index + searchValue.length);
        const title = index > -1 ? (
            <span>
                {beforeStr}
                <span style={{ color: 'red' }}>{searchValue}</span>
                {afterStr}
            </span>
        ) : <span>{item.title}</span>;
        if (item.children) {
            return (
                <TreeNode key={item.key} title={title} dataRef={item}>
                    {this.loop(item.children)}
                </TreeNode>
            );
        }
        return <TreeNode dataRef={item} key={item.key} title={title} />;
    });

    onLoadData = (treeNode) => {
        let _url = '/api/Oranizations/createTreeStructure/'+treeNode.props.dataRef.key; 
        console.log(_url, "加载数据中.......");            
        let childrenArry = [];          
        httpPost(_url,treeNode.props.dataRef).then(data=>{
            switch (data["code"]) {
                case "0":
                    console.log(data.extension,"二级菜单");
                    childrenArry  = data.extension;
                    break;
                default:
                    messageWarn(data["message"]);
                    break;
            }
        });          
        return new Promise((resolve) => {
            //如果没有children节点就记载新的数据
            if (treeNode.props.children) { 
                resolve();
                return;
            }
            setTimeout(() => {
                treeNode.props.dataRef.children = childrenArry;
                this.setState({
                    gData: [...this.state.gData],
                });
                resolve();
            }, 1000);
        });
    };

    render() {
        const { expandedKeys, autoExpandParent, gData } = this.state;
        // 进行数组扁平化处理
        generateList(gData);
        return ( 
                <Tree 
                    onSelect={this.onSelect}
                    onExpand={this.onExpand}
                    expandedKeys={expandedKeys}
                    autoExpandParent={autoExpandParent}
                    loadData={this.onLoadData}
                >
                    {this.loop(gData)}
                </Tree>      
        );
    }
}

export default SearchTree;