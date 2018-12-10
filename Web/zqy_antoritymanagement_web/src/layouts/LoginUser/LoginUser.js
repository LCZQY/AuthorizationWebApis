import React, { Component } from 'react';
import { Row, Col } from 'antd';

export default class LoginUser extends Component {

    render() {
        return (
            <div id="login">
                <header>
                    <Row>
                        <Col span={24}>
                            <Col span={2}><h2>权限管理系统</h2></Col>
                            <Col span={12}><h2>权限管理系统</h2></Col>
                        </Col>
                    </Row>
                </header>
                <body>
                    <Row>
                        <Col span={24}>
                            <Col span={12}><img src="https://ss0.baidu.com/94o3dSag_xI4khGko9WTAnF6hhy/image/h%3D300/sign=de08a1f093510fb367197197e932c893/b999a9014c086e062550d0020f087bf40bd1cbfb.jpg" /></Col>
                            <Col span={12}>
                                    
                            </Col>
                        </Col>           
                    </Row>
                </body>
                <footer>
                    <Row>
                        <Col span={24}>&copy;郑强勇-2018-12-10</Col>
                    </Row>
                </footer>
            </div>
        );
    }
}