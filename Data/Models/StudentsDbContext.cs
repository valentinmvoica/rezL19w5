using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class StudentsDbContext : DbContext, IStudentsDbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
