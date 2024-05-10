import { Login } from "./components/Login";
import  ProductView from "./components/ProductView";
import { Products } from "./components/Products";
import { Register } from "./components/Register";
import { Account } from "./components/Account";
import { Checkout } from "./components/Checkout";
import Cart from "./components/Cart";

let cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
let products = JSON.parse(localStorage.getItem('products')) || [];

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
      element: <ProductView />
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
