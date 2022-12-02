import React, { useState } from 'react'
import MenuLink from './MenuLink'
import { RiDashboardFill } from 'react-icons/ri'
import { IoTicketSharp, IoSettingsSharp } from 'react-icons/io5'
import { FaStore, FaUsers } from 'react-icons/fa'
import { BiLogOut } from 'react-icons/bi'
import { AiOutlineTransaction } from 'react-icons/ai'
import { useAuth } from '../../../Auth/AuthContext'

const SidebarLinks = () => {

    const animateFrom = { x: -500 };
    const animateTo = { x: 0 }

    const [loading, setLoading] = useState(false)
    const { logout } = useAuth()

    const onLogout = (e) => {
        e.preventDefault()
        setLoading(true)
        logout()
        setLoading(false)
    }
    const onClick = e => { return };

    return (
        <div className='space-y-2 w-full'>
            <MenuLink
                onClick={onClick}
                text="Dashboard"
                path="/"
                icon={<RiDashboardFill className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.1} />

            <MenuLink
                onClick={onClick}
                text="Store"
                path="/store"
                icon={<FaStore className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.2} />
            <MenuLink
                onClick={onClick}
                text="My Tickets"
                path="/myTickets"
                icon={<IoTicketSharp className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.3} />
            <MenuLink
                onClick={onClick}
                text="Settings"
                path="/settings"
                icon={<IoSettingsSharp className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.4} />
            <div className='space-y-2'>
                <MenuLink
                    onClick={onClick}
                    text="Users"
                    path="/admin/users"
                    icon={<FaUsers className='w-4 h-4' />}
                    animateFrom={animateFrom}
                    animateTo={animateTo}
                    transitionDuration={0.4} />
                <MenuLink
                    onClick={onClick}
                    text="Transactions"
                    path="/admin/transactions"
                    icon={<AiOutlineTransaction className='w-4 h-4' />}
                    animateFrom={animateFrom}
                    animateTo={animateTo}
                    transitionDuration={0.4} />
            </div>
            <MenuLink
                text="Logout"
                path="/logout"
                icon={<BiLogOut className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.5}
                onClick={onLogout} />
        </div>
    )
}

export default SidebarLinks