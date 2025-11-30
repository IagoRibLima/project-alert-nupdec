namespace alert_nupdec.Views;
using alert_nupdec.Repository;
using alert_nupdec.Service;

public partial class EditarDados : ContentPage
{
    public EditarDados()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarDadosAtuais();
    }

    private void CarregarDadosAtuais()
    {
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

    private async void MudarFoto_Tapped(object sender, EventArgs e)
    {
        try
        {
            var service = new ImageService();
            string? base64Foto = await service.SelecionarFotoAsync();

            if (base64Foto != null)
            {
                // 1. Guardamos a string na variável temporária
                UsuarioRepository.fotoPerfilTemp = base64Foto;

                // 2. Atualizamos visualmente a imagem na tela imediatamente
                byte[] imageBytes = Convert.FromBase64String(base64Foto);
                img_perfil.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "Não foi possível carregar a foto: " + ex.Message, "OK");
        }
    }

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    //Botão de alterar dados
    private async void ButtonAlterar(object sender, EventArgs e)
    {
        try
        {
            string email = txt_novoemail.Text?.Trim();
            string telefone = txt_novotelefone.Text?.Trim();
            string senha = txt_novasenha.Text?.Trim();
            string confirmarSenha = txt_confirmarnovasenha.Text?.Trim();

            string resultado = UsuarioRepository.AtualizarDadosUsuario(email, telefone, senha, confirmarSenha);

            await DisplayAlert("Sucesso", resultado, "Ok");

            if (resultado.Contains("sucesso"))
            {
                txt_novoemail.Text = string.Empty;
                txt_novotelefone.Text = string.Empty;
                txt_novasenha.Text = string.Empty;
                txt_confirmarnovasenha.Text = string.Empty;                
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }

    //Botão que mostra e esconde a senha
    private void ButtonVerSenha(object sender, EventArgs e)
    {
        txt_novasenha.IsPassword = !txt_novasenha.IsPassword;

        var button = (ImageButton)sender;

        if (txt_novasenha.IsPassword)
        {
            button.Source = "olho_aberto.png";
        }
        else
        {
            button.Source = "olho_fechado.png";
        }
    }

    //Botão que mostra e esconde confirmar senha
    private void ButtonVerConfirmarSenha(object sender, EventArgs e)
    {
        txt_confirmarnovasenha.IsPassword = !txt_confirmarnovasenha.IsPassword;

        var button = (ImageButton)sender;

        if (txt_confirmarnovasenha.IsPassword)
        {
            button.Source = "olho_aberto.png";
        }
        else
        {
            button.Source = "olho_fechado.png";
        }
    }
}