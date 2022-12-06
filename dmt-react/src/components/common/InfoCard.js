import React from 'react'

const InfoCard = ({ header, color, icon, value, bottomIcon }) => {
    return (
        <div className="font-semibold w-[250px] text-white space-y-10 rounded-2xl px-6 py-4 shadow-lg" style={{ backgroundColor: color }}>
            <div className='flex items-center space-x-2'>
                <div>{icon}</div>
                <p className=''>{header}</p>
            </div>
            <div className='flex items-center justify-end'><div>{value}</div><div>{bottomIcon}</div></div>
        </div>
    )
}

export default InfoCard