using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uni_BackEnd_API.Data;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,manager")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext) { 
        
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Categories);
        }
        [HttpGet("{CategoryId}")]
        public IActionResult GetById(int CategoryId)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.id == CategoryId);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Category newCategory)
        {          
            var category = new Category();
            {
                category.categoryName = newCategory.categoryName;
            }
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = category
            }) ;
        }
        [HttpPut("{CategoryId}")]
        public IActionResult Update(int CategoryId, Category updateCategory)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.id == CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            //update
            category.categoryName = updateCategory.categoryName;
            _dbContext.SaveChanges();

            return Ok(category);
        }
        [HttpDelete("{CategoryId}")]
        public IActionResult Delete(int CategoryId)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.id == CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            //update

            _dbContext.Remove(category);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
