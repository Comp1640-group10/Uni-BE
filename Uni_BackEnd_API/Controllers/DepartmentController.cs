using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uni_BackEnd_API.Data;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentController(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Departments);
        }
        [HttpPost]
        public IActionResult Create(Department newDepartment)
        {
            var department = new Department();
            {
                department.departmentName = newDepartment.departmentName;
            }
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = department
            });
        }
        [HttpPut("{deparmentId}")]
        public IActionResult Update(int deparmentId, Department updateDepartment)
        {
            var department = _dbContext.Departments.SingleOrDefault(c => c.id == deparmentId);
            if (department == null)
            {
                return NotFound();
            }
            //update

            department.departmentName = updateDepartment.departmentName;
            _dbContext.SaveChanges();
            return Ok(department);
        }

        [HttpDelete("{deparmentId}")]
        public IActionResult Delete(int deparmentId)
        {
            var department = _dbContext.Departments.SingleOrDefault(c => c.id == deparmentId);
            if (department == null)
            {
                return NotFound();
            }
            //update

            _dbContext.Remove(department);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
