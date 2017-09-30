using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VueEP.Controllers
{
    [Route("auth/login")]
    public class AuthController : Controller
    {
        public class LoginModel
        {
            String Login { get; set; }
            String Password { get; set; }
        }
        [HttpPost]
        public String Post([FromBody]dynamic data)
        {
            //String login = data.First.Login;
            //String password = data.First.Password;

            return String.Empty;
        }
    }
}
