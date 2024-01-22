import { useState } from "react";
import { useNavigate } from 'react-router-dom';
import { Card, Button, Input, Select } from "antd";
import api from "../../api/api";
import store from "../../data/Store";


const Room = ({ item }) => {
    let navigate = useNavigate();
    const isAuthorized = store.getState()?.AuthorizationReducer?.isAuthorized;

    const [beginDate, setBeginDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [numberOfBeds, setnumberOfBeds] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    return (
        <Card title={"Информация о номере"} style={{ width: 500, margin: "auto" , display : "inline-block"}}>
            <img  src={require(`../../images/${item.number}.jpg`)} alt="some" style={{ width: 400, height:300}}/>
            <p>Номер: {item?.number}</p>
            <p>Этаж: {item?.level}</p>
            <p>Категория: {item?.category}</p>
            <p>Площадь: {item?.area}</p>
            <p>Количество мест: {item?.numberOfBeds}</p>
            <p>Цена: {item?.price}</p>
            <label htmlFor="beginDate">Дата начала</label><br/>
            <Input
                style={{display:'inline-block', width:'250px'}}
                type="date"
                name = "beginDate"
                onChange={(e) => { setBeginDate(e.target.value) }} /><br/>
            <label htmlFor="endDate">Дата конца</label><br/>
            <Input
                style={{display:'inline-block', width:'250px'}}
                type="date"
                name = "endDate"
                onChange={(e) => { setEndDate(e.target.value) }} /><br/>
            <label htmlFor="numberOfBeds">Количество мест</label><br/>
            <Input
                style={{display:'inline-block', width:'250px'}}
                type="number"
                name = "numberOfBeds"
                onChange={(e) => { setnumberOfBeds(e.target.value) }} /><br/><br/>
            <Button
                onClick={() => {
                    if(!isAuthorized){
                        navigate('/login')
                    }
                    console.log(numberOfBeds);
                    console.log(beginDate);
                    console.log(endDate);

                    if(numberOfBeds == 0){
                        setErrorMessage("Заполните количество мест")
                        return
                    }

                    if(beginDate == 0){
                        setErrorMessage("Заполните дату начала")
                        return
                    }

                    if(endDate == 0){
                        setErrorMessage("Заполните дату конца")
                        return
                    }

                    api.post('/bookings',
                        {BeginBookingDate : beginDate, EndBookingDate : endDate, NumberOfBeds : numberOfBeds, roomId : item.id}).then((res) => { navigate('/bookings') }).catch((error) => { console.log(error); setErrorMessage(error.response.data) });
                      
                }}
            >Забронировать</Button>
            {errorMessage && <div className="error" style={{ color: "red" }}> {errorMessage} </div>}
        </Card>
    );
}

export default Room;