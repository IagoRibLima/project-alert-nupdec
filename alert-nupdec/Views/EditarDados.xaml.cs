namespace alert_nupdec.Views;

public partial class EditarDados : ContentPage
{
	public EditarDados()
	{
		InitializeComponent();
	}

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}