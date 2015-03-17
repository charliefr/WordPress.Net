using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Charlie.Web.WordPress.Data.Models
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
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

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<UserMeta> UserMetas { get; set; }
    }
}
