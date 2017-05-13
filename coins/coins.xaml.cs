using System;

using Xamarin.Forms;

namespace coins
{
	public partial class App : Application
	{
		public App()
		{
            InitializeComponent();
			if (Helpers.Settings.GeneralSettings.Length == 0) Helpers.Settings.GeneralSettings = "EUR";
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

                BarBackgroundColor = Device.OnPlatform<Color>(Color.Transparent, Color.FromHex("#4A4A4A"), Color.FromHex("#4A4A4A")),

				Children = {
					new NavigationPage(new CoinList())
					{
						Title = "Wallet",
						Icon = Device.OnPlatform("ic_format_list_bulleted.png", null, null)
					},
					new NavigationPage(new BalancePage())
					{
						Title = "Balance",
						Icon = Device.OnPlatform("ic_account_balance_wallet.png", null, null)
					},
					new NavigationPage(new RatesPage())
					{
						Title = "Rates",
						Icon = Device.OnPlatform("ic_monetization_on.png", null, null)
					},
					new NavigationPage(new SettingsPage())
					{
						Title = "Settings",
						Icon = Device.OnPlatform("ic_settings.png", null, null)
					},
				}
			};
		}
	}
}
