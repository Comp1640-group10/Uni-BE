using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uni_BackEnd_API.Data;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public IdeaController(ApplicationDbContext dbContext, IWebHostEnvironment environment)
        {

            _dbContext = dbContext;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Ideas);
        }
        [HttpGet("{ideaId}")]
        public IActionResult GetById(int ideaId)
        {
            var idea = _dbContext.Ideas.SingleOrDefault(c => c.id == ideaId);
            if (idea == null)
            {
                return NotFound();
            }
            return Ok(idea);
        }
        [HttpPost]
        public IActionResult Create(Idea newidea)
        {
            var currentUser = _dbContext.Users.SingleOrDefault(c => c.fullName == HttpContext.Session.GetString("userName"));

            var idea = new Idea();
            {
                idea.text = newidea.text;
                idea.filePath = newidea.filePath;
                idea.dateTime = DateTime.Now.Date;
                idea.userId = currentUser.id;
                idea.topicId = newidea.topicId;
                idea.categoryId = newidea.categoryId;
            }
            _dbContext.Ideas.Add(idea);
            _dbContext.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = idea
            });
        }
        [HttpPut("{ideaId}")]
        public IActionResult Update(int ideaId, Idea updateidea)
        {
            var idea = _dbContext.Ideas.SingleOrDefault(c => c.id == ideaId);
            if (idea == null)
            {
                return NotFound();
            }
            //update

            idea.text = updateidea.text;
            idea.filePath = updateidea.filePath;
            _dbContext.SaveChanges();
            return Ok(idea);
        }

        [HttpDelete("{ideaId}")]
        public IActionResult Delete(int ideaId)
        {
            var idea = _dbContext.Ideas.SingleOrDefault(c => c.id == ideaId);
            if (idea == null)
            {
                return NotFound();
            }
            //update

            _dbContext.Remove(idea);
            _dbContext.SaveChanges();
            return Ok();
        }
        //private string UploadFile(IFormFile file)
        //{
        //    string directoryPath = Path.Combine(_environment.ContentRootPath, "uploadFile");

        //    string filePath = Path.Combine(directoryPath, file.Name);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }
        //    return filePath;
        //}
    }
}
