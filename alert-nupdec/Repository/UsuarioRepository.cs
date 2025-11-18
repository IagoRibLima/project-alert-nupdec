using alert_nupdec.Models;
using System.Collections;

namespace alert_nupdec.Repository
{
    public class UsuarioRepository
    {
        public static Usuario idUsuarioEncontrado { get; set; }

        public static Usuario usuario_logado { get; set; }

        public static ArrayList lista_voluntarios = new ArrayList();

        public static ArrayList lista_adm = new ArrayList()
        {
            new Usuario()
            {
                Id = "0",
                NomeCompleto = "Iago Lima",
                Email = "iago@email.com",
                CPF = "00000000000",
                Telefone = "11999999999",
                Unidade = new AreaRisco()
                {
                    Rua = "Rua A",
                    Bairro = "Centro",
                    CEP = "00000000"
                },
                Senha = "Abc1234@"
            },
            new Usuario()
            {
                Id = "1",
                NomeCompleto = "Pri Couto",
                Email = "pri@email.com",
                CPF = "11111111111",
                Telefone = "11988888888",
                Unidade = new AreaRisco()
                {
                    Rua = "Rua A",
                    Bairro = "Centro",
                    CEP = "00000000"
                },
                Senha = "Abc1234@"
            }
        };

        /*------------------------------------------------------------------------------------------------------*/

        //Metodo para cadastrar um novo voluntário
        public static void cadastrarUsuario(Usuario user)
        {
            user.Id = lista_voluntarios.Count.ToString();
            lista_voluntarios.Add(user);
            System.Diagnostics.Debug.WriteLine($"Voluntário cadastrado: {user.NomeCompleto} " +
                                               $"\nID: {user.Id} " +
                                               $"\nEmail: {user.Email}" +
                                               $"\nCPF: {user.CPF}" +
                                               $"\nTelefone: {user.Telefone}" +
                                               $"\nUnidade: {user.Unidade}" +
                                               $"\nSenha: {user.Senha}");
        }

        //Metodo para procurar o usuário
        public static void procurarUsuario(string email, string cpf)
        {
            Usuario admEncontrado = lista_adm
                .Cast<Usuario>()
                .FirstOrDefault(i => (email == i.Email) && (cpf == i.CPF));

            if (admEncontrado != null)
            {
                idUsuarioEncontrado = admEncontrado;
                return;

            }

            Usuario voluntarioEncontrado = lista_voluntarios
                    .Cast<Usuario>()
                    .FirstOrDefault(i => (email == i.Email) && (cpf == i.CPF));

            if (voluntarioEncontrado != null)
            {
                idUsuarioEncontrado = voluntarioEncontrado;
                return;

            }
        }

        //Metodo para atualizar a senha do usuário
        public static void AtualizarSenha(string novaSenha, string confirmarSenha)
        {
            if (novaSenha != confirmarSenha)
            {
                throw new Exception("As senhas não coincidem!");
            }
            else if (novaSenha.Length < 8)
            {
                throw new Exception("O campo Senha deve ter no mínimo 8 caracteres.");
            }
            else if (!novaSenha.Any(char.IsUpper))
            {
                throw new Exception("O campo Senha deve ter pelo menos uma letra maiúscula.");
            }
            else if (!novaSenha.Any(char.IsDigit))
            {
                throw new Exception("O campo Senha deve ter pelo menos um número.");
            }
            else if (novaSenha.All(char.IsLetterOrDigit))
            {
                throw new Exception("O campo Senha deve ter pelo menos um caractere especial (ex: @, #, $, !).");
            }
            else
            {
                if (lista_adm[int.Parse(idUsuarioEncontrado.Id)] == idUsuarioEncontrado)
                {
                    idUsuarioEncontrado.Senha = novaSenha;
                    lista_adm[int.Parse(idUsuarioEncontrado.Id)] = idUsuarioEncontrado;
                    idUsuarioEncontrado = null;
                    return;
                }

                if (lista_voluntarios[int.Parse(idUsuarioEncontrado.Id)] == idUsuarioEncontrado)
                {
                    idUsuarioEncontrado.Senha = novaSenha;
                    lista_voluntarios[int.Parse(idUsuarioEncontrado.Id)] = idUsuarioEncontrado;
                    idUsuarioEncontrado = null;
                    return;
                }
            }            
        }


    }
}
