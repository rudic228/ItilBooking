import { InfoCircleOutlined, UserOutlined } from '@ant-design/icons';
import { Button, Input, Tooltip } from 'antd';
import { test } from '../../data/actionCreators/LoginActions';
import api from "../../api/api";
import { useNavigate } from 'react-router-dom';
const About = () => {
    let navigate = useNavigate();
    return (
        <div style={{
            width: "500px",
            marginTop: "50px",
            margin: "auto",
        }}>
            <h2>
                Приложение разработал студент группы ИСЭбд-41 Миронов Евгений 
                <br />
                <br />
                <br />
                <br />Спасибо за внимание!!!
            </h2>
        </div >
    );
}

export default About;