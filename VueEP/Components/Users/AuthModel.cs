using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEP.Components.Users
{
    public class AuthModel
    {
        /// <summary>
        /// Регистрационное имя
        /// </summary>
        public String Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public String Password { get; set; }
    }
}
