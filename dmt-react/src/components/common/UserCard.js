import { TbEdit } from 'react-icons/tb'
import { MdDelete, MdMarkEmailUnread } from 'react-icons/md'
import { useEffect, useRef, useState } from 'react'
import { IoCheckmarkDone } from "react-icons/io5"

const UserCard = ({ user, onSubmit }) => {

  const [editEmail, setEditEmail] = useState(false)
  const [editRole, setEditRole] = useState(false)
  const [email, setEmail] = useState()
  const [role, setRole] = useState()

  const emailRef = useRef()
  const roleRef = useRef()

  const style = {
    container: 'w-full font-semibold text-sm border-y h-16',
    icon: 'ml-2 text-gray-400 p-1 rounded-lg hover:bg-gray-400 hover:text-white hover:transition hover:cursor-pointer',
    iconCheck: 'ml-2 text-gray-400 p-1 rounded-lg hover:bg-[#30D5C8] hover:text-white hover:transition hover:cursor-pointer',
    inputEmail: `${!editEmail ? "hover:cursor-default" : ""} p-2 focus:outline-[#30D5C8] rounded-md`,
    inputRole: `${!editRole ? "hover:cursor-default" : ""} p-2 focus:outline-[#30D5C8] w-14 rounded-md`,
    image: 'p-1 w-10 h-10 rounded-full',
    name: 'flex items-center space-x-3',

  }

  const onClickEmail = (e) => {
    setEditEmail(true)
    emailRef.current.focus()
  }
  const onClickRole = e => {
    setEditRole(true)
    roleRef.current.focus()
  }
  const onChangeEmail = (e) => {
    setEmail(e.target.value)
  }
  const onChangeRole = (e) => {
    setRole(e.target.value)
  }

  useEffect(() => {
    setEmail(user.email)
    setRole(user.role)
  }, [])

  return (
    <tr className={style.container}>
      <td><div className={style.name}><img className={style.image} src={user.profilePic} /><p>{user.id}</p></div></td>

      <td>
        <div className='flex items-center'>
          <input ref={roleRef} className={style.inputRole} onChange={onChangeRole} defaultValue={user.role} readOnly={!editRole} />
          <div className='flex'>
            <div className={style.icon} onClick={onClickRole}>
              <TbEdit className='w-4 h-4' />
            </div>
            {editRole &&
              <div className={style.iconCheck} onClick={() => onSubmit(user.id, email, role)}>
                <IoCheckmarkDone className='w-4 h-4' />
              </div>}
          </div>
        </div>
      </td>

      <td>
        <div className='flex items-center'>
          <input ref={emailRef} className={style.inputEmail} onChange={onChangeEmail} defaultValue={user.email} readOnly={!editEmail} />
          <div className={style.icon} onClick={onClickEmail}>
            <TbEdit className='w-4 h-4' />
          </div>
          {editEmail &&
            <div className={style.iconCheck} onClick={() => onSubmit(user.id, email, role)}>
              <IoCheckmarkDone className='w-4 h-4' />
            </div>}
        </div>
      </td>

      <td>{user.phone}</td>

      <td className='w-[150px]'>
        <div className='flex space-x-3'>
          <div className='border rounded-md'>
            <MdDelete className='p-1 w-8 h-8 text-[#30D5C8]' />
          </div>
          <div className='border rounded-md'>
            <MdMarkEmailUnread className='p-1 w-8 h-8 text-[#30D5C8]' />
          </div>
        </div>
      </td>
    </tr>
  )
}

export default UserCard