using alert_nupdec.Repository;
using alert_nupdec.Models;

namespace alert_nupdec.Views;

public partial class Ocorrencias : ContentPage
{
	public Ocorrencias()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarOcorrencias();
    }

    private void CarregarOcorrencias()
    {
        // Filtra apenas os alertas que NÃO foram aceitos ainda (!Aceito)
        var ocorrenciasPendentes = AlertaRepository.list_alerta
            .Where(a => a.Aceito == false)
            .OrderByDescending(a => a.Id)
            .ToList();

        lista_ocorrencias_pendentes.ItemsSource = ocorrenciasPendentes;
    }

    private async void ButtonAceitar_Clicked(object sender, EventArgs e)
    {
        // Pega o botão que foi clicado
        var button = sender as Button;

        // Pega o objeto Alerta que estava atrelado ao botão (via CommandParameter)
        var alertaSelecionado = button.CommandParameter as Alerta;

        if (alertaSelecionado != null)
        {
            bool confirm = await DisplayAlert("Confirmar", "Deseja aceitar esta ocorrência?", "Sim", "Não");
            if (confirm)
            {
                try
                {
                    // Chama o método do repositório
                    AlertaRepository.aceitarAlerta(alertaSelecionado);                    

                    // Recarrega a lista para remover o item que acabou de ser aceito
                    CarregarOcorrencias();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }
            }
        }
    }

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}