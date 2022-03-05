using InstagramCloneAPI.Context;
using InstagramCloneAPI.Interfaces;
using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly InstagramCloneDbContext _context;
        public PostRepository(InstagramCloneDbContext context)
        {
            _context = context;
        }

        public async Task<Post> AddPost(Post post)
        {
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task DeletePost(Post post)
        {
            var result = _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> UpdatePost(Post post)
        {
            var result = _context.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetAllPost()
        {
            return await _context.Set<Post>().ToListAsync();
        }



    }


}