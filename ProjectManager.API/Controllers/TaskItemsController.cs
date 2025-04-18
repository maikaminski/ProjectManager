using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Data;
using ProjectManager.API.DTOs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskItemsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/TaskItems
        [HttpPost]
        public async Task<ActionResult<TaskItemReadDto>> CreateTaskItem(TaskItemCreateDto taskItemDto)
        {
            var taskItem = new TaskItem
            {
                Title = taskItemDto.Title,
                Status = taskItemDto.Status,
                ProjectId = taskItemDto.ProjectId
            };

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            var readDto = new TaskItemReadDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Status = taskItem.Status,
                ProjectId = taskItem.ProjectId
            };

            return CreatedAtAction(nameof(GetTaskItemById), new { id = taskItem.Id }, readDto);
        }

        // GET: api/TaskItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemReadDto>>> GetAllTaskItems()
        {
            var taskItems = await _context.TaskItems
                .Select(t => new TaskItemReadDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Status = t.Status,
                    ProjectId = t.ProjectId
                })
                .ToListAsync();

            return Ok(taskItems);
        }

        // GET: api/TaskItems/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemReadDto>> GetTaskItemById(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null)
                return NotFound();

            var readDto = new TaskItemReadDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Status = taskItem.Status,
                ProjectId = taskItem.ProjectId
            };

            return Ok(readDto);
        }

        // PUT: api/TaskItems/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskItem(int id, TaskItemCreateDto taskItemDto)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
                return NotFound();

            taskItem.Title = taskItemDto.Title;
            taskItem.Status = taskItemDto.Status;
            taskItem.ProjectId = taskItemDto.ProjectId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/TaskItems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
                return NotFound();

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
