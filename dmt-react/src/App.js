import { Routes, Route } from "react-router-dom"
import Store from "./components/pages/Store"
import Dashboard from "./components/pages/Dashboard";
import Profile from "./components/pages/Profile";
import Layout from "./components/Layout/Layout";
import MyTickets from "./components/pages/MyTickets";
import Register from "./components/pages/Register"
import Login from "./components/pages/Login";
import Users from "./components/pages/admin/Users";
import './App.css'
import Train from "./components/pages/Train";


function App() {

  return (
    <>

      <Routes>

        <Route path="register" element={<Register />} />
        <Route path="login" element={<Login />} />
        <Route path="train" element={<Train />} />

        <Route element={<Layout />}>
          <Route path="/" element={<Dashboard />} />
          <Route path="store" element={<Store />} />
          <Route path="profile" element={<Profile />} />
          <Route path="myTickets" element={<MyTickets />} />

          <Route path="admin">
            <Route path="users" element={<Users />} />
            <Route path="transactions" element={<Users />} />
          </Route>
        </Route>

        <Route path="admin">
          <Route path=""></Route>
        </Route>
      </Routes>
    </>
  );
}

export default App;
