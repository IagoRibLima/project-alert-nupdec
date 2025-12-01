using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class HomeVoluntario : ContentPage
{
    public HomeVoluntario()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Recarrega a lista toda vez que a p?gina se torna vis?vel (ex: ao voltar de EmitirAlerta)
        lista_alertas.ItemsSource = null; // Limpa para for?ar o refresh
        lista_alertas.ItemsSource = AlertaRepository.list_alerta;
        CarregarDadosUsuario();
    }

    private void CarregarDadosUsuario()
    {
        if (UsuarioRepository.usuario_logado != null)
        {
            lbl_boasvindas.Text = $"Administrador: {UsuarioRepository.usuario_logado.NomeCompleto}";
            lbl_unidade.Text = $"Nupdec - {UsuarioRepository.usuario_logado.Unidade.enderecoCompleto} - {UsuarioRepository.usuario_logado.Unidade.cep}";
        }

        if (UsuarioRepository.usuario_logado != null && !string.IsNullOrEmpty(UsuarioRepository.usuario_logado.Foto))
        {
            byte[] imageByte = Convert.FromBase64String(UsuarioRepository.usuario_logado.Foto);
            img_perfil.Source = ImageSource.FromStream(() => new MemoryStream(imageByte));
        }
        else
        {
            img_perfil.Source = "usuario.png";
        }
    }

    //Bot?o de emitir alerta
    private async void ButtonEmitirAlerta(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmitirAlerta());
    }
}