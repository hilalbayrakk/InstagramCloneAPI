using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Interfaces
{
    public interface ICommentRepository
    {
    Task<Comment> AddComment(Comment comment);
    Task<Comment> UpdateComment(Comment comment);
    Task DeleteComment(Comment comment);
    Task<List<Comment>> GetAllComment();
    Task<Comment> GetCommentById (int id);
    Task<List<Comment>>GetCommentByPostId(int postId);
    Task<List<Comment>>GetCommentByUserId(int userId);
   
    }
}