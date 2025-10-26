using alert_nupdec.Models;
using alert_nupdec.Repository;
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
            Usuario dados_digitados = new Usuario()
            {
                NomeCompleto = txt_usuario.Text,
                Senha = txt_senha.Text
            };

            if(UsuarioRepository.lista_adm.
                Cast<Usuario>().
                Any(i => (dados_digitados.NomeCompleto == i.NomeCompleto && 
                          dados_digitados.Senha == i.Senha)))
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.NomeCompleto);

                App.Current.MainPage = new Home();
            }
            else if (UsuarioRepository.ListaVoluntarios != null &&
                     UsuarioRepository.ListaVoluntarios.
                     Cast<Usuario>().
                     Any(i => (dados_digitados.NomeCompleto == i.NomeCompleto &&
                               dados_digitados.Senha == i.Senha)))
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.NomeCompleto);
                App.Current.MainPage = new HomeVoluntario();
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