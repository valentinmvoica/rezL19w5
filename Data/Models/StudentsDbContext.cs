using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    internal class StudentsDbContext : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public StudentsDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\v\source\repos\rezL19w5\Data\Students.mdf;Integrated Security=True");
        }
    }
}
