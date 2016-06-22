using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCard.Entities
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [Required]
        public byte Level { get; set; }
        [Required]
        [StringLength(450)]
        public string Name { get; set; }
        [Required]
        [StringLength(450)]
        public string UrlSlug { get; set; }
        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        [Required]
        public bool IsPublished { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsMainMenu { get; set; }

        public bool Status { get; set; }

        public ICollection<Card> Cards { get; set; }

        public Category()
        {
            Level = 1;
            DateCreated = System.DateTime.UtcNow;
            IsPublished = true;
            IsDeleted = false;
            Status = false;
            IsMainMenu = true;

            Cards = new List<Card>();
        }
    }
}
