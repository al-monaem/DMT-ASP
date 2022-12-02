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

        public static CLASS2 MapSingle(CLASS1 data)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CLASS1, CLASS2>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);

            return mapper.Map<CLASS2>(data);
        }
    }
}
