namespace alert_nupdec.Views;

public partial class RecuperarSenhaAlteracao : ContentPage
{
	public RecuperarSenhaAlteracao()
	{
		InitializeComponent();
	}

	private async void ButtonVoltar(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
    }

	private async void ButtonAlterar(object sender, EventArgs e) 
	{ 
	
	}
}