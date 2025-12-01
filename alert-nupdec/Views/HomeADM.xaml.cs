using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class HomeADM : ContentPage
{
    public HomeADM()
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

    //Botão de emitir alerta
    private async void ButtonEmitirAlerta(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmitirAlerta());
    }
}