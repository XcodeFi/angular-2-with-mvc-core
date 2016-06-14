using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCard.Entities
{
    public class CategoryBlog : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public CategoryBlog()
        {
            DateEdited = System.DateTime.UtcNow;
            Status = false;

            Blogs = new List<Blog>();
        }
    }
}
