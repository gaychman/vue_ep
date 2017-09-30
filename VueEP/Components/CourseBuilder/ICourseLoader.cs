using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEP.Components.CourseBuilder
{
    interface ICourseLoader
    {
        Task Save(Object course);
        Task<Object> Load(String Id);
    }
}
