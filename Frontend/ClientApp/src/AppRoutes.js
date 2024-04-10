import { Login } from "./components/Login";
import { Products } from "./components/Products";
import { Register } from "./components/Register";

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
  }
];

export default AppRoutes;
