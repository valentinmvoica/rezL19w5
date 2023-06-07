using Data.DAL;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions
{
    public static class DalUtils
    {
        public static void AddDataAccessLayer(this IServiceCollection services, string? connString)
        {
            services.AddDbContext<StudentsDbContext>(options => options.UseSqlServer(connString));

            services.AddScoped<IDataAccessLayerService, DataAccessLayerService>();
        }
    }
}
