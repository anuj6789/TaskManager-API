
using TaskManager.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManager.API.Data;
using TaskManager.API.Models;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This is the key! It protects all endpoints in this controller.
    public class TasksController : ControllerBase
    {
        private readonly DataContext _context;

        public TasksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            // Get the current user's ID from the token
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var tasks = await _context.TaskItems
                                    .Where(t => t.UserId == userId)
                                    .ToListAsync();
            return Ok(tasks);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskCreateDto request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            // Create a new TaskItem from the DTO
            var newTask = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                DueDate = request.DueDate,
                UserId = userId // Set the user ID from the token
            };

            _context.TaskItems.Add(newTask);
            await _context.SaveChangesAsync();

            return Ok(newTask);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem updatedTask)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var task = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null)
            {
                return NotFound("Task not found or you do not have permission to edit it.");
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Status = updatedTask.Status;
            task.DueDate = updatedTask.DueDate;

            await _context.SaveChangesAsync();
            return Ok(task);
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var task = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null)
            {
                return NotFound("Task not found or you do not have permission to delete it.");
            }

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();

            return Ok("Task deleted successfully.");
        }
    }
}