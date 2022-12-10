import { useState } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../../Auth/AuthContext";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const Support = () => {
  const style = {
    input: "p-3 rounded-lg border w-[50%] focus:outline-blue-300",
    label: "pl-1",
    form: "w-full space-y-2 flex flex-col items-center relative",
    field: "flex flex-col w-full",
    form_container:
      "w-[55%] shadow-md rounded-lg bg-[#b3ecff] py-10 px-8 flex flex-col items-center",
    container: "mx-auto w-[70%] h-[70%]  flex  items-center justify-center",
    btn: "w-[25%] flex justify-center p-2 rounded-lg text-black bg-[#b3c6ff] font-semibold border-2 border-black-900",
  };

  const { currentUser, supportRequest } = useAuth();
  const [data, setData] = useState({
    email: currentUser.email,
    category: "",
    details: "",
  });
  const onChange = (e) => {
    const value = e.target.value;
    //console.log(value)
    setData({
      ...data,
      [e.target.name]: value,
    });
  };
  const onSubmit = async (e) => {
    e.preventDefault();
    const response = await supportRequest(data);
    if (response.code === "200") {
      toast.success(response.message, {
        position: "bottom-right",
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        theme: "colored",
      });
    } else if (response.code === "201") {
      toast.error(response.message, {
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
    e.target.reset();
  };
  return (
    <div className="flex w-full">
      <div className="w-[50%]">
        <form
          className="flex justify-center w-[70%] mx-auto space-x-3"
          onSubmit={onSubmit}
        >
          <div className="m-auto mt-10 w-full max-w-2xl rounded-lg bg-[#0ebbffa6] px-5 py-10 shadow">
            <div className="mb-6 text-center text-3xl font-light text-gray-800">
              Create Ticket !
            </div>
            <div className="m-auto grid max-w-xl grid-cols-2 gap-4">
              <div className="col-span-2">
                <div className="relative">
                  <input
                    type="email"
                    className="w-full flex-1 rounded-lg border bg-white px-4 py-2 text-base text-gray-700  focus:ring-2 focus:ring-red-600"
                    placeholder="Email"
                    defaultValue={currentUser.email}
                    readOnly
                  />
                </div>
              </div>
              <div className="col-span-2">
                <div className="relative">
                  <select
                    className="w-full flex-1 rounded-lg border bg-white px-4 py-2 text-base text-gray-700  focus:ring-2 focus:ring-red-600"
                    name="category"
                    onChange={(e) => onChange(e)}
                  >
                    <option>Select an option</option>
                    <option value="refund">Refund Issue</option>
                    <option value="payment_fail">Payment Failure</option>
                    <option value="service_req">Service Request</option>
                    <option value="complaints">
                      Complaints against Employee
                    </option>
                  </select>
                </div>
              </div>

              <div className="col-span-2">
                <label className="text-gray-700" for="name">
                  <textarea
                    className="w-full flex-1 rounded-lg border bg-white px-4 py-2 text-base text-gray-700  focus:ring-2 focus:ring-red-600"
                    placeholder="Enter your comment"
                    name="details"
                    rows="5"
                    cols="40"
                    onChange={(e) => onChange(e)}
                    required
                  ></textarea>
                </label>
              </div>
              <div className="col-span-2 text-right">
                <button
                  type="submit"
                  className="w-full rounded-lg bg-indigo-600 py-2 px-4 text-center text-base font-semibold text-white shadow-md transition duration-200 ease-in hover:bg-[#1365ff] focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 focus:ring-offset-indigo-200"
                >
                  Send
                </button>
              </div>
            </div>
          </div>
        </form>
      </div>
      <div className="w-[50%]">XXXX</div>
    </div>
  );
};

export default Support;
