using System.Text.Json;
using challenge_sprint3.Model;

namespace challenge_sprint3.Utils
{
    public static class JsonLogger
    {
        private static readonly string logFile = "logs.json";


        public static void RegistrarLog(int clienteId, string perfil)
        {
            List<LogRegistro> logs = new();


            if (File.Exists(logFile))
            {
                string jsonExistente = File.ReadAllText(logFile);
                logs = JsonSerializer.Deserialize<List<LogRegistro>>(jsonExistente) ?? new List<LogRegistro>();
            }


            logs.Add(new LogRegistro
            {
                DataHora = DateTime.Now,
                ClienteId = clienteId,
                PerfilInvestidor = perfil
            });


            string novoJson = JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(logFile, novoJson);
        }


        public static List<LogRegistro> LerLogs()
        {
            if (!File.Exists(logFile)) return new List<LogRegistro>();
            string json = File.ReadAllText(logFile);
            return JsonSerializer.Deserialize<List<LogRegistro>>(json) ?? new List<LogRegistro>();
        }
    }
}
