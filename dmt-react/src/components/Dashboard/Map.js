import { GoogleMap, useLoadScript, Marker, } from "@react-google-maps/api"
import Details from "./Details"
import LoaderAnim from "../common/LoaderAnim"

const GMap = () => {

    return (
        <>
            <GoogleMap
                zoom={16}
                center={{ lat: 23.81, lng: 90.41 }}
                mapContainerClassName={"w-full h-full"}
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

            </GoogleMap>
            <div className="flex items-center justify-center absolute bottom-0 z-50 mb-20 w-auto h-[8%]">
                <Details key={1} />
            </div>
        </>
    )

}


const Map = () => {
    const { isLoaded } = useLoadScript({
        googleMapsApiKey: process.env.REACT_APP_GOOGLE_MAPS_API_KEY,
    });

    if (!isLoaded) return <LoaderAnim />
    return <GMap />
}

export default Map