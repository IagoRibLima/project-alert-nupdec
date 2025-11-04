using alert_nupdec.Repository;

namespace alert_nupdec.Views;

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
            UsuarioRepository.usuario_logado = null;
            App.Current.MainPage = new Login();
        }
    }

    private async void OnTapDicas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dicas());
    }

    private async void OnTapCursos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cursos());
    }

    private async void OnTapConfiguracoes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Configuracoes());
    }
}