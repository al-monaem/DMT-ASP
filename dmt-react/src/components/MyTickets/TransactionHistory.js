import React, { useEffect, useState } from 'react'
import FilterBox from '../common/FilterBox'
import Transaction from '../common/Transaction'

const TransactionHistory = ({ tickets }) => {
    const [tExpanded, setExpanded] = useState(0);

    const onClick = (index) => {
        //console.log(e)
        setExpanded(index)
    }

    useEffect(() => {

    })

    return (
        <div className='flex w-full h-full px-3 py-6'>
            <div className='w-[25%]'>
                <FilterBox />
            </div>
            <div className='relative ml-auto w-[50%] mr-5'>
                <div className='absolute space-y-5 h-full overflow-y-auto w-full pr-2'>
                    {tickets.map((ticket, index) => {
                        return <Transaction key={index} ticket={ticket} onClick={onClick} index={index} expanded={tExpanded === index ? true : false} />
                    })}
                </div>
            </div>
        </div>
    )
}

export default TransactionHistory