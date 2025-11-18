namespace alert_nupdec.Views;

public partial class FlyoutPageADM : FlyoutPage
{
	public FlyoutPageADM()
	{
		InitializeComponent();
	}

    //Botão de cadastro de voluntário
    private async void OnTapCadastrarVoluntario(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroVoluntario());
    }

    //Botão de cadastro de dica
    private async void OnTapCadastroDica(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroDica());
    }

    //Botão de cadastro de treinamento
    private async void OnTapCadastroTreinamento(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroTreinamento());
    }

    //Botão de configurações
    private async void OnTapConfiguracoes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Configuracoes());
    }

    //Botão de cadastro da area de risco
    private async void OnTapAreaDeRisco(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AreaDeRisco());
    }

    //Botão de dashboard
    private async void OnTapDashboard(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Dashboard());
    }

    //Botão de ver ocorrências
    private async void OnTapOcorrencia(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Ocorrencias());
    }
}