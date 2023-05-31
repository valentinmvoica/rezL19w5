using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace rezL19w5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursuriController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public CursuriController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }
        /// <summary>
        /// Initializeaza DB-ul
        /// </summary>
        [HttpPost()]
        public void AddCurs([FromBody]string cursName) =>
           dal.AddCurs(cursName);
        [HttpGet()]
        public List<Curs> GetAll() =>
           dal.GetAllCursuri();

    }
}
