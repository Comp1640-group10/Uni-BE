using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uni_BackEnd_API.Data;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public ViewController(ApplicationDbContext dbContext, IWebHostEnvironment environment)
        {

            _dbContext = dbContext;
            _environment = environment;
        }
        [HttpGet("{ideaId}")]
        public IActionResult GetAll(int ideaId)
        {
            var view = _dbContext.Views.Where(w => w.ideaId == ideaId).ToList();
            int viewCount = view.Count();
            return Ok(new
            {
                Success = true,
                Message = "Success",
                Count = viewCount
            });
        }
        [HttpPost("{ideaId}")]
        public IActionResult Create(int ideaId)
        {
            var currentUser = _dbContext.Users.SingleOrDefault(c => c.fullName == HttpContext.Session.GetString("userName"));
            if (currentUser == null)
            {
                return BadRequest();
            }
            var view = new View();
            {
                view.visitTime = DateTime.Now.Date;
                view.userId = currentUser.id;
                view.ideaId = ideaId;
            }
            _dbContext.Views.Add(view);
            _dbContext.SaveChanges();
            var react = _dbContext.Reacts.SingleOrDefault(c => c.ideaId == ideaId && c.userId == currentUser.id);
            if (react == null)
            {
                var newReact= new React();
                {
                    newReact.userId = currentUser.id;
                    newReact.ideaId = ideaId;
                    newReact.react = ReactOption.NOREACT;
                }
                _dbContext.Reacts.Add(newReact);
                _dbContext.SaveChanges();
            }

            return Ok(new
            {
                Success = true,
                Data = view
            });

        }
    }
}
