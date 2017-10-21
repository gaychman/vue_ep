using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VueEP.Components.Users
{
    public class AuthUser
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public String EMail { get; set; }
        /// <summary>
        /// Регистрационное имя
        /// </summary>
        public String Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public String Password { get; set; }
        /// <summary>
        /// Случайные байты для шифрования пароля
        /// </summary>
        public byte[] Salt { get; set; }
        /// <summary>
        /// Роли пользователя
        /// </summary>
        public IEnumerable<String> Roles { get; set; }
        /// <summary>
        /// Получение списка сведений о пользователе
        /// </summary>
        public IEnumerable<Claim> Claims
        {
            get
            {
                IList<Claim> list = new List<Claim>();
                if (!String.IsNullOrWhiteSpace(EMail))
                {
                    list.Add(new Claim(JwtRegisteredClaimNames.Email, EMail));
                }
                list.Add(new Claim(JwtRegisteredClaimNames.Sub, Id.ToString()));
                return list;
            }
        }
    }
}
