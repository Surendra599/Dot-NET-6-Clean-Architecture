using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
    }
}