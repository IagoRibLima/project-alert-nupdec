namespace alert_nupdec.Views
{
    public partial class VisualizarEditarArea : ContentPage
    {

        public VisualizarEditarArea()
        {
            InitializeComponent();

        }        

        private async void ButtonVoltar(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}