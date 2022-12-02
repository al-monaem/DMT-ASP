import React, { useState } from 'react'
import { useAuth } from '../../Auth/AuthContext'
import { CgMenuGridO } from "react-icons/cg"
import { TbDotsVertical } from "react-icons/tb"

const MapToolkit = ({ onChangeDestination, onChangePickup }) => {

    const { stations } = useAuth()
    const [showToolkit, setShowToolkit] = useState(false)

    const [destinationStations, setDestinationStations] = useState(stations)
    const [pickupStations, setPickupStations] = useState(stations)

    const style = {
        container: `relative ${showToolkit ? "bg-[#30D5C8] p-2 rounded-lg shadow-lg" : ""} flex flex-col`,
        icon: `ml-auto p-2 rounded-full bg-[#30D5C8] text-white shadow-lg hover:cursor-pointer`,
        toottipContainer: 'bg-[#30D5C8] mt-2 pb-3 px-2 flex flex-col',
        tooltipBlock: 'flex flex-col space-y-2 text-sm',
        select: 'w-[200px] p-1 px-3 rounded-lg focus:outline-[#30D5C8] focus:outline'
    }

    return (
        <div className={style.container}>
            <div
                className={style.icon}
                onClick={() => setShowToolkit(!showToolkit)}>
                <CgMenuGridO className='h-6 w-6' />
            </div>
            {showToolkit &&
                <div className={style.toottipContainer}>
                    <div className={style.tooltipBlock}>
                        <label className='text-white font-semibold ml-1'>Destination Station</label>
                        <select id='destination' onChange={onChangeDestination} className={style.select}>
                            <option value="" disabled selected hidden>Where To?</option>
                            {stations.map((station) => <option>{station.id}</option>)}
                        </select>
                    </div>
                    <div className={`mt-3 mb-2 text-white`}>
                        <TbDotsVertical className='w-6 h-6' />
                    </div>
                    <div className={style.tooltipBlock}>
                        <label className='text-white font-semibold ml-1'>Pickup Station</label>
                        <select id='pickup' onChange={onChangePickup} className={style.select}>
                            <option value="" disabled selected hidden>Pickup location...</option>
                            {stations.map((station) => <option>{station.id}</option>)}
                        </select>
                    </div>
                </div>}
        </div>
    )
}

export default MapToolkit