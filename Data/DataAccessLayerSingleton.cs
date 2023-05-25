using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataAccessLayerSingleton
    {
        #region singleton
        private DataAccessLayerSingleton()
        {
        }
        private static DataAccessLayerSingleton instance;
        public static DataAccessLayerSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccessLayerSingleton();
                }
                return instance;
            }
        }
        #endregion

        #region seed
        public void Seed()
        {
            using var ctx = new StudentsDbContext();

            ctx.Add(new Student
            {
                Nume = "Marin Chitac",
                Varsta = 43,
                Adresa = new Adresa
                {
                    Oras = "Iasi",
                    Strada = "Revolutiei",
                    Numar = 32
                }
            });

            ctx.Add(new Student
            {
                Nume = "Florin Dumitrescu",
                Varsta = 38,
                Adresa = new Adresa
                {
                    Oras = "Bucuresti",
                    Strada = "Pietei",
                    Numar = 13
                }
            });
            ctx.Add(new Student
            {
                Nume = "Ionel Lupu",
                Varsta = 23,
                Adresa = new Adresa
                {
                    Oras = "Cluuuj",
                    Strada = "Centrala",
                    Numar = 14
                }
            });
            ctx.Add(new Student
            {
                Nume = "Mihaela Popa",
                Varsta = 18,
                Adresa = new Adresa
                {
                    Oras = "Deva",
                    Strada = "Principala",
                    Numar = 4
                }
            });

            ctx.SaveChanges();
        }
        #endregion

        public IEnumerable<Student> GetAllStudents()
        {
            using var ctx = new StudentsDbContext();
            return ctx.Studenti.ToList();
        }
        public Student GetStudentById(int id)
        {
            using var ctx = new StudentsDbContext();
            return ctx.Studenti.FirstOrDefault(s => s.Id == id);
        }

        public Student CreateStudent(Student student)
        {
            using var ctx = new StudentsDbContext();

            if (ctx.Studenti.Any(s => s.Id == student.Id))
            {
                //todo throw exception
            }

            ctx.Add(student);
            ctx.SaveChanges();

            return student;
        }

        public Student UpdateStudent(Student studentToUpdate)
        {
            using var ctx = new StudentsDbContext();


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
            using var ctx = new StudentsDbContext();


            var student = ctx.Studenti.Include(s=>s.Adresa).FirstOrDefault(s => s.Id == studentId);
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
            using var ctx = new StudentsDbContext();

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
