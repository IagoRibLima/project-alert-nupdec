using alert_nupdec.Models;
using alert_nupdec.Repository;

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
            string imagem = txt_imagem.Text?.Trim();                        

            AlertaRepository.cadastrarAlerta(tipo, endereco, descricao, imagem);

            await DisplayAlert("Sucesso", "Alerta emitido com sucesso", "Fechar");

            picker_ocorrencia.SelectedItem = null;
            txt_descricao.Text = string.Empty;
            txt_endereco.Text = string.Empty;
            txt_imagem.Text = string.Empty;

            OnAppearing();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }

}