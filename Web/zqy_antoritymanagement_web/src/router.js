import React,{Component} from 'react';
import {HashRouter,Route,Switch} from 'react-router-dom';
import DefaultLayout from './layouts/DefaultLayout/DefaultLayout';
import LoginUser from './layouts/LoginUser/LoginUser';

// 路由设置
export default class RouterWrap extends Component{

    render(){
        return (
            <div id="routers">
                <HashRouter>
                    <Switch>                      
                        <Route path="/" component={LoginUser} exact />
                        <Route path="/home" component={DefaultLayout}   />
                    </Switch>
                </HashRouter>
            </div>
        )
    }
}
