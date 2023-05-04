using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TechPort.Models
{
    public class Motorista
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Motorista")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string CNH { get; set; }
    }
}