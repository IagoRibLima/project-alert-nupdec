namespace alert_nupdec.Models
{
    public class Alerta
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public Usuario Usuario { get; set; }
        public bool Aceito { get; set; }
    }
}
