using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    public class TreinamentoRepository
    {        
        public static List<Treinamento> list_treinamento = new List<Treinamento>()
        {
            new Treinamento
            {
                Id = 0,
                Nome = "Primeiros Socorros",
                Vaga = "100",
                Descricao = "Como agir em casos de ferimentos, desmaios, quedas e parada cardiorespiratoria"
            }
        };
        
        /*------------------------------------------------------------------------------*/

        // Método para cadastrar um novo treinamento
        public static void cadastrarTreinamento(string nome, string vaga, string descricao)
        {
            Treinamento treinamento = new Treinamento
            {
                Id = list_treinamento.Count + 1,
                Nome = nome,
                Vaga = vaga,
                Descricao = descricao
            };

            list_treinamento.Add(treinamento);
            
            System.Diagnostics.Debug.WriteLine($"Id: {treinamento.Id}" +
                                               $"Nome: {treinamento.Nome}" +
                                               $"\nVaga: {treinamento.Vaga}" +
                                               $"\nDescricao: {treinamento.Descricao}");
        }

    }
}
