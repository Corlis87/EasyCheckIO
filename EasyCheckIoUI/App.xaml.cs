using EasyCheckIoUI.View;

namespace EasyCheckIoUI
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