using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEP.Components.News
{
    public class NewsModel
    {
        /// <summary>
        /// Идентификатор новости
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// Заголовок новости
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// Текст новости
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Дата публиккации
        /// </summary>
        public DateTime Date { get; set; }
    }
}
