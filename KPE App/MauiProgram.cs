using SkiaSharp.Views.Maui.Controls.Hosting;
using KPE_App.Services;
using KPE_App.ViewModels;
using KPE_App.ViewPages;

namespace KPE_App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseSkiaSharp(true)
            .UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
            });

        builder.Services.AddSingleton<StundenViewModel>();
        builder.Services.AddSingleton<StundenÜbersichtPage>();
		builder.Services.AddSingleton<StundenService>();

		return builder.Build();
	}
}
