namespace TechPort.Models

public class Equipamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        Equipamento equipamento = new Equipamento();

        Console.WriteLine("Informe o ID do equipamento:");
        equipamento.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o nome do equipamento:");
        equipamento.Nome = Console.ReadLine();

        Console.WriteLine("Informe o tipo do equipamento:");
        equipamento.Tipo = Console.ReadLine();

        Console.WriteLine("\nDados do equipamento:");
        Console.WriteLine("ID: " + equipamento.Id);
        Console.WriteLine("Nome: " + equipamento.Nome);
        Console.WriteLine("Tipo: " + equipamento.Tipo);

    

        Console.ReadLine(); 
    }
}
