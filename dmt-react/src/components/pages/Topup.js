import { useState } from "react";
import { TbDiscount2 } from "react-icons/tb";
import { GiWallet } from "react-icons/gi";

/* <LoaderAnim />*/

const Topup = () => {
  const style = {
    container:
      "container flex flex-col w-full justify-center items-center pt-2",
  };
  return (
    <div class="px-4 pt-8">
      <div class="flex flex-wrap justify-evenly">
        <div class="mb-8 rounded bg-[#30e9d9] px-4 pb-6 shadow-md hover:scale-110 w-full md:w-[70%] group-hover:transition delay-150 duration-300 ease-in-out">
          <div class="flex-1 justify-center">
            <div class="pt-4 text-lg font-semibold">Subscribe Prime</div>
            <div class="inline-flex items-center pt-1 pb-3 text-base">
              <TbDiscount2 size={25} /> &nbsp;Upto 10% off
            </div>
            <br />
            <button
              type="button"
              class="inline-block rounded border-2 border-[#ffffff] px-6 py-2 text-xs font-bold uppercase leading-tight text-[#ffffff] transition duration-150 ease-in-out hover:bg-black hover:bg-opacity-5 focus:outline-none focus:ring-0"
            >
              Subscribe Now
            </button>
          </div>
        </div>
      </div>

      <div class="flex flex-wrap justify-evenly">
        <div class="mb-8 rounded bg-[#30e9d9] px-4 pb-6 shadow-md hover:scale-105 md:w-[31%] group-hover:transition delay-150 duration-300 ease-in-out">
          <div class="flex-1 items-center">
            <div class="pt-4 text-lg font-semibold">Fast Recharge</div>
            <div class="inline-flex items-center pt-3 text-lg font-bold">
              <GiWallet size={40} />
              &nbsp;BDT 50
            </div>
            <div className="flex justify-between ">
              <div class="pt-2 text-xs">*No Refund available</div>
              <button
                type="button"
                class="inline-border rounded border-2 border-[#ffffff] px-3 py-2 text-xs font-bold uppercase leading-tight text-[#ffffff] transition duration-150 ease-in-out hover:bg-black hover:bg-opacity-45 focus:outline-none focus:ring-0"
              >
                Recharge
              </button>
            </div>
          </div>
        </div>
        <div class="mb-8 rounded bg-[#30e9d9] px-4 pb-6 shadow-md hover:scale-105 md:w-[31%] group-hover:transition delay-150 duration-300 ease-in-out">
          <div class="flex-1 items-center">
            <div class="pt-4 text-lg font-semibold">Fast Recharge</div>
            <div class="inline-flex items-center pt-3 text-lg font-bold">
              <GiWallet size={40} />
              &nbsp;BDT 50
            </div>
            <div className="flex justify-between ">
              <div class="pt-2 text-xs">*No Refund available</div>
              <button
                type="button"
                class="inline-border rounded border-2 border-[#ffffff] px-3 py-2 text-xs font-bold uppercase leading-tight text-[#ffffff] transition duration-150 ease-in-out hover:bg-black hover:bg-opacity-45 focus:outline-none focus:ring-0"
              >
                Recharge
              </button>
            </div>
          </div>
        </div>
        <div class="mb-8 rounded bg-[#30e9d9] px-4 pb-6 shadow-md hover:scale-105 md:w-[31%] group-hover:transition delay-150 duration-300 ease-in-out">
          <div class="flex-1 items-center">
            <div class="pt-4 text-lg font-semibold">Fast Recharge</div>
            <div class="inline-flex items-center pt-3 text-lg font-bold">
              <GiWallet size={40} />
              &nbsp;BDT 50
            </div>
            <div className="flex justify-between ">
              <div class="pt-2 text-xs">*No Refund available</div>
              <button
                type="button"
                class="inline-border rounded border-2 border-[#ffffff] px-3 py-2 text-xs font-bold uppercase leading-tight text-[#ffffff] transition duration-150 ease-in-out hover:bg-black hover:bg-opacity-45 focus:outline-none focus:ring-0"
              >
                Recharge
              </button>
            </div>
          </div>
        </div>
        <div class="mb-8 rounded bg-[#30e9d9] px-4 pb-6 shadow-md hover:scale-105 md:w-[31%] group-hover:transition delay-150 duration-300 ease-in-out">
          <div class="flex-1 items-center">
            <div class="pt-4 text-lg font-semibold">Fast Recharge</div>
            <div class="inline-flex items-center pt-3 text-lg font-bold">
              <GiWallet size={40} />
              &nbsp;BDT 50
            </div>
            <div className="flex justify-between ">
              <div class="pt-2 text-xs">*No Refund available</div>
              <button
                type="button"
                class="inline-border rounded border-2 border-[#ffffff] px-3 py-2 text-xs font-bold uppercase leading-tight text-[#ffffff] transition duration-150 ease-in-out hover:bg-black hover:bg-opacity-45 focus:outline-none focus:ring-0"
              >
                Recharge
              </button>
            </div>
          </div>
        </div>
        <div class="mb-8 rounded bg-[#30e9d9] px-4 pb-6 shadow-md hover:scale-105 md:w-[31%] group-hover:transition delay-150 duration-300 ease-in-out">
          <div class="flex-1 items-center">
            <div class="pt-4 text-lg font-semibold">Fast Recharge</div>
            <div class="inline-flex items-center pt-3 text-lg font-bold">
              <GiWallet size={40} />
              &nbsp;BDT 50
            </div>
            <div className="flex justify-between flex-row">
              <div class="pt-2 text-xs">*No Refund available</div>
              <button
                type="button"
                class="inline-border rounded border-2 border-[#ffffff] px-3 py-2 text-xs font-bold uppercase leading-tight text-[#ffffff] transition duration-150 ease-in-out hover:bg-black hover:bg-opacity-45 focus:outline-none focus:ring-0"
              >
                Recharge
              </button>
            </div>
          </div>
        </div>
        <div class="mb-8 rounded bg-[#30e9d9] px-4 pb-6 shadow-md hover:scale-105 md:w-[31%] group-hover:transition delay-150 duration-300 ease-in-out">
          <div class="flex-1 items-center">
            <div class="pt-4 text-lg font-semibold">Fast Recharge</div>
            <div class="inline-flex items-center pt-3 text-lg font-bold">
              <GiWallet size={40} />
              &nbsp;BDT 50
            </div>
            <div className="flex justify-between ">
              <div class="pt-2 text-xs">*No Refund available</div>
              <button
                type="button"
                class="inline-border rounded border-2 border-[#ffffff] px-3 py-2 text-xs font-bold uppercase leading-tight text-[#ffffff] transition duration-150 ease-in-out hover:bg-black hover:bg-opacity-45 focus:outline-none focus:ring-0"
              >
                Recharge
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Topup;
