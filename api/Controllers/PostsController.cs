using System.Collections.Generic;
using core.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace api.Controllers
{
    [Route("api/v1/post")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostService _service; 
        public PostsController(IPostService service)
        {
            _service =  service; 
        }

        [HttpGet("/")]
        public IEnumerable<Post> GetPost()
        {
            return  _service.GetAllPosts();
        }

        [HttpGet("/{id:int}")]
        public Post GetPostById(int id)
        {
            return _service.GetPostById(id); 
        }

        [HttpPost("/")]
        public void AddPost(Post post)
        {
            _service.AddPost(post);
        }

        [HttpDelete("/")]
        public void DeletePost(Post post)
        {
            _service.DeletePost(post);
        }
        
        [HttpPut("/")]
        public void UpdatePost(Post post)
        {
            _service.UpdatePost(post);
        }
    }
}
