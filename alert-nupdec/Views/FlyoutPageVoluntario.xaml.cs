using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class FlyoutPageVoluntario : FlyoutPage
{
	public FlyoutPageVoluntario()
	{
		InitializeComponent();
	}

    //Botão para ver dicas
    private async void OnTapDicas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dicas());
    }

    //Botão para ver treinamentos
    private async void OnTapTreinamentos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Treinamentos());
    }

    //Botão de configurações
    private async void OnTapConfiguracoes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Configuracoes());
    }

    //Botão de sair
    private async void OnTapSair(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Deseja realmente sair do aplicativo?", "Sim", "Não");

        if (confirmacao)
        {
            UsuarioRepository.usuario_logado = null;
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }
}