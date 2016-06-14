using GreetingCard.Entities;
using GreetingCard.Infrastructure.Repositories.Abstract;

namespace GreetingCard.Infrastructure.Repositories
{
    public class UserRoleRepository: EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(GreetingCardContext context) : base(context) { }
    }
   
}
