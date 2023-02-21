namespace TechPort.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Conteiner>? Conteiners { get; set;}
        public IList<Navio>? Navios { get; set;}
    }
}
