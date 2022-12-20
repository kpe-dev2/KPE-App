using Microsoft.Maui.Graphics.Text;
using System.Windows.Input;

namespace KPE_App.Controls;

public partial class OutlinedEntryLoginControl : Grid
{
    public OutlinedEntryLoginControl()
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

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        propertyName: nameof(TextColor),
        returnType: typeof(Color),
        declaringType: typeof(OutlinedEntryLoginControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay);

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set { SetValue(TextColorProperty, value); }
    }

    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
        propertyName: nameof(BorderColor),
        returnType: typeof(Color),
        declaringType: typeof(OutlinedEntryLoginControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay);

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set { SetValue(BorderColorProperty, value); }
    }

    public static readonly BindableProperty FrameBackgroundColorProperty = BindableProperty.Create(
      propertyName: nameof(FrameBackgroundColor),
      returnType: typeof(Color),
      declaringType: typeof(OutlinedEntryLoginControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);

    public Color FrameBackgroundColor
    {
        get => (Color)GetValue(FrameBackgroundColorProperty);
        set { SetValue(FrameBackgroundColorProperty, value); }
    }

    public static readonly BindableProperty LabelBackgroundColorProperty = BindableProperty.Create(
      propertyName: nameof(LabelBackgroundColor),
      returnType: typeof(Color),
      declaringType: typeof(OutlinedEntryLoginControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);

    public Color LabelBackgroundColor
    {
        get => (Color)GetValue(LabelBackgroundColorProperty);
        set { SetValue(LabelBackgroundColorProperty, value); }
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
      propertyName: nameof(Placeholder),
      returnType: typeof(string),
      declaringType: typeof(OutlinedEntryLoginControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }

    public static readonly BindableProperty ReturnCommandProperty = BindableProperty.Create(
    propertyName: nameof(ReturnCommand),
    returnType: typeof(ICommand),
    declaringType: typeof(OutlinedEntryLoginControl),
    defaultValue: null,
    defaultBindingMode: BindingMode.OneWay);

    public ICommand ReturnCommand
    {
        get => (ICommand)GetValue(ReturnCommandProperty);
        set { SetValue(ReturnCommandProperty, value); }
    }

    public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(
    propertyName: nameof(ReturnType),
    returnType: typeof(ReturnType),
    declaringType: typeof(OutlinedEntryLoginControl),
    defaultValue: null,
    defaultBindingMode: BindingMode.OneWay);

    public ReturnType ReturnType
    {
        get => (ReturnType)GetValue(ReturnTypeProperty);
        set { SetValue(ReturnTypeProperty, value); }
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
      propertyName: nameof(IsPassword),
      returnType: typeof(bool),
      declaringType: typeof(OutlinedEntryLoginControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set { SetValue(IsPasswordProperty, value); }
    }

    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
      propertyName: nameof(Keyboard),
      returnType: typeof(Keyboard),
      declaringType: typeof(OutlinedEntryLoginControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set { SetValue(KeyboardProperty, value); }
    }



    private void TxtEntry_Focused(object sender, FocusEventArgs e)
    {

        lblPlaceholder.FontSize = 11;
        lblPlaceholder.TranslateTo(0, -30, 80, easing: Easing.CubicInOut);
    }

    private void TxtEntry_Unfocused(object sender, FocusEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            lblPlaceholder.FontSize = 11;
            lblPlaceholder.TranslateTo(0, -30, 80, easing: Easing.CubicInOut);
        }
        else
        {
            lblPlaceholder.FontSize = 15;
            lblPlaceholder.TranslateTo(0, 0, 80, easing: Easing.CubicInOut);
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        txtEntry.Focus();
    }
}