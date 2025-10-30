using alert_nupdec.Models;
using alert_nupdec.Repository;
using System.Security.Cryptography.X509Certificates;

namespace alert_nupdec;

public partial class Login : ContentPage
{
    public Login()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
            string emailDigitado = txt_usuario.Text?.Trim();
            string senhaDigitada = txt_senha.Text;

            if (string.IsNullOrWhiteSpace(emailDigitado))
                throw new Exception("Por favor, preecha o e-mail e a senha.");

            Usuario admEncontrado = UsuarioRepository.lista_adm
                .Cast<Usuario>()
                .FirstOrDefault(i => emailDigitado == i.Email && senhaDigitada == i.Senha);

            if (admEncontrado != null)
            {
                UsuarioRepository.usuario_logado = admEncontrado;
                App.Current.MainPage = new Home();
            }
            else if (UsuarioRepository.lista_voluntarios != null)
            {
                Usuario voluntarioEncontrado = UsuarioRepository.ListaVoluntarios
                    .Cast<Usuario>()
                    .FirstOrDefault(i => emailDigitado == i.Email && senhaDigitada == i.Senha);

                if (voluntarioEncontrado != null)
                {
                    UsuarioRepository.usuario_logado = voluntarioEncontrado;
                    App.Current.MainPage = new HomeVoluntario();
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

    private void SenhaButton_Clicked(object sender, EventArgs e)
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