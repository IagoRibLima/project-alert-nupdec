namespace alert_nupdec.Models
{
    public class AreaRisco
    {
        public string nomeArea { get; set; }
        public string enderecoCompleto { get; set; }
        public string cep { get; set; }
        public string tipoProblema { get; set; }
        public string descricao { get; set; }
        public bool riscoImediato { get; set; }
        public string Imagem { get; set; }

        public Color CorRisco => riscoImediato ? Color.FromArgb("#ff751f") : Color.FromArgb("#1848a0");

        public string StatusRisco => riscoImediato ? "RISCO IMEDIATO (ALERTA)" : "RISCO POTENCIAL";
    }
}
