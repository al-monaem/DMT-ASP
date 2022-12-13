import { TbEdit } from "react-icons/tb";
import { MdDelete, MdMarkEmailUnread } from "react-icons/md";
import { useEffect, useRef, useState } from "react";
import { IoCheckmarkDone } from "react-icons/io5";
import { TiUserDelete } from "react-icons/ti";

import ReactModal from "react-modal";

const UserCard = ({ user, onSubmit, onDelete, sendEmailtoUser }) => {
  const [editEmail, setEditEmail] = useState(false);
  const [editRole, setEditRole] = useState(false);
  const [email, setEmail] = useState(user.email);
  const [role, setRole] = useState(user.role);
  const [isOpen, setIsOpen] = useState(false);
  const [isEmailOpen, setIsEmailOpen] = useState(false);
  const [sendEmail, setSendEmail] = useState({ email: user.email })

  const emailRef = useRef();
  const roleRef = useRef();

  const style = {
    container: "w-full font-semibold text-sm border-y h-16",
    icon: "ml-2 text-gray-400 p-1 rounded-lg hover:bg-gray-400 hover:text-white hover:transition hover:cursor-pointer",
    iconCheck:
      "ml-2 text-gray-400 p-1 rounded-lg hover:bg-[#30D5C8] hover:text-white hover:transition hover:cursor-pointer",
    inputEmail: `${!editEmail ? "hover:cursor-default" : ""
      } p-2 focus:outline-[#30D5C8] rounded-md`,
    inputRole: `${!editRole ? "hover:cursor-default" : ""
      } p-2 focus:outline-[#30D5C8] w-14 rounded-md`,
    image: "p-1 w-10 h-10 rounded-full",
    name: "flex items-center space-x-3",
    action:
      "border rounded-md hover:cursor-pointer hover:transition text-[#30D5C8] hover:text-white hover:scale-125 duration-700 hover:duration-500",
  };

  const onClickEmail = (e) => {
    setEditEmail(true);
    emailRef.current.focus();
  };
  const onClickRole = (e) => {
    setEditRole(true);
    roleRef.current.focus();
  };
  const onChangeEmail = (e) => {
    setEmail(e.target.value);
  };
  const onChangeRole = (e) => {
    setRole(e.target.value);
  };
  const handleDelete = (e) => {
    e.preventDefault();
    setIsOpen(true);
    //console.log(isOpen);
  };
  useEffect(() => {
    setEmail(user.email);
    setRole(user.role);
  }, []);

  const onChange = (e) => {

    setSendEmail({
      ...sendEmail,
      [e.target.name]: e.target.value
    })

  }

  return (
    <tr className={style.container}>
      <td>
        <div className={style.name}>
          <img className={style.image} src={user.profilePic} />
          <p>{user.id}</p>
        </div>
      </td>
      <td>
        <div className="flex items-center">
          <input
            ref={roleRef}
            className={style.inputRole}
            onChange={onChangeRole}
            defaultValue={user.role}
            readOnly={!editRole}
          />
          <div className="flex">
            <div className={style.icon} onClick={onClickRole}>
              <TbEdit className="w-4 h-4" />
            </div>
            {editRole && (
              <div
                className={style.iconCheck}
                onClick={() => onSubmit(user, email, role)}
              >
                <IoCheckmarkDone className="w-4 h-4" />
              </div>
            )}
          </div>
        </div>
      </td>
      <td>
        <div className="flex items-center">
          <input
            ref={emailRef}
            className={style.inputEmail}
            onChange={onChangeEmail}
            defaultValue={user.email}
            readOnly={!editEmail}
          />
          <div className={style.icon} onClick={onClickEmail}>
            <TbEdit className="w-4 h-4" />
          </div>
          {editEmail && (
            <div
              className={style.iconCheck}
              onClick={() => onSubmit(user, email, role)}
            >
              <IoCheckmarkDone className="w-4 h-4" />
            </div>
          )}
        </div>
      </td>
      <td>{user.phone}</td>
      <ReactModal
        isOpen={isOpen}
        onRequestClose={() => setIsOpen(false)}
        className="mx-auto my-64 h-[25%] w-[25%] rounded-2xl border-4 border-gray-200 bg-white p-3 shadow-lg"
      >
        <div className="h-full w-full text-center">
          <div className="flex h-full flex-col justify-between">
            <TiUserDelete
              className="w-12 h-12 m-auto mt-4 text-indigo-500"
              size={50}
            />

            <p className="mt-4 text-xl font-bold text-gray-800">Remove User</p>

            <p className="px-6 py-2 text-xs text-gray-600">
              Are you sure you want to delete this user ?
            </p>
            <div className="mt-8 flex w-full items-center justify-between gap-4">
              <button
                onClick={() => onDelete(user.id)}
                type="button"
                className="w-[45%] rounded-lg bg-red-600 py-2 px-4 text-center text-base font-semibold text-white shadow-md transition duration-200 ease-in hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 focus:ring-offset-indigo-200"
              >
                Delete
              </button>
              <button
                onClick={
                  () => setIsOpen(false)
                }
                type="button"
                className="w-[45%] rounded-lg bg-gray-100 py-2 px-4 text-center text-base font-semibold text-red-500 shadow-md transition duration-200 ease-in hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 focus:ring-offset-indigo-200"
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      </ReactModal>

      <ReactModal
        isOpen={isEmailOpen}
        onRequestClose={() => setIsEmailOpen(false)}
        className="absolute flex items-center justify-center w-full h-full"
      >
        <div className="w-[30%] text-center rounded-2xl border-4 border-gray-200 bg-white p-3 shadow-lg">
          <div className="flex h-full flex-col justify-between">
            <TiUserDelete
              className="w-12 h-12 m-auto mt-4 text-indigo-500"
              size={50}
            />

            <p className="mt-4 text-xl font-bold text-gray-800">Email</p>

            <p className="px-6 py-2 text-xs text-gray-600">
              Send an email
            </p>
            <div className="text-sm space-y-3 flex flex-col w-full">
              <div>
                <input required className="border w-[70%] border-[#30D5C8] rounded-lg px-3 py-1 focus:outline-[#30D5C8]" placeholder="subject" name="subject" type="text" onChange={e => onChange(e)} />
              </div>
              <div className="w-full">
                <textarea required className="w-[80%] border border-[#30D5C8] rounded-lg px-3 py-1 focus:outline-[#30D5C8]" name="body" onChange={e => onChange(e)} />
              </div>
            </div>
            <div className="mt-8 flex w-full items-center justify-between gap-4">
              <button
                onClick={() => {
                  sendEmailtoUser(sendEmail)
                  setIsEmailOpen(false)
                }}
                type="button"
                class="w-[45%] rounded-lg bg-blue-500 py-2 px-4 text-center text-base font-semibold text-white shadow-md transition duration-200 ease-in hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 focus:ring-offset-indigo-200"
              >
                Send
              </button>
              <button
                onClick={
                  () => setIsEmailOpen(false)
                }
                type="button"
                className="w-[45%] rounded-lg bg-gray-100 py-2 px-4 text-center text-base font-semibold text-red-500 shadow-md transition duration-200 ease-in hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 focus:ring-offset-indigo-200"
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      </ReactModal>

      <td className="w-[150px]">
        <div className="flex space-x-3">
          <div
            className={`${style.action}  hover:bg-red-500`}
            onClick={(e) => handleDelete(e)}
          >
            <MdDelete className="p-1 w-8 h-8" />
          </div>
          <div className={`${style.action}  hover:bg-blue-500`} onClick={(e) => setIsEmailOpen(true)}>
            <MdMarkEmailUnread className="p-1 w-8 h-8" />
          </div>
        </div>
      </td>
    </tr>
  );
};

export default UserCard;
