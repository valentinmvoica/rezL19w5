using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    internal class StudentsDbContext : DbContext, IStudentsDbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public DbSet<Nota> Note { get; set; }
        public DbSet<Curs> Cursuri { get; set; }
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
