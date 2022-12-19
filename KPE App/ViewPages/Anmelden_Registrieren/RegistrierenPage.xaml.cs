namespace KPE_App.ViewPages;

public partial class RegistrierenPage : ContentPage
{
	public RegistrierenPage()
	{
		InitializeComponent();
	}

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        SubmitBtn.Text = $"Gesendet!";
        SemanticScreenReader.Announce(SubmitBtn.Text);
    }
}