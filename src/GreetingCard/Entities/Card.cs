using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCard.Entities
{
    public class Card : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int CateId { get; set; }
        public string Title { get; set; }
        [StringLength(450)]
        public string UrlSlug { get; set; }
        [Required]
        [StringLength(500)]
        public string Content { get; set; }
        [Required]
        public int ViewNo { get; set; }
        [Required]
        public int LikesNo { get; set; }
        [Required]
        [StringLength(50)]
        public string CardSize { get; set; }
        [Required]
        [StringLength(50)]
        public string CardType { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public byte? RateNo { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public bool IsPublished { get; set; }
        [Required]
        [StringLength(250)]
        public string TextSearch { get; set; }
        [ForeignKey("CateId")]
        public virtual Category Category { get; set; }

        public Card()
        {
            ViewNo = 0;
            LikesNo = 0;
            IsDeleted = false;
            RateNo = 3;
            DateCreated = System.DateTime.UtcNow;
            IsPublished = true;
        }
    }
}