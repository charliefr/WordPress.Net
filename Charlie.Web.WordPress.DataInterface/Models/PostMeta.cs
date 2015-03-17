using System.ComponentModel.DataAnnotations;

namespace Charlie.Web.WordPress.Data.Models
{
    public partial class PostMeta
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        [Required]
        [StringLength(255)]
        public string MetaKey { get; set; }

        [Required]
        public string MataValue { get; set; }

        public virtual Post Post { get; set; }
    }
}
