using System.ComponentModel.DataAnnotations;
using TechPort.Models.Enums;

namespace TechPort.Models
{
    public class Viagem
    {
        public int Id { get; set; }
        [Display(Name ="Código")]
        public string Codigo { get; set; }
        [Display(Name ="Navio")]
        public int NavioId { get; set; }
        public Navio Navio { get; set; }
        [Display(Name ="Tipo de Viagem")]
        public TipoViagem TipoViagem { get; set; }
    }

    //public enum TipoViagem
    //{
    //    Importacao,
    //    Exportacao,
    //    Transbordo
    //}



}
