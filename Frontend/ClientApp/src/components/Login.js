import "../styles.css";
import React, { Component } from 'react';
import LoginForm from "./LoginForm";

export class Login extends Component {
  static displayName = Login.name;

  render() {
    return (
      <div className="Container">
        <img
          src="https://en.expensereduction.com/wp-content/uploads/2018/02/logo-placeholder-300x68.png"
          alt="logo"
          className="logo"
          draggable="false"
        />
        <LoginForm />
      </div>
    );
  }
}
