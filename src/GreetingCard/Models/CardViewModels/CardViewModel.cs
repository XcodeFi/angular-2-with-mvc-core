using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCard.Models.CardViewModels
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public int CateId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewNo { get; set; }
        public int LikesNo { get; set; }
        public string CardSize { get; set; }
        public string CardType { get; set; }
        public bool IsDelete { get; set; }
        public string ImageUrl { get; set; }
        public byte? RateNo { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPublish { get; set; }
        public string TextSearch { get; set; }
    }
}
