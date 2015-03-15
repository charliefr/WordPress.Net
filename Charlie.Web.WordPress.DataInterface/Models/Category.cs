namespace Charlie.Web.WordPress.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public sealed partial class Category
    {
        public Category()
        {
            CategoryMetas = new HashSet<CategoryMeta>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string VirualPath { get; set; }

        [Required]
        [StringLength(16)]
        public string VirualPathHash { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [StringLength(255)]
        public string Keywords { get; set; }

        public ICollection<CategoryMeta> CategoryMetas { get; set; }
    }
}
