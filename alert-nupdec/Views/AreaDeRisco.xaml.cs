using alert_nupdec.Models;
using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class AreaDeRisco : ContentPage
{
	public AreaDeRisco()
	{
		InitializeComponent();
	}

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // Método para cadastrar uma nova área de risco
    private async void ButtonCadastrar(object sender, EventArgs e)
    {
        try
        {           
            string rua = txt_rua.Text?.Trim();
            string bairro = txt_bairro.Text?.Trim();
            string cep = txt_cep.Text?.Trim();                                  

            AreaDeRiscoRepository.cadastrarArea(rua, bairro, cep);

            await DisplayAlert("Sucesso", "Área de risco cadastrada com sucesso!", "Fechar");

            txt_rua.Text = string.Empty;
            txt_bairro.Text = string.Empty;
            txt_cep.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro ao cadastrar a área de risco: \n{ex.Message}", "OK");
        }
    }
}