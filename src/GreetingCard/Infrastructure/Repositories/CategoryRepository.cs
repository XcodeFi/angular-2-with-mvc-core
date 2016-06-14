using GreetingCard.Entities;
using GreetingCard.Infrastructure.Repositories.Abstract;

namespace GreetingCard.Infrastructure.Repositories
{
    public class CategoryRepository:EntityBaseRepository<Category>,ICateRepository
    {
        public CategoryRepository(GreetingCardContext context) : base(context) { }
    }
}
