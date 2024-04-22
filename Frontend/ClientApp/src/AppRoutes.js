import { Login } from "./components/Login";
import { Products } from "./components/Products";
import { Register } from "./components/Register";
import { Account } from "./components/Account";

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
  }
];

export default AppRoutes;
