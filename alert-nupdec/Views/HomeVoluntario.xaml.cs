using alert_nupdec.Repository;

namespace alert_nupdec.Views;

public partial class HomeVoluntario : ContentPage
{
	public HomeVoluntario()
	{
		InitializeComponent();

        CarregarDadosUI();

        lista_alertas.ItemsSource = AlertaRepository.list_alerta;
    }

    private void CarregarDadosUI()
    {
        // Usamos o Dispatcher para garantir que as Labels sejam atualizadas
        // no Thread Principal (UI Thread).
        Dispatcher.Dispatch(() =>
        {
            if (UsuarioRepository.usuario_logado != null)
            {
                lbl_boasvindas.Text = $"Voluntario: {UsuarioRepository.usuario_logado.NomeCompleto}";
                lbl_unidade.Text = $"Nupdec - {UsuarioRepository.usuario_logado.Unidade.Bairro} - {UsuarioRepository.usuario_logado.Unidade.CEP}";
            }
        });
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Recarrega a lista toda vez que a página se torna visível (ex: ao voltar de EmitirAlerta)
        lista_alertas.ItemsSource = null; // Limpa para forçar o refresh
        lista_alertas.ItemsSource = AlertaRepository.list_alerta;
    }

    //Botão de emitir alerta
    private async void ButtonEmitirAlerta(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmitirAlerta());
    }
}