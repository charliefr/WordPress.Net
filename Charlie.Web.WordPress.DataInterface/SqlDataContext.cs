using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Charlie.Web.WordPress.Data.Models;


namespace Charlie.Web.WordPress.Data
{
   public  class SqlDataContext:DataContext,IDataProvider
    {

       public SqlDataContext():base()
       {
           Debug.WriteLine("SqlDataContext is initialized");
       }
        public async Task<Post> AddPost(Post model)
        {
            Posts.Add(model);
            await SaveChangesAsync();
            return model;
        }

        public async Task<Post> UpdatePost(int id, Post model)
        {
            Entry(model).State = EntityState.Modified;
            await SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = new Post(){Id=id};
            Entry(post).State = EntityState.Deleted;//标识库中对应实体为删除状态
            return  0 == await SaveChangesAsync();
        }

        public Task<Post> GetPost(int id)
        {
            throw new NotImplementedException();
        }




     
    }
}
