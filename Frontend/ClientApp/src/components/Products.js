import "../styles.css";
import React, { Component } from 'react';
import ProductList from './ProductList';
import { Route, Routes } from 'react-router-dom';
import ProductFilter from './ProductFilter';
import ShoppingCart from './ShoppingCart';
import ProductCard from './ProductCard';
import ProductView from './ProductView';
import ProductForm from "./ProductForm";

export class Products extends Component {
  static displayName = Products.name;

  render() {
    return (
      <ProductForm />
    )}
}
export default Products;