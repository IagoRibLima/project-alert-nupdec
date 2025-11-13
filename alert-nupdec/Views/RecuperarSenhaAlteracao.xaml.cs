using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class RecuperarSenhaAlteracao : ContentPage
{
	public RecuperarSenhaAlteracao()
	{
		InitializeComponent();
	}

	private async void ButtonVoltar(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
    }

	private async void ButtonAlterar(object sender, EventArgs e)
	{
		try
		{
			string novaSenha = txt_senha.Text?.Trim();
			string confirmarSenha = txt_confirmarsenha.Text?.Trim();

			UsuarioRepository.AtualizarSenha(novaSenha, confirmarSenha);


        }
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "Fechar");
		}
	}
}