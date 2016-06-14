using GreetingCard.Entities;
using GreetingCard.Infrastructure.Repositories.Abstract;

namespace GreetingCard.Infrastructure.Repositories
{
    public class CommentRepository: EntityBaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GreetingCardContext context) : base(context) { }
    }
}
