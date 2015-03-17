using System.ComponentModel.DataAnnotations;

namespace Charlie.Web.WordPress.Data.Models
{
    public partial class CategoryMeta
    {
        public int Id { get; set; }

        public int CotegoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string MetaKey { get; set; }

        [Required]
        public string MetaValue { get; set; }

        public virtual Category Category { get; set; }
    }
}
