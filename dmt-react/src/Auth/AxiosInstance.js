import axios from 'axios'

export const AxiosInstance = axios.create({
    baseURL: 'https://localhost:44361'
});

export const setToken = (token) => {
    const auth = `Bearer ${token}`;
    AxiosInstance.defaults.headers.common = { 'Authorization': `Bearer ${auth}` }
};