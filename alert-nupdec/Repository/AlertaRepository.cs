using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    class AlertaRepository
    {
        public static List<Alerta> list_alerta = new List<Alerta>();

        public static string ImagemBase64Temp { get; set; }

        /*---------------------------------------------------------------------------------------------*/

        //Metodo para cadastrar alerta
        public static void cadastrarAlerta(string tipo, string endereco, string descricao)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(tipo))
                erros.Add("É necessário selecionar o tipo de ocorrência");
            if (string.IsNullOrWhiteSpace(endereco))
                erros.Add("É necessário informa o endereço da ocorrência");
            if (string.IsNullOrWhiteSpace(descricao))
                erros.Add("Descreva a ocorrência");
            if (string.IsNullOrEmpty(ImagemBase64Temp))
                erros.Add("Envie uma imagem da ocorrência");

            if (erros.Count > 0)
            {
                string mensagemErro = string.Join("\n", erros);
                throw new Exception(mensagemErro);
            }

            Alerta alerta = new Alerta()
            {
                Tipo = tipo,
                Endereco = endereco,
                Descricao = descricao,
                Imagem = ImagemBase64Temp,
                Usuario = UsuarioRepository.usuario_logado
            };

            list_alerta.Add(alerta);

            System.Diagnostics.Debug.WriteLine($"Tipo: {alerta.Tipo}" +
                                               $"\nEndereço: {alerta.Endereco}" +
                                               $"\nDescricao: {alerta.Descricao}" +
                                               $"\nImagem: {alerta.Imagem}" +
                                               $"\nUsuario: {alerta.Usuario.NomeCompleto}");

            ImagemBase64Temp = null;
        }        
    }
}
