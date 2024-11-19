using Microsoft.EntityFrameworkCore;

namespace WebApplication.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
    : base(options)
        { }
        public DbSet<Models.Item> Items { get; set; }
    }
}
