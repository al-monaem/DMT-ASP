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
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var users = AutoMapperService<User, UserDTO>.MapList(data);
            return users;
        }
        public static UserDTO Get(string id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var user = AutoMapperService<User, UserDTO>.MapSingle(data);
            return user;
        }
    }
}
