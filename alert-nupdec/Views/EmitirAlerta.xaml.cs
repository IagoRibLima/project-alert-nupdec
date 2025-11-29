using alert_nupdec.Models;
using alert_nupdec.Repository;
using alert_nupdec.Service;

namespace alert_nupdec.Views;

public partial class EmitirAlerta : ContentPage
{
	public EmitirAlerta()
	{
		InitializeComponent();

        //Tipos de ocorrências
        picker_ocorrencia.ItemsSource = new List<string>
        {
            "Unidade A",
            "Unidade B",
            "Unidade C",
            "Unidade D"
        };
    }

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {        
        await Navigation.PopAsync();
    }

    //Botão com metodo para emitir alerta
    private async void ButtonEmitirAlerta(object sender, EventArgs e) 
    {
        try
        {           
            string tipo = picker_ocorrencia.SelectedItem as string;
            string endereco = txt_endereco.Text?.Trim();
            string descricao = txt_descricao.Text?.Trim();
            //string imagem = txt_imagem.Text?.Trim();                        

            AlertaRepository.cadastrarAlerta(tipo, endereco, descricao);

            await DisplayAlert("Sucesso", "Alerta emitido com sucesso", "Fechar");

            picker_ocorrencia.SelectedItem = null;
            txt_descricao.Text = string.Empty;
            txt_endereco.Text = string.Empty;            

            OnAppearing();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
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

            AlertaRepository.ImagemBase64Temp = base64Result;

            await DisplayAlert("Imagem Selecionada", "Imagem selecionada com sucesso!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha ao selecionar imagem: {ex.Message}", "OK");
        }
    }
}