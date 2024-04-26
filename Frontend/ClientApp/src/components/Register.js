import "../styles.css";
import React, { Component } from 'react';
import Form from "./Form"

export class Register extends Component {
  static displayName = Register.name;

  render() {
    return (
      <div className="Container">
        <img
          src="https://i.imgur.com/1dK701w.png"
          alt="logo"
          className="logo"
          draggable="false"
        />
        <Form />
      </div>
    );
  }
}
