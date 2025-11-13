using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Treinamentos : ContentPage
{
	public Treinamentos()
	{
		InitializeComponent();
        CarregarTreinamentos();
    }

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void CarregarTreinamentos()
    {

        lista_treinamentos.ItemsSource = TreinamentoRepository.ListarTreinamentos();
    }
}