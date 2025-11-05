using alert_nupdec.Models;

namespace alert_nupdec.Repository
{
    class AlertaRepository
    {
        public static List<Alerta> list_alerta = new List<Alerta>();
        
        public List<Alerta> ListAlertas
        {
            get { return list_alerta; }
        }

        public static void cadastrarAlerta(Alerta alerta)
        {
            list_alerta.Add(alerta);
            System.Diagnostics.Debug.WriteLine($"Tipo: {alerta.Tipo}" +
                                               $"\nEndereço: {alerta.Endereco}" +
                                               $"\nDescricao: {alerta.Descricao}" +
                                               $"\nImagem: {alerta.Imagem}" +
                                               $"\nUsuario: {alerta.Usuario.NomeCompleto}");
        }
    }
}
