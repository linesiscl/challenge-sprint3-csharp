using challenge_sprint3.Data;
using challenge_sprint3.Model;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace challenge_sprint3.Repository
{
    public class ClienteRepository
    {
        private readonly OracleDbContext _context;


        public ClienteRepository(OracleDbContext context)
        {
            _context = context;
        }


        public int Adicionar(Cliente cliente)
        {
            using var conn = _context.CreateConnection();
            string sql = @"INSERT INTO Clientes (Nome, Email, Senha, PerfilInvestidor)
VALUES (:Nome, :Email, :Senha, :PerfilInvestidor)
RETURNING Id INTO :Id";


            var parametros = new DynamicParameters();
            parametros.Add(":Nome", cliente.Nome);
            parametros.Add(":Email", cliente.Email);
            parametros.Add(":Senha", cliente.Senha);
            parametros.Add(":PerfilInvestidor", cliente.PerfilInvestidor);
            parametros.Add(":Id", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);


            conn.Execute(sql, parametros);
            return parametros.Get<int>(":Id");
        }


        public Cliente ObterPorEmail(string email)
        {
            using var conn = _context.CreateConnection();
            return conn.QueryFirstOrDefault<Cliente>("SELECT * FROM Clientes WHERE Email = :Email", new { Email = email });
        }

        public void AtualizarPerfil(int clienteId, string novoPerfil)
        {
            using var connection = _context.CreateConnection();
            string sql = "UPDATE CLIENTES SET PERFILINVESTIDOR = :perfil WHERE ID = :id";
            connection.Execute(sql, new { perfil = novoPerfil, id = clienteId });
        }

        public Cliente ObterPorId(int id)
        {
            using var conn = _context.CreateConnection();
            string sql = "SELECT * FROM Clientes WHERE Id = :Id";
            return conn.QueryFirstOrDefault<Cliente>(sql, new { Id = id });
        }

        public List<Cliente> ObterTodos()
        {
            using var conn = _context.CreateConnection();
            string sql = "SELECT * FROM Clientes";
            return conn.Query<Cliente>(sql).ToList();
        }

        public void Remover(int id)
        {
            using var conn = _context.CreateConnection();
            string sql = "DELETE FROM Clientes WHERE Id = :Id";
            conn.Execute(sql, new { Id = id });
        }
    }
}
