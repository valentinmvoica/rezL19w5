using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace rezL19w5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public SeedController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }
        /// <summary>
        /// Initializeaza DB-ul
        /// </summary>
        [HttpPost()]
        public void Seed() =>
            dal.Seed();

    }
}
