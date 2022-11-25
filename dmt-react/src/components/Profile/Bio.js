import React from 'react'
import { motion, AnimatePresence } from "framer-motion"

const Bio = ({ user, editable }) => {

    const style = {
        label: "font-semibold w-[10%]",
        details: 'flex space-x-40 w-full items-center',
        input: 'text-sm border py-2 px-4 rounded-lg w-[35%]',
        conatiner: 'absolute overflow-y-auto flex flex-col w-full space-y-10 p-8 h-full'
    }

    const onChange = () => {

    }

    return (
        <AnimatePresence>
            <motion.div
                key={"bio"}
                initial={{ x: 100, padding: "18px", opacity: 0 }}
                animate={{ x: 0, padding: "20px", opacity: 1 }}
                transition={{ duration: 0.4 }}
                exit={{ x: -100, opacity: 0 }}
                className={style.conatiner}>
                <div className={style.details}>
                    <label className={style.label}>ID</label>
                    <input type="text" className={style.input} defaultValue={user.id} readOnly={!editable} onChange={onChange} />
                </div>
                <div className={style.details}>
                    <label className={style.label}>Username</label>
                    <input type="text" className={style.input} defaultValue={user.name} readOnly={!editable} onChange={onChange} />
                </div>
                <div className={style.details}>
                    <label className={style.label}>Email</label>
                    <input type="email" className={style.input} defaultValue={user.email} readOnly={!editable} onChange={onChange} />
                </div>
                <div className={style.details}>
                    <label className={style.label}>Contact</label>
                    <input type="text" className={style.input} defaultValue={user.phone} readOnly={!editable} onChange={onChange} />
                </div>
                <div className={style.details}>
                    <label className={style.label}>NID</label>
                    <input type="text" className={style.input} defaultValue={user.nid} readOnly={!editable} onChange={onChange} />
                </div>
            </motion.div >
        </AnimatePresence>
    )
}

export default Bio