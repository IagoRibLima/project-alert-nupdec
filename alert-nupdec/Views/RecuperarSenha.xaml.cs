using alert_nupdec.Models;
using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class RecuperarSenha : ContentPage
{
	public RecuperarSenha()
	{
		InitializeComponent();
	}

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ButtonProcurar(object sender, EventArgs e)
    {
        try
        {
            string emailDigitado = txt_email.Text?.Trim();
            string cpfDigitado = txt_cpf.Text?.Trim();

            string idNovaSenha = UsuarioRepository.AlterarSenha(emailDigitado, cpfDigitado);

            if (idNovaSenha != null)
            {
                await Navigation.PushAsync(new RecuperarSenhaAlteracao());
            }
            else
            {
                await DisplayAlert("Erro", "Email ou CPF incorretos. Tente novamente.", "Fechar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }
}