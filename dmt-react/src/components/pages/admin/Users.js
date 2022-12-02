import React from 'react'
import UserCard from '../../common/UserCard'
import { HiChevronUpDown } from 'react-icons/hi2'
import SearchBar from '../../common/SearchBar'

const Users = () => {

    const user = {
        id: "Bish0p",
        profilePic: "/images/dummyProfile.jpg",
        role: "admin",
        email: "shanto45777@gmail.com",
        phone: "01875609450",
    }

    return (
        <div className='px-8 py-5 w-full h-full absolute flex flex-col items-center justify-center'>
            <div className='mb-3 w-full'>
                <SearchBar />
            </div>
            <div className='relative w-full h-full'>
                <div className='relative h-full flex w-full overflow-y-auto'>
                    <table className='absolute w-full h-full border-collapse'>
                        <thead className='sticky top-0 bg-white'>
                            <tr className='text-gray-400 h-12 text-left'>
                                <th className='pl-2'><div className='flex items-center'><p>Name</p><HiChevronUpDown /></div></th>
                                <th><div className='flex items-center'><p>Role</p><HiChevronUpDown /></div></th>
                                <th>Email</th>
                                <th>Contact</th>
                                <th><div className='flex items-center'><p>Actions</p></div></th>
                            </tr>
                        </thead>
                        <tbody className='w-full h-full'>
                            <UserCard user={user} />
                            <UserCard user={user} />
                            <UserCard user={user} />
                            <UserCard user={user} />
                            <UserCard user={user} />
                            <UserCard user={user} />
                            <UserCard user={user} />
                            <UserCard user={user} />
                            <UserCard user={user} />
                            <UserCard user={user} />
                            <UserCard user={user} />
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    )
}

export default Users