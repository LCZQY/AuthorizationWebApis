import {message} from 'antd';

/** 验证手机号码 */
export const isPhoneNumber = (phoneNumber) => {
    const reg = /^0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$/;
    return reg.test(phoneNumber);
};


/**成功消息提示 */
export const messageSuccess = (content) => {
    message.success(content);
};

/** 错误消息提示 */
export const messageError= (content) =>{
    message.error(content);    
}

/** 警告消息提示 */
export const messageWarn = (content) =>{
    message.warn(content);    
}

/** 服务端地址 */
export const $Url="http://192.168.100.120:5002";


/**GET Fetch 请求*/
export async function httpGet(uri, params) {
    let tokens = localStorage.getItem("id_token");
    uri = $Url + uri;
    let init = {
        method: 'GET',
        credentials: 'include',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': tokens
        },
        body: JSON.stringify(params)
    };

    return new Promise(function(resolve, reject) {
        try {
            fetch(uri, init)
                .then(response => response.json())
                .then(data => {
                    resolve(data);
                })
                .catch(function (ex) {
                    reject(ex);
                    messageError("请求数据错误，请重试");
                });                
        } catch (e) {
            messageError("请求数据错误，请重试");
            console.log(e, "请求：" + uri + "出现异常.")
        }
    });
}

/**Post Fetch 请求 */
export async function httpPost(uri, params) {
    let tokens = localStorage.getItem("id_token");
    uri = $Url + uri;
    let init = {
        method: 'POST',
        credentials: 'include',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': tokens
        },
        body: JSON.stringify(params)
    };
    return new Promise(function (resolve, reject) {
        
        try {
            fetch(uri, init)
                .then(response => response.json())
                .then(data => {
                    resolve(data);
                })
                .catch(function (ex) {
                    reject(ex);
                    messageError("请求数据错误，请重试");
                });
        } catch (e) {
            messageError("请求数据错误，请重试");
            console.log(e, "请求：" + uri + "出现异常.")
        }
    });
}

