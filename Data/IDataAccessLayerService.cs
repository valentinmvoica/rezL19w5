using Data.Models;

namespace Data
{
    public interface IDataAccessLayerService
    {
        Student CreateStudent(Student student);
        void DeleteStudent(int studentId);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void Seed();
        bool UpdateOrCreateStudentAddress(int studentId, Adresa nouaAdresa);
        Student UpdateStudent(Student studentToUpdate);
    }
}