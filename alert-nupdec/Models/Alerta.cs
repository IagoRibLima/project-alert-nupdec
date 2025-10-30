namespace alert_nupdec.Models
{
    class Alerta
    {
        public string Tipo { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public Usuario Usuario { get; set; }
    }
}
