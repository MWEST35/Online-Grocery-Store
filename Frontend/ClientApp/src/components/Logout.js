import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function LoginForm() {
  const navigate = useNavigate();
  const logOut = () => {
    sessionStorage.setItem('userId', 0);
    sessionStorage.setItem('cartId', 0);
    navigate("/");
  }
  return (<button onClick={logOut} className='Logout'>Log Out</button>);
}