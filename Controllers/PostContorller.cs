using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase 
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _postRepository;

        public PostController(ILogger<PostController> logger, IPostRepository repository)
        {
            _logger = logger;
            _postRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPost() 
        {
            return Ok(_postRepository.GetAllPosts());
        }

        [HttpGet]
        [Route("{postId:int}")]
        public ActionResult<Post> GetPostById(int postId) 
        {
            var post = _postRepository.GetPostById(postId);
            if (post == null) {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Post> CreatePost(Post post) 
        {
            if (!ModelState.IsValid || post == null) {
                return BadRequest();
            }
            var newPost = _postRepository.CreatePost(post);
            return Created(nameof(GetPostById), newPost);
        }

        [HttpPut]
        [Route("{postId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Post> UpdatePost(int postId, Post post) 
        {
            if (!ModelState.IsValid || post == null) {
                return BadRequest();
            }
            return Ok(_postRepository.UpdatePost(post));
        }

        [HttpDelete]
        [Route("{postId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeletePost(int postId) 
        {
            _postRepository.DeletePostById(postId); 
            return NoContent();
        }
    }
}