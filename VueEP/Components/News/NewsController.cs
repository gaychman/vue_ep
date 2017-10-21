using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using VueEP.Components.News;
using Microsoft.AspNetCore.Authorization;

namespace VueEP.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        public IDbConnection Connection { get; }

        public NewsController(IDbConnection conn)
        {
            Connection = conn;
        }

        public IActionResult Index()
        {
            //var authenticateInfo = await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync( HttpContext.Authentication.GetAuthenticateInfoAsync("Bearer");

            var news = Connection.Query<NewsDescription>("SELECT TOP 5 id, date, title, description FROM news ORDER BY date DESC");
            return Json(new
            {
                isEditable = true,
                list = news.Select(n => new { date = n.Date.ToString("dd.MM.yyyy HH:mm"), title = n.Title, description = n.Description, id = n.Id })
            });
        }
    }
}
