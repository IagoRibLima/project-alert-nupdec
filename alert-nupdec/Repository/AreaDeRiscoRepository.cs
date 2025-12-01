using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    class AreaDeRiscoRepository
    {
        public static List<AreaRisco> list_areasderisco = new List<AreaRisco>();

        public static string ImagemBase64Temp { get; set; }
        /*--------------------------------------------------------------------------------*/

        // Método para cadastrar uma nova área de risco
        public static void cadastrarArea(String nomeArea, String enderecoCompleto, String cep, String itemSelecionado, String descricao, bool riscoImediato)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(nomeArea))
                erros.Add("É necessário informar o nome da área");
            if (string.IsNullOrWhiteSpace(enderecoCompleto))
                erros.Add("É necessário informar o cep.");
            if (string.IsNullOrWhiteSpace(cep))
                erros.Add("É necessário informar o ponto de referência.");
            if (string.IsNullOrWhiteSpace(itemSelecionado))
                erros.Add("É necessário selecionar o tipo de problema.");
            if (string.IsNullOrWhiteSpace(descricao))
                erros.Add("É necessário informar a descrição do problema.");



            if (erros.Count > 0)
            {
                string mensagemErro = string.Join("\n", erros);
                throw new Exception(mensagemErro);
            }

            AreaRisco area = new AreaRisco()
            {
                nomeArea = nomeArea,
                enderecoCompleto = enderecoCompleto,
                cep = cep,
                tipoProblema = itemSelecionado,
                descricao = descricao,
                riscoImediato = riscoImediato,
                Imagem = ImagemBase64Temp
            };

            list_areasderisco.Add(area);

            System.Diagnostics.Debug.WriteLine($"Nome da area: {area.nomeArea}" +
                                               $"\nEndereço completo: {area.enderecoCompleto}" +
                                               $"\nPonto de referencia: {area.cep}" +
                                               $"\nTipo problema: {area.tipoProblema}" +
                                               $"\nDescrição: {area.descricao}" +
                                               $"\nRisco imediato: {area.riscoImediato}" +
                                               $"\nImagem: {area.Imagem}");

            ImagemBase64Temp = null;
        }

    }
}
