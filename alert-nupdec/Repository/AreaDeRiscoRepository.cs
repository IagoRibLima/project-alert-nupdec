using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    class AreaDeRiscoRepository
    {
        public static List<AreaRisco> list_areasderisco = new List<AreaRisco>();

        /*--------------------------------------------------------------------------------*/

        // Método para cadastrar uma nova área de risco
        public static void cadastrarArea(string rua, string bairro, string cep)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(rua))
                erros.Add("É necessário informar a rua.");
            if (string.IsNullOrWhiteSpace(bairro))
                erros.Add("É necessário informar o bairro.");
            if (string.IsNullOrWhiteSpace(cep))
                erros.Add("É necessário informar o CEP.");

            if (!string.IsNullOrWhiteSpace(cep))
            {
                string numeroCep = new string(cep.Where(char.IsDigit).ToArray());
                if (numeroCep.Length != 8)
                    erros.Add("O campo CEP deve conter 8 dígitos.");
            }

            if (erros.Count > 0)
            {
                string mensagemErro = string.Join("\n", erros);
                throw new Exception(mensagemErro);
            }

            AreaRisco area = new AreaRisco()
            {
                Rua = rua,
                Bairro = bairro,
                CEP = cep
            };

            list_areasderisco.Add(area);
            System.Diagnostics.Debug.WriteLine($"Rua: {area.Rua}" +
                                               $"\nBairro: {area.Bairro}" +
                                               $"\nCEP: {area.CEP}");
        }

    }
}
