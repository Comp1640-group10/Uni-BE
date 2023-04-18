using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Uni_BackEnd_API.Data;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IConfiguration _config;
        public UserController(ApplicationDbContext dbContext, IConfiguration config)
        {
            _config = config;
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Users);
        }
        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            var user = _dbContext.Users.SingleOrDefault(c => c.id == userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpPost]
        public IActionResult CreateAccount([FromBody] User user)
        {
            var newUser = new User();
            {
                newUser.fullName = user.fullName;
                newUser.password = user.password;
                newUser.departmentId = user.departmentId;
                newUser.roleId = user.roleId;
            }
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = newUser
            });
        }
        [HttpPut("{userId}")]
        public IActionResult UpdateAccount([FromBody] User user,int userId)
        {
            var updateUser = _dbContext.Users.SingleOrDefault(s => s.id == userId);
            if (updateUser == null)
            {
                return NotFound();
            }
                updateUser.fullName = user.fullName;
                updateUser.password = user.password;
                updateUser.departmentId = user.departmentId;
                updateUser.roleId = user.roleId;
            _dbContext.Users.Update(updateUser);
            _dbContext.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = updateUser
            });
        }
        [HttpDelete("{userId}")]
        public IActionResult DeleteAccount(int userId)
        {
            var user= _dbContext.Users.SingleOrDefault(s => s.id == userId);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return Ok(new
            {
                Success = true,
                Message = "Account has been removed"
            });
        }

        [HttpPost("Login")]
        public IActionResult Validate (LoginModel loginModel)
        {
            var user = _dbContext.Users.SingleOrDefault(p => p.fullName.ToUpper() == loginModel.fullName.ToUpper() && p.password == loginModel.password);
            if(user == null)
            {
                return Ok(new
                {
                    Success = false,
                    Message = "Invalid user name or password"
                });
            }
            var token = GenerateToken(user);
            if (token == "not Found")
                return NotFound(new
                {
                    Message = "Role Not Found"
                });
            return Ok(new
            {
                Success = true,
                Message = "Success",
                Data = token,
                Role = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.SingleOrDefault(n => n.Type == ClaimTypes.Role).Value.ToString()
            }) ;
        }
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var role = _dbContext.Roles.SingleOrDefault(p => p.id == user.roleId);
            if(role == null)
            {
                return "not Found";
            }
            var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.fullName));
                claims.Add(new Claim(ClaimTypes.Role, role.roleName));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            HttpContext.Session.SetString("userName", user.fullName);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
