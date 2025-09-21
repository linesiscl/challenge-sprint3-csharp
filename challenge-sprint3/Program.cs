using challenge_sprint3.Data;
using challenge_sprint3.Repository;
using challenge_sprint3.Services;
using challenge_sprint3.UI;

//troque para seu respectivo usuário e senha ao testar o código
string connectionString = "User Id=usuario;Password=senha;Data Source=oracle.fiap.com.br:1521/orcl";

var dbContext = new OracleDbContext(connectionString);

var clienteRepository = new ClienteRepository(dbContext);
var funcionarioRepository = new FuncionarioRepository(dbContext);

var clienteService = new ClienteService(clienteRepository);
var funcionarioService = new FuncionarioService(funcionarioRepository);

var ui = new ConsoleUI(clienteService, funcionarioService);

ui.Iniciar();
