using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TechPort.Models
{
    public class Conteiner
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        [Display(Name ="Container")]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Display(Name = "Empresa")]
        public int? EmpresaId { get; set; }

        public Empresa? Empresa { get; set; }

        public IList<VidaConteiner>? VidaConteinerList { get;set; }
    }
}
