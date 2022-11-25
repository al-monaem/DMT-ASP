import React, { useEffect } from 'react'
import { AxiosInstance, setToken } from '../../Auth/AxiosInstance'
import Map from '../Dashboard/Map'
import MapToolkit from '../Dashboard/MapToolkit'

const Dashboard = () => {

    // useEffect(() => {

    //     const axios = AxiosInstance;
    //     setToken("3124asviujghqe1")

    //     const bodyParameters = {
    //         key: "value"
    //     };


    //     axios.post("/api/post", {
    //     }).then((result) => {
    //         console.log(result.data)
    //     }).catch((err) => {

    //     });

    // }, [])

    return (
        <div className='w-full h-full relative'>
            <div className='flex p-5 w-full h-full justify-center'>
                <Map />
            </div>
            <div className='absolute z-50'>
                <MapToolkit />
            </div>
        </div>
    )
}

export default Dashboard