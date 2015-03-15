namespace Charlie.Web.WordPress.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public sealed partial class User
    {
        public User()
        {
            UserMetas = new HashSet<UserMeta>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(68)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string Mailbox { get; set; }

        public bool IsMailVerified { get; set; }

        public DateTime RegisteredTime { get; set; }

        public int Status { get; set; }

        public ICollection<UserMeta> UserMetas { get; set; }
    }
}
