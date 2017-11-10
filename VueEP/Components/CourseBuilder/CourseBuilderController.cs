using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VueEP.Components.CourseBuilder;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Logging;
using System.Data;
using Dapper;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace VueEP.Controllers
{
    [Route("api/course-builder")]
    [Authorize(Roles = "course_admin")]
    public class CourseBuilderController : Controller
    {
        IMongoDatabase MongoDB { get; }
        private IDbConnection Connection { get; }
        private ILogger Logger { get; }

        public CourseBuilderController(IMongoDatabase mongodb, IDbConnection conn,
            ILogger<CourseBuilderController> logger)
        {
            this.MongoDB = mongodb;
            this.Connection = conn;
            this.Logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Добавление нового курса в ДБЗ и Mongo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CourseDescription model)
        {
            try
            {
                var user = User.Identity as ClaimsIdentity;
                if (null == user)
                {
                    throw new Exception("Пользователь не авторизован");
                }
                var id_claim = user.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
                if(null == id_claim)
                {
                    throw new Exception("Идентификатор пользователя не задан");
                }
                BsonDocument doc = new BsonDocument { { "name", model.Name }, { "width", model.Width }, { "height", model.Height } };
                var collection = MongoDB.GetCollection<BsonDocument>("courses");
                await collection.InsertOneAsync(doc);
                // добавляем в ДБЗ
                await Connection.ExecuteAsync("INSERT INTO documents (name, roles, type, creator_id, is_private, modification_date, status, external_ref) VALUES (@name, @roles, @type, @creator_id, @is_private, @modification_date, @status, @external_ref)", 
                    new { name = model.Name, roles = 0, type = VueEP.Components.DKB.NodeTypes.COURSE, creator_id = Int32.Parse(id_claim.Value), is_private = true, modification_date = DateTime.Now, status = 0, external_ref = doc.AsObjectId});
                // добавляем в MongoDB
                
                return Json(new { });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Logger.LogError(ex, "Ошибка при добавлении курса");
                return Json(new { });
            }
        }

    }
}
