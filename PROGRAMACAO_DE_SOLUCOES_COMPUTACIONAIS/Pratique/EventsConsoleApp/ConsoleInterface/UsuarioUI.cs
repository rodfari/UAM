using EventsConsoleApp.Application;
using EventsConsoleApp.Domain;

namespace EventsConsoleApp.ConsoleInterface;

public class UsuarioUI
{
    public async Task CriarUsuario(){
        Usuario usuario = new();

        Console.WriteLine("\n\nDigite o seu nome.".ToUpper());
        usuario.Nome = Console.ReadLine().Trim();

        Console.WriteLine("\n\nDigite o seu e-mail.".ToUpper());
        usuario.Email = Console.ReadLine().Trim();

        Console.WriteLine("\n\nDigite o seu celular.".ToUpper());
        usuario.Celular = Console.ReadLine().Trim();

        Console.WriteLine("\n\nDigite o seu idade.".ToUpper());
        usuario.Idade = int.Parse(Console.ReadLine().Trim());
        UserDataManager  userData = new UserDataManager();
        await userData.CadastrarEventoAsync(usuario);
    }
}