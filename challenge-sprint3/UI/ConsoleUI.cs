using challenge_sprint3.Services;
using challenge_sprint3.Model;
using challenge_sprint3.Utils;


namespace challenge_sprint3.UI
{
    public class ConsoleUI
    {
        private readonly ClienteService _clienteService;
        private readonly FuncionarioService _funcionarioService;


        public ConsoleUI(ClienteService clienteService, FuncionarioService funcionarioService)
        {
            _clienteService = clienteService;
            _funcionarioService = funcionarioService;
        }


        public void Iniciar()
        {
            while (true)
            {
                Console.WriteLine("=== Banco de Investimentos ===");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Login Cliente");
                Console.WriteLine("3 - Login Funcionário");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");
                string opcao = Console.ReadLine();


                switch (opcao)
                {
                    case "1":
                        CadastrarCliente();
                        break;
                    case "2":
                        LoginCliente();
                        break;
                    case "3":
                        LoginFuncionario();
                        break;
                    case "0":
                        return;
                }
            }
        }


        private void CadastrarCliente()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();


            Console.WriteLine("Escolha o perfil: 1-Conservador 2-Moderado 3-Arrojado");
            string perfilEscolhido = Console.ReadLine();
            string perfil = perfilEscolhido switch
            {
                "1" => "Conservador",
                "2" => "Moderado",
                "3" => "Arrojado",
                _ => "Moderado"
            };


            int id = _clienteService.CadastrarCliente(nome, email, senha, perfil);
            Console.WriteLine($"Cliente cadastrado com sucesso! ID: {id}");
        }

        private void LoginCliente()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            var cliente = _clienteService.Login(email, senha);
            if (cliente != null)
            {
                Console.WriteLine($"Login realizado com sucesso! Bem-vindo, {cliente.Nome}.");
                MenuCliente(cliente); 
            }
            else
            {
                Console.WriteLine("Email ou senha inválidos.");
            }
        }


        private void LoginFuncionario()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            if (_funcionarioService.LoginFuncionario(email, senha))
            {
                Console.WriteLine("Login de funcionário realizado!");
                MenuFuncionario(); // Novo menu do funcionário
            }
            else
            {
                Console.WriteLine("Credenciais inválidas.");
            }
        }

        public void MenuCliente(Cliente cliente)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n--- Área do Cliente ---");
                Console.WriteLine("1 - Ver meu perfil de investidor");
                Console.WriteLine("2 - Alterar meu perfil de investidor");
                Console.WriteLine("3 - Simular investimento");
                Console.WriteLine("4 - Ver meu histórico de alterações");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine($"Seu perfil de investidor: {cliente.PerfilInvestidor}");
                        break;

                    case "2":
                        Console.Write("Novo perfil (Conservador/Moderado/Arrojado): ");
                        string novoPerfil = Console.ReadLine();

                        if (!string.IsNullOrEmpty(novoPerfil))
                        {
                            cliente.PerfilInvestidor = novoPerfil;
                            _clienteService.AtualizarPerfil(cliente);
                            Console.WriteLine("Perfil atualizado com sucesso!");
                        }
                        break;

                    case "3":
                        Console.Write("Valor a investir: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                        {
                            decimal rendimento = SimularRendimento(valor, cliente.PerfilInvestidor);
                            Console.WriteLine($"Após 1 ano, seu valor pode chegar a: {valor + rendimento:C}");
                        }
                        break;

                    case "4":
                        var logs = JsonLogger.LerLogs()
                            .Where(l => l.ClienteId == cliente.Id)
                            .OrderBy(l => l.DataHora);

                        foreach (var log in logs)
                        {
                            Console.WriteLine($"{log.DataHora:dd/MM/yyyy HH:mm} - {log.PerfilInvestidor}");
                        }
                        break;

                    case "0":
                        sair = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        private decimal SimularRendimento(decimal valor, string perfil)
        {
            decimal taxa = perfil switch
            {
                "Conservador" => 0.05m,
                "Moderado" => 0.10m,
                "Arrojado" => 0.15m,
                _ => 0.05m
            };

            return valor * taxa;
        }

        private void MenuFuncionario()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n--- Área do Funcionário ---");
                Console.WriteLine("1 - Listar todos os clientes");
                Console.WriteLine("2 - Deletar cliente por ID");
                Console.WriteLine("3 - Exibir relátorio de cadastros");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        var clientes = _funcionarioService.ListarClientes(); 

                        Console.WriteLine("\n--- Lista de Clientes ---");

                        if (clientes.Count == 0)
                        {
                            Console.WriteLine("Nenhum cliente encontrado no banco.");
                        }
                        else
                        {
                            foreach (var cliente in clientes)
                            {
                                Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | Email: {cliente.Email} | Perfil: {cliente.PerfilInvestidor}");
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("Qual o id da conta que deseja deletar?");
                        if (int.TryParse(Console.ReadLine(), out int idCerto))
                        {
                            bool deletado = _funcionarioService.DeletarCliente(idCerto);
                            Console.WriteLine(deletado ? "Cliente deletado com sucesso!" : "Cliente não encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido. Digite um número.");
                        }
                        break;

                    case "3":
                        _funcionarioService.ExibirRelatorio();
                        break;

                    case "0":
                        sair = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
