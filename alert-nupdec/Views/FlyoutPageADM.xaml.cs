using alert_nupdec.Repository;

namespace alert_nupdec;

public partial class FlyoutPageADM : FlyoutPage
{
	public FlyoutPageADM()
	{
		InitializeComponent();
    }

    private async void DisconectButton_Clicked(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Deseja realmente sair do aplicativo?", "Sim", "Não");

        if (confirmacao)
        {
            //SecureStorage.Default.Remove("usuario_logado");
            UsuarioRepository.usuario_logado = null;
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }

    private async void CadastrarButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroVoluntario());
    }
}