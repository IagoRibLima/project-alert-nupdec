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
                NomeDica = dica,
                Descricao = descricao
            };

            list_dicas.Add(dicas);

            System.Diagnostics.Debug.WriteLine($"NomeDica: {dicas.NomeDica}" +
                                               $"\nDescricao: {dicas.Descricao}");
        }
    }
}
