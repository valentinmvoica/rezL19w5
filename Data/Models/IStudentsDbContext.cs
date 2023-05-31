using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public interface IStudentsDbContext
    {
        DbSet<Adresa> Adrese { get; set; }
        DbSet<Student> Studenti { get; set; }
    }
}