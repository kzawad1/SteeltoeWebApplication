using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteeltoeWebApplication.Models;

namespace SteeltoeWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoDbContext _dbContext;
        private readonly ILogger<TodoItemsController> _logger;

        public TodoItemsController(TodoDbContext dbContext, ILogger<TodoItemsController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _dbContext.TodoItems.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            if (id == 0)
            {
                var newItem = new TodoItem
                {
                    IsComplete = false,
                    Name = "A new auto-generated ToDo item"
                };

                _dbContext.TodoItems.Add(newItem);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Super secret id==0 was provided, so a new item was auto-added.");
                return Ok("Item created.");
            }

            var todoItem = await _dbContext.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}
