import { InfoCircleOutlined, UserOutlined } from '@ant-design/icons';
import { Routes, Route, useParams } from 'react-router-dom';
import { Button, Input, Tooltip } from 'antd';
import { useNavigate } from 'react-router-dom';
import { useEffect, useState } from "react";
import api from "../../api/api";

const CreateLink = () => {
    let { roomId } = useParams();
    const [link, setLink] = useState('');

    const Create = () => {
        api.post("/Bookings", { LongLink: link }).then(res => { navigate('*') }).catch((error) => { console.log(error) })
    };
    let navigate = useNavigate();

    const [room, setRoom] = useState({});

    useEffect(() => {
        console.log("sas");
        api.get(`/Rooms/${roomId}`).then(res => {
            setRoom(res.data);
            console.log(res.data);
        });
    }, []);

    return (
        <div style={{
            width: "500px",
            marginTop: "50px",
            margin: "auto",
        }}>
        </div >
    );
}

export default CreateLink;