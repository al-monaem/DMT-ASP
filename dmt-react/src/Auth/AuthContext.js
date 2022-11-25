import React, { useContext, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { AxiosInstance } from './AxiosInstance'

const AuthContext = React.createContext()

export const useAuth = () => {
    return useContext(AuthContext)
}

export const AuthProvider = ({ children }) => {

    const [currentUser, setCurrentUser] = useState(null)
    const [accessToken, setAccessToken] = useState("")
    const navigate = useNavigate()

    const axios = AxiosInstance

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
        try {
            const response = await axios.post("api/login", JSON.stringify(user), {
                headers: {
                    "Content-type": "application/json"
                }
            })
            const data = response.data
            //debugger
            if (data && data.accessToken !== null) {
                setAccessToken(data.accessToken)
                setCurrentUser(data.User)
                //debugger
                if (currentUser !== null && currentUser !== undefined) {
                    //debugger
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

    const value = {
        currentUser,
        accessToken,
        register,
        login
    }

    return (
        <AuthContext.Provider value={value}>
            {children}
        </AuthContext.Provider>
    )
}