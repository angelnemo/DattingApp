using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;


[ApiController]
[Route("api/[controller]")]
public class UsersController:ControllerBase {

    private readonly DataContext _context;
    public UsersController(DataContext context ) { /*es DataContext, la misma que esta referenciando en Program.cs*/
        _context = context;    
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
        var users = await _context.Users.ToListAsync();
        return users;
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id){
        var user = await _context.Users.FindAsync(id);
        if (user == null ) {
            return NotFound();
        }
        return user;
    }

}