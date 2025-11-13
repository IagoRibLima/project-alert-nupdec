using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    public class DicasRepository
    {
        public static List<Dicas> list_dicas = new List<Dicas>();

        public List<Dicas> ListDicas
        {
            get { return list_dicas; }
        }

        public static void cadastrarDicas(Dicas Dicas)
        {
            list_dicas.Add(Dicas);
            System.Diagnostics.Debug.WriteLine($"NomeDica: {Dicas.NomeDica}" +
                                               $"\nDescricao: {Dicas.Descricao}");
        }
    }
}
