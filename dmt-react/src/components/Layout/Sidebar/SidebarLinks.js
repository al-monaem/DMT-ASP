import React, { useEffect, useState } from 'react'
import MenuLink from './MenuLink'
import { RiDashboardFill } from 'react-icons/ri'
import { IoTicketSharp, IoSettingsSharp } from 'react-icons/io5'
import { FaStore } from 'react-icons/fa'
import { BiLogOut } from 'react-icons/bi'

const SidebarLinks = () => {

    const [rendered, setRendered] = useState(false);
    let renderAnimation = false;

    useEffect(() => setRendered(true), []);

    const animateFrom = { x: -500 };
    const animateTo = { x: 0 }

    return (
        <div className='space-y-2 w-full'>
            <MenuLink
                text="Dashboard"
                path="/"
                icon={<RiDashboardFill className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.1} />

            <MenuLink
                text="Store"
                path="/store"
                icon={<FaStore className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.2} />
            <MenuLink
                text="My Tickets"
                path="/myTickets"
                icon={<IoTicketSharp className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.3} />
            <MenuLink
                text="Settings"
                path="/settings"
                icon={<IoSettingsSharp className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.4} />
            <MenuLink
                text="Logout"
                path="/logout"
                icon={<BiLogOut className='w-4 h-4' />}
                animateFrom={animateFrom}
                animateTo={animateTo}
                transitionDuration={0.5} />
        </div>
    )
}

export default SidebarLinks