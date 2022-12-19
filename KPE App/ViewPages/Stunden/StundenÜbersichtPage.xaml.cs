using KPE_App.ViewModels;

namespace KPE_App.ViewPages;

public partial class StundenÜbersichtPage : ContentPage
{
	public StundenÜbersichtPage(StundenViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}