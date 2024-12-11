using Microsoft.EntityFrameworkCore;
using TwTodos.Models;

namespace TwTodos.Contexts;

public class TwTodosContexts : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = c:\\Users\\kal_r\\Documents\\TwTodos\\todos.sqlite");
    }
}




 