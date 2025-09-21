

namespace challenge_sprint3.Model
{
    public class Funcionario
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public Funcionario()
        {
            //Credenciais predefinidas
            Email = "admin@banco.com";
            Senha = "123456"; 
        }
    }
}
