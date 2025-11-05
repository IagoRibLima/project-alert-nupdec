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