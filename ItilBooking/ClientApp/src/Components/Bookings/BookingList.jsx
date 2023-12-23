import { useEffect, useState } from "react";
import api from "../../api/api";
import Booking from "../Bookings/Booking";

const BookingList = ({ }) => {
    const [rooms, setArray] = useState([]);
    const [item, setItem] = useState({});

    useEffect(() => {
        console.log("sas");
        api.get("/Bookings").then(res => {
            setArray(res.data);
            console.log(res.data);
        });
    }, []);

    return (
        rooms.map(el => (
            <Booking key = {item.id} item = {el}/>
        ))
    );
}

export default BookingList;