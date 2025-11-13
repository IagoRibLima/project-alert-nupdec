using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Dicas : ContentPage
{
	public Dicas()
	{
		InitializeComponent();
        CarregarDicas();
	}

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void CarregarDicas()
    {
        lista_dicas.ItemsSource = DicasRepository.list_dicas;
    }
}