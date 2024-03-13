namespace EventsConsoleApp.Domain;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Celular { get; set; }
    public int Idade { get; set; }
}