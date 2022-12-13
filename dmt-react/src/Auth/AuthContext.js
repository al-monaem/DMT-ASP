import React, { useContext, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { AxiosInstance, InitializeToken } from "./AxiosInstance";

const AuthContext = React.createContext();

export const useAuth = () => {
  return useContext(AuthContext);
};

export const AuthProvider = ({ children }) => {
  const axios = AxiosInstance;

  const [currentUser, setCurrentUser] = useState(null);
  const [accessToken, setAccessToken] = useState("");
  const [stations, setStations] = useState(null);
  const [mode, setMode] = useState(0);

  const [routedetails, setRoutedetails] = useState([]);
  const [paymentdetails, setPaymentdetails] = useState([]);

  const navigate = useNavigate();

  const onChangeMode = (mode) => {
    setMode(mode);
  };

  const saveUser = (user) => {
    localStorage.setItem("user", JSON.stringify(user));
  };

  const getRoutes = async (e) => {
    try {
      InitializeToken();
      const response = await axios.get("api/routes");
      const data = await response.data;

      return data;
    } catch {
      console.log("station data error");
    }
  };

  const setStationData = async (e) => {
    try {
      InitializeToken();
      const response = await axios.get("api/stations", {
        headers: {
          "Content-type": "application/json",
        },
      });
      const data = await response.data;
      //debugger
      if (data) {
        setStations(data);
        return true;
      }
      return;
    } catch (error) {
      console.log("station data error");
      return false;
    }
  };

  const getRevenues = async (e) => {
    debugger;
    try {
      const response = await axios.get(`api/admin/revenues`);
      const data = await response.data;
      return data;
    } catch (error) {
      return error;
    }
  };

  const handleRecharge = async (payment) => {
    //debugger;
    try {
      const response = await axios.post(
        "api/walletrecharge",
        JSON.stringify(payment),
        {
          headers: {
            "Content-type": "application/json",
          },
        }
      );
      const data = await response.data;
      //debugger
      if (data) {
        //console.log(data);
        setPaymentdetails(data);
        //console.log(paymentdetails);
        return {
          method: data.method,
          data: data,
          status: response.status,
        };
      }
      return;
    } catch (error) {
      console.log("data error");
      return false;
    }
  };

  const handlePayment = async (payment) => {
    try {
      const response = await axios.post("api/checkout", payment);
      const data = await response.data;
      debugger
      if (data.transaction) {
        setPaymentdetails(data.transaction);
        await refreshUser(currentUser.id)
        return data;
      }
      return data.error;
    } catch (error) {
      return error;
    }
  };

  const supportRequest = async (support) => {
    try {
      const response = await axios.post("api/supportcreate", support, {
        headers: {
          "Content-type": "application/json",
        },
      });
      const data = await response.data;
      if (data) {
        return { message: data.message, code: data.code };
      }
      return;
    } catch (error) {
      return error;
    }
  };

  const sendReset = async (email) => {
    try {
      const response = await axios.post("api/passwordreset", email);
      const data = await response.data;
      if (data) {
        return data;
      }
      return { success: "", error: "Server under maintenance" };
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  };
  const passwordUpdate = async (password) => {
    //debugger;
    try {
      const response = await axios.post("api/passwordupdate", password, {
        headers: {
          "Content-type": "application/json",
        },
      });
      const data = await response.data;
      //debugger
      if (data) {
        console.log(data);
        return { message: data.message, code: data.code };
      }
      return;
    } catch (error) {
      //debugger
      //console.log("route data error");
      //return data.message;
    }
  };
  const handleRefund = async (id) => {
    InitializeToken();
    try {
      const response = await axios.post(`api/refund/${id}`);
      const data = await response.data;
      if (data) {
        await refreshUser(currentUser.id);
        return data;
      }
      return;
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  };

  const verifyTicket = async (id) => {
    InitializeToken();
    try {
      const response = await axios.post(`api/verifyticket/${id}`);
      const data = await response.data;
      if (data) {
        return data;
      }
      return;
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  };

  const setRouteData = async (route) => {
    //debugger;
    InitializeToken();
    try {
      const response = await axios.get(`api/route/${route.id}`);
      const data = await response.data;
      debugger;
      if (data) {
        console.log(data);
        setRoutedetails(data);
        return true;
      }
      return;
    } catch (error) {
      //console.log("route data error");
      return false;
    }
  };

  const setCredentials = async () => {
    setCurrentUser(JSON.parse(localStorage.getItem("user")));
    setAccessToken(localStorage.getItem("accessToken"));
  };

  const uploadImage = async (image) => {
    var formdata = new FormData();
    formdata.append("image", image);
    try {
      const response = await axios.post(
        "https://api.imgbb.com/1/upload?key=9d114e45a6fe1705ae2311bc729f758e",
        formdata,
        {
          headers: {
            "Content-Type": "multipart/form-data",
            Authorization: "",
          },
        }
      );
      const data = response.data;
      const user = { ...currentUser, profilePic: data.image.url };
      return updateUser(user);
    } catch {
      return { error: "Error uploading picture" };
    }
  };

  const getTickets = async () => {
    debugger
    try {
      const response = await axios.get(`api/transactions/${currentUser.id}`);
      const data = await response.data;
      return data;
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  };

  const sendEmail = async (email) => {
    debugger
    try {
      const response = await axios.post(`api/sendEmail`, email);
      const data = await response.data;
      return data;
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  }

  const deleteUser = async (id) => {
    debugger
    try {
      const response = await axios.post(`api/admin/delete/${id}`);
      const data = await response.data;
      return data;
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  };

  const getTransactions = async () => {
    debugger
    try {
      const response = await axios.get("api/admin/transactions");
      const data = await response.data;
      return data;
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  };

  const updatePassword = async (user) => {
    InitializeToken();
    try {
      debugger;
      const response = await axios.post("api/updatePassword", user);
      const data = response.data;
      return data;
    } catch {
      return { success: "", error: "Server under maintenance" };
    }
  };

  const updateUser = async (user) => {
    debugger
    try {
      var response = await axios.post(`api/update`, user);
      const data = await response.data;
      if (data.success.length > 0) {
        setCurrentUser(data.User);
        saveUser(data.User);
      }
      return data;
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  };

  const adminUpdateUser = async (user) => {
    debugger;
    try {
      var response = await axios.post(`api/update`, user);
      const data = await response.data;
      return data;
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  };

  const getUsers = async () => {
    try {
      debugger;
      const response = await axios.get(`api/admin/users`);
      const data = await response.data;
      return data;
    } catch (error) {
      //console.log("station data error")
      return null;
    }
  };

  const register = async (data) => {
    try {
      const response = await axios.post("api/register", data);
      const message = response.data;
      return message;
    } catch (error) {
      return { success: "", error: "Server under maintenance" };
    }
  };

  const refreshUser = async (id) => {
    debugger
    try {
      const response = await axios.get(`api/getUser/${id}`);
      const data = await response();
      if (data.success.length > 0 && data.User) {
        setCurrentUser(data.User);
        localStorage.setItem("user", JSON.stringify(data.User));
      }
      return
    } catch {
      return
    }
  }

  const login = async (user) => {
    try {
      const response = await axios.post("api/login", user);
      const data = await response.data;
      if (data.success && data.success.accessToken !== null) {
        setAccessToken(data.success.accessToken);
        setCurrentUser(data.success.User);

        if (data.success.User) {
          localStorage.setItem("user", JSON.stringify(data.success.User));
          localStorage.setItem("accessToken", data.success.accessToken);
          navigate("/");
        }

        return data;
      }
      return data;
    } catch (error) {
      setAccessToken("");
      setCurrentUser("");
      return { success: "", error: "Server under maintenance" };
    }
  };

  const logout = async () => {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("user");
    try {
      InitializeToken();
      const response = await axios.post("api/logout");
    } catch (error) { }
    navigate("/login");
  };

  const value = {
    currentUser,
    accessToken,
    register,
    login,
    setCredentials,
    logout,
    setStationData,
    getTickets,
    stations,
    getUsers,
    updateUser,
    getTransactions,
    onChangeMode,
    mode,
    setRouteData,
    routedetails,
    sendReset,
    passwordUpdate,
    handlePayment,
    paymentdetails,
    getRoutes,
    updatePassword,
    adminUpdateUser,
    uploadImage,
    deleteUser,
    getRevenues,
    supportRequest,
    handleRecharge,
    handleRefund,
    verifyTicket,
    refreshUser,
    sendEmail
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};
