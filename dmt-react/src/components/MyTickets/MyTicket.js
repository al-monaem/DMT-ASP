import React from 'react'

const MyTicket = ({ id, ticket }) => {
    return (
        <div className='flex w-full flex-col items-center bg-[#DEE8FD] rounded-lg shadow-lg'>
            <div className='bg-[#30D5C8] rounded-b-lg py-2 px-4 font-semibold text-white text-sm'>{ticket.transaction_id}</div>
            <div className='flex flex-col items-center'>
                <div className='p-5'>
                    <img className='h-52' src='images/QR.png' />
                </div>
                <div className='space-x-3 pb-5 flex text-xs font-semibold'>
                    <div>
                        <p>Price: {ticket.Ticket.Route.price} BDT</p>
                        <p>Purchased at: {ticket.date.split("T")[0]}</p>
                    </div>
                    <div>
                        <p>Pickup: {ticket.Ticket.Route.station_1}</p>
                        <p>Destination: {ticket.Ticket.Route.station_2}</p>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default MyTicket