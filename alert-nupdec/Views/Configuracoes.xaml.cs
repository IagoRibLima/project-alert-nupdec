using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Configuracoes : ContentPage
{
	public Configuracoes()
	{
		InitializeComponent();

        Task.Run(async () =>
        {
            lbl_usuario.Text = $"{UsuarioRepository.usuario_logado.NomeCompleto}";
            lbl_email.Text = $"{UsuarioRepository.usuario_logado.Email}";
            lbl_senha.Text = $"{UsuarioRepository.usuario_logado.Senha}";
        });
    }

    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
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
}