import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import Ticket from "../Ticket";

const style = {
    table: "table-auto h-full w-[70%] text-gray-700 divide-y border text-center",
    btn: "bg-sky-500 text-white font-semibold rounded-lg px-5 py-2",
    container: "w-full flex items-center justify-center mt-10"
}

const BuyTicket = () => {

    useEffect(() => {
        //getList();
    }, []);

    const [Records, setRecords] = useState([]);
    const [Stations, setStations] = useState([]);

    async function getList() {
        const raw = await fetch("http://127.0.0.1:8000/api/buyTicket", {
            headers: {
                method: 'post',
            }
        });
        const data = await raw.json();
        //console.log(data.records);

        setRecords(data.records);
        setStations(data.stations);
    }

    return (
        <div>
            <Ticket />
        </div>
    )
}

export default BuyTicket