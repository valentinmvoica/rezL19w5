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
        public Curs AddCurs(string numeCurs)
        {
            var curs = new Curs { Nume = numeCurs };
            ctx.Cursuri.Add(curs);
            ctx.SaveChanges();
            return curs;
        }
        public List<Curs> GetAllCursuri() =>
            ctx.Cursuri.ToList();

    }
}
