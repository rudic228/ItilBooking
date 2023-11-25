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
            <label>
                This is Link Shortener app.
                <br />You can use it to create short version of your URL.
                <br />Login or Register to access the ability to create shortened links.
            </label>
            
            <Button type="primary" block onClick={() => {
                    api.get('/weatherforecast/test', {withCredentials: false}).then((res) => {alert("Внутри") ; navigate('/login') }).catch((error) => { console.log(error) });
                }} style={{ marginTop: "5px" }}>
                    TEST
                </Button>
        </div >
    );
}

export default About;