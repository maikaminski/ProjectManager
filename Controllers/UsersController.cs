using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Data;
using ProjectManager.API.Models;
using ProjectManager.API.DTOs;

namespace ProjectManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {
        var users = await _context.Users
            .Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            })
            .ToListAsync();

        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser(CreateUserDTO dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Projects = new List<Project>()
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var userDTO = new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };

        return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, userDTO);
    }
}
