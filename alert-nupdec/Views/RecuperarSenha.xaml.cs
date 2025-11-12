namespace alert_nupdec.Views;

public partial class RecuperarSenha : ContentPage
{
	public RecuperarSenha()
	{
		InitializeComponent();
	}

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ButtonProcurar(object sender, EventArgs e)
    {

    }
}