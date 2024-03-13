using EventsConsoleApp.ConsoleInterface;

var UserUI = new UsuarioUI();
var EventoUI = new EventoUI();
var UsuarioEventoUI = new UsuarioEventoUI();

bool navegar = true;
while (navegar)
{
    string mensagem = $""" 
                SELECIONE O QUE DESEJA FAZER:
                1 - CADASTRAR USUARIO
                2 - LISTAR EVENTOS
                3 - CADASTRAR EVENTO
                4 - CADASTRAR-SE EM UM EVENTO
                5 - MEUS EVENTOS
                6 - SAIR
            """;

    Console.WriteLine(mensagem);

    string acao = Console.ReadLine().Trim();
    string msg = string.Empty;

    switch (acao)
    {
        case "1":
            await UserUI.CriarUsuario();
            msg = "USUÁRIO CADASTRADO COM SUCESSO";
            break;
        case "2":
            Console.WriteLine("\n\n ---- CONFIRA OS EVENTOS DISPONÍVEIS ----");
            msg = await EventoUI.ListarEventosAsync();
            break;
        case "3":
            await EventoUI.CriarEvento();
            break;
        case "4":
            await UsuarioEventoUI.IngressarEmEvento();
            break;
        case "5":
            UsuarioEventoUI.MeusEventos();
            break;
        case "6":
            navegar = false;
            msg = "Obrigado por utilizar o sistema!".ToUpper();
            break;    
        default:
            navegar = false;
            break;
    }

    Console.WriteLine($"\n{msg}\n\n");
}


