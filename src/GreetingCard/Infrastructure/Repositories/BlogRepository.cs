using GreetingCard.Entities;
using GreetingCard.Infrastructure.Repositories.Abstract;

namespace GreetingCard.Infrastructure.Repositories
{
    public class BlogRepository:EntityBaseRepository<Blog>,IBlogRepository
    {
        public BlogRepository(GreetingCardContext context)
            : base(context)
        { }
    }
}
