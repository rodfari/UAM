using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using EventsConsoleApp.Domain;
using EventsConsoleApp.Domain.Enums;

namespace EventsConsoleApp.ConsoleInterface;

public class EventoUI
{
    EventsDataManager manager = new EventsDataManager();

    public async Task<string> ListarEventosAsync()
    {
        EventsDataManager eventsData = new EventsDataManager();
        string eventos = await eventsData.ListarAsync();
        if (!string.IsNullOrEmpty(eventos))
        {
            return eventos.Replace(";", "    ");
        }
        eventos = "\n\nNÃO EXISTE NENHUM EVENTO CADASTRADO!\n\n";
        return eventos;
    }

    

    public async Task CriarEvento()
    {

        string nomeEvento, endereco;
        Console.WriteLine("\n\nDigite o nome do evento.".ToUpper());

        nomeEvento = Console.ReadLine();
        Console.WriteLine("\n\nDigite o endereco do evento.".ToUpper());

        endereco = Console.ReadLine();

        Console.WriteLine("""
                            SELECIONE A CATEGORIA DO EVENTO.
                            1 - SHOW 
                            2 - TEATRO
                            3 - PARQUE DE DIVERSAO
                            4 - RODEIO,
                            5 - CINEMA
                        """);

        _ = int.TryParse(Console.ReadLine(), out int categoria);

        Console.WriteLine("Informe a data - Digite no formato dd/mm/aaaa hh:mm");

        string dateFormat = "dd/MM/yyyy HH:mm";
        DateTime dateResult = new DateTime();
        bool dataNaoValida = true;
        do
        {
            try
            {
                dateResult = DateTime.ParseExact(
                    Console.ReadLine(),
                    dateFormat,
                    new CultureInfo("pt-BR"),
                    DateTimeStyles.None);

                    dataNaoValida = false;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Formato inválido - Digite no formato dd/mm/aaaa hh:mm");
            }


        } while (dataNaoValida);

        Eventos evento = new()
        {
            Nome = nomeEvento,
            Endereco = endereco,
            Categorias = (Categorias)categoria,
            DataEvento = dateResult
        };
        await manager.CadastrarEventoAsync(evento);

        Console.WriteLine("\n\nEVENTO CADASTRADO COM SUCESSO!\n\n");
    }
}