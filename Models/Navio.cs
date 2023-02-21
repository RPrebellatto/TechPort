using System.ComponentModel.DataAnnotations;

namespace TechPort.Models
{
    public class Navio
    {
        public int Id { get; set; }
        [Display(Name = "Navio")]
        [Required]
        public string? Nome { get; set; }
        [Display(Name = "Empresa")]
        public int? EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
        public IList<Viagem>? Viagens { get; set;}
    }
}
