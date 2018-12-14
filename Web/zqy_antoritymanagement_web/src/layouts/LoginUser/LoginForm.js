import React, { Component } from 'react';
import { Form, Icon, Input, Button } from 'antd/lib/';
const FormItem = Form.Item;


function hasErrors(fieldsError) {
    return Object.keys(fieldsError).some(field => fieldsError[field]);
}

class LoginForm extends Component {

    constructor(props) { //构造函数
        super(props);
        // this.state = {
        //     data_user: '',
        //     data_passwrod: ''
        // }
        this.props.form.validateFields();
    }

    handleSubmit = e => {
        e.preventDefault();
        this.props.form.validateFields((err, values) => {
            if (!err) {
                
                //判断密码是否正确/该用户名是否存在/如何实现跳转问题 ？
                console.log("传递的参数是： ", JSON.stringify(values.userName));                                          
                let url = 'http://localhost:5002/api/Values/token';
                fetch(url, {
                    method: 'POST',                                      
                    headers: { "Content-Type": "application/json", "Accept":  "application/json"},               
                    body: JSON.stringify(values)
                })
                .then(response => response.json())
                .then(
                    data => {
                        console.log(data, "登陆日志")
                    }
                ).catch((error) => {
                    console.error(error,"获取用户信息报错。");
                });
            }
        });
    };

    render() {
        const {
            getFieldDecorator, getFieldsError, getFieldError, isFieldTouched,
        } = this.props.form;

        // Only show error after a field is touched.
        const userNameError = isFieldTouched('userName') && getFieldError('userName');
        const passwordError = isFieldTouched('password') && getFieldError('password');
        return (
            <Form  onSubmit={this.handleSubmit} className="login-form">
                <FormItem validateStatus={userNameError ? 'error' : ''} help={userNameError || ''}>
                    {
                        getFieldDecorator('userName', {
                            rules: [{ required: true, message: '请输入用户名 !' }],
                        })(
                            <Input prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />} placeholder="Username" />
                        )}
                </FormItem>
                <FormItem validateStatus={passwordError ? 'error' : ''} help={passwordError}>
                    {
                        getFieldDecorator('passWord', {
                            rules: [{ required: true, message: '请输入密码' }]
                        })(
                            <Input prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />} type="passWord" placeholder="password" />
                        )
                    }
                </FormItem>
                <FormItem>
                    <Button type="primary"
                        htmlType="submit"
                        className="login-form-button"
                        size="large"
                        disabled={hasErrors(getFieldsError())}>登陆</Button>
                </FormItem>
            </Form>
        );
    }
}
const LoginForms = Form.create()(LoginForm);
export default LoginForms;
