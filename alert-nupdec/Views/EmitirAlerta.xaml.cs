using alert_nupdec.Models;
using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class EmitirAlerta : ContentPage
{
	public EmitirAlerta()
	{
		InitializeComponent();
        picker_ocorrencia.ItemsSource = new List<string>
        {
            "Unidade A",
            "Unidade B",
            "Unidade C",
            "Unidade D"
        };
	}

    private async void VoltarButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private async void EmitirOKButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            var erros = new List<string>();

            string tipo = picker_ocorrencia.SelectedItem as string;
            string endereco = txt_endereco.Text?.Trim();
            string descricao = txt_descricao.Text?.Trim();
            string imagem = txt_imagem.Text?.Trim();

            if (string.IsNullOrWhiteSpace(tipo))
                erros.Add("É necessário selecionar o tipo de ocorrência");
            if (string.IsNullOrWhiteSpace(endereco))
                erros.Add("É necessário informa o endereço da ocorrência");
            if (string.IsNullOrWhiteSpace(descricao))
                erros.Add("descreva a ocorrência");
            if (string.IsNullOrEmpty(imagem))
                erros.Add("envie uma imagem da ocorrência");

            if (erros.Count > 0)
            {
                string mensagemErro = string.Join("\n", erros);
                await DisplayAlert("Campos inválidos", mensagemErro, "Corrigir");
                return;
            }

            Alerta alerta = new Alerta()
            {
                Tipo = tipo,
                Endereco = endereco,
                Descricao = descricao,
                Imagem = imagem,
                Usuario = UsuarioRepository.usuario_logado
            };

            AlertaRepository.cadastrarAlerta(alerta);

            await DisplayAlert("Sucesso", "Alerta emitido com sucesso", "Fechar");

            picker_ocorrencia.SelectedItem = null;
            txt_descricao.Text = string.Empty;
            txt_endereco.Text = string.Empty;
            txt_imagem.Text = string.Empty;
        }
        catch (Exception ex) 
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }
}