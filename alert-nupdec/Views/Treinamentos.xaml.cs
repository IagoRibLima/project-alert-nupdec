using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Treinamentos : ContentPage
{
	public Treinamentos()
	{
		InitializeComponent();
        // Carrega os treinamentos ao iniciar a página
        CarregarTreinamentos();
    }

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Metodo para carregar as dicas na ListView
    private void CarregarTreinamentos()
    {

        lista_treinamentos.ItemsSource = TreinamentoRepository.ListarTreinamentos();
    }
}