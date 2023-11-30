using Data.DAL;
using Data.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rezL19w5.Dtos;

namespace rezL19w5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IDataAccessLayerService dataAccessLayerService;
        public NoteController(IDataAccessLayerService dataAccessLayerService)
        {
            this.dataAccessLayerService = dataAccessLayerService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nota"></param>
        [HttpPost]
        public IActionResult AddNota([FromBody] NotaToCreateDto nota)
        {
                dataAccessLayerService.AcordaNota(nota.Valoare, nota.StudentId, nota.CursId);
                return Ok();
            }
        }
   }

