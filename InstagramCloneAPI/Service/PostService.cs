using InstagramCloneAPI.Interfaces;
using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> AddPost(Post post)
        {
            return await _postRepository.AddPost(post);
        }

        public async Task DeletePost(Post post)
        {
            var result = _postRepository.GetById(post.Id);
            if (result != null)
            {
                _postRepository.DeletePost(post);
            }
            throw new Exception("Böyle bir post bulunamadı.");
        }

        public async Task<List<Post>> GetAllPost()
        {
            return await _postRepository.GetAllPost();
        }

        public async Task<Post> UpdatePost(int id, Post post)
        {
            var updatedPost = await _postRepository.GetById(id);
            if (updatedPost != null)
            {
                updatedPost = post;
                await _postRepository.UpdatePost(post);
                return post;
            }
            throw new InvalidOperationException("Güncellenecek öğrenci bulunamadı!");
        }

        public async Task<List<Post>> GetAllPostByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetById(int postId)
        {
            throw new NotImplementedException();
        }
    }
}