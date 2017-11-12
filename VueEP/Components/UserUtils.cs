using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace VueEP.Components
{
    public static class UserUtils
    {
        public static Int32 Id(this IIdentity identity)
        {
            var user = identity as ClaimsIdentity;
            if (null == user)
            {
                throw new Exception("Пользователь не авторизован");
            }
            var id_claim = user.Claims.FirstOrDefault(x => CustomClaims.ID == x.Type);
            if (null == id_claim)
            {
                throw new Exception("Идентификатор пользователя не задан");
            }
            return Int32.Parse(id_claim.Value);
        }
    }
}
