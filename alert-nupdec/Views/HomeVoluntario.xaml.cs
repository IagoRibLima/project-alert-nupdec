namespace alert_nupdec;

public partial class HomeVoluntario : ContentPage
{
	public HomeVoluntario()
	{
		InitializeComponent();

        string? usuario_logado = null;

        Task.Run(async () =>
        {
            usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            lbl_boasvindas.Text = $"Bem-vindo(a) {usuario_logado}";
        });
    }

    private async void DisconectButton_Clicked(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Deseja realmente sair do aplicativo?", "Sim", "Não");

        if (confirmacao)
        {
            SecureStorage.Default.Remove("usuario_logado");
            App.Current.MainPage = new Login();
        }
    }
}