using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class CadastroUnidade : ContentPage
{
    public CadastroUnidade()
    {
        InitializeComponent();
    }
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // Método para cadastrar uma nova unidade
    private async void ButtonCadastrar(object sender, EventArgs e)
    {
        try
        {
            string nome = txt_nome.Text?.Trim();
            string enderecoCompleto = txt_enderecoCompleto.Text?.Trim();
            string cep = txt_cep.Text?.Trim();
            string descricao = txt_descricao.Text?.Trim();

            UnidadeRepository.cadastrarUnidade(nome, enderecoCompleto, cep, descricao);

            await DisplayAlert("Sucesso", "Unidade cadastrada com sucesso!", "Fechar");

            txt_nome.Text = string.Empty;
            txt_enderecoCompleto.Text = string.Empty;
            txt_cep.Text = string.Empty;
            txt_descricao.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro ao cadastrar a área de risco: \n{ex.Message}", "OK");
        }
    }    

}