namespace alert_nupdec.Views;

public partial class VizualizarVoluntario : ContentPage
{
	public VizualizarVoluntario()
	{
		InitializeComponent();
	}

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}