import React, { Component } from 'react';
import { Form, Icon, Input, Button } from 'antd/lib/';
import {  httpPost, messageWarn } from '../../utils/public';



const FormItem = Form.Item;
function hasErrors(fieldsError) {
    return Object.keys(fieldsError).some(field => fieldsError[field]);
}

class LoginForm extends Component {

    constructor(props) { //构造函数
        super(props);      
        this.props.form.validateFields();
    }

    handleSubmit = e => {
        e.preventDefault();
        this.props.form.validateFields((err, values) => {
            if (!err) {
                console.log("传递的参数是： ", JSON.stringify(values));
                let url = '/api/Token/token';    
                httpPost(url,values).then(data=>{
                    console.log(data, "登陆日志");
                    switch (data["code"]) {
                        case "0":
                            window.location.href = "#/home?returnurl=";
                            localStorage.setItem('id_token', "Bearer "+data["extension"]);
                            break;
                        default:
                            messageWarn(data["message"] || data["userName"]);
                            break;
                    }
                });                                                        
            }
        });
    };

    render() {
        const {
            getFieldDecorator, getFieldsError, getFieldError, isFieldTouched,
        } = this.props.form;
        const userNameError = isFieldTouched('userName') && getFieldError('userName');
        const passwordError = isFieldTouched('password') && getFieldError('password');
        return (
            <Form onSubmit={this.handleSubmit} className="login-form">
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
                        style={{ width:"100%", textAlign:"center"}}
                        disabled={hasErrors(getFieldsError())}>登陆</Button>
                </FormItem>
            </Form>
        );
    }
}
const LoginForms = Form.create()(LoginForm);
export default LoginForms;
