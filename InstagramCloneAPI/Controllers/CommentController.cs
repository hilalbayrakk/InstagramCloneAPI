using InstagramCloneAPI.Interfaces;
using InstagramCloneAPI.Model;
using Microsoft.AspNetCore.Mvc;
namespace InstagramCloneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("add")]
        public async Task<Comment> Add(Comment comment)
        {
            await _commentService.AddComment(comment);
            return comment;
        }

        [HttpPut("delete")]
        public async Task Delete(Comment comment)
        {
            await _commentService.DeleteComment(comment);
        }

        [HttpPut("update")]
        public async Task<Comment> Update(int id, Comment comment)
        {
            var result = await _commentService.UpdateComment(id, comment);
            return comment;
        }

        [HttpGet("getall")]
        public async Task<List<Comment>> GetAll()
        {
            return await _commentService.GetAllComment();
        }

        [HttpGet("getbyid")]
        public async Task<Comment> GetCommentById(int id)
        {
            var result = await _commentService.GetCommentById(id);
            return result;
        }
        [HttpGet("getbypostid")]
        public async Task<Comment> GetCommentByPostId(int postId)
        {
            return await _commentService.GetCommentById(postId);
        }
        [HttpGet("getbyuserid")]
        public async Task<Comment> GetCommentByUserId(int userId)
        {
            return await _commentService.GetCommentById(userId);
        }
    }
}
