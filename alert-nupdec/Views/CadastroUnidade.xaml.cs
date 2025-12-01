using alert_nupdec.Repository;
using alert_nupdec.Service;

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
            img_unidade.IsVisible = false;
            UnidadeRepository.ImagemBase64Temp = null;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro ao cadastrar a área de risco: \n{ex.Message}", "OK");
        }
    }

    private async void ButtonSelecionarImagem(object sender, EventArgs e)
    {
        var imageService = new ImageService();

        try
        {
            string base64Result = await imageService.SelecionarFotoAsync();

            if (string.IsNullOrEmpty(base64Result))
                return;
            UnidadeRepository.ImagemBase64Temp = base64Result;
            img_unidade.IsVisible = true;
            byte[] imageByte = Convert.FromBase64String(UnidadeRepository.ImagemBase64Temp);
            img_unidade.Source = ImageSource.FromStream(() => new MemoryStream(imageByte));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha ao selecionar imagem: {ex.Message}", "OK");
        }
    }
}