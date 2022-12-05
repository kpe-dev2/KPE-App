using Android.Media;

namespace KPE_App.ViewPages;

public partial class StundenEingabePage : ContentPage
{
    public StundenEingabePage()
    {
        InitializeComponent();
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        SubmitBtn.Text = $"Gesendet!";        
        SemanticScreenReader.Announce(SubmitBtn.Text);
        
        ResetBtn.Text = $"Reset";
        SemanticScreenReader.Announce(ResetBtn.Text);
    }
    private void OnResetClicked(object sender, EventArgs e)
    {

        ResetBtn.Text = $"Zurückgesetzt!";
        SemanticScreenReader.Announce(ResetBtn.Text);

        SubmitBtn.Text = $"Absenden";
        SemanticScreenReader.Announce(SubmitBtn.Text);
    }
}