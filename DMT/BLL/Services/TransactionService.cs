﻿using BLL.DTOs;
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
    }
}