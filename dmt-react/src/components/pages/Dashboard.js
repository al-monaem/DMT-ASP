import React, { useEffect, useState } from 'react'
import { useAuth } from '../../Auth/AuthContext'
import Map from '../Dashboard/Map'
import MapToolkit from '../Dashboard/MapToolkit'
import io from "socket.io-client"

const Dashboard = () => {

    const { setStationData } = useAuth()
    const [loaded, setLoaded] = useState(false)
    const { stations } = useAuth()

    const [destination, setDestination] = useState("")
    const [pickup, setPickup] = useState("")

    const [coords, setCoords] = useState()

    const load = async e => {
        const rs = await setStationData()
        setLoaded(rs)
    }

    const socket = io.connect("https://192.168.0.104:3001", { 'reconnection': false })

    socket.on("broadcast", (data) => {
        setCoords(data)
    })

    const onChangeDestination = e => {
        stations.map((station) => {
            if (station.id === e.target.value) {
                const d = { lat: station.latitude, lng: station.longitude }
                setDestination(d)
            }
        })
    }
    const onChangePickup = e => {
        stations.map((station) => {
            if (station.id === e.target.value) {
                const d = { lat: station.latitude, lng: station.longitude }
                setPickup(d)
            }
        })
    }

    useEffect((e => {
        load()

        return () => { socket.disconnect() }
    }), [])

    return (
        <div className='flex p-5 flex-col w-full h-full relative'>
            <div className='flex relative w-full h-full justify-center'>
                <Map coords={coords} loaded={loaded} stations={stations} destination={destination} pickup={pickup} />
            </div>
            <div className='absolute'>
                <MapToolkit onChangeDestination={onChangeDestination} onChangePickup={onChangePickup} />
            </div>
        </div>
    )
}

export default Dashboard