using alert_nupdec.Repository;
using alert_nupdec.Models;

namespace alert_nupdec.Views;

public partial class CadastroDica : ContentPage
{
	public CadastroDica()
	{
		InitializeComponent();
	}

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Botão com metodo para cadastrar a dica
    private async void ButtonCadastrarDica(object sender, EventArgs e)
    {
        string dica = txt_nome_dica.Text;
        string descricao = txt_descricao.Text;

        if (string.IsNullOrWhiteSpace(dica) ||
            string.IsNullOrWhiteSpace(descricao))
        {
            await DisplayAlert("Erro", "Preencha os campos título e descrição.", "OK");
            return;
        }

        DicasRepository.cadastrarDicas(dica, descricao);

        await DisplayAlert("Sucesso", "Dica cadastrada com sucesso!", "OK");

        txt_nome_dica.Text = string.Empty;
        txt_descricao.Text = string.Empty;
    }
}