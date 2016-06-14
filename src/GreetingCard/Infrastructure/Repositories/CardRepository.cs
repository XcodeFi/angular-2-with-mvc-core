using GreetingCard.Entities;
using GreetingCard.Infrastructure.Repositories.Abstract;

namespace GreetingCard.Infrastructure.Repositories
{
    public class CardRepository: EntityBaseRepository<Card>, ICardRepository
    {
        public CardRepository(GreetingCardContext context)
            : base(context)
        { }
    }
}
