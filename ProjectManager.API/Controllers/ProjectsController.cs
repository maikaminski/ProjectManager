using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Data;
using ProjectManager.API.DTOs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProjectsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Projects
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectReadDTO>>> GetAll()
    {
        var projects = await _context.Projects
            .Select(p => new ProjectReadDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            })
            .ToListAsync();

        return Ok(projects);
    }

    // POST: api/Projects
    [HttpPost]
    public async Task<ActionResult<ProjectReadDTO>> Create(ProjectCreateDTO dto)
    {
        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description,
            UserId = dto.UserId
        };

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        var readDto = new ProjectReadDTO
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description
        };

        return CreatedAtAction(nameof(GetAll), new { id = readDto.Id }, readDto);
    }
}
