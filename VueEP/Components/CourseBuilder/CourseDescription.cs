using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEP.Components.CourseBuilder
{
    public class CourseDescription
    {
        public String Id { get; set; }

        /// <summary>
        /// Ширина курса в пикселях, если null - подстройка под размер экрана
        /// </summary>
        public Int32? Width { get; set; }
        /// <summary>
        /// Высота курса в пикселях, если null - подстройка под размер экрана
        /// </summary>
        public Int32? Height { get; set; }
        /// <summary>
        /// Название курса
        /// </summary>
        public String Name { get; set; }   
    }
}
