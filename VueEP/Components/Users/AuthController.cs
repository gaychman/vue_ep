using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using VueEP.Components.Users;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace VueEP.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthController : Controller
    {
        private IDbConnection Connection { get; }
        private IConfigurationRoot Configuration { get; }
        private Int32 cryptIterations;

        public AuthController(IDbConnection conn, IConfigurationRoot configuration)
        {
            Connection = conn;
            Configuration = configuration;


            if(Int32.TryParse(Configuration["Password:Iterations"], out cryptIterations))
            {
                cryptIterations = 10;
            }
        }

        public class LoginModel
        {
            String Login { get; set; }
            String Password { get; set; }
        }

        private String CryptedPass(String password, byte[] seed)
        {
            byte[] crypted;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, seed, 10))
            {
                crypted = deriveBytes.GetBytes(32);
            }
            return Convert.ToBase64String(crypted);
        }

        [Route("api/users/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel data)
        {
            var salt = new byte[32];
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(salt);
            }

            await Connection.ExecuteAsync("INSERT INTO users (login, email, password, salt) VALUES (@login, @email, @password, @salt)", new
            {
                login = data.Login,
                salt,
                email = data.EMail,
                password = CryptedPass(data.Password, salt)
            });
            return Json(new { });
        }

        [Route("api/users/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]AuthModel data)
        {
            try
            {
                var user = await Connection.QuerySingleAsync<AuthUser>("SELECT u.id, u.email, u.salt, u.password, u.roles AS rolesmask FROM users u WHERE u.login=@login", new { login = data.Login });
                if (null == user)
                {
                    Response.StatusCode = 400;
                    return Content("Invalid username or password.");
                }
                // проверяем пароль
                if(user.Password != CryptedPass(data.Password, user.Salt))
                {
                    Response.StatusCode = 400;
                    return Content("Invalid username or password.");
                }
                // получаем роли
                user.Roles = await Connection.QueryAsync<String>("SELECT name FROM roles WHERE (code & @roles)<>0", new { roles = user.RolesMask });

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"]));
                var now = DateTime.Now;
                var token = new JwtSecurityToken(
                    issuer: Configuration["Token:Issuer"],
                    audience: Configuration["Token:Audience"],
                    notBefore: now,
                    claims: user.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(30)),                     
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
