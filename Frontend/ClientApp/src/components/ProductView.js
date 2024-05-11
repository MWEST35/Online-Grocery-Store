import React from 'react';
import { Link, useParams } from 'react-router-dom';
import Logout from './Logout';

function ProductView() {
    const products = JSON.parse(localStorage.getItem('products')) || [];
    const { productId } = useParams();
    const product = products.find(p => p.id === parseInt(productId));
    if (!product) {
        return <div>Product not found</div>;
    }

    return (
        <div className="ProductContainer">

            <img
                src="https://i.imgur.com/1dK701w.png"
                alt="logo"
                className="logo"
                draggable="false"
            />
            <Logout />

        <div className="ProductDetails">
            <h2>{product.name}</h2>
            <p>Rating: {product.rating} of 5 Stars</p>
            <img src={product.image} alt={product.name} />
            <p>Price: ${product.price}</p>
            <p>Category: {product.category}</p>
            <p>Manfactuer: {product.manufacturer}</p>
            <p>Description: {product.description}</p>
            <p>Dimensions: {product.dimensions}</p>
            <p>Weight: {product.weight}</p>
            <p>SKU: {product.SKU}</p>
            {/* Add more product information as needed */}
            <Link to="/products" className="back-link">Back to Products</Link>
            </div>
        </div>
    );
}

export default ProductView;