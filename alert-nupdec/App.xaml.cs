using alert_nupdec.Views;

namespace alert_nupdec
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window();
            window.Page = new NavigationPage (new Login());
            window.Width = 412;
            window.Height = 915;
            window.Title = "Alert NUPDEC";

            return window;
        }

    }
}