import React, { Component } from 'react';
import { Row, Col, Affix } from 'antd';
//一个变量不用括号标识
import LoginFrom from '../../components/Form/LoginForm';


export default class LoginUser extends Component {
    render() {
        return (
            <div id="login">
                {
                    <header>
                        <Row>
                            <Col span={24}>
                                <Affix>
                                    
                                </Affix>
                            </Col>
                        </Row>
                    </header>
                }
                <Row>
                    <Col span={6} push={9}  >
                        <h2>权限管理系统</h2>
                        <LoginFrom />
                    </Col>
                </Row>
                {
                    /* <footer>
                    <Row>
                        <Col span={24}>&copy;郑强勇-2018-12-10</Col>
                    </Row>
                </footer> */
                }
            </div>
        );
    }
}