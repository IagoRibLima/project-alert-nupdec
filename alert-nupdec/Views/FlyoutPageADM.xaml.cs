using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class FlyoutPageADM : FlyoutPage
{
	public FlyoutPageADM()
	{
		InitializeComponent();
	}

    //Botão submenu de voluntários
    private async void OnTapSubMenuVoluntario(object sender, EventArgs e)
    {
        subMenuVoluntario.IsVisible = !subMenuVoluntario.IsVisible;
    }

    //Botão submenu de dicas
    private async void OnTapSubMenuDica(object sender, EventArgs e)
    {
        subMenuDica.IsVisible = !subMenuDica.IsVisible;
    }

    //Botão de cadastro de treinamentos
    private async void OnTapSubMenuTreinamento(object sender, EventArgs e)
    {
        subMenuTreinamento.IsVisible = !subMenuTreinamento.IsVisible;
    }

    //Botão submenu area de risco
    private async void OnTapSubMenuAreaDeRisco(object sender, EventArgs e)
    {
        subMenuAreaDeRisco.IsVisible = !subMenuAreaDeRisco.IsVisible;
    }

    //Botão de cadastro de voluntários
    private async void OnTapCadastrarVoluntario(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroVoluntario());
    }

    //Botão de cadastro de dicas
    private async void OnTapGerenciarDica(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroDica());
    }

    //Botão de cadastro de treinamentos
    private async void OnTapGerenciarTreinamento(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroTreinamento());
    }

    //Botão de configurações
    private async void OnTapConfiguracoes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Configuracoes());
    }

    //Botão de cadastro da area de risco
    private async void OnTapGerenciarAreaDeRisco(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AreaDeRisco());
    }

    //Botão de ver ocorrências
    private async void OnTapOcorrencia(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Ocorrencias());

    }

    //Botão de sair
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