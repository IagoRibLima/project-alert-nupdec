using alert_nupdec.Models;
using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    //Botão com metodo para fazer o login
    private async void ButtonLogin(object sender, EventArgs e)
    {
        try
        {
            string usuarioDigitado = txt_usuario.Text?.Trim();
            string senhaDigitada = txt_senha.Text;

            if (string.IsNullOrWhiteSpace(usuarioDigitado) || string.IsNullOrWhiteSpace(senhaDigitada))
                throw new Exception("Por favor, preecha o e-mail/CPF e a senha.");

            UsuarioRepository.login(usuarioDigitado, senhaDigitada);

            if (UsuarioRepository.usuario_logado.Adm == true)
            {
                App.Current.MainPage = new NavigationPage(new FlyoutPageADM());
            }
            if (UsuarioRepository.usuario_logado.Adm == false)
            {
                App.Current.MainPage = new NavigationPage(new FlyoutPageVoluntario());
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }

    //Botão que esconde e mostra a senha
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

    //Botão que muda para a pagina de recuperar senha 
    private async void OnTapRecuperarSenha(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecuperarSenha());
    }
}