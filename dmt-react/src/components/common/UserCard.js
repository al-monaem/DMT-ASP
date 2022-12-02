import { AiFillEdit } from 'react-icons/ai'
import { MdDelete, MdMarkEmailUnread } from 'react-icons/md'

const UserCard = ({ user }) => {

  const style = {
    container: 'w-full font-semibold text-sm border-y h-16',
  }

  return (
    <tr className={style.container}>
      <td><div className='flex items-center space-x-3'><img className='p-1 w-10 h-10 rounded-full' src={user.profilePic} /><p>{user.id}</p></div></td>
      <td>{user.role}</td>
      <td>{user.email}</td>
      <td>{user.phone}</td>
      <td className='w-[200px]'>
        <div className='flex space-x-3'>
          <div className='border rounded-md'>
            <AiFillEdit className='p-1 w-8 h-8' />
          </div>
          <div className='border rounded-md'>
            <MdDelete className='p-1 w-8 h-8' />
          </div>
          <div className='border rounded-md'>
            <MdMarkEmailUnread className='p-1 w-8 h-8' />
          </div>
        </div>
      </td>
    </tr>
  )
}

export default UserCard