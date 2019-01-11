import React, { Component } from 'react';
import { Tree } from 'antd';
import { httpPost, messageWarn } from '../../utils/public';
const { TreeNode } = Tree;


export default class SelectTree extends Component {

    state = {
        expandedKeys: ['1'],
        searchValue: '',
        autoExpandParent: true,
        gData: [],
        OranizationsId: "",
        checkedKeys:[],
        selectedKeys:[]                
    };

 
    componentDidMount() {        
        this.Initialization("0");      
    }

    /**初始化树状结构 */
    Initialization = (id) => {    
        let _url = '/api/Oranizations/createTreeStructure/' + id;
        httpPost(_url, null).then(data => {
            if (data.code != "0") {
                messageWarn(data["message"]);
                return;
            }
            this.setState({
                gData: data.extension
            })
        });
    }

    /**点击树节点 */
    onSelect = (selectedKeys, { selected: bool, selectedNodes, node, event }) => {
        console.log(selectedKeys, selectedNodes[0].props.dataRef.title, "父Id");
        this.selectedKeys=[];
    };

    onExpand = (expandedKeys) => {
        console.log(expandedKeys, "扩展.........");
        this.setState({
            expandedKeys,
            autoExpandParent: false,
        });
    };

    /**组合子节点 */
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

    /**加载新数据 */
    onLoadData = (treeNode) => {
        let _url = '/api/Oranizations/createTreeStructure/' + treeNode.props.dataRef.key;
        let childrenArry = [];
        httpPost(_url, treeNode.props.dataRef).then(data => {
            switch (data["code"]) {
                case "0":
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

    /**选中的节点 */
    onCheck = (checkedKeys) => {              
        Object.assign(this.state,this.props);
        this.props.OranChecked(checkedKeys);       
    }  
    render() {
        const { expandedKeys, autoExpandParent, gData } = this.state;
        return (
            <div>                            
                    <Tree                                                         
                        checkable={this.props.checkState}
                        onCheck={this.onCheck}                                                                
                        checkedKeys={this.props.ResetKeys}
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

