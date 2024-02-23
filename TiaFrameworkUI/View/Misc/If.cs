
namespace TiaFrameworkUI.View
{
    public class If : ContentView
    {
        public static readonly BindableProperty ConditionProperty =
            BindableProperty.Create(nameof(Condition), typeof(bool), typeof(If), false, propertyChanged: OnContentDependentPropertyChanged);

        public bool Condition
        {
            get => (bool)GetValue(ConditionProperty);
            set => SetValue(ConditionProperty, value);
        }

        public static readonly BindableProperty TrueProperty =
            BindableProperty.Create(nameof(True), typeof(Microsoft.Maui.Controls.View), typeof(If), null, propertyChanged: OnContentDependentPropertyChanged);

        public Microsoft.Maui.Controls.View True
        {
            get => (Microsoft.Maui.Controls.View)GetValue(TrueProperty);
            set => SetValue(TrueProperty, value);
        }

        public static readonly BindableProperty FalseProperty =
            BindableProperty.Create(nameof(False), typeof(Microsoft.Maui.Controls.View), typeof(If), null, propertyChanged: OnContentDependentPropertyChanged);

        public Microsoft.Maui.Controls.View False
        {
            get => (Microsoft.Maui.Controls.View)GetValue(FalseProperty);
            set => SetValue(FalseProperty, value);
        }

        private static void OnContentDependentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            If currentIf = (If)bindable;

            currentIf.UpdateContent();
        }

        private void UpdateContent()
        {
            if (Condition)
            {
                Content = True;
            }
            else
            {
                Content = False;
            }
        }
    }
}
