using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEP.Components.Users
{
    public class RegisterModel
    {
        /// <summary>
        /// Регистрационное имя
        /// </summary>
        public String Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public String Password { get; set; }
        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public String EMail { get; set; }
    }
}
