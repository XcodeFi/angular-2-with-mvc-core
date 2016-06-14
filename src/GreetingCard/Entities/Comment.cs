using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCard.Entities
{
    public class Comment : IEntityBase
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public byte IsDelete { get; set; }
        public int? LikeNo { get; set; }
        public bool Status { get; set; }
        public int? CardId { get; set; }
        public DateTime DatePosted { get; set; }
        public virtual Blog Blog { get; set; }
        public Comment()
        {
            IsDelete = 0;
            Status = false;
            DatePosted = System.DateTime.UtcNow;
        }
    }
}
