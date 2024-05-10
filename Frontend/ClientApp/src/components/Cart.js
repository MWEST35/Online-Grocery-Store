import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';


const Cart = () => {
    let [cartItems, setCartItems] = useState([]);

    useEffect(() => {
        const storedCartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
        setCartItems(storedCartItems);
    }, []);

    const handleRemoveItem = (itemId) => {
        const updatedCartItems = cartItems.map(item =>
            item.id === itemId
                ? { ...item, quantity: item.quantity - 1 }
                : item
        ).filter(item => item.quantity > 0);

        cartItems = updatedCartItems;
        localStorage.setItem('cartItems', JSON.stringify(updatedCartItems));
        // Force component re-render to reflect the updated cartItems
        window.location.reload();
    };

    console.log("Cart Items:", cartItems)

    const totalPrice = cartItems.reduce((total, item) => total + (item.price * item.quantity), 0);

    return (
        <div className="CartContainer">
            <img
                src="https://i.imgur.com/1dK701w.png"
                alt="logo"
                className="logo"
                draggable="false"
            />
            <h2 className="cart-header">Shopping Cart</h2>
            <div className="cart-items">
                {cartItems.map(item => (
                    <div key={item.id} className="cart-item">
                        <img src={item.image} alt={item.name} />
                        <div className="cart-item-info">
                            <div className="cart-item-name">{item.name}</div>
                            <div className="cart-item-price">${item.price}</div>
                        </div>
                        <div className="cart-item-quantity"> Quantity: {item.quantity}</div>
                        <div className="cart-item-buttons">
                            <button onClick={() => handleRemoveItem(item.id)}>Remove</button>
                        </div>
                    </div>
                ))}
            </div>
            <div className="total-price">Total Price: ${totalPrice}</div>
            <Link to="/products" className="back-to-products">
                <button className="button">Back to Products</button>
            </Link>
        </div>
    );
};

export default Cart;