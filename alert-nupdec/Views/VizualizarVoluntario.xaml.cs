using alert_nupdec.Repository;
using alert_nupdec.Models;

namespace alert_nupdec.Views;

public partial class VizualizarVoluntario : ContentPage
{
	public VizualizarVoluntario()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        lista_usuario.ItemsSource = null;
        lista_usuario.ItemsSource = UsuarioRepository.lista_usuario
            .Cast<Usuario>()
            .Where(u => u.Adm == false)
            .ToList();
    }

    //Botão de voltar
    private async void ButtonVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}