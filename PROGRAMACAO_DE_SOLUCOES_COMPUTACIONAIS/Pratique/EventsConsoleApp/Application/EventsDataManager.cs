
using System.Text;
using EventsConsoleApp.Application;
using EventsConsoleApp.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
public class EventsDataManager : DataManager
{

    public EventsDataManager()
    {
        _arquivo = "events_data.txt";

    }

    private async Task<string> InitFile(Func<Task<string>> action)
    {
        if (!File.Exists(_arquivo))
        {
            using FileStream file = File.Create(_arquivo);
            file.Close();
            file.Dispose();

        }
        return await action.Invoke();
    }
    public async Task CadastrarEventoAsync(Eventos eventos)
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
        .Append($"{eventos.Nome};")
        .Append($"{eventos.Endereco};")
        .Append($"{eventos.Categorias};")
        .Append($"{eventos.DataEvento.ToString("dd/MM/yyyy HH:mm")};");

        using StreamWriter write = File.CreateText(_arquivo);
        await write.WriteAsync(strBuilder);
        write.Close();
    }

    public async Task<string> ObterEvento(string Id)
    {
        var result =  await File.ReadAllLinesAsync(_arquivo);
        var filter = result.Where(x => x.Contains(Id.Trim())).FirstOrDefault();
        return filter;

    }

    public async Task<string> ListarAsync()
    {
        return await InitFile(async () =>
        {

            return await File.ReadAllTextAsync(this._arquivo) ?? "NÃO EXISTE NENHUM EVENTO CADASTRADO!";
        });
    }


}