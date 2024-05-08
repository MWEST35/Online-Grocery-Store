import "../styles.css";
import React, { Component } from 'react';
import ProductList from './ProductList';
import { Route, Routes } from 'react-router-dom';
import ProductFilter from './ProductFilter';
import ShoppingCart from './ShoppingCart';
import ProductCard from './ProductCard';
import ProductView from './ProductView';

export class Products extends Component {
    static displayName = Products.name;
    constructor(props) {
        super(props);
        this.state = {
            products: [{
                id: 1,
                name: 'Apple',
                price: 10,
                category: 'Fruit',
                manufacturer: 'PepsiCo',
                description: "Example Product Description",
                dimensions: "5.43 x 5.43 x 11.02 inches",
                weight: "0.55 Kilograms",
                SKU: "KSRUFTT",
                rating: "4",
                image: 'https://png.pngtree.com/element_our/png/20181129/vector-illustration-of-fresh-red-apple-with-single-leaf-png_248312.jpg'
            },
                {
                    id: 2,
                    name: 'Banana',
                    price: 20,
                    category: 'Fruit',
                    manufacturer: 'PepsiCo',
                    description: "Example Product Description",
                    dimensions: "5.43 x 5.43 x 11.02 inches",
                    weight: "0.55 Kilograms",
                    SKU: "KSRUFTT",
                    rating: "4",
                    image: 'https://png.pngtree.com/element_our/png/20181129/vector-illustration-of-fresh-red-apple-with-single-leaf-png_248312.jpg'
                },
                {
                    id: 3,
                    name: 'Loaf of Bread',
                    price: 30,
                    category: 'Bread',
                    manufacturer: 'PepsiCo',
                    description: "Example Product Description",
                    dimensions: "5.43 x 5.43 x 11.02 inches",
                    weight: "0.55 Kilograms",
                    SKU: "KSRUFTT",
                    rating: "4",
                    image: 'https://png.pngtree.com/element_our/png/20181129/vector-illustration-of-fresh-red-apple-with-single-leaf-png_248312.jpg'
                },
                {
                    id: 4,
                    name: 'Steak',
                    price: 40,
                    category: 'Meat',
                    manufacturer: 'PepsiCo',
                    description: "Example Product Description",
                    dimensions: "5.43 x 5.43 x 11.02 inches",
                    weight: "0.55 Kilograms",
                    SKU: "KSRUFTT",
                    rating: "4",
                    image: 'https://png.pngtree.com/element_our/png/20181129/vector-illustration-of-fresh-red-apple-with-single-leaf-png_248312.jpg'
                }],
            categories: ['All', 'Fruit', 'Vegetables', 'Bread', 'Meat'/* array of product filters goes here */],
            cartItems: JSON.parse(sessionStorage.getItem('cartItems')) || [],
            selectedCategory: "All",
            searchQuery: "",
        };
    }

    handleFilterChange = (e) => {
        const category = e.target.value;
        this.setState({ selectedCategory: category });
    }

    handleSearch = (e) => {
        const searchQuery = e.target.value;
        this.setState({ searchQuery });
    };


    handleAddToCart = (product) => {
        const { cartItems } = this.state;
        const existingItem = cartItems.find(item => item.id === product.id);

        if (existingItem) {
            const updatedCartItems = cartItems.map(item =>
                item.id === product.id ? { ...item, quantity: item.quantity + 1 } : item
            );
            this.setState({ cartItems: updatedCartItems });
            sessionStorage.setItem('cartItems', JSON.stringify(updatedCartItems));
        } else {
            const newCartItem = { ...product, quantity: 1 };
            const updatedCartItems = [...cartItems, newCartItem];
            this.setState({ cartItems: updatedCartItems });
            sessionStorage.setItem('cartItems', JSON.stringify(updatedCartItems));
        }
    };

    render() {
        const { products, categories, selectedCategory, cartItems, searchQuery } = this.state;

        const filteredProducts = products.filter(product => {
            return (
                (selectedCategory === 'All' || product.category === selectedCategory) &&
                (searchQuery === '' || product.name.toLowerCase().includes(searchQuery.toLowerCase()))
            );
        });


        return (
            <div className="ProductContainer">

                <img
                    src="https://i.imgur.com/1dK701w.png"
                    alt="logo"
                    className="logo"
                    draggable="false"
                />

                            <div className="SearchBar">
                                <input
                                    type="text"
                                    placeholder="Search by name..."
                                    value={searchQuery}
                                    onChange={this.handleSearch}
                                />
                            </div>

                            <div className="ProductDisplay">
                                {filteredProducts.map(product => (
                                    <ProductCard key={product.id} product={product} handleAddToCart={this.handleAddToCart} />
                                ))}
                            </div>

                            <div className="ProductFilter">
                                <ProductFilter categories={categories} handleFilterChange={this.handleFilterChange} /> {/* Pass the productsFilters array to the ProductFilter component */}
                            </div>

                            <div className="ShoppingCart">
                                <ShoppingCart cartItems={cartItems} /> {/* Pass the cartItems array to the ShoppingCart component */}
                            </div>
            </div>
        );
    }
}
export default Products;