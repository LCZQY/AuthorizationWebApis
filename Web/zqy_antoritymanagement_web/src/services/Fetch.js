import Config from './config.js';
import { $Url } from '../utils/public.js';
import {  message } from 'antd/lib/';
class Fetch extends Config {

    constructor(url, params) {
        super();        
        this.url = $Url + url;
        this.params = params;       
    }

   
    //发送POST请求
    postFetch = () => {
        fetch(this.url, {
                method: 'POST',
                headers: { "Content-Type": "application/json", "Accept": "application/json" },
                body: JSON.stringify(this.params),
            })
            .then(response => response.json())
            .then(
                data => {
                    return data;                    
                }
            ).catch((error) => {
                message.error("获取后台数据报错！");
                console.log(error,this.url+"请求时，获取后台数据报错");
        });
    }
}

export default Fetch;
