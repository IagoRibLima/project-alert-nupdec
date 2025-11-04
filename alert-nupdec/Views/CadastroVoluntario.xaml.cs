using System.Net.Mail;
using alert_nupdec.Models;
using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class CadastroVoluntario : ContentPage
{
	public CadastroVoluntario()
	{
		InitializeComponent();

        picker_unidades.ItemsSource = new List<string>
        {
            "Unidade A",
            "Unidade B",
            "Unidade C",
            "Unidade D"
        };
    }

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ButtonCadastrar(object sender, EventArgs e)
    {
        try
        {
            var erros = new List<string>();

            string nome = txt_nome_completo.Text?.Trim();
            string email = txt_email.Text?.Trim();
            string cpf = txt_cpf.Text?.Trim();
            string telefone = txt_telefone.Text?.Trim();
            string unidade = picker_unidades.SelectedItem as string;
            string senha = txt_senha.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nome))
                erros.Add("O campo Nome Completo é obrigatório.");
            if (string.IsNullOrWhiteSpace(email))
                erros.Add("O campo Email é obrigatório.");
            if (string.IsNullOrWhiteSpace(telefone))
                erros.Add("O campo Telefone é obrigatório.");
            if (string.IsNullOrWhiteSpace(cpf))
                erros.Add("O campo CPF é obrigatório.");
            if (string.IsNullOrWhiteSpace(unidade))
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
                await DisplayAlert("Campos inválidos", mensagemErro, "Corrigir");
                return;
            }

            Usuario voluntario = new Usuario()
            {
                NomeCompleto = nome,
                Email = email,
                CPF = cpf,
                Telefone = telefone,
                Unidade = unidade,
                Senha = senha
            };

            UsuarioRepository.cadastrarUsuario(voluntario);

            await DisplayAlert("Sucesso", "Voluntário cadastrado com sucesso!", "Fechar");

            txt_nome_completo.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_cpf.Text = string.Empty;
            txt_telefone.Text = string.Empty;
            picker_unidades.SelectedItem = null;
            txt_senha.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }

    private void ButtonVerSenha(object sender, EventArgs e)
    {
        txt_senha.IsPassword = !txt_senha.IsPassword;

        var button = (Button)sender;

        if (txt_senha.IsPassword)
        {
            button.ImageSource = "olho_aberto.png";
        }
        else
        {
            button.ImageSource = "olho_fechado.png";
        }
    }
}