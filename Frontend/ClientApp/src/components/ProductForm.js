import "../styles.css";
import { useState, useEffect } from "react";
import ProductFilter from './ProductFilter';
import ShoppingCart from './ShoppingCart';
import ProductCard from './ProductCard';
import { Link } from "react-router-dom";
import Logout from './Logout';

export default function ProductForm() {
  const [products, setProducts] = useState([]);
  const [categories, setCategories] = useState(['All', 'Fruit', 'Vegetables', 'Bread', 'Meat'/* array of product filters goes here */]);
  const [cartItems, setCartItems] = useState(JSON.parse(localStorage.getItem('cartItems')) || []);
  const [selectedCategory, setSelectedCategory] = useState("All");
  const [searchQuery, setSearchQuery] = useState("");

  const initPage = (DBproducts) => {
    let updatedProducts = [];
    for (const product of DBproducts) {
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
      updatedProducts = [...updatedProducts, newProduct];
    }
    setProducts(updatedProducts);
    localStorage.setItem('products', JSON.stringify(updatedProducts));
  };

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
    fetch(`http://localhost:44478/api/product/`, {
      method: 'GET',
    })
      .then(response => response.json())
      .then(result => initPage(result))
      .catch(error => console.log("Error: ", error));
    fetch(`http://localhost:44478/api/product/${sessionStorage.getItem('cartId')}`, {
      method: 'GET',
    })
      .then(response => response.json())
      .then(result => initCart(result))
      .catch(error => console.log("Error: ", error));
  }, [products]);

  const handleFilterChange = (e) => {
    setSelectedCategory(e.target.value);
  }

  const handleSearch = (e) => {
    setSearchQuery(e.target.value);
  };

  const handleAddToCart = (product) => {
    fetch(`http://localhost:44478/api/product/${product.id}/${sessionStorage.getItem('cartId')}/${true}`, {
      method: 'PUT',
    })
      .then(response => response.json())
      .then(result => console.log("result"))
      .catch(error => console.log("Error: ", error));
    /**
    const existingItem = cartItems.find(item => item.id === product.id);

    if (existingItem) {
      const updatedCartItems = cartItems.map(item =>
        item.id === product.id ? { ...item, quantity: item.quantity + 1 } : item
      );
      setCartItems(updatedCartItems);
      localStorage.setItem('cartItems', JSON.stringify(updatedCartItems));
    } else {
      const newCartItem = { ...product, quantity: 1 };
      const updatedCartItems = [...cartItems, newCartItem];
      setCartItems(updatedCartItems);
      localStorage.setItem('cartItems', JSON.stringify(updatedCartItems));
    }*/
  };

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

      <Logout />

      <div className="SearchBar">
        <input
          type="text"
          placeholder="Search by name..."
          value={searchQuery}
          onChange={handleSearch}
        />
      </div>

      <div className="ProductDisplay">
        {filteredProducts.map(product => (
          <ProductCard key={product.id} product={product} handleAddToCart={handleAddToCart} />
        ))}
      </div>

      <div className="ProductFilter">
        <ProductFilter categories={categories} handleFilterChange={handleFilterChange} /> {/* Pass the productsFilters array to the ProductFilter component */}
      </div>

      <div className="ShoppingCart">
        <ShoppingCart cartItems={cartItems} /> {/* Pass the cartItems array to the ShoppingCart component */}
      </div>
    </div>
  );
}
