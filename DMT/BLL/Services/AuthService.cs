using BLL.DTOs;
using DAL;
using DAL.EF;
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
    }
}
