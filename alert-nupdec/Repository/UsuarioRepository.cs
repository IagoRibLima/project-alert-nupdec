using alert_nupdec.Models;
using System.Collections;

namespace alert_nupdec.Repository
{
    public class UsuarioRepository
    {
        public static ArrayList lista_voluntarios = new ArrayList();

        public static ArrayList lista_adm = new ArrayList()
        {
            new Usuario()
            {
                Id = 0,
                NomeCompleto = "Iago Lima",
                Email = "iago@email.com",
                Telefone = "11999999999",
                Unidade = "Unidade A",
                Senha = "A@bc1234"
            },
            new Usuario()
            {
                Id = 1,
                NomeCompleto = "Pri Couto",
                Email = "pri@email.com",
                Telefone = "11988888888",
                Unidade = "Unidade A",
                Senha = "A@bc1234"
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
            System.Diagnostics.Debug.WriteLine($"Voluntário cadastrado: {user.NomeCompleto}, ID: {user.Id}");
        }
    }
}
