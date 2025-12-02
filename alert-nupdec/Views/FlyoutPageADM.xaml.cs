using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class FlyoutPageADM : FlyoutPage
{
    public FlyoutPageADM()
    {
        InitializeComponent();
    }

    //Bot?o submenu de volunt?rios
    private async void OnTapSubMenuVoluntario(object sender, EventArgs e)
    {
        subMenuVoluntario.IsVisible = !subMenuVoluntario.IsVisible;
    }

    //Bot?o submenu de dicas
    private async void OnTapSubMenuDica(object sender, EventArgs e)
    {
        subMenuDica.IsVisible = !subMenuDica.IsVisible;
    }

    //Bot?o de cadastro de treinamentos
    private async void OnTapSubMenuTreinamento(object sender, EventArgs e)
    {
        subMenuTreinamento.IsVisible = !subMenuTreinamento.IsVisible;
    }

    //Bot?o submenu area de risco
    private async void OnTapSubMenuAreaDeRisco(object sender, EventArgs e)
    {
        subMenuAreaDeRisco.IsVisible = !subMenuAreaDeRisco.IsVisible;
    }

    //Bot?o de cadastro de volunt?rios
    private async void OnTapCadastrarVoluntario(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroVoluntario());
    }

    //Bot?o de cadastro de dicas
    private async void OnTapGerenciarDica(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroDica());
    }

    //Bot?o de cadastro de treinamentos
    private async void OnTapGerenciarTreinamento(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroTreinamento());
    }

    //Bot?o de configura??es
    private async void OnTapConfiguracoes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Configuracoes());
    }

    //Bot?o de cadastro da area de risco
    private async void OnTapCadastrarAreaDeRisco(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroUnidade());
    }

    private async void OnTapEditarVisualizarAreaDeRisco(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VisualizarEditarArea());
    }

    //Bot?o de ver ocorr?ncias
    private async void OnTapOcorrencia(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Ocorrencias());

    }

    //Bot?o de sair
    private async void OnTapSair(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Deseja realmente sair do aplicativo?", "Sim", "Não");

        if (confirmacao)
        {
            UsuarioRepository.usuario_logado = null;
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }
}