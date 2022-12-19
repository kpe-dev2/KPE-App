using SkiaSharp.Views.Maui.Controls.Hosting;
using KPE_App.Services;
using KPE_App.ViewModels;
using KPE_App.ViewPages;
using KPE_App.Controls;

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
		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
		{
			if (view is BorderlessEntry)
			{
#if ANDROID
				handler.PlatformView.Background = null;
				handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);

#elif IOS || MACCATALYST
				handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
				handler.PlatformView.Layer.BorderWith = 0;
				handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
				handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
#endif
			}
		});

		builder.Services.AddSingleton<StundenViewModel>();
        builder.Services.AddSingleton<StundenÜbersichtPage>();
		builder.Services.AddSingleton<StundenService>();

		return builder.Build();
	}
}
