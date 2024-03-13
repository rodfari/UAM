using System.Text;
using EventsConsoleApp.Domain;
using System.Linq.Expressions;

namespace EventsConsoleApp.Application;

public class UserDataManager: DataManager
{
    public UserDataManager()
    {
        _arquivo = "events_data_usuario.txt";
    }

    public async Task<string> ObterUsuarioCadastrado(string email){
        string[] linhas = Array.Empty<string>();
        string user = string.Empty;
        if(File.Exists(_arquivo))
            linhas = await File.ReadAllLinesAsync(_arquivo);

        foreach (var linha in linhas)
        {
            if(linha.Contains(email)){
                user = linha;
                break;
            }
        }            
        return user;
    }

    public async Task CadastrarEventoAsync(Usuario usuario)
    {
        string text = string.Empty;
        if (File.Exists(_arquivo))
        {
            text = await File.ReadAllTextAsync(_arquivo);
        }

        StringBuilder strBuilder = new();

        if (!string.IsNullOrEmpty(text))
        {
            strBuilder.AppendLine(text);
        }

        strBuilder
        .Append($"{Guid.NewGuid()};")
        .Append($"{usuario.Nome};")
        .Append($"{usuario.Email};")
        .Append($"{usuario.Celular};")
        .Append($"{usuario.Idade};");

        using StreamWriter write = File.CreateText(_arquivo);
        await write.WriteAsync(strBuilder);
        write.Close();
    }
}