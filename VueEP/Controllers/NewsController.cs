using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

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
            var news = Connection.Query("SELECT TOP 5 date, title, description FROM news ORDER BY date DESC");
            return Json(news);
        }
    }
}
