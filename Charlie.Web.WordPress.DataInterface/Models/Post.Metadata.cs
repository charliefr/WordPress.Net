using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Charlie.Web.WordPress.Data.DataResources;

namespace Charlie.Web.WordPress.Data.Models
{
    [MetadataType(typeof(PostMetadata))]
    public partial class Post
    {
        private string _virtualPath;

        public Post()
         {
             OnCreate();
         }
         private void OnCreate()
         {
             Content = Keywords = Name = Summary = Title=VirtualPath  = string.Empty;
             this.Publish = DateTime.UtcNow;
             PostCategoryConnections = new HashSet<PostCategoryConnection>();
             PostMetas = new HashSet<PostMeta>();
         }

        public string VirtualPath
        {
            get { return _virtualPath; }
            set
            {
                _virtualPath = value;
                VirtualPathHash = value == null ? null : value.Md5();
            }
        }

        public string VirtualPathHash { get; protected internal set; }

        private sealed class PostMetadata
         {
       
             [HiddenInput]
             //, ReadOnly(true)
             [Display(ResourceType = typeof(DispayResource), AutoGenerateField = false, AutoGenerateFilter = false, Name = "Post_Id_Name", Description = "Post_Id_Description", Prompt = "Post_Id_Prompt")]
             public int Id { get; set; }

            // [Required]
            // [StringLength(255,MinimumLength=1)]
             [Display(ResourceType = typeof(DispayResource), Name = "Post_VirtualPath_Name", Description = "Post_VirtualPath_Description", Prompt = "Post_VirtualPath_Prompt")]
             public string VirtualPath { get; set; }
            // [StringLength(16,MinimumLength=16)]
            // [System.Web.Mvc.HiddenInput]
             //, ReadOnly(true)
             [Display(ResourceType = typeof(DispayResource), Name = "Post_VirtualPathHash_Name", Description = "Post_VirtualPathHash_Description", Prompt = "Post_VirtualPathHash_Prompt")]
             public string VirtualPathHash { get; set; }
             [Display(ResourceType = typeof(DispayResource), Name = "Post_Publish_Name", Description = "Post_Publish_Description", Prompt = "Post_Publish_Prompt")]
             public DateTime Publish { get; set; }
          //  [System.Web.Mvc.HiddenInput]
             [Display(ResourceType = typeof(DispayResource), Name = "Post_Status_Name", Description = "Post_Status_Description", Prompt = "Post_Status_Prompt")]
             public int Status { get; set; }
             [Display(ResourceType = typeof(DispayResource), Name = "Post_Name_Name", Description = "Post_Name_Description", Prompt = "Post_Name_Prompt")]
           //  [StringLength(255)]
             public string Name { get; set; }
           //  [System.Web.Mvc.HiddenInput]
             [Display(ResourceType = typeof(DispayResource), Name = "Post_UserId_Name", Description = "Post_UserId_Description", Prompt = "Post_UserId_Prompt")]
             public int UserId { get; set; }
             [Display(ResourceType = typeof(DispayResource), Name = "Post_Title_Name", Description = "Post_Title_Description", Prompt = "Post_Title_Prompt")]
            // [Required]
            // [StringLength(255)]
             public string Title { get; set; }
             [Display(ResourceType = typeof(DispayResource), Name = "Post_Summary_Name", Description = "Post_Summary_Description", Prompt = "Post_Summary_Prompt")]
             public string Summary { get; set; }
             [Display(ResourceType = typeof(DispayResource), Name = "Post_Keywords_Name", Description = "Post_Keywords_Description", Prompt = "Post_Keywords_Prompt")]
            // [StringLength(255)]
             public string Keywords { get; set; }
             [Display(ResourceType = typeof(DispayResource), Name = "Post_Content_Name", Description = "Post_Content_Description", Prompt = "Post_Content_Prompt")]
             public string Content { get; set; }

         }
     
    }

    
}
