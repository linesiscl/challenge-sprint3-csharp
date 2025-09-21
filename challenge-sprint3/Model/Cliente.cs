

namespace challenge_sprint3.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string PerfilInvestidor { get; set; } // Conservador, Moderado, Arrojado
    }
}
