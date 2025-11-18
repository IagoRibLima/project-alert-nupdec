using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class RecuperarSenhaAlteracao : ContentPage
{
	public RecuperarSenhaAlteracao()
	{
		InitializeComponent();

        Task.Run(async () =>
        {
            lbl_nome.Text = $"{UsuarioRepository.idUsuarioEncontrado.NomeCompleto}";
            lbl_email.Text = $"{UsuarioRepository.idUsuarioEncontrado.Email}";
            lbl_cpf.Text = $"{UsuarioRepository.idUsuarioEncontrado.CPF}";
        });
    }

	private async void ButtonVoltar(object sender, EventArgs e)
	{
		UsuarioRepository.idUsuarioEncontrado = null;
        await Navigation.PopAsync();
    }

	private async void ButtonAlterar(object sender, EventArgs e)
	{
		try
		{
			string novaSenha = txt_senha.Text?.Trim();
			string confirmarSenha = txt_confirmarsenha.Text?.Trim();

			UsuarioRepository.AtualizarSenha(novaSenha, confirmarSenha);

			await DisplayAlert("Sucesso", "Senha alterada com sucesso!", "Fechar");

			await Navigation.PopToRootAsync();

        }
		catch (Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "Fechar");
		}
	}

    private void ButtonVerSenha(object sender, EventArgs e)
    {
        txt_senha.IsPassword = !txt_senha.IsPassword;

        var button = (ImageButton)sender;

        if (txt_senha.IsPassword)
        {
            button.Source = "olho_aberto.png";
        }
        else
        {
            button.Source = "olho_fechado.png";
        }
    }

    private void ButtonVerConfirmarSenha(object sender, EventArgs e)
    {
        txt_confirmarsenha.IsPassword = !txt_confirmarsenha.IsPassword;

        var button = (ImageButton)sender;

        if (txt_confirmarsenha.IsPassword)
        {
            button.Source = "olho_aberto.png";
        }
        else
        {
            button.Source = "olho_fechado.png";
        }
    }
}