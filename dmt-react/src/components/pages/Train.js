import React, { useEffect, useState } from 'react'
import io from "socket.io-client"
import Loader from '../common/Loader'

const Train = () => {

    const socket = io.connect("https://192.168.0.104:3001")

    let coords = {
        lat: null,
        lng: null
    }
    const [location, setLocation] = useState(coords)

    const [loaded, setLoaded] = useState(false)
    const [error, setError] = useState("")

    useEffect(() => {
        const interval = setInterval(() => {
            if (coords.lat && coords.lng)
                setLoaded(true)
            //console.log('This will run every second!');
            navigator.geolocation.getCurrentPosition(function (position) {
                //console.log(position)
                coords.lat = position.coords.latitude
                coords.lng = position.coords.longitude
                socket.emit("send", coords)
            }, showError);

            setLocation(coords)
        }, 1000);
        return () => clearInterval(interval);
    }, []);

    function showError(error) {
        switch (error.code) {
            case error.PERMISSION_DENIED:
                setError("User denied the request for Geolocation.")
                console.log("asd")
                break;
            case error.POSITION_UNAVAILABLE:
                setError("Location information is unavailable.")
                break;
            case error.TIMEOUT:
                setError("The request to get user location timed out.")
                break;
            case error.UNKNOWN_ERROR:
                setError("An unknown error occurred.")
                break;
        }
    }

    return error ? <div>{error}</div> : <div>{location.lat} {location.lng}</div>
}

export default Train