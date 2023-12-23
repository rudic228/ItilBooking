import { useEffect, useState } from "react";
import Room from "../Rooms/Room";
import api from "../../api/api";
import { Button, Input, Select } from "antd";
import { Option } from "antd/es/mentions";

const RoomList = ({ }) => {
    const [rooms, setArray] = useState([]);
    const [item, setItem] = useState({});
    const [beginDate, setBeginDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [level, setLevel] = useState('');
    const [numberOfBeds, setnumberOfBeds] = useState('');
    const [roomCategory, setRoomCategory] = useState('');


    useEffect(() => {
        console.log("sas");
        api.get("/Rooms").then(res => {
            setArray(res.data);
            console.log(res.data);
        });
    }, []);

    return (
        <div>
        <table style={{ width: 1200, margin: "20px auto" }}>
            <tr>
                <td>
                    <label htmlFor="beginDate">Дата начала</label><br/>
                    <Input
                        style={{display:'inline-block'}}
                        type="date"
                        name = "beginDate"
                        onChange={(e) => { setBeginDate(e.target.value) }} />
                </td>

                <td>
                    <label htmlFor="endDate">Дата конца</label><br/>
                    <Input
                        style={{display:'inline-block'}}
                        type="date"
                        name = "endDate"
                        onChange={(e) => { setEndDate(e.target.value) }} />
                </td>

                <td>
                    <label htmlFor="level">Этаж</label><br/>
                    <Input
                        style={{display:'inline-block', maxWidth:'150px'}}
                        type="number"
                        name = "level"
                        onChange={(e) => { setLevel(e.target.value) }} />
                </td>

                <td>
                    <label htmlFor="numberOfBeds">Количество мест</label><br/>
                    <Input
                        style={{display:'inline-block', maxWidth:'150px'}}
                        type="number"
                        name = "numberOfBeds"
                        onChange={(e) => { setnumberOfBeds(e.target.value) }} />
                </td>
                
                <td>
                    <label htmlFor="numberOfBeds">Категория номера</label><br/>
                    <Select 
                        style={{minWidth:'150px', display:'inline-block'}}
                        name="roomCategory"
                        value={roomCategory}
                        onChange={(e) => {setRoomCategory(e) }}>
                        <Option value="Suite" key="Suite">Сьют</Option>
                        <Option value="Apartment" key="Apartment">Апартаменты</Option>
                        <Option value="Lux" key="Lux" selected>Люкс</Option>
                        <Option value="JuniorSuite" key="JuniorSuite">Полулюкс</Option>
                        <Option value="Studio" key="Studio">Студия</Option>
                    </Select>
                </td>
                
                <Button style={{marginTop:'20px'}} type="primary"
                    onClick={() => {
                        api.get(`/Rooms?BeginDate=${beginDate}&EndDate=${endDate}&Level=${level}&NumberOfBeds=${numberOfBeds}&RoomCategory=${roomCategory}`)
                        .then((res) => {setArray(res.data); }).catch((error) => { console.log(error.response.data) });
                    }}>Поиск</Button>
            </tr>
            
        </table>
        {rooms.map(el => (
            <Room key = {item.id} item = {el}/>
        ))}
        </div>
        
    );
}

export default RoomList;