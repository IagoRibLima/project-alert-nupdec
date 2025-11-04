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
            lbl_boasvindas.Text = $"Bem-vindo(a) {UsuarioRepository.usuario_logado.NomeCompleto}";
        });
    }

    private async void ButtonDisconect(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Deseja realmente sair do aplicativo?", "Sim", "Não");

        if (confirmacao)
        {
            UsuarioRepository.usuario_logado = null;
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }

    private async void ButtonEmitirAlerta(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmitirAlerta());
    }
}