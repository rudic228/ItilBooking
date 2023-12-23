import { useState } from "react";
import { Card, Button} from "antd";
import api from "../../api/api";
import store from "../../data/Store";
import { useNavigate } from 'react-router-dom';


const isAuthorized = store.getState()?.AuthorizationReducer?.isAuthorized;

const Booking = ({ item }) => {
    let navigate = useNavigate();
    return (
        <Card title={"Информация о бронировании"} style={{ width: 500, margin: "auto" , display : "inline-block"}}>
            <p>C: {item?.beginBookingDate} по {item?.endBookingDate}</p>
            <p>Номер: {item?.roomNumber}</p>
            <p>Категория: {item?.category}</p>
            <p>Цена за сутки: {item?.roomPrice}</p>
            <h4>Итоговая стоимость : {item?.price}</h4>
            <Button
                onClick={() => {
                    if(!isAuthorized){
                        navigate('/login')
                    }

                    api.delete(`/bookings/${item.id}`).then((res) => { navigate('/bookings') })
                    .catch((error) => { console.log(error); });
                      
                }}
            >Отменить бронирование</Button>
        </Card>
    );
}

export default Booking;