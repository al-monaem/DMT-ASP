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
    public class AuthService
    {
        public static TokenDTO Authenticate(LoginDTO user)
        {
            var rs = DataAccessFactory.AuthDataAccess().Authenticate(user.email, user.password);

            if (rs != null)
            {
                var tokenObj = DataAccessFactory.TokenDataAccess().GetByUser(rs.id);
                if (tokenObj == null)
                {
                    tokenObj = new Token()
                    {
                        userId = rs.id,
                        created_at = DateTime.Now,
                        expired_at = null,
                        accessToken = Guid.NewGuid().ToString()
                    };
                    var tk = DataAccessFactory.TokenDataAccess().Add(tokenObj);
                    tokenObj = tk;
                }

                var token = AutoMapperService<Token, TokenDTO>.MapSingle(tokenObj);
                return token;
            }
            return null;
        }

        public static bool IsTokenValid(string accessToken)
        {
            var token = DataAccessFactory.TokenDataAccess().Get(accessToken);
            if(token!=null && token.expired_at == null)
            {
                return true;
            }
            return false;
        }

        public static bool ExpireToken(string token)
        {
            return DataAccessFactory.TokenDataAccess().Expire(token);
        }

        public static bool IsAdmin(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if (tk.User.role == 1)
                return true;
            return false;
        }

        public static int Register(UserRegisterDTO user)
        {
            var data = AutoMapperService<UserRegisterDTO, User>.MapSingle(user);
            var res = DataAccessFactory.AuthDataAccess().Register(data);

            return res;
        }

        public static int UpdatePassword(string id, string currentPassword, string newPassword)
        {
            return DataAccessFactory.AuthDataAccess().UpdatePassword(id, currentPassword, newPassword);
        }
    }
}
