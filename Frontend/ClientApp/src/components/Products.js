import "../styles.css";
import React, { Component } from 'react';
import ProductList from './ProductList';
import ProductFilter from './ProductFilter';
import ShoppingCart from './ShoppingCart';

export class Products extends Component {
    static displayName = Products.name;
    constructor(props) {
        super(props);
        this.state = {
            products: [ /* array of products goes here */],
            categories: [/* array of product filters goes here */],
            cartItems: [/* array of cart items goes here */],
        };
    }

    render() {
        const { products } = this.state;
        const { categories } = this.state;
        const { cartItems } = this.state;

        return (
            <div className="Container">
            <p> Products Page :) </p>
                <ProductList products={products} /> {/* Pass the products array to the ProductList component */}
                <ProductFilter productFilters={categories} /> {/* Pass the productsFilters array to the ProductFilter component */}
                <ShoppingCart cartItems={cartItems} /> {/* Pass the cartItems array to the ShoppingCart component */}
            </div>
        );
    }
}