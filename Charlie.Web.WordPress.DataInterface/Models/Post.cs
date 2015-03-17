using System;
using System.Collections.Generic;

namespace Charlie.Web.WordPress.Data.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public DateTime Publish { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }

        public virtual Archive Archive { get; set; }

        public virtual ICollection<PostCategoryConnection> PostCategoryConnections { get; set; }

        public virtual ICollection<PostMeta> PostMetas { get; set; }

        public virtual User User { get; set; }
    }
}
