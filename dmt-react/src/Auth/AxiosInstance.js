import axios from 'axios'

export const AxiosInstance = axios.create({
    baseURL: 'https://localhost:44361/'
});

export const InitializeToken = () => {
    //const auth = `Bearer ${token}`;
    AxiosInstance.defaults.headers.common = { Authorization: `${localStorage.getItem('accessToken')}`, "Content-type": "application/json" }
};