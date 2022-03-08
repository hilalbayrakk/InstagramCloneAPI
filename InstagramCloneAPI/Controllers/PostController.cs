using InstagramCloneAPI.Interfaces;
using InstagramCloneAPI.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost("add")]
    public async Task<Post> Add(Post post)
    {
        await _postService.AddPost(post);
        return post;
    }

    [HttpPut("delete")]
    public async Task Delete(Post post)
    {
        await _postService.DeletePost(post);
    }

    [HttpPut("update")]
    public async Task<Post> Update(int id, Post post)
    {
        var result = await _postService.UpdatePost(id, post);
        return result;
    }

    [HttpGet("getall")]
    public async Task<List<Post>> GetAll()
    {
        return await _postService.GetAllPost();
    }

    [HttpGet("getbyid")]
    public async Task<Post>GetById(int id)
    {
        return await _postService.GetById(id);
    }

    [HttpGet("getbyusername")]
    public async Task<List<Post>>GetPostByUserName(string userName)
    {
        return await _postService.GetAllPostByUserName(userName);
    }

}


