using alert_nupdec.Repository;

namespace alert_nupdec;

public partial class FlyoutPageVoluntario : FlyoutPage
{
	public FlyoutPageVoluntario()
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
            App.Current.MainPage = new Login();
        }
    }
}