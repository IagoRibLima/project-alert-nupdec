using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    public class DicasRepository
    {
        public static List<Dicas> list_dicas = new List<Dicas>();

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
