using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCard.Entities
{
    public class Contact : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime SendedTime { get; set; }
        public byte IsDelete { get; set; }
        public byte Status { get; set; }

        public Contact()
        {
            SendedTime = System.DateTime.UtcNow;
            IsDelete = 0;
            Status = 0;
        }
    }

}
