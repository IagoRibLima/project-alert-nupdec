namespace alert_nupdec.Views;

public partial class Ocorrencias : ContentPage
{
	public Ocorrencias()
	{
		InitializeComponent();
	}

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}