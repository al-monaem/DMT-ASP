import React, { useContext, useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { AxiosInstance, setToken } from './AxiosInstance'

const AuthContext = React.createContext()

export const useAuth = () => {
    return useContext(AuthContext)
}

export const AuthProvider = ({ children }) => {

    const axios = AxiosInstance

    const [currentUser, setCurrentUser] = useState(null)
    const [accessToken, setAccessToken] = useState("")
    const [stations, setStations] = useState([])
    const navigate = useNavigate()

    const setStationData = async e => {
        try {
            const response = await axios.get("api/stations", {
                headers: {
                    "Content-type": "application/json"
                }
            })
            const data = await response.data
            debugger
            if (data) {
                setStations(data)
                return true
            }
            return
        } catch (error) {
            console.log("station data error")
            return false
        }
    }

    const setCredentials = () => {
        setCurrentUser(JSON.parse(localStorage.getItem('user')))
        setAccessToken(localStorage.getItem('accessToken'))
    }

    const getTickets = async () => {
        try {
            const response = await axios.get(`api/tickets/${currentUser.id}`, {
                headers: {
                    "Content-type": "application/json"
                }
            })
            const data = await response.data
            return data
        } catch (error) {
            console.log("station data error")
            return []
        }
    }

    const register = async (data) => {
        try {
            const response = await axios.post("api/register", JSON.stringify(data), {
                headers: {
                    "Content-type": "application/json"
                }
            })
        } catch (error) {

        }
    }

    const login = async (user) => {
        debugger
        try {
            const response = await axios.post("api/login", JSON.stringify(user), {
                headers: {
                    "Content-type": "application/json"
                }
            })
            const data = await response.data
            //debugger
            if (data && data.accessToken !== null) {
                setAccessToken(data.accessToken)
                setCurrentUser(data.User)

                if (data.User) {
                    localStorage.setItem('user', JSON.stringify(data.User))
                    localStorage.setItem('accessToken', data.accessToken)
                    navigate("/", { replace: true })
                }

                return { "message": "Error in server" }
            }
            return { "message": "Invalid email or password" }
        } catch (error) {
            setAccessToken("")
            setCurrentUser("")
            return { "message": "Error communicating with server" }
        }
    }

    const logout = async () => {
        localStorage.removeItem('accessToken')
        localStorage.removeItem('user')
        try {
            setToken(accessToken)
            const response = await axios.post("api/logout")
        } catch (error) {

        }
        navigate("/login")
    }

    const value = {
        currentUser,
        accessToken,
        register,
        login,
        setCredentials,
        logout,
        setStationData,
        getTickets,
        stations
    }

    return (
        <AuthContext.Provider value={value}>
            {children}
        </AuthContext.Provider>
    )
}