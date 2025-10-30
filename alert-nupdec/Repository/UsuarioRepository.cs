using alert_nupdec.Models;
using System.Collections;

namespace alert_nupdec.Repository
{
    public class UsuarioRepository
    {
        public static Usuario usuario_logado { get; set; }
        public static ArrayList lista_voluntarios = new ArrayList();

        public static ArrayList lista_adm = new ArrayList()
        {
            new Usuario()
            {
                Id = 0,
                NomeCompleto = "Iago Lima",
                Email = "iago@email.com",
                CPF = "00000000000",
                Telefone = "11999999999",
                Unidade = "Unidade A",
                Senha = "Abc1234@"
            },
            new Usuario()
            {
                Id = 1,
                NomeCompleto = "Pri Couto",
                Email = "pri@email.com",
                CPF = "11111111111",
                Telefone = "11988888888",
                Unidade = "Unidade A",
                Senha = "Abc1234@"
            }
        };

        public static ArrayList ListaVoluntarios
        {
            get { return lista_voluntarios; }
        }


        public static void cadastrarUsuario(Usuario user)
        {
            user.Id = lista_voluntarios.Count;
            lista_voluntarios.Add(user);
            System.Diagnostics.Debug.WriteLine($"Voluntário cadastrado: {user.NomeCompleto} " +
                                               $"\nID: {user.Id} " +
                                               $"\nEmail: {user.Email}" +
                                               $"\nCPF: {user.CPF}" +
                                               $"\nTelefone: {user.Telefone}" +
                                               $"\nUnidade: {user.Unidade}" +
                                               $"\nSenha: {user.Senha}");
        }
    }
}
