import React,{Component} from 'react';
import {HashRouter,Route,Switch} from 'react-router-dom';
import DefaultLayout from './layouts/Home/Home';
import LoginUser from './layouts/LoginUser/LoginUser';

// 路由设置
export default class RouterWrap extends Component{
    render(){
        return (
            <div id="router">
                <HashRouter>
                    <Switch>
                        <Route path="/login" component={DefaultLayout}  exact />
                        <Route path="/" component={LoginUser} />
                    </Switch>
                </HashRouter>
            </div>
        )
    }
}
