using Microsoft.EntityFrameworkCore;
using WebAPIPhong.Models;

namespace WebAPIPhong.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}