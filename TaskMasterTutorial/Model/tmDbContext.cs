using Microsoft.EntityFrameworkCore;

namespace TaskMasterTutorial.Model;

public class tmDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source = USER-PC\SQLEXPRESS; Initial Catalog = TaskMasterDb; User ID= na; Password=****; TrustServerCertificate=true;");
    }

    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<Task> Tasks => Set<Task>();
}
