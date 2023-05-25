using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace rezL19w5.Dtos
{
    public class StudentToCreateDto
    {

        [Required(AllowEmptyStrings =false,ErrorMessage =" numele nu poate fi gol")]
        public string Nume { get; set; }

        [Range(1,100)]
        public int Varsta { get; set; }
    }
}
