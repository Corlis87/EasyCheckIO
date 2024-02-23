using TiaFrameworkUI.View;

namespace TiaFrameworkUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =   new AppShell();
        }
    }
}