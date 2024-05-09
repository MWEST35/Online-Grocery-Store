import { Login } from "./components/Login";
import  ProductView from "./components/ProductView";
import { Products } from "./components/Products";
import { Register } from "./components/Register";
import { Account } from "./components/Account";
import { Checkout } from "./components/Checkout";
import Cart from "./components/Cart";

let cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];

const products = [{
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
    }];


const AppRoutes = [
  {
    index: true,
    element: <Login />
  },
  {
    path: "/register",
    element: <Register />
  },
  {
      path: "/products",
      element: <Products />

  },
  {
      path: "/products/:productId",
      element: < ProductView products={ products } />
  },
  {
    path: "/account",
    element: <Account />
  },
  {
    path: "/checkout",
    element: <Checkout />
    },
    {
        path: "/cart",
        element: <Cart />
    }
];

export default AppRoutes;
