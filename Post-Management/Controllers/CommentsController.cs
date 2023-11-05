using Microsoft.AspNetCore.Mvc;
using Post_Management.Models;
using Post_Management.Repository;

namespace Post_Management.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly CommentManagementService _commentManagementService; 
        public CommentsController(CommentManagementService commentManagementService)
        {
            _commentManagementService = commentManagementService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var posts = _commentManagementService.GetAllComments();
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
                var post = _commentManagementService.GetCommentsById(id);
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
        public IActionResult Create( CommentModel comment)
        {
            try
            {
                var createdPost = _commentManagementService.CreateComment(comment);
                return CreatedAtAction("GetById", new { id = createdPost.Id }, createdPost);
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
                if (!_commentManagementService.DeleteComment(id))
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CommentModel post)
        {
            try
            {
                if (!_commentManagementService.Update(id, post))
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
