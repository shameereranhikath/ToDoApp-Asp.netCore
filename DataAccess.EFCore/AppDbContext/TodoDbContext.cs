using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.AppDbContext
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
