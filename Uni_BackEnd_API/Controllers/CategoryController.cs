using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> categories = new List<Category>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int categoryId)
        {
            var category = categories.SingleOrDefault(c => c.id == categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            var category = new Category();
            {
                category.categoryName = newCategory.categoryName;
            }
            categories.Add(category);
            return Ok(new
            {
                Success = true,
                Data = category
            }) ;
        }
        [HttpPut("{id}")]
        public IActionResult Update(int categoryId, Category updateCategory)
        {
            var category = categories.SingleOrDefault(c => c.id == categoryId);
            if (category == null)
            {
                return NotFound();
            }
            //update

            category.categoryName = updateCategory.categoryName;

            return Ok(category);
        }
    }
}
