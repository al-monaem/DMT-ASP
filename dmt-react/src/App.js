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
import Transactions from "./components/pages/admin/Transactions";
import AdminDashboard from "./components/pages/admin/AdminDashboard";
import Misc from "./components/pages/admin/Misc";
import IsAdmin from "./Auth/IsAdmin";


function App() {

  return (
    <>
      <Routes>
        <Route path="register" element={<Register />} />
        <Route path="login" element={<Login />} />
        <Route path="train" element={<Train />} />

        <Route element={<Layout />}>
          <Route path="/" element={<Dashboard />} exact />
          <Route path="store" element={<Store />} />
          <Route path="profile" element={<Profile />} />
          <Route path="myTickets" element={<MyTickets />} />
        </Route>
        <Route element={<Layout />}>
          <Route element={<IsAdmin />}>
            <Route path="admin">
              <Route path="users" element={<Users />} />
              <Route path="transactions" element={<Transactions />} />
              <Route path="dashboard" element={<AdminDashboard />} />
              <Route path="misc" element={<Misc />} />
            </Route>
          </Route>
        </Route>

      </Routes>
    </>
  );
}

export default App;
