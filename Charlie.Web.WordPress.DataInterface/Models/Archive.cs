using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Charlie.Web.WordPress.Data.Models
{
    public partial class Archive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostId { get; set; }

        public int Id { get; set; }

        public virtual Post Post { get; set; }
    }
}
