using Microsoft.EntityFrameworkCore;

namespace Status.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<Product> Products {get; set;}

    public DbSet<Review> Reviews {get;set;}
}