using aim_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}