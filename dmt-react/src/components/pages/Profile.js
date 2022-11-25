import { useEffect, useRef, useState } from 'react'
import Cover from '../Profile/Cover'
import Bio from '../Profile/Bio'
import Security from '../Profile/Security'
import { motion } from "framer-motion"
import { FaUserEdit } from "react-icons/fa"
import LoaderAnim from "../common/LoaderAnim"

const Profile = () => {

    const [user, setUser] = useState(null);
    const [loaded, setLoaded] = useState(false);
    const [editable, setEditable] = useState(false);
    const [selected, setSelected] = useState(1);
    const [indicatorWidth, setIndicatorWidth] = useState(0);
    const [indicatorPosition, setIndicatorPosition] = useState(0);
    const [indicatorPrevPosition, setIndicatorPrevPosition] = useState(0);
    const offset = 12;

    const style = {
        indicator: `absolute bottom-0 bg-[#30D5C8] h-[2px]`,
        btn: `p-2 hover:bg-[#30D5C8] hover:text-white rounded-t-lg`,
        tabs: 'space-x-3 flex text-sm px-3 pt-2 border-b w-full relative',
        container: 'absolute flex flex-col h-full p-3 w-full',
        content_container: 'relative w-full h-full',
        content: 'absolute w-full h-full',
        edit: `ml-auto mr-8 p-2 rounded-lg hover:bg-[#1fccbe] hover:transition flex items-center bg-[#30D5C8] text-white font-semibold`
    }

    const ref1 = useRef(null);
    const ref2 = useRef(null);

    useEffect(() => {
        getUser();
    }, [])

    useEffect(() => {
        if (loaded) {
            if (selected === 1) {
                setIndicatorWidth(ref1.current.offsetWidth);
                setIndicatorPosition(ref1.current.offsetLeft - offset);
                setIndicatorPrevPosition(ref2.current.offsetLeft - offset);
            }
            if (selected === 2) {
                setIndicatorWidth(ref2.current.offsetWidth);
                setIndicatorPosition(ref2.current.offsetLeft - offset);
                setIndicatorPrevPosition(ref1.current.offsetLeft - offset);
            }
        }
    }, [selected]);

    async function getUser() {
        const user = await fetch("http://127.0.0.1:8000/api/getUser/Bishop");
        const userData = await user.json();
        //console.log(userData);
        setUser(userData);
        setLoaded(true);
    }

    const onTabClick = (index) => {
        setSelected(index);
    }

    const clickHandler = (e) => {
        const id = e.target.id;
        setEditable({ ...editable, [id]: !editable[id] });
        //e.parent.children[0].focus();
    }

    async function updateUser(e) {
        e.preventDefault();
        console.log(JSON.stringify(user));
        const post = await fetch(`http://127.0.0.1:8000/api/updateUser/${user.id}`, {
            method: "POST",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user),
        });

        const res = await post.json();
        console.log(res);
        setUser(res);
    }

    const onclick = () => {
        setEditable(true);
    }

    if (!loaded) return (<LoaderAnim />);
    return (
        <div className={style.container}>

            <div className=''>
                <Cover />
            </div>

            <div className={style.tabs}
                style={{ flex: "0 1 auto" }}>
                <motion.div
                    initial={{ x: indicatorPrevPosition }}
                    animate={{ x: indicatorPosition }}
                    transition={{ duration: 0.4 }}
                    className={style.indicator}
                    style={{ width: `${indicatorWidth}px` }}
                />
                <button
                    ref={ref1}
                    className={`${style.btn} ${selected === 1 ? "font-semibold" : ""}`}
                    onClick={() => onTabClick(1)}>
                    Personal Details
                </button>
                <button
                    ref={ref2}
                    className={`${style.btn} ${selected === 2 ? "font-semibold" : ""}`}
                    onClick={() => onTabClick(2)}>
                    Security & Privacy
                </button>
                <div className='flex-1 mb-1'>
                    <button
                        onClick={onclick}
                        className={style.edit}>
                        <FaUserEdit className='mr-2 h-5 w-5' />
                        Edit Profile
                    </button>
                </div>
            </div>

            <div className={style.content_container}>
                {selected === 1 &&
                    <div className={style.content}>
                        <Bio user={user} editable={editable} />
                    </div>}
                {selected === 2 &&
                    <div className={style.content} editable={editable}>
                        <Security />
                    </div>}
            </div>

        </div >
    )
}

export default Profile