import SidebarLinks from './SidebarLinks'
import SidebarAD from './SidebarAD/SidebarAD'

const Sidebar = () => {

    return (
        <div className='flex flex-col h-full'>
            <div className="p-5">
                <SidebarLinks />
            </div>
            <div className='mt-auto mb-10 py-2 mx-3 shadow-lg rounded-lg bg-[#30D5C8]'>
                <SidebarAD size={{ h: "h-24", w: "w-full" }} />
            </div>
        </div>
    )
}

export default Sidebar