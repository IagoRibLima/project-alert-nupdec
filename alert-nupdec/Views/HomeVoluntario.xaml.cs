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
            //usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            lbl_boasvindas.Text = $"Bem-vindo(a) {UsuarioRepository.usuario_logado.NomeCompleto}";
        });
    }

    private async void DisconectButton_Clicked(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Deseja realmente sair do aplicativo?", "Sim", "Não");

        if (confirmacao)
        {
            UsuarioRepository.usuario_logado = null;
            App.Current.MainPage = new Login();
        }
    }

    private async void EmitirAlertaButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmitirAlerta());
    }
}