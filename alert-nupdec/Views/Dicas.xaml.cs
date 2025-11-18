using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Dicas : ContentPage
{
	public Dicas()
	{
		InitializeComponent();
        // Carrega as dicas ao inicializar a página
        CarregarDicas();
	}

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Método para carregar as dicas na ListView
    private void CarregarDicas()
    {
        lista_dicas.ItemsSource = DicasRepository.list_dicas;
    }
}