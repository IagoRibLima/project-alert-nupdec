using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    public class DicasRepository
    {
        public static List<Dicas> list_dicas = new List<Dicas>()
        {
            new Dicas()
            {
                Id = 0,
                NomeDica = "Desligue a energia",
                Descricao = "Em casos de fortes chuvas com risco de enchentes, desligue a energia"
            }
        };

        /*-----------------------------------------------------------------------------*/

        // Método para cadastrar dicas
        public static void cadastrarDicas(string dica, string descricao)
        {
            Dicas dicas = new Dicas
            {
                Id = list_dicas.Count + 1,
                NomeDica = dica,
                Descricao = descricao
            };

            list_dicas.Add(dicas);

            System.Diagnostics.Debug.WriteLine($"Id: {dicas.Id}" +
                                               $"NomeDica: {dicas.NomeDica}" +
                                               $"\nDescricao: {dicas.Descricao}");
        }
    }
}
