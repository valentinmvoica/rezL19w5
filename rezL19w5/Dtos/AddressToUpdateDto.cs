using System.ComponentModel.DataAnnotations;

namespace rezL19w5.Dtos
{
    /// <summary>
    /// Addres that will be used for update
    /// </summary>
    public class AddressToUpdateDto
    {
        /// <summary>
        /// Street name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Strada nu poate fi goala")]
        public string Strada { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "orasul nu poate fi gol")]
        public string Oras { get; set; }
        /// <summary>
        /// Street no
        /// </summary>
        [Range(1,int.MaxValue)]
        public int Numar { get; set; }
    }
}
