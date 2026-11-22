using BookKeep.Models;
using Microsoft.EntityFrameworkCore;

namespace BookKeep.Database;

public  class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options){}
    
    public DbSet<Book> Books {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet <ReadingProgress> ReadingProgresses {get; set;}
}