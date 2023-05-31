using Data.DAL;
using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public void AcordaNota(int valoare, int studentId, int cursId)
        {
            if (!ctx.Studenti.Any(s=>s.Id == studentId))
            {
                throw new InvalidIdException($"id student invalid {studentId}");
            }
            if (!ctx.Cursuri.Any(s => s.Id == cursId))
            {
                throw new InvalidIdException($"id curs invalid {studentId}");
            }

            ctx.Note.Add(new Nota { Valoare = valoare, StudentId = studentId, CursId=cursId });
            ctx.SaveChanges();
        }

    }
}
