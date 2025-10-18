using alert_nupdec.Models;
using System.Collections;

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
            ArrayList lista_adm = new ArrayList()
            {
                new Usuario()
                {
                    Username = "Iago",
                    Senha = "iago123"
                },
                new Usuario()
                {
                    Username = "Pri",
                    Senha = "pri123"
                }
            };

            Usuario dados_digitados = new Usuario()
            {
                Username = txt_usuario.Text,
                Senha = txt_senha.Text
            };

            if(lista_adm.
                Cast<Usuario>().
                Any(i => (dados_digitados.Username == i.Username && 
                          dados_digitados.Senha == i.Senha)))
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Username);

                App.Current.MainPage = new Home();
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
}