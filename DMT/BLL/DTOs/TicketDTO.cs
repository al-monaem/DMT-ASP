﻿using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TicketDTO
    {
        public int id { get; set; }
        public int route_id { get; set; }
        public string status { get; set; }

        public virtual RouteDTO Route { get; set; }
    }
}
