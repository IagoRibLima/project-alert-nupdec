using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class HomeADM : ContentPage
{
	public HomeADM()
	{
		InitializeComponent();

		string? usuario_logado = null;

        Task.Run(async () =>
        {
            lbl_boasvindas.Text = $"Administrador: {UsuarioRepository.usuario_logado.NomeCompleto}";
            lbl_unidade.Text = $"Nupdec - {UsuarioRepository.usuario_logado.Unidade.Bairro} - {UsuarioRepository.usuario_logado.Unidade.CEP}";
        });
    }

    private async void ButtonEmitirAlerta(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmitirAlerta());
    }
}