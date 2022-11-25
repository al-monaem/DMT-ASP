import React from 'react'
import { motion } from "framer-motion"

import { Swiper, SwiperSlide } from "swiper/react"

import 'swiper/css';
import 'swiper/css/bundle';
import MyTicket from './MyTicket';

export const ActiveTickets = ({ swiper, activeSlide, setActiveSlide }) => {
    return (
        <div className='w-[80%] flex items-center'>
            <Swiper
                ref={swiper}
                centeredSlides={true}
                initialSlide={activeSlide}
                onSlideChange={(e) => setActiveSlide(e.realIndex)}
                spaceBetween={20}
                slidesPerView={3}>
                <SwiperSlide className='h-[200px]'>
                    <div className='p-10 flex items-center justify-center'>
                        <motion.div
                            animate={activeSlide === 0 ? { scale: 1.5 } : { scale: 1 }}
                            transition={{ duration: 0.5 }}
                            className={`w-[200px] h-[100px] bg-sky-500`}>
                            <MyTicket id={4} />
                        </motion.div>
                    </div>
                </SwiperSlide>
                <SwiperSlide>
                    <div className='p-10 flex items-center justify-center'>
                        <motion.div
                            animate={activeSlide === 1 ? { scale: 1.5 } : { scale: 1 }}
                            transition={{ duration: 0.5 }}
                            className={`w-[200px] h-[100px] bg-sky-500`}>
                            <MyTicket id={4} />
                        </motion.div>
                    </div>
                </SwiperSlide>
                <SwiperSlide>
                    <div className='p-10 flex items-center justify-center'>
                        <motion.div
                            animate={activeSlide === 2 ? { scale: 1.5 } : { scale: 1 }}
                            transition={{ duration: 0.5 }}
                            className={`w-[200px] h-[100px] bg-sky-500`}>
                            <MyTicket id={4} />
                        </motion.div>
                    </div>
                </SwiperSlide>
                <SwiperSlide>
                    <div className='p-10 flex items-center justify-center'>
                        <motion.div
                            animate={activeSlide === 3 ? { scale: 1.5 } : { scale: 1 }}
                            transition={{ duration: 0.5 }}
                            className={`w-[200px] h-[100px] bg-sky-500`}>
                            <MyTicket id={4} />
                        </motion.div>
                    </div>
                </SwiperSlide>
                <SwiperSlide>
                    <div className='p-10 flex items-center justify-center'>
                        <motion.div
                            animate={activeSlide === 4 ? { scale: 1.5 } : { scale: 1 }}
                            transition={{ duration: 0.5 }}
                            className={`w-[200px] h-[100px] bg-sky-500`}>
                            <MyTicket id={4} />
                        </motion.div>
                    </div>
                </SwiperSlide>
            </Swiper>
        </div>
    )
}
