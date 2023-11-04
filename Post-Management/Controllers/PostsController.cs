using Microsoft.AspNetCore.Mvc;
using Post_Management.Models;
using Post_Management.Models.Domain;
using Post_Management.Repository;
using System;

namespace Post_Management.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostRepository _postRepository;

        public PostsController(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var posts = _postRepository.GetAll();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var post = _postRepository.GetById(id);
                if (post == null)
                    return NotFound();
                return Ok(post);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public IActionResult Create(BlogPostModel post)
        {
            try
            {
                var createdPost = _postRepository.Create(post);
                return CreatedAtAction("GetById", new { id = createdPost.Id }, createdPost);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, BlogPostModel post)
        {
            try
            {
                if (!_postRepository.Update(id, post))
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (!_postRepository.Delete(id))
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
