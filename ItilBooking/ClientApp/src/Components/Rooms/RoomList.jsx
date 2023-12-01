import { useEffect, useState } from "react";
import Room from "../Rooms/Room";
import api from "../../api/api";

const RoomList = ({ }) => {
    const [rooms, setArray] = useState([]);
    const [item, setItem] = useState({});

    useEffect(() => {
        console.log("sas");
        api.get("/Rooms").then(res => {
            setArray(res.data);
            console.log(res.data);
        });
    }, []);

    return (
        rooms.map(el => (
            <Room key = {item.id} item = {el}/>
        ))
    );
}

export default RoomList;