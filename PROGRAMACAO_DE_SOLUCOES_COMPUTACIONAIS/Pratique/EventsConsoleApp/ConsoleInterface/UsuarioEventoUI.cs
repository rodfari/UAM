

namespace EventsConsoleApp.ConsoleInterface;
public class UsuarioEventoUI
{
    public async Task<string> IngressarEmEvento()
    {
        Console.WriteLine("DIGITE O SEU EMAIL CADASTRADO:");
        string email = Console.ReadLine();

        Console.WriteLine("DIGITE O CÓDIGO DO EVENTO:");
        string eventoId = Console.ReadLine();

        UsuarioEventoDataManager DataManager = new();
        await DataManager.CadastrarEventoAsync(new Domain.UsuarioEvento{
            IdEvento = Guid.Parse(eventoId),
            EmailUsuario = email
        });
        return "Ingresso realizado com sucesso!";
    }

    public async void MeusEventos(){
        Console.WriteLine("DIGITE O SEU EMAIL CADASTRADO:");
        string email = Console.ReadLine();

        UsuarioEventoDataManager DataManager = new();
        var eventos = await DataManager.ObterIngressoUsuarioJoinAsync(email);
        
        var list = (List<string>) eventos[email];
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}