import CartItem from "./CartItem";
import { Link } from 'react-router-dom';
import React from 'react';

/* Allows users to add items to their shopping cart */
const ShoppingCart = ({ cartItems, handleCheckout }) => {
    
    return (
        <div className="shopping-cart">
            <h3>Shopping Cart</h3>
            {cartItems.map(item => (
                <CartItem key={item.id} item={item} />
            ))}
            <Link to="/Checkout">
                <button style={{ marginTop: '15px', marginLeft: '40px' }} onClick={handleCheckout} className="checkout-button">Checkout</button>
            </Link>
            <Link to="/Cart">
                <button style={{ marginLeft: '10px' }} className="view-cart-button"> View Cart</button>
            </Link>
        </div>
    );
};

export default ShoppingCart;