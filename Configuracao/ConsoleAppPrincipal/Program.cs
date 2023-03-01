using BLL;
using MODELS;

internal class Program

{
    private static void Main(string[] args)
    {
        int opcao = 0;
        Console.WriteLine("Escolha uma opção: ");
        Console.WriteLine("1 - Cadastrar usuário");
        Console.WriteLine("2 - Excluir usuário");
        Console.WriteLine("3 - Buscar todos os usuários");

        opcao = Convert.ToInt32(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                CadastrarUsuario();
                break;
            case 2:
                ExcluirUsuario();
                break;
            case 3:
                BuscarTodosOsUsuarios();
                break;
            default:
                break;
        }
    }
    private static void BuscarTodosOsUsuarios()
    {
        try
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            //TODO: Criar o método BuscarTodos
            List<Usuario> usuarios = usuarioBLL.BuscarTodos();

            foreach (Usuario item in usuarios)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Username: " + item.Username);
                Console.WriteLine("E-mail: " + item.Email);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void CadastrarUsuario()
    {
        try
        {
            string opc;
            do
            {
                Usuario usuario = new Usuario();
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                Console.Write("Digite seu nome: ");
                usuario.Nome = Console.ReadLine();
                Console.Write("Digite seu nome de usuario: ");
                usuario.Username = Console.ReadLine();
                Console.Write("Usuario ativo (S) ou (N) para inativo: ");
                string mod = Console.ReadLine();
                if (mod == "S") ;
                {
                    usuario.Ativo = true;

                }
                if (mod == "N")
                {
                    usuario.Ativo = false;

                }
                Console.Write("EMAIL: ");
                usuario.Email = Console.ReadLine();
                Console.Write("CPF: ");
                usuario.CPF = Console.ReadLine();
                Console.Write("SENHA: ");
                usuario.Senha = Console.ReadLine();
                Console.Write("Deseja continuar cadastro? (S)SIM(N)NÃO");
                opc = Console.ReadLine();
                Console.Clear();

                usuarioBLL.Inserir(usuario);
            } while (opc == "S");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void ExcluirUsuario()
    {
        Console.WriteLine("Excluir usuário");
    }
}
