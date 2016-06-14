using AutoMapper;
using GreetingCard.Models.CardViewModels;
using GreetingCard.Entities;

namespace GreetingCard.Infrastructure.Mapping
{
    public class DomainToViewModelMappingProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Card, CardViewModel>()
               .ForMember(vm => vm.ImageUrl, map => map.MapFrom(p => "/images/" + p.ImageUrl));

            //Mapper.CreateMap<Category, CategoryViewModel>()
            //    .ForMember(vm => vm.TotalCard, map => map.MapFrom(a => a.Cards.Count))
            //    .ForMember(vm => vm.ImageUrl, map =>
            //        map.MapFrom(a => (a.ImageUrl != null) ?
            //        "/images/" + a.Photos.First().Uri :
            //        "/images/thumbnail-default.png"));
        }
    }
}
