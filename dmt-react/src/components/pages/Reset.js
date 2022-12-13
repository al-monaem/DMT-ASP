import React, { useState } from "react";
import Logo from "../Login/Logo";
import { useAuth } from "../../Auth/AuthContext";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useNavigate } from "react-router-dom";

const Reset = () => {
  const style = {
    image: "ml-10 flex flex-col w-[50%] h-full visible",
    from_container: "flex h-full w-[50%] items-center justify-center relative",
    container: "absolute flex w-full h-full bg-[#f0f2f5]",
    input: "p-3 rounded-lg border focus:outline-blue-300",
    label: "pl-1",
    form: "w-full space-y-3 flex flex-col items-center relative",
    field: "flex flex-col space-y-1 w-full",
    form_container:
      "w-[65%] shadow-md rounded-lg bg-white py-10 px-8 flex flex-col items-center space-y-5",
    container: "absolute w-full flex h-full items-center justify-center",
    btn: "w-full p-2 rounded-lg mt-5 text-white font-semibold bg-blue-700",
  };

  const navigate = useNavigate()
  const [data, setData] = useState({
    email: "",
    otp: "",
    password: "",
  });
  const [emailresponse, setEmailresponse] = useState({ success: "", error: "" });

  const { sendReset, passwordUpdate } = useAuth();
  const [isOpen, setIsOpen] = useState(false);

  const onSubmit = async (e) => {
    e.preventDefault();
    if (e.currentTarget.id === "reset") {
      const response = await sendReset(data);
      setEmailresponse(response);
      //console.log(response);

      if (response.error.length > 0) {
        toast.error(response.error, {
          position: "bottom-right",
          autoClose: 3000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: "colored",
        });
      } else {
        setIsOpen(true);
        toast.success(response.success, {
          position: "bottom-right",
          autoClose: 3000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: "colored",
        });
      }
    }
    else if (e.currentTarget.id === "update") {
      const response = await sendReset(data);
      setEmailresponse(response);
      if (response.success.length > 0) {
        navigate('/login')
        toast.success(response.success, {
          position: "bottom-right",
          autoClose: 3000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: "colored",
        });
      }
      else {
        toast.error(response.error, {
          position: "bottom-right",
          autoClose: 3000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: "colored",
        });
      }
    }
  };

  const handleChange = (e) => {
    const value = e.target.value;
    setData({
      ...data,
      [e.target.name]: value,
    });
  };

  return (
    <div className={style.container}>
      {console.log(emailresponse)}
      <div className={style.image}>
        <Logo />
      </div>
      <div className={style.from_container}>
        <div className={style.form_container}>
          <p className="font-semibold text-2xl">Reset</p>
          <form className={style.form}>
            <div className={style.field}>
              <label className={style.label}>Email</label>
              <input
                name="email"
                className={style.input}
                type="email"
                placeholder="john@doe.com"
                required
                onChange={handleChange}
              />
            </div>
            <div className="text-green-500 pl-1 w-full text-sm tracking-wide">
              <span>
                <ToastContainer
                  position="bottom-right"
                  autoClose={3000}
                  hideProgressBar={false}
                  newestOnTop={false}
                  closeOnClick
                  rtl={false}
                  pauseOnFocusLoss
                  draggable
                  pauseOnHover
                  theme="colored"
                />
              </span>
            </div>
            {isOpen && (
              <div className={style.field}>
                <label className={style.label}>OTP</label>
                <input
                  name="otp"
                  className={style.input}
                  type="otp"
                  required
                  onChange={handleChange}
                />
                <label className={style.label}>New Password</label>
                <input
                  name="password"
                  className={style.input}
                  type="password"
                  required
                  onChange={handleChange}
                />
              </div>
            )}
            <div className={style.field}>
              {!isOpen && (
                <button
                  className={style.btn}
                  id="reset"
                  onClick={(e) => onSubmit(e)}
                  type="submit"
                >
                  Reset
                </button>
              )}
              {isOpen && (
                <button
                  className={style.btn}
                  id="update"
                  onClick={e => onSubmit(e)}
                  type="submit"
                >
                  Update
                </button>
              )}
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Reset;
