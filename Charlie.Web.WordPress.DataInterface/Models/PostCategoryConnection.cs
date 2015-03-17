namespace Charlie.Web.WordPress.Data.Models
{
    public partial class PostCategoryConnection
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Post Post { get; set; }
    }
}
