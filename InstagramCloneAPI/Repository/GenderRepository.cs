using InstagramCloneAPI.Context;
using InstagramCloneAPI.Interfaces;
using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Repository
{
    public class GenderRepository : IGenderRepository
    {
        private readonly InstagramCloneDbContext _context;
        public GenderRepository(InstagramCloneDbContext context)
        {
            _context = context;
        }
       public async Task<Gender>AddGender(Gender gender)
        {
           await _context.AddAsync(gender);
           await _context.SaveChangesAsync();
           return gender;
        }

        public async Task DeleteGender(Gender gender)
        {
            var result = _context.Remove(gender);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Gender>>GetAllGender()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Gender>UpdateGender(Gender gender)
        {
            var result = _context.Update(gender);
            await _context.SaveChangesAsync();
            return gender;
        }
    }
}