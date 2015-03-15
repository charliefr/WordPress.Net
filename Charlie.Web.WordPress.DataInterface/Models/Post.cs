namespace Charlie.Web.WordPress.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public sealed partial class Post
    {
        public Post()
        {
            PostMetas = new HashSet<PostMeta>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string VirtualPath { get; set; }

        [Required]
        [StringLength(16)]
        public string VirtualPathHash { get; set; }

        public DateTime Publish { get; set; }

        public int Status { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Guid Author { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [StringLength(255)]
        public string Keywords { get; set; }

        [Required]
        public string Content { get; set; }

        public ICollection<PostMeta> PostMetas { get; set; }
    }
}
