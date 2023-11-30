using Data.DAL;
using Data.Exceptions;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rezL19w5.Dtos;
using rezL19w5.Utils;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace rezL19w5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public StudentiController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }
       
        /// <summary>
        /// Returns all the students in the db
        /// </summary>
        [HttpGet]
        public IEnumerable<StudentToGetDto> GetAllStudents()
        {
            var allStudents = dal.GetAllStudents();

            return allStudents.Select(s => s.ToDto()).ToList();
        }


        /// <summary>
        /// Gets a student by id
        /// </summary>
        /// <param name="id">id of the student</param>
        /// <returns>student data</returns>
        [HttpGet("/id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

        public ActionResult<StudentToGetDto> GetStudentById([Range(10, int.MaxValue)] int id)=>
            Ok(dal.GetStudentById(id).ToDto());

        [HttpGet("statistics")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentStatisticsDto>))]
        public IActionResult GetStudentsStatistics()
        {
            var students = dal.GetAllStudents(true)
                .ToList();

            return Ok(
                students.Select(s =>
                {
                    return new StudentStatisticsDto
                    {
                        Id = s.Id,
                        Nume = s.Nume,
                        Varsta = s.Varsta,
                        Media = s.Note.Average(n => n.Valoare)
                    };
                }).ToList()
                );
        }
            

        /// <summary>
        /// Creates a student
        /// </summary>
        /// <param name="studentToCreate">student to create data</param>
        /// <returns>created student data</returns>
        [HttpPost]
        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studentToCreate) =>
            dal.CreateStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns></returns>
        [HttpPatch]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate) =>
            dal.UpdateStudent(studentToUpdate.ToEntity()).ToDto();


        /// <summary>
        /// sddshjjklasdjklasdkljjasldk
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressToUpdate"></param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdateStudentAddress([FromRoute] int id, [FromBody] AddressToUpdateDto addressToUpdate)
        {

            if (dal.UpdateOrCreateStudentAddress(id, addressToUpdate.ToEntity()))
            {
                return Created("succeess", null);
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 0)
            {
                return BadRequest("id cannot be 0");
            }
            try
            {
                dal.DeleteStudent(id);
            }
            catch (InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }

    }
}
