using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uni_BackEnd_API.Data;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public ReactController(ApplicationDbContext dbContext, IWebHostEnvironment environment)
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
        [HttpPut("{ideaId}/Like")]
        public IActionResult Like(int ideaId)
        {
            var currentUser = _dbContext.Users.SingleOrDefault(c => c.fullName == HttpContext.Session.GetString("userName"));
            if (currentUser == null)
            {
                return BadRequest();
            }
            var react = _dbContext.Reacts.SingleOrDefault(c => c.ideaId == ideaId && c.userId == currentUser.id);
            if (react == null)
            {
                return BadRequest();
            }
            if(react.react == ReactOption.LIKE)
            {
                react.react = ReactOption.NOREACT;
            }
            else
            {
                react.react = ReactOption.LIKE;
            }
            _dbContext.Reacts.Update(react);
            _dbContext.SaveChanges();
            return Ok();

        }
        [HttpPut("{ideaId}/DisLike")]
        public IActionResult DisLike(int ideaId)
        {
            var currentUser = _dbContext.Users.SingleOrDefault(c => c.fullName == HttpContext.Session.GetString("userName"));
            if (currentUser == null)
            {
                return BadRequest();
            }
            var react = _dbContext.Reacts.SingleOrDefault(c => c.ideaId == ideaId && c.userId == currentUser.id);
            if (react == null)
            {
                return BadRequest();
            }
            if (react.react == ReactOption.DISLIKE)
            {
                react.react = ReactOption.NOREACT;
            }
            else
            {
                react.react = ReactOption.DISLIKE;
            }
            _dbContext.Reacts.Update(react);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
