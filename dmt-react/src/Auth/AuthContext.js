import React, { useContext, useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { AxiosInstance, InitializeToken } from './AxiosInstance'

const AuthContext = React.createContext()

export const useAuth = () => {
    return useContext(AuthContext)
}

export const AuthProvider = ({ children }) => {

    const axios = AxiosInstance

    const [currentUser, setCurrentUser] = useState(null)
    const [accessToken, setAccessToken] = useState("")
    const [stations, setStations] = useState(null)
    const [mode, setMode] = useState(0)
    const navigate = useNavigate()

    const onChangeMode = (mode) => {
        setMode(mode)
    }

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
        debugger
        try {
            const response = await axios.get(`api/transactions/${currentUser.id}`)
            const data = await response.data
            return data
        } catch (error) {
            return null
        }
    }

    const getTransactions = async () => {
        try {
            const response = await axios.get('api/transactions')
            const data = await response.data
            return data
        } catch (error) {
            return null
        }
    }

    const updateUser = async (user) => {
        console.log(user)
        try {
            const response = await axios.post(`api/update`, user)
            const data = await response.data
            debugger
            return data.message
        } catch (error) {
            console.log("station data error")
            return null
        }
    }

    const getUsers = async () => {
        try {
            debugger
            const response = await axios.get(`api/admin/users`)
            const data = await response.data
            return data
        } catch (error) {
            console.log("station data error")
            return null
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
        console.log(user)
        debugger
        try {
            const response = await axios.post("api/login", user, {
                "content-type": "application/json"
            })
            const data = await response.data
            debugger
            if (data && data.accessToken !== null) {
                setAccessToken(data.accessToken)
                setCurrentUser(data.User)

                if (data.User) {
                    localStorage.setItem('user', JSON.stringify(data.User))
                    localStorage.setItem('accessToken', data.accessToken)
                    navigate("/")
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
            const response = await axios.post("api/logout")
            setCurrentUser(null)
            setAccessToken("")
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
        stations,
        getUsers,
        updateUser,
        getTransactions,
        onChangeMode,
        mode
    }

    return (
        <AuthContext.Provider value={value}>
            {children}
        </AuthContext.Provider>
    )
}