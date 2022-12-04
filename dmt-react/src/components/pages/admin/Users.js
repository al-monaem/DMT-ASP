import React, { useEffect, useState } from 'react'
import UserCard from '../../common/UserCard'
import { HiChevronUpDown } from 'react-icons/hi2'
import SearchBar from '../../common/SearchBar'
import { useAuth } from '../../../Auth/AuthContext'
import Loader from "../../common/Loader"

const Users = () => {

    const [user, setUser] = useState(null)
    const [users, setUsers] = useState(null)
    const [loading, setLoading] = useState(true)

    const { getUsers, updateUser } = useAuth()

    const style = {
        container: 'px-8 py-5 w-full h-full absolute flex flex-col items-center justify-center',
        tableContainer: 'relative h-full flex w-full overflow-y-auto',
        table: 'absolute w-full border-collapse',

    }

    const onSubmit = (id, email, role) => {
        //console.log(id, email, role)
        setUser(null)
        users.map((u) => {
            if (u.id === id) {
                setUser({ ...u, role: role, email: email })
            }
        })
    }

    const loadUsers = async () => {
        const data = await getUsers()
        setUsers(data)
        setLoading(false)
    }
    const loadUsersOnUserChange = async (user) => {
        setLoading(true)
        const data = await updateUser(user)
        await loadUsers()
        setLoading(false)
    }

    useEffect(() => {
        if (user) {
            loadUsersOnUserChange(user)
        }
    }, [user])

    useEffect(() => {
        loadUsers()
    }, [])

    return (
        !loading ?
            <div className={style.container}>
                <div className='mb-3 w-full'>
                    <SearchBar />
                </div>
                <div className='w-full h-full'>
                    <div className={style.tableContainer}>
                        <table className={style.table}>
                            <thead className='sticky top-0 bg-white'>
                                <tr className='text-gray-400 h-12 text-left'>
                                    <th className='pl-2'><div className='flex items-center'><p>Name</p><HiChevronUpDown /></div></th>
                                    <th><div className='flex items-center'><p>Role</p><HiChevronUpDown /></div></th>
                                    <th>Email</th>
                                    <th>Contact</th>
                                    <th><div className='flex items-center'><p>Actions</p></div></th>
                                </tr>
                            </thead>
                            <tbody className='w-full'>
                                {users && users.map((user) => {
                                    return <UserCard key={user.id} user={user} onSubmit={onSubmit} />
                                })}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div> : <Loader />
    )
}

export default Users