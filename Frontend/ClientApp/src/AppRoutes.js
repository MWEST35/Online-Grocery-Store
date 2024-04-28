import { Login } from "./components/Login";
import { Products } from "./components/Products";
import { Register } from "./components/Register";
import { Account } from "./components/Account";
import { Checkout } from "./components/Checkout";

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
    path: "/account",
    element: <Account />
  },
  {
    path: "/checkout",
    element: <Checkout />
  }
];

export default AppRoutes;
