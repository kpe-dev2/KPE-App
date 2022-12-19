using Microsoft.Maui.Graphics.Text;

namespace KPE_App.Controls;

public partial class OutlinedEntryControl : Grid
{
    public OutlinedEntryControl()
    {
        InitializeComponent();
    }


    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(OutlinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set { SetValue(TextProperty, value); }
    }

    //public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
    //    propertyName: nameof(TextColor),
    //    returnType: typeof(string),
    //    declaringType: typeof(OutlinedEntryControl),
    //    defaultValue: null,
    //    defaultBindingMode: BindingMode.OneWay);

    //public string TextColor
    //{
    //    get => (string)GetValue(TextColorProperty);
    //    set { SetValue(TextColorProperty, value); }
    //}

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
      propertyName: nameof(Placeholder),
      returnType: typeof(string),
      declaringType: typeof(OutlinedEntryControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
      propertyName: nameof(IsPassword),
      returnType: typeof(string),
      declaringType: typeof(OutlinedEntryControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);

    public string IsPassword
    {
        get => (string)GetValue(IsPasswordProperty);
        set { SetValue(IsPasswordProperty, value); }
    }

    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
      propertyName: nameof(Keyboard),
      returnType: typeof(string),
      declaringType: typeof(OutlinedEntryControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.TwoWay);

    public string Keyboard
    {
        get => (string)GetValue(KeyboardProperty);
        set { SetValue(KeyboardProperty, value); }
    }

    private void TxtEntry_Focused(object sender, FocusEventArgs e)
    {

        lblPlaceholder.FontSize = 11;
        lblPlaceholder.TranslateTo(0, -20, 80, easing: Easing.Linear);
    }

    private void TxtEntry_Unfocused(object sender, FocusEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            lblPlaceholder.FontSize = 11;
            lblPlaceholder.TranslateTo(0, -20, 80, easing: Easing.Linear);
        }
        else
        {
            lblPlaceholder.FontSize = 15;
            lblPlaceholder.TranslateTo(0, 0, 80, easing: Easing.Linear);
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        txtEntry.Focus();
    }
}