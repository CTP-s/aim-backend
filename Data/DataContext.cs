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

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}