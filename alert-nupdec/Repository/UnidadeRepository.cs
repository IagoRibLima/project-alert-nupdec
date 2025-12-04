using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    public class UnidadeRepository
    {
        public static List<Unidade> list_unidade = new List<Unidade>()
        {
            new Unidade(){
                nome = "Selecione uma unidade",
                enderecoCompleto = null,
                cep = null,
                descricaoUnidade = null
            },
            new Unidade()
            {
                nome = "Itagaçaba",
                enderecoCompleto = "Rua A",
                cep = "12345678",
                descricaoUnidade = "As margens do Paraiba"
            }
        };



        // Método para cadastrar uma nova unidade
        public static void cadastrarUnidade(String nome, String enderecoCompleto, String cep, String descricaoUnidade)
        {
            var erros = new List<string>();
            
            if (string.IsNullOrWhiteSpace(nome))
                erros.Add("É necessário informar o nome da unidade");
            if (string.IsNullOrWhiteSpace(enderecoCompleto))
                erros.Add("É necessário informar o endereço completo.");
            if (string.IsNullOrWhiteSpace(cep))
                erros.Add("É necessário informar o CEP.");

            if (erros.Count > 0)
            {
                string mensagemErro = string.Join("\n", erros);
                throw new Exception(mensagemErro);
            }

            Unidade unidade = new Unidade()
            {
                nome = nome,
                enderecoCompleto = enderecoCompleto,
                cep = cep,
                descricaoUnidade = descricaoUnidade
            };

            list_unidade.Add(unidade);

            System.Diagnostics.Debug.WriteLine($"Nome da Unidade: {unidade.nome}" +
                                               $"\nEndereço completo: {unidade.enderecoCompleto}" +
                                               $"\nCEP: {unidade.cep}" +
                                               $"\nDescrição: {unidade.descricaoUnidade}");
        }
    }
}
