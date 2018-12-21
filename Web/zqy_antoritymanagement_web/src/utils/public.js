import {message} from 'antd';

//>>错误消息提示
export const messageError= (content) =>{
    message.error(content);    
}

//>>警告消息提示
export const messageWarn = (content) =>{
    message.warn(content);    
}

//>>服务端地址
export const $Url="http://localhost:5002";

 //>>发送POST请求 ? 如何传递一个方法进来
 export const postFetch = ($_url,$_params) => {
    fetch($_url, {
            method: 'POST',
            headers: { "Content-Type": "application/json", "Accept": "application/json" },
            body: JSON.stringify($_params),
        })        
        .then(response => response.json())
        .then(
            data => {
                return data;
            }
        ).catch((error) => {
            console.error(error, "获取后台数据报错~");
    });
}


