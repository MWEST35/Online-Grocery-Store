import { Login } from "./components/Login";
import { Register } from "./components/Register";

const AppRoutes = [
  {
    index: true,
    element: <Login />
  },
  {
    path: "/register",
    element: <Register />
  }
];

export default AppRoutes;
