import "../styles.css";
import React, { Component } from 'react';
import Form from "./Form"

export class Register extends Component {
  static displayName = Register.name;

  render() {
      return (
          <div className="Container">
          <div className="Register">
                <Form />
              </div>
          </div>
    );
  }
}
