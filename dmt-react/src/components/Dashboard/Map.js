import { GoogleMap, useJsApiLoader, MarkerF, DirectionsRenderer } from "@react-google-maps/api"
import Details from "./Details"
import Loader from "../common/Loader"
import { useCallback, useEffect, useState } from "react";

const GMap = ({ stations, destination, pickup }) => {

    const center = {
        lat: stations[0].latitude,
        lng: stations[0].longitude
    };
    const [map, setMap] = useState(null)

    const directionsService = new window.google.maps.DirectionsService();
    //const directionsRenderer = new window.google.maps.DirectionsRenderer();
    let directions;

    const onLoad = useCallback(function callback(map) {
        setMap(map)
    }, [])

    useEffect(e => {
        if (destination && pickup) {
            directionsService.route(
                {
                    origin: pickup,
                    destination: destination,
                    travelMode: window.google.maps.TravelMode.DRIVING
                },
                (result, status) => {
                    if (status === window.google.maps.DirectionsStatus.OK) {
                        this.setState({
                            directions: result
                        });
                    } else {
                        console.error(`error fetching directions ${result}`);
                    }
                }
            );
        }
    }, [destination, pickup])

    const onUnmount = useCallback(function callback(map) {
        setMap(null)
    }, [])

    return <>
        <GoogleMap
            zoom={16}
            center={center}
            mapContainerClassName={"w-full h-full"}
            onLoad={onLoad}
            onUnmount={onUnmount}
            options={{
                disableDefaultUI: true, styles: [{
                    featureType: "poi", stylers: [
                        { visibility: "off" }
                    ]
                },
                {
                    featureType: "transit",
                    stylers: [{ "visibility": "off" }]
                },
                {
                    featureType: "administrative.neighborhood",
                    stylers: [{ "visibility": "off" }]
                },
                {
                    featureType: "road.local",
                    stylers: [{ "visibility": "off" }]
                }
                ]
            }}
        >
            {map && stations.map((data) => {
                return <MarkerF
                    icon={{
                        url: "https://cdn-icons-png.flaticon.com/512/8059/8059120.png",
                        scaledSize: new window.google.maps.Size(40, 40)
                    }}
                    position={{ lat: data.latitude, lng: data.longitude }}
                    title={data.id}
                />
            })}
            <DirectionsRenderer
                directions={directions}
            />
        </GoogleMap>
        <div className="flex items-center justify-center absolute bottom-0 z-50 mb-20 w-auto h-[8%]">
            <Details key={1} />
        </div>
    </>
}


const Map = ({ loaded, stations, destination, pickup }) => {

    const { isLoaded } = useJsApiLoader({
        id: "google-map-script",
        googleMapsApiKey: process.env.REACT_APP_GOOGLE_MAPS_API_KEY,
    });

    if (!isLoaded || !loaded) return <Loader />
    return <GMap stations={stations} destination={destination} pickup={pickup} />
}

export default Map