using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uni_BackEnd_API.Data;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmtController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public CmtController(ApplicationDbContext dbContext, IWebHostEnvironment environment)
        {

            _dbContext = dbContext;
            _environment = environment;
        }
        [HttpGet("{ideaId}")]
        public IActionResult GetAll(int ideaId)
        {
            var comments = _dbContext.Comments.Where(w => w.ideaId == ideaId).ToList();
            return Ok(comments);
        }
        [HttpPost("{ideaId}")]
        public IActionResult Create([FromBody] CmtModel newComment,int ideaId)
        {
            var currentUser = _dbContext.Users.SingleOrDefault(c => c.fullName == HttpContext.Session.GetString("userName"));
            var comment = new Comment();
            {
                comment.Text = newComment.Text;
                comment.dateTime = DateTime.Now.Date;
                comment.userId = currentUser.id;
                comment.ideaId = ideaId;
            }
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = comment
            });
        }
        [HttpPut("{ideaId}/cmtId")]
        public IActionResult Update(int ideaId, int cmtId, CmtModel updateComment)
        {
            var currentUser = _dbContext.Users.SingleOrDefault(c => c.fullName == HttpContext.Session.GetString("userName"));
            var comment = _dbContext.Comments.SingleOrDefault(c => c.id == cmtId);
            if (comment != null && currentUser != null && comment.userId != currentUser.id)
            {
                return BadRequest();
            }
            if (comment == null)
            {
                return NotFound();
            }
            //update

            comment.Text = updateComment.Text;
            comment.userId = currentUser.id;
            comment.ideaId = ideaId;
            comment.dateTime = DateTime.Now.Date;
            _dbContext.SaveChanges();
            return Ok(comment);
        }
        [HttpDelete("{ideaId}/cmtId")]
        public IActionResult Delete(int ideaId, int cmtId)
        {
            var currentUser = _dbContext.Users.SingleOrDefault(c => c.fullName == HttpContext.Session.GetString("userName"));
            var comment = _dbContext.Comments.SingleOrDefault(c => c.id == cmtId);
            if (comment != null && currentUser != null && comment.userId != currentUser.id)
            {
                return BadRequest();
            }
            if (comment == null)
            {
                return NotFound();
            }
            //update

            _dbContext.Remove(comment);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
