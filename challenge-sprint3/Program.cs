using challenge_sprint3.Data;
using challenge_sprint3.Repository;
using challenge_sprint3.Services;
using challenge_sprint3.UI;

string connectionString = "User Id=rm97966;Password=120205;Data Source=oracle.fiap.com.br:1521/orcl";

// 📌 Inicializa contexto do banco
var dbContext = new OracleDbContext(connectionString);

// 📌 Inicializa repositórios
var clienteRepository = new ClienteRepository(dbContext);
var funcionarioRepository = new FuncionarioRepository(dbContext);

// 📌 Inicializa serviços
var clienteService = new ClienteService(clienteRepository);
var funcionarioService = new FuncionarioService(funcionarioRepository);

// 📌 Inicializa UI (console)
var ui = new ConsoleUI(clienteService, funcionarioService);


// ▶ Inicia aplicação
ui.Iniciar();
