using GreetingCard.Entities;
using GreetingCard.Infrastructure.Repositories.Abstract;

namespace GreetingCard.Infrastructure.Repositories
{
    public class LoggingRepository:EntityBaseRepository<Error>,ILoggingRepository
    {
        public LoggingRepository(GreetingCardContext context) : base(context) { }
    }
}
