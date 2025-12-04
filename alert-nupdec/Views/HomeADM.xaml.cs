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
        // Recarrega a lista toda vez que a p?gina se torna vis?vel (ex: ao voltar de EmitirAlerta)
        lista_alertas.ItemsSource = null; // Limpa para for?ar o refresh
        lista_alertas.ItemsSource = AlertaRepository.lista_alerta_aceito
            .OrderByDescending(d => d.Id)
            .ToList();
        CarregarDadosUsuario();
        VerificarNotificacoes();
    }

    private void VerificarNotificacoes()
    {
        // Verifica na lista GERAL se existe algum alerta que NÃO foi aceito ainda
        bool temPendencia = AlertaRepository.list_alerta.Any(a => a.Aceito == false);

        // Se tiver pendência, torna o indicador visível
        indicador_notificacao.IsVisible = temPendencia;
    }

    //Carrega os dados do usuário logado
    private void CarregarDadosUsuario()
    {
        if (UsuarioRepository.usuario_logado != null)
        {
            lbl_boasvindas.Text = $"Administrador: {UsuarioRepository.usuario_logado.NomeCompleto}";
            lbl_unidade.Text = $"Nupdec - {UsuarioRepository.usuario_logado.Unidade.nome} - {UsuarioRepository.usuario_logado.Unidade.cep}";
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

    private void ButtonOpenMenu_Clicked(object sender, EventArgs e)
    {
        // 1. Tenta pegar a referência da FlyoutPage "pai" desta tela
        var flyoutPai = FindParentFlyoutPage(this);

        // 2. Se achou, inverte o estado (Abre ou Fecha)
        if (flyoutPai != null)
        {
            flyoutPai.IsPresented = !flyoutPai.IsPresented;
        }
        else
        {
            // Debug: Apenas para você saber se não encontrou
            Console.WriteLine("ERRO: Não encontrei nenhuma FlyoutPage pai.");
            DisplayAlert("Erro", "Não foi possível localizar o menu.", "OK");
        }
    }

    // Método auxiliar que sobe a hierarquia visual procurando uma FlyoutPage
    private FlyoutPage FindParentFlyoutPage(Element element)
    {
        var parent = element.Parent;

        while (parent != null)
        {
            if (parent is FlyoutPage flyout)
            {
                return flyout;
            }
            parent = parent.Parent;
        }
        return null;
    }

    //Botão de emitir alerta
    private async void ButtonEmitirAlerta(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmitirAlerta());
    }

    private async void ButtonOcorrencia(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Ocorrencias());
    }
}