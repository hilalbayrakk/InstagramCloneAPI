using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Interfaces
{
    public interface IPostService
    {
    Task<Post> AddPost(Post post);
    Task<Post> UpdatePost(int id, Post post);
    Task DeletePost(Post post);
    Task<List<Post>> GetAllPost();
    Task<Post>GetById(int postId);
    Task<List<Post>>GetAllPostByUserName(string userName);
    }
}