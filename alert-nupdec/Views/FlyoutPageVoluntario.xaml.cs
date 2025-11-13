namespace alert_nupdec.Views;

public partial class FlyoutPageVoluntario : FlyoutPage
{
	public FlyoutPageVoluntario()
	{
		InitializeComponent();
	}

    private async void OnTapDicas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dicas());
    }

    private async void OnTapTreinamentos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Treinamentos());
    }

    private async void OnTapConfiguracoes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Configuracoes());
    }
}