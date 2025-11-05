using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class HomeVoluntario : ContentPage
{
	public HomeVoluntario()
	{
		InitializeComponent();

        string? usuario_logado = null;

        Task.Run(async () =>
        {
            lbl_boasvindas.Text = $"Voluntário: {UsuarioRepository.usuario_logado.NomeCompleto}";
            lbl_unidade.Text = $"Nupdec - {UsuarioRepository.usuario_logado.Unidade}";
        });
    }

    private async void ButtonEmitirAlerta(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmitirAlerta());
    }
}