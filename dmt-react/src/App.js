import { Routes, Route } from "react-router-dom"
import Store from "./components/pages/Store"
import Dashboard from "./components/pages/Dashboard";
import Profile from "./components/pages/Profile";
import Layout from "./components/Layout/Layout";
import MyTickets from "./components/pages/MyTickets";
import Register from "./components/pages/Register"
import Login from "./components/pages/Login";
import PrivateRoute from "./components/common/PrivateRoute"



function App() {

  return (
    <>

      <Routes>

        <Route path="register" element={<Register />} />
        <Route path="login" element={<Login />} />

        <Route element={<Layout />}>
          <Route path="/" element={<Dashboard />} />
          <Route path="store" element={<Store />} />
          <Route path="profile" element={<Profile />} />
          <Route path="myTickets" element={<MyTickets />} />
        </Route>

        <Route path="admin">
          <Route path=""></Route>
        </Route>
      </Routes>
    </>
  );
}

export default App;
