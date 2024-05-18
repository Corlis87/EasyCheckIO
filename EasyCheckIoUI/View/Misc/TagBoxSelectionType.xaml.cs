using Microsoft.Maui.Controls;

namespace EasyCheckIoUI.View;

public partial class TagBoxSelectionType : ContentView
{
	public TagBoxSelectionType()
	{
		InitializeComponent();

    }

    #region Property

    #region Value

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
       nameof(Value),
       typeof(object),
       typeof(TagBoxSelectionType),
       0,
       BindingMode.TwoWay, null, ValueChangedOn);
    public object Value
    {
        get => (object)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    #endregion

    #region SelectedType

    public static readonly BindableProperty SelectedTypeProperty = BindableProperty.Create(
      nameof(SelectedType),
      typeof(Int32),
      typeof(TagBoxSelectionType),
      0,
      BindingMode.TwoWay);

    public Int32 SelectedType
    {
        get => (Int32)GetValue(SelectedTypeProperty);
        set => SetValue(SelectedTypeProperty, value);
    }

    #endregion

    #endregion

    #region Method
    private static string DecimalToBinary(int selectedtype,object s)
    {
        if(selectedtype ==1)
        {
            if (s is bool _bool)
                return Convert.ToString(_bool);
            else if (s is byte _byte)
                return "0b" + Convert.ToString(_byte, 2).PadLeft(8, '0');
            else if (s is short _short)
                return "0b" + Convert.ToString(_short, 2).PadLeft(16, '0');
            else if (s is int _int)
                return "0b" + Convert.ToString(_int, 2).PadLeft(32, '0');
            else return "NaN";
        }
        else return Convert.ToString(s);   
    }

    #endregion

    #region Event
    private static void ValueChangedOn(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue != null && bindable is TagBoxSelectionType main)
        {
            var a = newValue;
            main.ConvertedValueLabel.Text = DecimalToBinary(main.SelectedType, a);
        }
    }

    #endregion

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Value != null)
        {
            ConvertedValueLabel.Text = DecimalToBinary(SelectedType,Value);
        }
    }
}