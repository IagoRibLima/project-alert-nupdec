using alert_nupdec.Models;
using alert_nupdec.Repository;
using System.Collections.Generic;


namespace alert_nupdec.Views
{
    public partial class VisualizarEditarArea : ContentPage
    {

        public VisualizarEditarArea()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lista_areaRisco.ItemsSource = null;
            lista_areaRisco.ItemsSource = AreaDeRiscoRepository.list_areasderisco;
        }

        private async void ButtonVoltar(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}