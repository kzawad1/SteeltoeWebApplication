using Microsoft.EntityFrameworkCore;

namespace SteeltoeWebApplication.Models
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }
    }
}
