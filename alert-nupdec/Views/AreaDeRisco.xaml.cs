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
            var erros = new List<string>();

            string rua = txt_rua.Text?.Trim();
            string bairro = txt_bairro.Text?.Trim();
            string cep = txt_cep.Text?.Trim();

            if (string.IsNullOrWhiteSpace(rua))
                erros.Add("É necessário informar a rua.");
            if (string.IsNullOrWhiteSpace(bairro))
                erros.Add("É necessário informar o bairro.");
            if (string.IsNullOrWhiteSpace(cep))
                erros.Add("É necessário informar o CEP.");

            if (!string.IsNullOrWhiteSpace(cep)) { 
                string numeroCep = new string(cep.Where(char.IsDigit).ToArray());
                if (numeroCep.Length != 8)
                    erros.Add("O campo CEP deve conter 8 dígitos.");
            }

            if (erros.Count > 0)
            {
                string mensagemErro = string.Join("\n", erros);
                await DisplayAlert("Campos inválidos", mensagemErro, "Corrigir");
                return;
            }

            AreaRisco area = new AreaRisco()
            {
                Rua = rua,
                Bairro = bairro,
                CEP = cep
            };

            AreaDeRiscoRepository.cadastrarArea(area);

            await DisplayAlert("Sucesso", "Área de risco cadastrada com sucesso!", "Fechar");

            txt_rua.Text = string.Empty;
            txt_bairro.Text = string.Empty;
            txt_cep.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro ao cadastrar a área de risco: {ex.Message}", "OK");
        }
    }
}