using InstagramCloneAPI.Interfaces;
using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<Comment> AddComment(Comment comment)
        {
            var result = _commentRepository.GetCommentById(comment.Id);
            if (result is null)
            {
                return await _commentRepository.AddComment(comment);
            }
            throw new InvalidOperationException("Aynı id'ye sahip başka bir yorum bulunmaktadır!");
        }

        public async Task DeleteComment(Comment comment)
        {
            var result = _commentRepository.GetCommentById(comment.Id);
            if (result is not null)
            {
                await _commentRepository.DeleteComment(comment);
            }
            throw new Exception("Silinecek yorum bulunamadı!");
        }
        public async Task<Comment> UpdateComment(int id, Comment comment)
        {
            var updatedComment = await _commentRepository.GetCommentById(id);
            if (updatedComment is not null)
            {
                updatedComment = comment;
                await _commentRepository.UpdateComment(comment);
                return comment;
            }
            throw new InvalidOperationException("Güncellenecek yorum bulunamadı!");
        }
        public async Task<List<Comment>> GetAllComment()
        {
            return await _commentRepository.GetAllComment();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _commentRepository.GetCommentById(id);
        }

        public async Task<List<Comment>> GetCommentByPostId(int postId)
        {
            return await _commentRepository.GetCommentByPostId(postId);
        }

        public async Task<List<Comment>> GetCommentByUserId(int userId)
        {
            return await _commentRepository.GetCommentByUserId(userId);
        }


    }
}