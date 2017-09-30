using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEP.Components.CourseBuilder
{
    public class MongoCourseLoader : ICourseLoader
    {
        IMongoDatabase DB { get; }

        public MongoCourseLoader(IMongoDatabase db)
        {
            DB = db;
        }

        public async Task<object> Load(String id)
        {
            //var res = Query<Object>.EQ(p => p.Id, id);
            return await Task.FromResult(DB.GetCollection<Object>("Courses"));//.FindAsync();
        }

        public Task Save(object course)
        {
            throw new NotImplementedException();
        }
    }
}
