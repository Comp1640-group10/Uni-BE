using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uni_BackEnd_API.Data;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public RoleController(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Roles);
        }
        [HttpPost]
        public IActionResult Create(Role newRole)
        {
            var role = new Role();
            {
                role.roleName = newRole.roleName;
            }
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = role
            });
        }
        [HttpPut("{roleId}")]
        public IActionResult Update(int roleId, Role updateRole)
        {
            var role = _dbContext.Roles.SingleOrDefault(c => c.id == roleId);
            if (role == null)
            {
                return NotFound();
            }
            //update

            role.roleName = updateRole.roleName;
            _dbContext.SaveChanges();
            return Ok(role);
        }

        [HttpDelete("{roleId}")]
        public IActionResult Delete(int roleId)
        {
            var role = _dbContext.Roles.SingleOrDefault(c => c.id == roleId);
            if (role == null)
            {
                return NotFound();
            }
            //update

            _dbContext.Remove(role);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
