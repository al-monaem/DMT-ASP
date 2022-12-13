using AutoMapper;
using BLL.DTOs;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class AutoMapperService<CLASS1, CLASS2>
    {
        public static List<CLASS2> MapList(List<CLASS1> data)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CLASS1, CLASS2>());
            var mapper = new Mapper(config);

            return mapper.Map<List<CLASS2>>(data);
        }
        public static List<CLASS2> MapListWithAllDependency(List<CLASS1> data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ticket, TicketDTO>();
                cfg.CreateMap<Refund, RefundDTO>();
                cfg.CreateMap<Transaction, TransactionDTO>();
                cfg.CreateMap<Route, RouteDTO>();
                cfg.CreateMap<Station, StationDTO>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Revenue, RevenueDTO>();

                cfg.CreateMap<TicketDTO, Ticket>();
                cfg.CreateMap<RefundDTO, Refund>();
                cfg.CreateMap<TransactionDTO, Transaction>();
                cfg.CreateMap<RouteDTO, Route>();
                cfg.CreateMap<StationDTO, Station>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<RevenueDTO, Revenue>();
            });
            var mapper = new Mapper(config);

            return mapper.Map<List<CLASS2>>(data);
        }

        public static CLASS2 MapSingle(CLASS1 data)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CLASS1, CLASS2>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);

            return mapper.Map<CLASS2>(data);
        }

        public static CLASS2 MapSingleWithAllDependency(CLASS1 data)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Ticket, TicketDTO>();
                cfg.CreateMap<Refund, RefundDTO>();
                cfg.CreateMap<Transaction, TransactionDTO>();
                cfg.CreateMap<Route, RouteDTO>();
                cfg.CreateMap<Station, StationDTO>();
                cfg.CreateMap<User, UserDTO>();

                cfg.CreateMap<TicketDTO, Ticket>();
                cfg.CreateMap<RefundDTO, Refund>();
                cfg.CreateMap<TransactionDTO, Transaction>();
                cfg.CreateMap<RouteDTO, Route>();
                cfg.CreateMap<StationDTO, Station>();
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);

            return mapper.Map<CLASS2>(data);
        }
    }
}
