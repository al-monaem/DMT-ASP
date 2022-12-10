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
        public static UserDTO Update(UserDTO u, string token)
        {
            var user = AutoMapperService<UserDTO, User>.MapSingle(u);
            var res = DataAccessFactory.UserDataAccess().Update(user, token);
            var newUser = AutoMapperService<User, UserDTO>.MapSingle(res);

            return newUser;
        }
    }
}
