import React from 'react'
import { Navigate, Outlet } from 'react-router-dom'
import { useAuth } from '../../Auth/AuthContext'
import Sidebar from "./Sidebar/Sidebar"
import Topbar from "./Topbar/Topbar"

const Layout = () => {

    const { currentUser } = useAuth()

    return (
        currentUser ? (<div className="flex w-screen divide-x max-h-screen h-screen ">

            <div className="w-[15%]">
                <Sidebar />
            </div>

            <div className="flex flex-col w-full h-screen">
                <div className="p-5 w-full border-b">
                    <Topbar />
                </div>
                <div className="relative h-full">
                    <Outlet />
                </div>
            </div>

        </div>) : <Navigate to="/login" />
    )
}

export default Layout