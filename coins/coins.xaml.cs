using System;

using Xamarin.Forms;

namespace coins
{
	public partial class App : Application
	{
		public App()
		{
            InitializeComponent();
			if (Helpers.Settings.GeneralSettings == null || Helpers.Settings.GeneralSettings.Length == 0) Helpers.Settings.GeneralSettings = "EUR";
			GoToMainPage();

		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		public static void GoToMainPage()
		{
            Current.MainPage = new TabbedPage
            {

#pragma warning disable CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'
                BarBackgroundColor = Device.OnPlatform<Color>(Color.Transparent, Color.FromHex("#4A4A4A"), Color.FromHex("#4A4A4A")),
#pragma warning restore CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'

				Children = {
					new NavigationPage(new CoinList())
					{
						Title = "Wallet",
#pragma warning disable CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'
						Icon = Device.OnPlatform("ic_format_list_bulleted.png", null, null)
#pragma warning restore CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'
					},
					new NavigationPage(new BalancePage())
					{
						Title = "Balance",
#pragma warning disable CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'
						Icon = Device.OnPlatform("ic_account_balance_wallet.png", null, null)
#pragma warning restore CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'
					},
					new NavigationPage(new RatePage())
					{
						Title = "Rates",
#pragma warning disable CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'
						Icon = Device.OnPlatform("ic_monetization_on.png", null, null)
#pragma warning restore CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'
					},
					new NavigationPage(new SettingsPage())
					{
						Title = "Settings",
#pragma warning disable CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'
						Icon = Device.OnPlatform("ic_settings.png", null, null)
#pragma warning restore CS0618 // 'Device.OnPlatform<T>(T, T, T)' is obsolete: 'Use switch(RuntimePlatform) instead.'
					},
				}
			};
		}
	}
}
