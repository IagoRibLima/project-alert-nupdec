using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class CadastroTreinamento : ContentPage
{
	public CadastroTreinamento()
	{
		InitializeComponent();
	}

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Botão com metodo de cadastrar o treinamento
    private async void ButtonCadastrarTreinamento(object sender, EventArgs e)
    {
        string nome = txt_nome_treinamento.Text;
        string vaga = txt_vaga.Text;
        string descricao = txt_descricao.Text;

        if (string.IsNullOrWhiteSpace(nome) ||
            string.IsNullOrWhiteSpace(vaga) ||
            string.IsNullOrWhiteSpace(descricao))
        {
            await DisplayAlert("Atenção", "Preencha todos os campos obrigatórios.", "OK");
            return;
        }        

        TreinamentoRepository.cadastrarTreinamento(nome, vaga, descricao);

        await DisplayAlert("Sucesso", "Treinamento cadastrado com sucesso!", "OK");

        txt_nome_treinamento.Text = string.Empty;
        txt_vaga.Text = string.Empty;
        txt_descricao.Text = string.Empty;
    }
}