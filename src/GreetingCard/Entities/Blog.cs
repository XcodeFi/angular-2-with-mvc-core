using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCard.Entities
{
    public class Blog:IEntityBase
    {
        public int Id { get; set; }
        public int CateBlogId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string UrlSlug { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int ViewNo { get; set; }
        public bool IsDelete { get; set; }
        public bool IsLock { get; set; }
        public bool Status { get; set; }
        public DateTime DatePosted { get; set; }
        public int LikeNo { get; set; }
        public DateTime DateEdited { get; set; }
        public string TextSearch { get; set; }

        public virtual CategoryBlog CategoryBlog { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        

        public Blog()
        {
            ViewNo = 0;
            IsDelete = false;
            IsLock = false;
            Status = false;
            LikeNo = 0;
            DateEdited = System.DateTime.UtcNow;

            Comments = new List<Comment>();
        }
    }
}
