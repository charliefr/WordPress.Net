using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Charlie.Web.WordPress.Api;
using Charlie.Web.WordPress.Data;
using Charlie.Web.WordPress.Data.Models;
using Microsoft.Owin;

namespace Charlie.Web.WordPress.Areas.Admin.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class PostsController : BaseApiController
    {

        /// <summary>
        /// The _DB
        /// </summary>
        private readonly SqlDataContext _db = new SqlDataContext();
        // GET: api/Posts
        public PostsController()
        {
        }

        public PostsController(Controller controller) : base(controller)
        {
        }

        /// <summary>
        /// Gets the posts.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Post> GetPosts()
        {
            return _db.Posts;
        }

        // GET: api/Posts/5
        /// <summary>
        /// Gets the post.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof (Post))]
        public async Task<IHttpActionResult> GetPost(int id)
        {
            var post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        /// <summary>
        /// Puts the post.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        [ResponseType(typeof (void))]
        public async Task<IHttpActionResult> PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            _db.Entry(post).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Posts
        /// <summary>
        /// Posts the specified post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        [ResponseType(typeof (Post))]
        public async Task<Post> Post(Post post)
        {
            //[FromBody]
            if (!ModelState.IsValid)
            {
                this.BadRequestMessage(ModelState);
                return post;
                //return Task.FromResult(post);
            }
             
            var provider =this.OwinContext.Get<IDataProvider>();
            if (provider==null)
            {
                this.ResponseMessage(this.ServerExceptionMessage(@"IOwinContext is empty"));
                return post;
            }




           post= await provider.AddPost(post).ContinueWith<Post>(s =>
            {
                if (s.IsFaulted)
                {
                    Debug.WriteLine("ResponseMessage");
                   this.ServerExceptionMessage(s.Exception);
                    Debug.WriteLine("IsFaulted");
                    return null;
                }
                return s.Result;
            });

            return post;
        }

        public override Task<HttpResponseMessage> ExecuteAsync(System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Threading.CancellationToken cancellationToken)
        {
            
            Debug.WriteLine(
                "ExecuteAsync(System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Threading.CancellationToken cancellationToken)");
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
   

        // DELETE: api/Posts/5
        /// <summary>
        /// Deletes the post.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof (Post))]
        public async Task<IHttpActionResult> DeletePost(int id)
        {
            var post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();

            return Ok(post);
        }

        /// <summary>
        /// 释放对象使用的非托管资源，并有选择性地释放托管资源。
        /// </summary>
        /// <param name="disposing">若为 true，则同时释放托管资源和非托管资源；若为 false，则仅释放非托管资源。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Posts the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool PostExists(int id)
        {
            return _db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}