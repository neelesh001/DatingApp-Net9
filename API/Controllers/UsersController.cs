using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            if (context.Users == null) return NotFound();

            var users = await context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id:int}")] // api/users/3
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            if (context.Users == null) return NotFound();

            var user = await context.Users.FindAsync(id);

            if (user == null) return NotFound();

            return user;
        }
    }
}
