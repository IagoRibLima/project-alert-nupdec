using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    class AlertaRepository
    {
        public static List<Alerta> list_alerta = new List<Alerta>();

        /*---------------------------------------------------------------------------------------------*/

        //Metodo para cadastrar alerta
        public static void cadastrarAlerta(string tipo, string endereco, string descricao, string imagem)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(tipo))
                erros.Add("É necessário selecionar o tipo de ocorrência");
            if (string.IsNullOrWhiteSpace(endereco))
                erros.Add("É necessário informa o endereço da ocorrência");
            if (string.IsNullOrWhiteSpace(descricao))
                erros.Add("Descreva a ocorrência");
            if (string.IsNullOrEmpty(imagem))
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
                Imagem = imagem,
                Usuario = UsuarioRepository.usuario_logado
            };

            list_alerta.Add(alerta);

            System.Diagnostics.Debug.WriteLine($"Tipo: {alerta.Tipo}" +
                                               $"\nEndereço: {alerta.Endereco}" +
                                               $"\nDescricao: {alerta.Descricao}" +
                                               $"\nImagem: {alerta.Imagem}" +
                                               $"\nUsuario: {alerta.Usuario.NomeCompleto}");
        }        
    }
}
