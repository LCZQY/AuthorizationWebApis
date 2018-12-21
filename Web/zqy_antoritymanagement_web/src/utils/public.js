import {message} from 'antd';

/** 验证手机号码 */
export const isPhoneNumber = (phoneNumber) => {
    const reg = /^0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$/;
    return reg.test(phoneNumber);
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
export const $Url="http://localhost:5002";//需要设置成ip地址，不能设置成localhost????


/**GET Fetch 请求*/
export function httpGet(uri) {
    uri = $Url + uri;
    let init = {
        method: 'GET',
        credentials: 'include',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    };
    return new Promise(function (resolve, reject) {
        fetch(uri, init)
            .then(response => response.json())
            .then(data => {        
                resolve(data);       
                // if (data.status === 0) {
                //     resolve(data);
                // } else {
                //     processError(data);
                // }
            }).catch(function (ex) {
                reject(ex);
                messageError("请求数据错误，请重试"+ex);
            });
    });
}

/**Post Fetch 请求 */
export  async  function httpPost(uri, params) {
    uri = $Url + uri;
    let init = {
        method: 'POST',
        credentials: 'include',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(params)
    };

    return new Promise(function (resolve, reject) {

        fetch(uri, init)
            .then(response => response.json())
            .then(data => {
                resolve(data);
                // if (data.code === 0) {
                //     resolve(data);
                // } else {
                //    messageError(data["message"]);
                // }
            }).catch(function (ex) {
                reject(ex);
                messageError("请求数据错误，请重试");
            });
    });
}
 
