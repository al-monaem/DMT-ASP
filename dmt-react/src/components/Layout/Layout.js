import React from 'react'
import { Outlet } from 'react-router-dom'
import Sidebar from "./Sidebar/Sidebar"
import Topbar from "./Topbar/Topbar"

const Layout = () => {
    return (
        <div className="flex w-screen divide-x max-h-screen h-screen ">

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

        </div>
    )
}

export default Layout