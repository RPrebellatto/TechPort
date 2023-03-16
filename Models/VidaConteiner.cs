using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TechPort.Models.Enums;

namespace TechPort.Models
{
    public class VidaConteiner
    {
        public int Id { get; set; }
        [Display(Name = "Container")]
        public int ConteinerId { get; set; }
        public Conteiner Conteiner { get; set; }
        [Display(Name = "Status")]
        public StatusConteiner StatusConteiner { get; set; }
        [Display(Name = "Viagem")]
        public int? ViagemId { get; set; }
        public Viagem? Viagem { get; set; }

        public string? Navio { get; set; }

        //public string? Navio { set { if (this.Viagem != null)
        //        {
        //            Navio = this.Viagem.Navio.Nome;
        //        }
        //                       }
        //                      get { return Navio; }           
        //                    }
        public Etapa Etapa {get; set; }
    
    }
}
