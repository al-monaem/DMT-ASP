import { AiOutlineSearch } from 'react-icons/ai'

const SearchBar = () => {

    const style = {
        container: 'flex w-full p-4 bg-[#f6f5f8] rounded-md justify-between',
        block: 'w-[35%] flex relative items-center',
        btn: 'bg-[#30D5C8] rounded-lg font-semibold mr-14 text-white px-10 flex items-center',
        input: 'w-full focus:outline-[#30D5C8] focus:outline focus:outline-2 font-semibold bg-white rounded-md text-sm py-3 pl-8 pr-5'
    }

    return (
        <div className={style.container}>
            <div className={style.block}>
                <div className='absolute ml-2'><AiOutlineSearch className='text-gray-400 w-5 h-5' /></div>
                <input className={style.input} type='text' placeholder='Search' />
            </div>
            <div className={style.block}>
                <select className={style.input}>
                    <option selected>User/Admin</option>
                    <option>User</option>
                    <option>Admin</option>
                </select>
            </div>
            <div className={style.btn}>
                <button>Search</button>
            </div>
        </div>
    )
}

export default SearchBar