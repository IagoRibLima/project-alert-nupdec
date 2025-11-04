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
            lbl_unidade.Text = $"Nupdec - {UsuarioRepository.usuario_logado.Unidade}";
        });
    }

    private async void ButtonEmitirAlerta(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmitirAlerta());
    }

    private void ButtonMenu(object sender, EventArgs e)
    {
        if (App.Current.MainPage is FlyoutPage flyoutPage)
        {
            flyoutPage.IsPresented = true;
        }
    }
}