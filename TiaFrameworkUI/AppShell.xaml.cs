using TiaFrameworkUI.View;
using TiaFrameworkUI.View.Form;

namespace TiaFrameworkUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SiemensConfigView), typeof(SiemensConfigView));
            Routing.RegisterRoute(nameof(SiemensEditorView), typeof(SiemensEditorView));
            Routing.RegisterRoute(nameof(SiemensNetConfigView), typeof(SiemensNetConfigView));         
            Routing.RegisterRoute(nameof(FormulasInverterView), typeof(FormulasInverterView));
            Routing.RegisterRoute(nameof(SiemensCompileView), typeof(SiemensCompileView));
            Routing.RegisterRoute(nameof(FormulasProportionView), typeof(FormulasProportionView));
            Routing.RegisterRoute(nameof(SiemensSearchView), typeof(SiemensSearchView));
            Routing.RegisterRoute(nameof(SiemensLoadTagsView), typeof(SiemensLoadTagsView));
        }
        private void ThemeToggled(object sender, ToggledEventArgs e)
        {
            App.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
        }
    }
}