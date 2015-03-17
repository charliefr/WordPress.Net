using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Charlie.Web.WordPress.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryMetas = new HashSet<CategoryMeta>();
            PostCategoryConnections = new HashSet<PostCategoryConnection>();
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

        public virtual ICollection<CategoryMeta> CategoryMetas { get; set; }

        public virtual ICollection<PostCategoryConnection> PostCategoryConnections { get; set; }
    }
}
