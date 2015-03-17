using Charlie.Web.WordPress.Data.Models;

namespace Charlie.Web.WordPress.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        protected DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Archive> Archives { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryMeta> CategoryMetas { get; set; }
        public virtual DbSet<PostCategoryConnection> PostCategoryConnections { get; set; }
        public virtual DbSet<PostMeta> PostMetas { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UserMeta> UserMetas { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.VirualPathHash)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryMetas)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CotegoryId);

            modelBuilder.Entity<Models.Post>()
                .Property(e => e.VirtualPathHash)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Models.Post>()
                .HasOptional(e => e.Archive)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
