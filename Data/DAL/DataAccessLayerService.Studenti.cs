using Data.DAL;
using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Data.DAL
{
    /// <summary>
    /// Data access layer - implemented with C#
    /// </summary>
    internal partial class DataAccessLayerService : IDataAccessLayerService
    {
        private readonly StudentsDbContext ctx;
        public DataAccessLayerService(StudentsDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Student> GetAllStudents(bool includeNote=true) { 
            if (includeNote)
            {
                return ctx.Studenti.Include(s=>s.Note).ToList();
            }
            else
            {
                return ctx.Studenti.ToList();
            }
        }

        public Student GetStudentById(int id) {
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new InvalidIdException($"invalid student id {id}");
            }
            return student;
        }

        public Student CreateStudent(Student student)
        {

            if (ctx.Studenti.Any(s => s.Id == student.Id))
            {
                throw new DuplicatedIdException($"duplicated student id");
            }

            ctx.Add(student);
            ctx.SaveChanges();

            return student;
        }
        public Student UpdateStudent(Student studentToUpdate)
        {
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == studentToUpdate.Id);
            if (student == null)
            {
                //throw exception
            }

            student.Nume = studentToUpdate.Nume;
            student.Varsta = studentToUpdate.Varsta;

            ctx.SaveChanges();

            return student;
        }
        public bool UpdateOrCreateStudentAddress(int studentId, Adresa nouaAdresa)
        {
            var student = ctx.Studenti.Include(s => s.Adresa).FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                //throw exception
            }

            var created = false;
            if (student.Adresa == null)
            {
                student.Adresa = new Adresa();
                created = true;
            }
            student.Adresa.Numar = nouaAdresa.Numar;
            student.Adresa.Strada = nouaAdresa.Strada;
            student.Adresa.Oras = nouaAdresa.Oras;

            ctx.SaveChanges();
            return created;
        }

        public void DeleteStudent(int studentId)
        {
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new InvalidIdException($"student not found {studentId}");
            }

            ctx.Studenti.Remove(student);

            ctx.SaveChanges();
        }

        public void DeleteStudent2(int studentId)
        {
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new InvalidIdException($"student not found {studentId}");
            }

            ctx.Studenti.Remove(student);
            ctx.SaveChanges();
        }

    }
}
