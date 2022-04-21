using aim_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}