using Data.DAL;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public void Seed()
        {
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
    }
}
