
using System.Data.SqlTypes;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")] // api/users
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
     
        public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers() {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }
        [HttpGet("{id:int}")]
      
        public async Task<ActionResult<AppUser>> GetUser(int id) {
            return await _dataContext.Users.FindAsync(id);
        }
    }
   
}