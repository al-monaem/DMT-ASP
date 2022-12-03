import React from 'react'

const MyTicket = ({ id }) => {
    return (
        <div className='flex w-full flex-col items-center bg-[#DEE8FD] rounded-lg shadow-lg'>
            <div className='bg-[#30D5C8] rounded-b-lg py-2 px-4 font-semibold text-white text-sm'>tck-2314897561</div>
            <div className='flex flex-col items-center'>
                <div className='p-5'>
                    <img className='h-52' src='images/QR.png' />
                </div>
                <div className='space-x-3 pb-5 flex text-xs font-semibold'>
                    <div>
                        <p>Price: 250 BDT</p>
                        <p>Purchased at: 2022-11-02</p>
                    </div>
                    <div>
                        <p>Pickup: Mirpur-10</p>
                        <p>Destination: Mirpur-12</p>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default MyTicket