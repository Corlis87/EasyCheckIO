using Microsoft.Maui.Controls;


namespace TiaFrameworkUI.View;

public partial class uc_InputModule : ContentView
{
    public static readonly BindableProperty ModuleNameProperty = BindableProperty.Create(
     nameof(ModuleName),
     typeof(string),
     typeof(uc_InputModule),
     string.Empty
     );

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value),
        typeof(Int32),
        typeof(uc_InputModule),
        0,
        BindingMode.TwoWay);


    public static readonly BindableProperty AddressProperty = BindableProperty.Create(
         nameof(Address),
         typeof(int),
         typeof(uc_InputModule),
         0,
         BindingMode.TwoWay,
         null,
         OnAddressPropertyChange);

    private static void OnAddressPropertyChange(BindableObject bindable, object oldValue, object newValue)
    {
        var a = bindable as uc_InputModule;

        //foreach (var item in a.VerticalColumn1.Children)
        //{
        //   if( item is HorizontalStackLayout)
        //    {
        //        var c = item as HorizontalStackLayout;
        //        var idx = 0;
        //        foreach (var item2 in c.Children)
        //        {

        //            if (item2 is Label)
        //            {
        //                var d = item2 as Label;
        //                d.Text = "I"+ a.Address.ToString() + "." + idx;
        //                idx= idx + 2;

        //            }
        //        }

        //    }
        //}

      


    }
   
    public Int32 Value
    {
        get => (Int32)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public int Address
    {
        get => (int)GetValue(AddressProperty);
        set => SetValue(AddressProperty, value);
    }

    public string ModuleName
    {
        get => (string)GetValue(ModuleNameProperty);
        set => SetValue(ModuleNameProperty, value);
    }


    public uc_InputModule()
    {
        InitializeComponent();


    }
}