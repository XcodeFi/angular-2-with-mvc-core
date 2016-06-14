using GreetingCard.Infrastructure.Repositories.Abstract;
using GreetingCard.Entities;

namespace GreetingCard.Infrastructure.Repositories
{
    public class CategoryBlogRepository:EntityBaseRepository<CategoryBlog>, ICateBlogRepository
    {
        public CategoryBlogRepository(GreetingCardContext context) : base(context) { }
    }
}
