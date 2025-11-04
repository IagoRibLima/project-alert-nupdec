using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Configuracoes : ContentPage
{
	public Configuracoes()
	{
		InitializeComponent();
	}

    private async void ButtonDisconect(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Deseja realmente sair do aplicativo?", "Sim", "Não");

        if (confirmacao)
        {
            UsuarioRepository.usuario_logado = null;
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }
}