using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Interfaces
{
    public interface ICommentRepository
    {
    Task<Comment> AddComment(Comment comment);
    Task<Comment> UpdateComment(Comment comment);
    Task DeleteComment(Comment prodcommentuct);
    Task<List<Comment>> GetAllComment();
    }
}