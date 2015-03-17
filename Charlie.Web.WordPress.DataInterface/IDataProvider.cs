using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charlie.Web.WordPress.Data.Models;



namespace Charlie.Web.WordPress.Data
{
    public interface IDataProvider:IDisposable
    {
        Task<Post> AddPost(Post model);

        Task<Post> UpdatePost(int id, Post model);

        Task<bool> DeletePost(int id);

        Task<Post> GetPost(int id);
    }
}
