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

            return transactions;
        }
        public static List<TransactionDTO> GetTransactions()
        {
            var data = DataAccessFactory.TransactionDataAccess().GetTransactions();
            var transactions = AutoMapperService<Transaction, TransactionDTO>.MapListWithAllDependency(data);

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

        public static TransactionDTO Checkout(GatewayDTO details)
        
        {
            var data = DataAccessFactory.TransactionDataAccess().Checkout(details.user_id, details.route_id, details.paymentMethod, details.price);
            var transaction = AutoMapperService<Transaction, TransactionDTO>.MapSingleWithAllDependency(data);

            return transaction;
        }

        public static bool Refund(int id)
        {
            return DataAccessFactory.TransactionDataAccess().Refund(id);
        }
    }
}
