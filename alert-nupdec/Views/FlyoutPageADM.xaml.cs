namespace alert_nupdec.Views;

public partial class FlyoutPageADM : FlyoutPage
{
	public FlyoutPageADM()
	{
		InitializeComponent();
	}

    private async void OnTapCadastrarVoluntario(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroVoluntario());
    }

    private async void OnTapCadastroDica(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroDica());
    }

    private async void OnTapCadastroTreinamento(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroTreinamento());
    }

    private async void OnTapConfiguracoes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Configuracoes());
    }

    private async void OnTapAreaDeRisco(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AreaDeRisco());
    }

    private async void OnTapDashboard(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dashboard());
    }

    private async void OnTapOcorrencia(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Ocorrencias());
    }
}