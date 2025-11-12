namespace alert_nupdec.Views;

public partial class Cursos : ContentPage
{
	public Cursos()
	{
		InitializeComponent();
	}

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}