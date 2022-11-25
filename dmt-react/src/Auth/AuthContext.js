import React, { useContext, useState } from 'react'
import { AxiosInstance } from './AxiosInstance'

const AuthContext = React.createContext()

export const useAuth = () => {
    return useContext(AuthContext)
}

export const AuthProvider = ({ children }) => {

    const [currentUser, setCurrentUser] = useState(null)
    const axios = AxiosInstance
    const controller = new AbortController();

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
                signal: controller.signal,
                headers: {
                    "Content-type": "application/json"
                }
            })
            const data = response.data
            //controller.abort()
            if (data && data.accessToken !== null) {
                return data
            }
            return { "message": "Incorrect email or password" }

        } catch (error) {
            //controller.abort()
            return { "message": "Login failed" }
        }
    }

    const value = {
        currentUser,
        register,
        login
    }

    return (
        <AuthContext.Provider value={value}>
            {children}
        </AuthContext.Provider>
    )
}