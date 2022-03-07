using InstagramCloneAPI.Context;
using InstagramCloneAPI.Interfaces;
using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly InstagramCloneDbContext _context;

        public CommentRepository(InstagramCloneDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> AddComment(Comment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task DeleteComment(Comment comment)
        {
            var result = _context.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllComment()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            var result = _context.Update(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
        async Task<Comment> ICommentRepository.GetCommentById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c=>c.Id == id);
        }

        public async Task<List<Comment>> GetCommentByPostId(int postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<List<Comment>> GetCommentByUserId(int userId)
        {
            return await _context.Comments.Where(c => c.UserId == userId).ToListAsync();
        }

    }
}