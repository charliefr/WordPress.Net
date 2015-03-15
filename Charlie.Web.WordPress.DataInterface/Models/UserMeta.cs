namespace Charlie.Web.WordPress.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserMeta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string MetaKey { get; set; }

        [Required]
        public string MetaValue { get; set; }

        public virtual User User { get; set; }
    }
}
