using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Charlie.Web.WordPress.Data.Models;


namespace Charlie.Web.WordPress.Areas.Admin.Controllers
{
    public class PostsController : BaseAdminController
    {
        // GET: Admin/Post
        public ActionResult Index()
        {
            // all post list;
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            //new
            return View(new Post()
            {
   Name ="123", UserId=1
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection formvalues)
        {
            var model = new Post();
            if (TryUpdateModel(model, formvalues.GetPrefix()) && ModelState.IsValid)
            {
                var api = new Api.PostsController();
               await api.PostPost(model);
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            var api = new Api.PostsController();
            //api.PutPost(id, null);
            return View();
        }

      

       
    }
}