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

            await DisplayAlert("Sucesso", "Área de risco cadastrada com sucesso!", "Fechar");

            txt_nomeArea.Text = string.Empty;
            txt_enderecoCompleto.Text = string.Empty;
            txt_cep.Text = string.Empty;
            picker_tipoProblema.SelectedIndex = 0;
            txt_descricao.Text = string.Empty;
            chkRiscoImediato.IsChecked = false;
            img_perfil.IsVisible = false;
            AreaDeRiscoRepository.ImagemBase64Temp = null;

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro ao cadastrar a área de risco: \n{ex.Message}", "OK");
        }
    }

    private void picker_Select(object sender, EventArgs e)
    {
        var itemSelecionado = picker_tipoProblema.SelectedItem?.ToString();
    }



    private async void ButtonSelecionarImagem(object sender, EventArgs e)
    {
        // Agora esta linha vai funcionar porque criamos a classe ImageService no Passo 2
        var imageService = new ImageService();

        try
        {
            string base64Result = await imageService.SelecionarFotoAsync();

            if (string.IsNullOrEmpty(base64Result))
                return;
            AreaDeRiscoRepository.ImagemBase64Temp = base64Result;
            img_perfil.IsVisible = true;
            byte[] imageByte = Convert.FromBase64String(AreaDeRiscoRepository.ImagemBase64Temp);
            img_perfil.Source = ImageSource.FromStream(() => new MemoryStream(imageByte));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha ao selecionar imagem: {ex.Message}", "OK");
        }
    }
}