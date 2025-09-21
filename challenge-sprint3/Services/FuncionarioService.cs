using challenge_sprint3.Model;
using challenge_sprint3.Repository;
using challenge_sprint3.Utils;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace challenge_sprint3.Services
{
    public class FuncionarioService
    {
        private readonly FuncionarioRepository _repository;
        private readonly ClienteRepository _clienteRepository;

        public FuncionarioService(FuncionarioRepository repository, ClienteRepository clienteRepository)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
        }


        public bool LoginFuncionario(string email, string senha)
        {
            var funcionario = new Funcionario();
            return funcionario.Email == email && funcionario.Senha == senha;
        }


        public void ExibirRelatorio(DateTime? dataFiltro = null)
        {
            var logs = JsonLogger.LerLogs();

            if (dataFiltro.HasValue)
            {
                logs = logs.Where(l => l.DataHora.Date == dataFiltro.Value.Date).ToList();
            }

            Console.WriteLine($"Total de clientes: {logs.Count}");
            Console.WriteLine($"Conservadores: {logs.Count(l => l.PerfilInvestidor == "Conservador")}");
            Console.WriteLine($"Moderados: {logs.Count(l => l.PerfilInvestidor == "Moderado")}");
            Console.WriteLine($"Arrojados: {logs.Count(l => l.PerfilInvestidor == "Arrojado")}");
        }


        private string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public List<Cliente> ListarClientes()
        {
            return _clienteRepository.ObterTodos();
        }

        
        public bool DeletarCliente(int id)
        {
            var cliente = _clienteRepository.ObterPorId(id);
            if (cliente == null)
                return false;

            _clienteRepository.Remover(id);
            return true;
        }
    }
}
