using System.Collections;

namespace alert_nupdec.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Unidade { get; set; }
        public string Senha { get; set; }
    }    
}
