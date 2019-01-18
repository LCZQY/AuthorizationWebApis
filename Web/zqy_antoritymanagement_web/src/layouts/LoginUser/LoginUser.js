import React, { Component } from 'react';
import { Row, Col, Affix } from 'antd';
//一个变量不用括号标识
import LoginFrom from '../../components/Form/LoginForm';


export default class LoginUser extends Component {
    render() {
        return (
            <div className="login" >               
                <Row style={{marginTop:"12%"}}>
                    <Col span={5} push={14}  style={{background:"#fff", padding:"2%"} } >
                        <h2>权限管理系统</h2>
                        <LoginFrom />
                    </Col>
                </Row>                
            </div>
        );
    }
}