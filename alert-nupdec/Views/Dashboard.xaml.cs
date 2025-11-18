namespace alert_nupdec.Views;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
	}

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}