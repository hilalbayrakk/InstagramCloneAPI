using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> AddComment(Comment comment);
        Task<Comment> UpdateComment (int id, Comment comment);
        Task DeleteComment(Comment comment);
        Task<List<Comment>>GetAllComment();
        Task<Comment>GetCommentById(int id);
        Task<List<Comment>>GetCommentByPostId(int postId);
        Task<List<Comment>>GetCommentByUserId(int userId);
        
    }
}