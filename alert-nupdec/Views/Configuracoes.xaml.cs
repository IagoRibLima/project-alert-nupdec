using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Configuracoes : ContentPage
{
	public Configuracoes()
	{
		InitializeComponent();

        // Carregar os dados do usuário logado
        Task.Run(async () =>
        {
            lbl_usuario.Text = $"{UsuarioRepository.usuario_logado.NomeCompleto}";
            lbl_email.Text = $"{UsuarioRepository.usuario_logado.Email}";
            lbl_senha.Text = $"{UsuarioRepository.usuario_logado.Senha}";
        });
    }

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Botão de alterar nome
    private async void ButtonAlterarNome(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AlterarNome());
    }
    
    //Botão de alterar email
    private async void ButtonAlterarEmail(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AlterarEmail());
    }

    //Botão de alterar senha
    private async void ButtonAlterarSenha(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AlterarSenha());
    }

    //Botão de desconectar
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