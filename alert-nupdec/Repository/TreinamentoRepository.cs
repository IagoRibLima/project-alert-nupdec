using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    public class TreinamentoRepository
    {
        // Lista estática de treinamentos
        private static List<Treinamento> list_treinamento = new List<Treinamento>();

        // Propriedade pública (caso queira acessar diretamente)
        public List<Treinamento> ListTreinamento
        {
            get { return list_treinamento; }
        }

        // Método para cadastrar um novo treinamento
        public static void cadastrarTreinamento(Treinamento treinamento)
        {
            list_treinamento.Add(treinamento);
            System.Diagnostics.Debug.WriteLine(
                $"Nome: {treinamento.Nome}" +
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
