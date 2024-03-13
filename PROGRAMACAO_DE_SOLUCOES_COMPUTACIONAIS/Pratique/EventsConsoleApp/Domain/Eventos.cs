using EventsConsoleApp.Domain.Enums;

namespace EventsConsoleApp.Domain;

public class Eventos
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public Categorias Categorias { get; set; }
    public DateTime DataEvento { get; set; }
}