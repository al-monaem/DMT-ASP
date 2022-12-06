import React, { useEffect, useState } from 'react'
import InfoCard from '../../common/InfoCard'
import { FaUsers } from "react-icons/fa"
import { TbCurrencyTaka } from "react-icons/tb"
import BarChart from '../../common/BarChart'
import { useAuth } from '../../../Auth/AuthContext'
import Loader from "../../common/Loader"

const AdminDashboard = () => {

    const style = {
        btn: 'rounded-lg px-4 py-1',

    }

    const [selected, setSelected] = useState(0);
    const [users, setUsers] = useState(null);
    const [transactions, setTransactions] = useState(null);
    const [loading, setLoading] = useState(true);
    const { getUsers, getTransactions } = useAuth();
    const [labels, setLabels] = useState({});

    const [userData, setUserData] = useState({});
    const [transactionData, setTransactionData] = useState([]);

    const loadData = async e => {
        const u = await getUsers();
        setUsers(u)
        //setUsers(u.sort((a, b) => a.registrationDate - b.registrationDate))

        const t = await getTransactions();
        setTransactions(t);
        setLoading(false)
    }

    const getLabel = (year, month) => {
        let str = "";
        switch (month) {
            case "01":
                str = "Jan"
                break
            case "02":
                str = "Feb"
                break
            case "03":
                str = "Mar"
                break
            case "04":
                str = "Apr"
                break
            case "05":
                str = "May"
                break
            case "06":
                str = "Jun"
                break
            case "07":
                str = "Jul"
                break
            case "08":
                str = "Aug"
                break
            case "09":
                str = "Sep"
                break
            case "10":
                str = "Oct"
                break
            case "11":
                str = "Nov"
                break
            case "12":
                str = "Dec"
                break
            default:
                break
        }
        str += `-${year.slice(-2)}`
        return str
    }

    const filterData = e => {

        let l = []
        let count = []

        let x = []

        users.map((u) => {
            let date = u.registrationDate
            let year = date.split("T")[0].split("-")[0]
            let month = date.split("T")[0].split("-")[1]
            let label = getLabel(year, month)

            if (l.includes(label)) {
                let index = l.indexOf(label)
                count[index] += 1
            }
            else {
                l.push(label)
                count.push(1)
            }
        })

        l.map((ll, index) => {
            x.push({ date: ll, count: count[index] })
        })
        x = x.sort((a, b) => {
            return new Date(a.date) - new Date(b.date);
        })

        setLabels(x)

        //console.log(x)
        l = []
        let c = []

        x.map((obj) => {
            l.push(obj.date)
            c.push(obj.count)
        })

        setUserData({
            labels: l,
            datasets: [{
                label: "Users Registered",
                data: c,
            }]
        })
    }

    useEffect(() => {
        if (users)
            filterData()

        console.log(userData)
    }, [users])

    useEffect(() => {
        loadData()
    }, [])

    return (
        loading && userData ? <Loader /> :
            <div className='flex flex-col'>
                <div className='flex items-center mx-20 mt-5 space-x-10'>
                    <div>
                        <InfoCard header={"User Count"} value={"10,365"} color={"#6071e4"} icon={<FaUsers />} />
                    </div>
                    <div>
                        <InfoCard header={"Transactions Made"} value={"50,654"} color={"#d69045"} icon={<FaUsers />} />
                    </div>
                    <div>
                        <InfoCard header={"Revenue Total"} value={`1,654,135`} bottomIcon={<TbCurrencyTaka />} color={"#30D5C8"} icon={<FaUsers />} />
                    </div>
                </div>
                <div className='p-3 w-full'>
                    <div className='w-full space-x-3 mt-5 ml-2'>
                        <button className={style.btn}>Users</button>
                        <button className={style.btn}>Transactions</button>
                        <button className={style.btn}>Revenue</button>
                    </div>
                    <div className='w-[50%]'>
                        <BarChart chartData={userData} />
                    </div>
                </div>
            </div>
    )
}

export default AdminDashboard