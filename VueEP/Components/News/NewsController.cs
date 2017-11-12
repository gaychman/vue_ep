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
using Microsoft.Extensions.Logging;

namespace VueEP.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private IDbConnection Connection { get; }
        private ILogger Logger { get; }

        public NewsController(IDbConnection conn,
            ILogger<NewsController> logger)
        {
            this.Connection = conn;
            this.Logger = logger;
        }
        /// <summary>
        /// Получение списка новостей
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            { 
                var news = await Connection.QueryAsync<NewsModel>("SELECT TOP 5 id, date, title, description FROM news ORDER BY date DESC");
                return Json(new
                {
                    isEditable = true,
                    list = news.Select(n => new { date = n.Date.ToString("dd.MM.yyyy HH:mm"), title = n.Title, description = n.Description, id = n.Id })
                });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Logger.LogError(ex, "Ошибка при получении списка новостей");
                return Json(new { });
            }
        }

        [HttpDelete]
        [Authorize(Roles = "news_admin")]
        public async Task<IActionResult> Delete(Int32 id)
        {
            try
            {
                await Connection.ExecuteAsync("DELETE FROM news WHERE id=@id", new { id });
                return Json(new { });
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                Logger.LogError(ex, "Ошибка при удалении новости");
                return Json(new { });
            }
        }
        /// <summary>
        /// Создание новости
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "news_admin")]
        public async Task<IActionResult> Create([FromBody]NewsModel model)
        {            
            try
            {
                await Connection.ExecuteAsync("INSERT INTO news (date, title, description) VALUES (@Date, @Title, @Description)", new { model.Date, model.Title, model.Description });
                return Json(new { });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Logger.LogError(ex, "Ошибка при добавлении новости");
                return Json(new { });
            }
        }
        /// <summary>
        /// Изменение новости
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Roles = "news_admin")]
        public async Task<IActionResult> Modify([FromBody]NewsModel model)
        {
            model.Date = DateTime.Now;
            try
            {
                await Connection.ExecuteAsync("UPDATE news SET date=@Date, title=@Title, description=@Description WHERE id=@Id", new { model.Id, model.Date, model.Title, model.Description });
                return Json(new { });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Logger.LogError(ex, "Ошибка при обновлении новости");
                return Json(new { });
            }
        }
    }
}
