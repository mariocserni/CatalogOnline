using CatalogOnlineWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogOnlineWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Studenti { get; set; }
        public DbSet<Disciplina> Discipline { get; set; }
        public DbSet<Contract> Contracte { get; set; }
        public DbSet<Admin> Admini { get; set; }
    }
}
