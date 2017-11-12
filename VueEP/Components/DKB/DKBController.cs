using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Dapper;
using VueEP.Components.DKB;
using VueEP.Components;

namespace VueEP.Controllers
{
    //[Produces("application/json")]
    //[Route("api/dkb")]
    public class DKBController : Controller
    {
        private IDbConnection Connection { get; }
        private ILogger Logger { get; }

        public DKBController(IDbConnection conn,
            ILogger<DKBController> logger)
        {
            this.Connection = conn;
            this.Logger = logger;
        }

        [Route("api/dkb/mylist")]
        //[Authorize]
        public async Task<IActionResult> MyDocuments(Int32? type)
        {
            try
            {
                Int32 limit = 10;

                var list = await Connection.QueryAsync<DocumentModel>($"SELECT TOP {limit} id, name, external_ref AS ExternalRef FROM documents WHERE creator_id=@uid AND type=@type ORDER BY modification_date DESC", new {uid = User.Identity.Id(), type });
                return Json(new
                {
                    list
                });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Logger.LogError(ex, "Ошибка при получении списка документов");
                return Json(new { });
            }
        }
    }
}