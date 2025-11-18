using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    public class TreinamentoRepository
    {        
        private static List<Treinamento> list_treinamento = new List<Treinamento>();
        
        /*------------------------------------------------------------------------------*/

        // Método para cadastrar um novo treinamento
        public static void cadastrarTreinamento(string nome, string vaga, string descricao)
        {
            Treinamento treinamento = new Treinamento
            {
                Nome = nome,
                Vaga = vaga,
                Descricao = descricao
            };

            list_treinamento.Add(treinamento);
            
            System.Diagnostics.Debug.WriteLine($"Nome: {treinamento.Nome}" +
                                               $"\nVaga: {treinamento.Vaga}" +
                                               $"\nDescricao: {treinamento.Descricao}");
        }

        // Método adicionado para listagem — compatível com sua View
        public static List<Treinamento> ListarTreinamentos()
        {
            return list_treinamento;
        }
    }
}
