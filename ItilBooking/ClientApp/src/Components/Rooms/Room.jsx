import { Card } from "antd";
import { useState } from "react";

const Room = ({ item }) => {

    return (
        <Card title={"Информация о номере"} style={{ width: 500, margin: "auto" , display : "inline-block"}}>
            <p>Номер: {item?.number}</p>
            <p>Этаж: {item?.level}</p>
            <p>Категория: {item?.category}</p>
            <p>Площадь: {item?.area}</p>
            <p>Цена: {item?.price}</p>
            {console.log(item)}
        </Card>
    );
}

export default Room;