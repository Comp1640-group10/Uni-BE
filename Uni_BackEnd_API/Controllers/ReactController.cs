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
        [HttpGet("{ideaId}/Like")]
        public IActionResult GetAllLike(int ideaId)
        {
            var like = _dbContext.Reacts.Where(w => w.ideaId == ideaId && w.react == ReactOption.LIKE).ToList();
            int likeCount = like.Count();
            return Ok(new
            {
                Success = true,
                Message = "Success",
                Count = likeCount
            });
        }
        [HttpGet("{ideaId}/DisLike")]
        public IActionResult GetAllDisLike(int ideaId)
        {
            var disLike = _dbContext.Reacts.Where(w => w.ideaId == ideaId && w.react == ReactOption.DISLIKE).ToList();
            int disLikeCount = disLike.Count();
            return Ok(new
            {
                Success = true,
                Message = "Success",
                Count = disLikeCount
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
