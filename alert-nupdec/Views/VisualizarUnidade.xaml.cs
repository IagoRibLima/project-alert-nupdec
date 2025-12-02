using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class VisualizarUnidade : ContentPage
{
	public VisualizarUnidade()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        lista_unidade.ItemsSource = null;
        lista_unidade.ItemsSource = UnidadeRepository.list_unidade;
    }

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}