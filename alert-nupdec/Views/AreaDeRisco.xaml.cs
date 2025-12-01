using alert_nupdec.Repository;
using alert_nupdec.Service;
namespace alert_nupdec.Views;

public partial class AreaDeRisco : ContentPage
{
    public AreaDeRisco()
    {
        InitializeComponent();
        picker_tipoProblema.SelectedIndex = 0;
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
            string nomeArea = txt_nomeArea.Text?.Trim();
            string enderecoCompleto = txt_enderecoCompleto.Text?.Trim();
            string cep = txt_cep.Text?.Trim();
            var itemSelecionado = picker_tipoProblema.SelectedItem?.ToString();
            string descricao = txt_descricao.Text?.Trim();
            bool riscoImediato = chkRiscoImediato.IsChecked ? true : false;

            AreaDeRiscoRepository.cadastrarArea(nomeArea, enderecoCompleto, cep, itemSelecionado, descricao, riscoImediato);

            await DisplayAlert("Sucesso", "�rea de risco cadastrada com sucesso!", "Fechar");

            txt_nomeArea.Text = string.Empty;
            txt_enderecoCompleto.Text = string.Empty;
            txt_cep.Text = string.Empty;
            picker_tipoProblema.SelectedItem = null;
            txt_descricao.Text = string.Empty;
            chkRiscoImediato.IsChecked = false;

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro ao cadastrar a �rea de risco: \n{ex.Message}", "OK");
        }
    }

    private void picker_Select(object sender, EventArgs e)
    {
        var itemSelecionado = picker_tipoProblema.SelectedItem?.ToString();
    }

    private async void ButtonSelecionarImagem(object sender, EventArgs e)
    {        
        var imageService = new ImageService();

        try
        {
            string base64Result = await imageService.SelecionarFotoAsync();

            if (string.IsNullOrEmpty(base64Result))
                return;
            AreaDeRiscoRepository.ImagemBase64Temp = base64Result;

            await DisplayAlert("Imagem Selecionada", "Imagem selecionada com sucesso!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha ao selecionar imagem: {ex.Message}", "OK");
        }
    }
}