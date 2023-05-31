using System.ComponentModel.DataAnnotations;

namespace rezL19w5.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class NotaToCreateDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Range(1,10)]
        public int Valoare { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Range(0, int.MaxValue)]
        public int StudentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CursId { get; set; }
    }
}
