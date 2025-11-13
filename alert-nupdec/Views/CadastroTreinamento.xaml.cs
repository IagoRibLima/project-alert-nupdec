using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class CadastroTreinamento : ContentPage
{
	public CadastroTreinamento()
	{
		InitializeComponent();
	}

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void ButtonCadastrarTreinamento(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txt_nome_treinamento.Text) ||
            string.IsNullOrWhiteSpace(txt_vaga.Text) ||
            string.IsNullOrWhiteSpace(txt_descricao.Text))
        {
            await DisplayAlert("Atenção", "Preencha todos os campos obrigatórios.", "OK");
            return;
        }

        var treinamento = new alert_nupdec.Models.Treinamento
        {
            Nome = txt_nome_treinamento.Text.Trim(),
            Vaga = txt_vaga.Text.Trim(),
            Descricao = txt_descricao.Text.Trim()
        };


        TreinamentoRepository.cadastrarTreinamento(treinamento);

        await DisplayAlert("Sucesso", "Treinamento cadastrado com sucesso!", "OK");

        txt_nome_treinamento.Text = string.Empty;
        txt_vaga.Text = string.Empty;
        txt_descricao.Text = string.Empty;
    }
}