using alert_nupdec.Models;
using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void ButtonLogin(object sender, EventArgs e)
    {
        try
        {
            string usuarioDigitado = txt_usuario.Text?.Trim();
            string senhaDigitada = txt_senha.Text;

            if (string.IsNullOrWhiteSpace(usuarioDigitado))
                throw new Exception("Por favor, preecha o e-mail/CPF e a senha.");

            Usuario admEncontrado = UsuarioRepository.lista_adm
                .Cast<Usuario>()
                .FirstOrDefault(i => (usuarioDigitado == i.Email || usuarioDigitado == i.CPF) &&
                                      senhaDigitada == i.Senha);

            if (admEncontrado != null)
            {
                UsuarioRepository.usuario_logado = admEncontrado;
                App.Current.MainPage = new NavigationPage(new FlyoutPageADM());
            }
            else if (UsuarioRepository.lista_voluntarios != null)
            {
                Usuario voluntarioEncontrado = UsuarioRepository.ListaVoluntarios
                    .Cast<Usuario>()
                    .FirstOrDefault(i => (usuarioDigitado == i.Email || usuarioDigitado == i.CPF) &&
                                         senhaDigitada == i.Senha);

                if (voluntarioEncontrado != null)
                {
                    UsuarioRepository.usuario_logado = voluntarioEncontrado;
                    App.Current.MainPage = new NavigationPage(new FlyoutPageVoluntario());
                }
                else
                {
                    throw new Exception("Usuário ou senha inválidos.");
                }
            }
            else
            {
                throw new Exception("Usuário ou senha inválidos.");
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }

    private void ButtonVerSenha(object sender, EventArgs e)
    {
        txt_senha.IsPassword = !txt_senha.IsPassword;

        var button = (ImageButton)sender;

        if (txt_senha.IsPassword)
        {
            button.Source = "olho_aberto.png";
        }
        else
        {
            button.Source = "olho_fechado.png";
        }
    }

    private async void OnTapRecuperarSenha(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecuperarSenha());
    }
}