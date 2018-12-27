import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import  Homes  from '../../routes/Home/Homes';
import  Oranizations from '../../routes/Oranizations';
import  Permissionitems  from '../../routes/Permissionitems';
import  Users from '../../routes/Users';
import  Roles  from '../../routes/Roles';

class DefaultLayout extends Component {

    render() {
        return (
            <div id="DefaultLayout">              
                <div className="content-wrap">
                    <Route path={this.props.match.url + '/'} component={Homes} exact />
                    <Route path={this.props.match.url + '/Oranizations'} component={Oranizations} />
                    <Route path={this.props.match.url + '/Permissionitems'} component={Permissionitems} />
                    <Route path={this.props.match.url + '/Roles'} component={Roles} />
                    <Route path={this.props.match.url + '/Users'} component={Users} />
                </div>           
            </div>
        );
    }
}

export default DefaultLayout;