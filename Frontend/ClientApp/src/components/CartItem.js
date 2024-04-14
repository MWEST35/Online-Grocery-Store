import React from 'react';

const CartItem = ({ item }) => {
    return (
        <div className="cart-item">
            <img src={item.image} alt={item.name} />
            <div>
                <h4>{item.name}</h4>
                <p>Price: ${item.price}</p>
                <p>Quantity: {item.quantity}</p>
            </div>
        </div>
    );
};

export default CartItem;