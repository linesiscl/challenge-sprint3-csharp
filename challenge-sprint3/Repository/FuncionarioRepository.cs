using challenge_sprint3.Data;
using challenge_sprint3.Model;
using Dapper;

namespace challenge_sprint3.Repository
{
    public class FuncionarioRepository
    {
        private readonly OracleDbContext _context;


        public FuncionarioRepository(OracleDbContext context)
        {
            _context = context;
        }


        public Funcionario ObterPorEmail(string email)
        {
            using var conn = _context.CreateConnection();
            return conn.QueryFirstOrDefault<Funcionario>("SELECT * FROM Funcionarios WHERE Email = :Email", new { Email = email });
        }

    }
}
