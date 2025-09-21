using challenge_sprint3.Model;
using challenge_sprint3.Repository;
using challenge_sprint3.Utils;
using System.Security.Cryptography;
using System.Text;

namespace challenge_sprint3.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository;


        public ClienteService(ClienteRepository repository)
        {
            _repository = repository;
        }


        public int CadastrarCliente(string nome, string email, string senha, string perfil)
        {
            string senhaHash = GerarHash(senha);
            var cliente = new Cliente { Nome = nome, Email = email, Senha = senhaHash, PerfilInvestidor = perfil };
            int id = _repository.Adicionar(cliente);
            JsonLogger.RegistrarLog(id, perfil);
            return id;
        }


        public bool Login(string email, string senha)
        {
            var cliente = _repository.ObterPorEmail(email);
            if (cliente == null) return false;
            return cliente.Senha == GerarHash(senha);
        }


        private string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public void AtualizarPerfil(Cliente cliente)
        {
            _repository.AtualizarPerfil(cliente.Id, cliente.PerfilInvestidor);
            JsonLogger.RegistrarLog(cliente.Id, cliente.PerfilInvestidor);
        }
    }
}
