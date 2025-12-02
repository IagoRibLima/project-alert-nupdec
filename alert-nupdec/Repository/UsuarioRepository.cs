using alert_nupdec.Models;
using System.Collections;
using System.Net.Mail;

namespace alert_nupdec.Repository
{
    public class UsuarioRepository
    {
        public static string fotoPerfilTemp { get; set; }
        public static Usuario idUsuarioEncontrado { get; set; }

        public static Usuario usuario_logado { get; set; }        

        public static ArrayList lista_usuario = new ArrayList()
        {
            new Usuario()
            {
                Id = "0",
                NomeCompleto = "Iago Lima",
                Email = "iago@email.com",
                CPF = "17158520013",
                Telefone = "11999999999",
                Unidade = new Unidade()
                {
                    nome = "Centro",
                    enderecoCompleto = "Rua A",
                    cep = "00000000",
                    descricaoUnidade = "Unidade Central",
                },
                Senha = "Abc1234@",
                Adm = true,
                Foto = null
            },
            new Usuario()
            {
                Id = "1",
                NomeCompleto = "Pri Couto",
                Email = "pri@email.com",
                CPF = "43693106010",
                Telefone = "11988888888",
                Unidade = new Unidade()
                {
                    nome = "Centro",
                    enderecoCompleto = "Rua A",
                    cep = "00000000",
                    descricaoUnidade = "Unidade Central",
                },
                Senha = "Abc1234@",
                Adm = false,
                Foto = null
            }          
        };

        /*------------------------------------------------------------------------------------------------------*/

        //Metodo para login
        public static void login(string usuario, string senha)
        {
            Usuario usuarioEncontrado = lista_usuario
                .Cast<Usuario>()
                .FirstOrDefault(i => (usuario == i.Email || usuario == i.CPF) &&
                                      senha == i.Senha);
            if (usuarioEncontrado != null)
            {
                usuario_logado = usuarioEncontrado;
                return;
            }

            throw new Exception("Infomações de login inválidas");
        }

        //Metodo para cadastrar voluntario
        public static void cadastrarUsuario(string nome, string email, string cpf, string telefone, Unidade unidade, string senha)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(nome))
                erros.Add("O campo Nome Completo é obrigatório.");
            if (string.IsNullOrWhiteSpace(email))
                erros.Add("O campo Email é obrigatório.");
            if (string.IsNullOrWhiteSpace(telefone))
                erros.Add("O campo Telefone é obrigatório.");
            if (string.IsNullOrWhiteSpace(cpf))
                erros.Add("O campo CPF é obrigatório.");
            if (unidade.nome.Equals("Selecione uma unidade"))
                erros.Add("O campo Unidade é obrigatório.");
            if (string.IsNullOrWhiteSpace(senha))
                erros.Add("O campo Senha é obrigatório.");            

            if (!string.IsNullOrWhiteSpace(cpf))
            {
                string numeroTelefone = new string(cpf.Where(char.IsDigit).ToArray());
                if (numeroTelefone.Length != 11)
                    erros.Add("O campo Telefone deve conter 11 dígitos.");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!MailAddress.TryCreate(email, out _))
                    erros.Add("O campo Email deve conter um endereço de email válido.");
            }

            if (!string.IsNullOrWhiteSpace(telefone))
            {
                string numeroTelefone = new string(telefone.Where(char.IsDigit).ToArray());
                if (numeroTelefone.Length != 11)
                    erros.Add("O campo Telefone deve conter 11 dígitos (DDD + número).");
            }

            if (!string.IsNullOrWhiteSpace(senha))
            {
                if (senha.Length < 8)
                    erros.Add("O campo Senha deve ter no mínimo 8 caracteres.");
                if (!senha.Any(char.IsUpper))
                    erros.Add("O campo Senha deve ter pelo menos uma letra maiúscula.");
                if (!senha.Any(char.IsDigit))
                    erros.Add("O campo Senha deve ter pelo menos um número.");
                if (senha.All(char.IsLetterOrDigit))
                    erros.Add("O campo Senha deve ter pelo menos um caractere especial (ex: @, #, $, !).");
            }

            if (erros.Count > 0)
            {
                string mensagemErro = string.Join("\n", erros);
                throw new Exception(mensagemErro);
            }

            Usuario voluntario = new Usuario()
            {
                Id = lista_usuario.Count.ToString(),
                NomeCompleto = nome,
                Email = email,
                CPF = cpf,
                Telefone = telefone,
                Unidade = unidade,
                Senha = senha,
                Adm = false,
                Foto = null
            };

            lista_usuario.Add(voluntario);

            System.Diagnostics.Debug.WriteLine($"Voluntário cadastrado: {voluntario.NomeCompleto} " +
                                               $"\nID: {voluntario.Id} " +
                                               $"\nEmail: {voluntario.Email}" +
                                               $"\nCPF: {voluntario.CPF}" +
                                               $"\nTelefone: {voluntario.Telefone}" +
                                               $"\nUnidade: {voluntario.Unidade}" +
                                               $"\nSenha: {voluntario.Senha}" +
                                               $"\nAdm: {voluntario.Adm}" +
                                               $"\nFoto: {voluntario.Foto}");
        }

        //Metodo para procurar o usuário
        public static void procurarUsuario(string email, string cpf)
        {
            Usuario usuarioEncontrado = lista_usuario
                .Cast<Usuario>()
                .FirstOrDefault(i => (email == i.Email) && (cpf == i.CPF));

            if (usuarioEncontrado != null)
            {
                idUsuarioEncontrado = usuarioEncontrado;
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
                if (lista_usuario[int.Parse(idUsuarioEncontrado.Id)] == idUsuarioEncontrado)
                {
                    idUsuarioEncontrado.Senha = novaSenha;
                    lista_usuario[int.Parse(idUsuarioEncontrado.Id)] = idUsuarioEncontrado;
                    idUsuarioEncontrado = null;
                    return;
                }
            }
        }

        //Metodo para atualizar os dados do usuário
        public static string AtualizarDadosUsuario(string email, string telefone, string senha, string confirmarSenha)
        {
            var alterados = new List<string>();

            int id = int.Parse(usuario_logado.Id);

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!MailAddress.TryCreate(email, out _))
                    throw new Exception("O campo Email deve conter um endereço de email válido.");

                ((Usuario)lista_usuario[id]).Email = email;

                alterados.Add("Email");
            }
            if (!string.IsNullOrWhiteSpace(telefone))
            {
                string numeroTelefone = new string(telefone.Where(char.IsDigit).ToArray());
                if (numeroTelefone.Length != 11)
                    throw new Exception("O campo Telefone deve conter 11 dígitos (DDD + número).");

                ((Usuario)lista_usuario[id]).Telefone = telefone;

                alterados.Add("Telefone");
            }
            if (!string.IsNullOrWhiteSpace(senha))
            {
                if (senha.Length < 8)
                    throw new Exception("O campo Senha deve ter no mínimo 8 caracteres.");
                if (!senha.Any(char.IsUpper))
                    throw new Exception("O campo Senha deve ter pelo menos uma letra maiúscula.");
                if (!senha.Any(char.IsDigit))
                    throw new Exception("O campo Senha deve ter pelo menos um número.");
                if (senha.All(char.IsLetterOrDigit))
                    throw new Exception("O campo Senha deve ter pelo menos um caractere especial (ex: @, #, $, !).");
                if (string.IsNullOrWhiteSpace(confirmarSenha))
                    throw new Exception("É necessário confirmar a senha.");
                if (senha != confirmarSenha)
                    throw new Exception("As senhas não coincidem!");

                ((Usuario)lista_usuario[id]).Senha = senha;

                alterados.Add("Senha");
            }
            if (!string.IsNullOrWhiteSpace(fotoPerfilTemp))
            {
                ((Usuario)lista_usuario[id]).Foto = fotoPerfilTemp;
                fotoPerfilTemp = null;
                alterados.Add("Foto de Perfil");
            }

            if (alterados.Count > 0)
            {
                usuario_logado = (Usuario)lista_usuario[id];
                return $"Dados alterados com sucesso: {string.Join(", ", alterados)}.";
            }
            else
            {
                throw new Exception("Nenhum dado foi alterado.");
            }
        }

    }
}
