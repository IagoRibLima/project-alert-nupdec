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
            window.Page = new Login();
            window.Width = 400;
            window.Height = 800;

            return window;
        }

    }
}