using alert_nupdec.Models;
using System.Collections;

namespace alert_nupdec;

public partial class Login : ContentPage
{
    ArrayList lista_adm = new ArrayList()
    {
        new Usuario()
        {
            NomeCompleto = "Iago Lima",
            Email = "iago@email.com",
            Telefone = "11999999999",
            Unidade = "central",
            Senha = "123"
        },
        new Usuario()
        {
            NomeCompleto = "Pri Couto",
            Email = "pri@email.com",
            Telefone = "11988888888",
            Unidade = "central",
            Senha = "123"
        }
    };

    public Login()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
            Usuario dados_digitados = new Usuario()
            {
                Email = txt_usuario.Text,
                Senha = txt_senha.Text
            };

            if(lista_adm.
                Cast<Usuario>().
                Any(i => (dados_digitados.Email == i.Email && 
                          dados_digitados.Senha == i.Senha)))
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.NomeCompleto);

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