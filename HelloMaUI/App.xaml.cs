
namespace HelloMaUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var win = new Window(new AppShell())
            {
                MinimumWidth = 500
            };
            return win;
        }
    }
}