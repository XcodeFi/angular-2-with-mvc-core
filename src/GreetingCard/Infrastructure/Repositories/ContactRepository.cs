using GreetingCard.Entities;
using GreetingCard.Infrastructure.Repositories.Abstract;

namespace GreetingCard.Infrastructure.Repositories
{
    public class ContactRepository:EntityBaseRepository<Contact>,IContactRepository
    {
        public ContactRepository(GreetingCardContext context) : base(context) { }
    }
}
