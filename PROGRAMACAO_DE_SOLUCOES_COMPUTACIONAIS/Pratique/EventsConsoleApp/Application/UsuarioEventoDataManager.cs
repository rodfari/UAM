using System.Collections;
using System.Text;
using EventsConsoleApp.Application;
using EventsConsoleApp.Domain;

namespace EventsConsoleApp;

public class UsuarioEventoDataManager : DataManager
{
    public UsuarioEventoDataManager()
    {
        _arquivo = "events_data_evento_usuario.txt";
    }
    public async Task<string[]> ObterIngressosUsuarioAsync(string email)
    {
        string[] linhas = Array.Empty<string>();
        string ingresso = string.Empty;
        if (File.Exists(_arquivo))
            linhas = await File.ReadAllLinesAsync(_arquivo);

        linhas = linhas.Where(x => x.Contains(email)).ToArray();
        return linhas;
    }

    public async Task<Hashtable> ObterIngressoUsuarioJoinAsync(string email)
    {
        Hashtable hashtable = new();

        var eventos = await ObterIngressosUsuarioAsync(email);
        EventsDataManager eventsData = new EventsDataManager();
        var listEvents = new List<string>();
        foreach (var evento in eventos)
        {
            var ev = evento.Split(';');
            var r = await eventsData.ObterEvento(ev[1]);
            listEvents.Add(r);
        }
        if (!hashtable.ContainsKey(email))
            hashtable.Add(email, listEvents);

        return hashtable;
    }

    public async Task CadastrarEventoAsync(UsuarioEvento UsuarioEvento)
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
        .Append($"{UsuarioEvento.EmailUsuario};")
        .Append($"{UsuarioEvento.IdEvento};");

        using StreamWriter write = File.CreateText(_arquivo);
        await write.WriteAsync(strBuilder);
        write.Close();
    }
}