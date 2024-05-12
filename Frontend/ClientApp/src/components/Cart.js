import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';


const Cart = () => {
  let [cartItems, setCartItems] = useState([]);
  let [totalPrice, setTotalPrice] = useState(0)

  const initCart = (DBcart) => {
    let updatedCartItems = [];
    for (const product of DBcart) {
      const newProduct = {
        id: parseInt(product[9]),
        name: product[0],
        price: parseFloat(product[5]),
        category: product[2],
        manufacturer: product[7],
        description: product[6],
        dimensions: product[3],
        weight: product[4],
        SKU: product[8],
        rating: product[1],
        image: product[10]
      };
      updatedCartItems = [...updatedCartItems, newProduct];
    }
    setCartItems(updatedCartItems);
    localStorage.setItem('cartItems', JSON.stringify(updatedCartItems));
  }

  useEffect(() => {
    fetch(`http://localhost:44478/api/product/${sessionStorage.getItem('cartId')}`, {
      method: 'GET',
    })
      .then(response => response.json())
      .then(result => initCart(result))
      .catch(error => console.log("Error: ", error));
    let total = cartItems.reduce((total, item) => (parseFloat(total) + parseFloat(item.price)).toFixed(2), 0);
    total = (parseFloat(total) + parseFloat(total) * parseFloat(0.07)).toFixed(2); 
    setTotalPrice(total);
  }, [cartItems]);



  const handleRemoveItem = (itemId) => {
    fetch(`http://localhost:44478/api/product/${itemId}/${sessionStorage.getItem('cartId')}/${false}`, {
      method: 'PUT',
    })
      .then(response => response.json())
      .then(result => console.log("result"))
      .catch(error => console.log("Error: ", error));
        /**const updatedCartItems = cartItems.map(item =>
            item.id === itemId
                ? { ...item, quantity: item.quantity - 1 }
                : item
        ).filter(item => item.quantity > 0);

        cartItems = updatedCartItems;
        localStorage.setItem('cartItems', JSON.stringify(updatedCartItems));
        // Force component re-render to reflect the updated cartItems
        window.location.reload();*/
    };

    

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