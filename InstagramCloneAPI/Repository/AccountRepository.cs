using InstagramCloneAPI.Context;
using InstagramCloneAPI.Interfaces;
using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly InstagramCloneDbContext _context;
        public AccountRepository(InstagramCloneDbContext context)
        {
            _context = context;
        }

    }
}