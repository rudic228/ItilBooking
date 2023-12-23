import React, { useState, useEffect } from 'react';
import { Routes, Route, useParams } from 'react-router-dom';
import { Card } from 'antd';

const Details = ({ }) => {
    let { roomId } = useParams();

    const [item, setItem] = useState({});

    return (
        <Card title={"Link info"} style={{ width: 500, margin: "auto" }}>
            <p>Link: {item?.longLink}</p>
            <p>Short link: {item?.shortLink}</p>
            <p>Created by: {item?.createdBy}</p>
            <p>Date created: {item?.createdDate}</p>
            {console.log(item)}
        </Card>
    );
}

export default Details;