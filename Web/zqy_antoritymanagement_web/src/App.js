import React, { Component } from "react";
import "./App.css";
import RouterWrap from "./router";
// import Button from 'antd/lib';

class App extends Component {

  // constructor()
  // {
  //   super();
  //   this.state = {
  //     num: 0
  //   }
  // }
  // changeNum = () => {
  //   let { num } = this.state;
  //   let newNum = num + 1;
  //   this.setState({
  //     num: newNum
  //   });
  // };
  render() {
      
    return (
      <div className="App" >
        <RouterWrap />
        {/* <Button onClick={this.changeNum()}>当前数值 :{this.num}</Button> */}
      </div>
    );
  }
}

export default App;
