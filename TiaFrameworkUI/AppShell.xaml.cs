using TiaFrameworkUI.View;
using TiaFrameworkUI.View.Form;

namespace TiaFrameworkUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Siemens_m100_ConfigView), typeof(Siemens_m100_ConfigView));
            Routing.RegisterRoute(nameof(Siemens_m200_EditorView), typeof(Siemens_m200_EditorView));
            Routing.RegisterRoute(nameof(Siemens_p300_NetConfigView), typeof(Siemens_p300_NetConfigView));         
            Routing.RegisterRoute(nameof(Formulas_p200_InverterView), typeof(Formulas_p200_InverterView));
            Routing.RegisterRoute(nameof(Siemens_p400_CompileView), typeof(Siemens_p400_CompileView));
            Routing.RegisterRoute(nameof(Formulas_p100_ProportionView), typeof(Formulas_p100_ProportionView));
            Routing.RegisterRoute(nameof(Siemens_p410_SearchView), typeof(Siemens_p410_SearchView));
            Routing.RegisterRoute(nameof(Siemens_p420_LoadTagsView), typeof(Siemens_p420_LoadTagsView));
        }
    }
}