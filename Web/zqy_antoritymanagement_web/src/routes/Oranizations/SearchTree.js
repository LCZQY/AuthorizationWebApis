import React, { Component } from 'react';
import { Tree } from 'antd';
import { messageWarn, httpPost, messageError } from '../../utils/public';
import  "./oranization.css";
const TreeNode = Tree.TreeNode;



/**组植树造 对于异步加载的子节点使用该key进行自增赋值*/
class SearchTree extends Component {

    state = {
        expandedKeys: ['1'],
        searchValue: '',
        autoExpandParent: true,
        gData: [],
        OranizationsId: "",
        
    };

    //初始化树状结构
    componentDidMount() {
        this.Initialization("0");
        this.props.onRef(this);
    }

    //请求后台数据
    Initialization = (id) => {
        let _url = '/api/Oranizations/createTreeStructure/' + id;

        //所有的方法都要以 =>{} 表示 ！
        httpPost(_url, null).then(data => {
            if (data.code != "0") {
                messageError(data["message"]);
                return;
            }
            console.log(data.extension, "初始化树状结构是！");
            this.setState({
                gData: data.extension
            })
        });
    }

   
    /**点击树节点 */
    onSelect = (selectedKeys, {selected: bool, selectedNodes, node}) => {
        this.props.ButtonFun(false);
        //?????????? 点击2次就获取不到该 id
        // console.log(selectedNodes[0].props, "selectedNodes");        
        // console.log(node, "node");             
        // console.log(selectedKeys,selectedNodes[0].props.dataRef.title, "父Id");              
        var pages = {
            "pageIndex": 0,
            "pageSize": 10,
            "oranizationId": selectedKeys[0]
        }
        //获取用户信息
        let url = "/api/User/getUsersMessages";
        httpPost(url, pages).then(data => {
            if (data.code != 0) {
                messageWarn(data.message);
                return;
            }
            console.log(data.extension, "返回的用户信息是");
            this.props.OangizChange(data.extension);
            var treeNodes ={
                key:selectedKeys[0],
                value: selectedNodes[0].props.dataRef.title
            }
            this.props.getMsg(treeNodes);
        });

    };
    


    onExpand = (expandedKeys) => {
        console.log(expandedKeys, "扩展.........");
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
        let _url = '/api/Oranizations/createTreeStructure/' + treeNode.props.dataRef.key;
        console.log(_url, "加载数据中.......");
        let childrenArry = [];
        httpPost(_url, treeNode.props.dataRef).then(data => {
            switch (data["code"]) {
                case "0":
                    console.log(data.extension, "二级菜单");
                    childrenArry = data.extension;
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
        return (
            <div>
                <tablecointe />
                <Tree
                    onSelect={this.onSelect}
                    onExpand={this.onExpand}
                    expandedKeys={expandedKeys}
                    autoExpandParent={autoExpandParent}
                    loadData={this.onLoadData}
                >
                    {this.loop(gData)}
                </Tree>
            </div>
        );
    }
}

export default SearchTree;