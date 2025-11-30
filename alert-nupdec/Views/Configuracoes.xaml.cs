using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class Configuracoes : ContentPage
{
	public Configuracoes()
	{
		InitializeComponent();     
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarDadosUsuario();
    }

    //Carrega os dados do usuário logado
    private void CarregarDadosUsuario()
    {
        if (UsuarioRepository.usuario_logado != null)
        {
            lbl_usuario.Text = $"{UsuarioRepository.usuario_logado.NomeCompleto}";
            lbl_email.Text = $"{UsuarioRepository.usuario_logado.Email}";
            lbl_cpf.Text = $"{UsuarioRepository.usuario_logado.CPF}";
            lbl_telefone.Text = $"{UsuarioRepository.usuario_logado.Telefone}";
            lbl_unidade.Text = $"{UsuarioRepository.usuario_logado.Unidade.Bairro}";
            lbl_senha.Text = $"{UsuarioRepository.usuario_logado.Senha}";
        }
    }

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Botão de alterar nome
    private async void ButtonEditar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditarDados());
    }            
}