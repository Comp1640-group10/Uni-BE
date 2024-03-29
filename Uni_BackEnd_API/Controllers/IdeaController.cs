﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
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
        public IActionResult Create(newIdeaModel newidea)
        {
            var currentUser = _dbContext.Users.SingleOrDefault(c => c.fullName == HttpContext.Session.GetString("userName"));
            var topic = _dbContext.Topics.SingleOrDefault(c => c.id == newidea.topicId);
            if (DateTime.Now < topic.closureDate)
            {
                var idea = new Idea();
                {
                    idea.name = newidea.name;
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
            else
            {
                return BadRequest();
            }

        }
        [HttpPut("{ideaId}")]
        public IActionResult Update(int ideaId, newIdeaModel updateidea)
        {
            var idea = _dbContext.Ideas.SingleOrDefault(c => c.id == ideaId);
            if (idea == null)
            {
                return NotFound();
            }
            //update
            idea.name = updateidea.name;
            idea.text = updateidea.text;
            idea.filePath = updateidea.filePath;
            idea.topicId = updateidea.topicId;
            idea.categoryId = updateidea.categoryId;
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
        [HttpGet("CSV")]
        public IActionResult ExportCSV()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Idea Name,View,Like");
            var Ideas = _dbContext.Ideas;
            foreach(var idea in Ideas)
            {
                var viewCount = _dbContext.Views.Where(v => v.ideaId == idea.id).ToList().Count();
                var LikeCount = _dbContext.Views.Where(v => v.ideaId == idea.id).ToList().Count();
                builder.AppendLine($"{idea.name},{viewCount},{LikeCount}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()),"text/csv","Idea.csv");
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
