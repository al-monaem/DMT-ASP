using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TransactionService
    {
        public static List<StationDTO> GetStations()
        {
            var data = DataAccessFactory.TransactionDataAccess().GetStations();
            var stations = AutoMapperService<Station, StationDTO>.MapList(data);

            return stations;
        }
        public static List<TransactionDTO> GetTransactions(string id)
        {
            var data = DataAccessFactory.TransactionDataAccess().GetTransactions(id);
            var transactions = AutoMapperService<Transaction, TransactionDTO>.MapListWithAllDependency(data); 
            //List<TransactionDTO> transactions = new List<TransactionDTO>();

            //foreach (var t in data)
            //{
            //    transactions.Add(new TransactionDTO()
            //    {
            //        date = t.date,
            //        id = t.id,
            //        method = t.method,
            //        status = t.status,
            //        Ticket = new TicketDTO()
            //        {
            //            id=t.Ticket.id,
            //            route_id=t.Ticket.route_id,
            //            status = t.Ticket.status,
                  
            //        }
            //    });
            //}

            return transactions;
        }
        public static List<TransactionUserDTO> GetTransactions()
        {
            var data = DataAccessFactory.TransactionDataAccess().GetTransactions();
            var transactions = AutoMapperService<Transaction, TransactionUserDTO>.MapListWithAllDependency(data);

            return transactions;
        }

        public static List<RouteDTO> GetRoutes()
        {
            var data = DataAccessFactory.TransactionDataAccess().GetRoutes();
            var routes = AutoMapperService<Route, RouteDTO>.MapListWithAllDependency(data);

            return routes;
        }

        public static RouteDTO GetRoute(int id)
        {
            var data = DataAccessFactory.TransactionDataAccess().GetRoute(id);
            var route = AutoMapperService<Route, RouteDTO>.MapSingleWithAllDependency(data);

            return route;
        }
    }
}
