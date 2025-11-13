using alert_nupdec.Repository;
using alert_nupdec.Models;

namespace alert_nupdec.Views;

public partial class CadastroDica : ContentPage
{
	public CadastroDica()
	{
		InitializeComponent();
	}

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ButtonCadastrarDica(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txt_nome_dica.Text) ||
            string.IsNullOrWhiteSpace(txt_descricao.Text))
        {
            await DisplayAlert("Atenção", "Preencha todos os campos obrigatórios.", "OK");
            return;
        }

        var dica = new alert_nupdec.Models.Dicas
        {
            NomeDica = txt_nome_dica.Text.Trim(),
            Descricao = txt_descricao.Text.Trim()
        };


        DicasRepository.cadastrarDicas(dica);

        await DisplayAlert("Sucesso", "Dica cadastrada com sucesso!", "OK");

        txt_nome_dica.Text = string.Empty;
        txt_descricao.Text = string.Empty;
    }
}