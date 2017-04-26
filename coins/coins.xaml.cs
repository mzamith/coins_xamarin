using System;

using Xamarin.Forms;

namespace coins
{
	public partial class App : Application
	{
		public App()
		{
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
                Children = {
                    new NavigationPage(new View.CoinList())
                    {
                        Title = "Wallet",
                        Icon = Device.OnPlatform("ic_format_list_bulleted.png", null, null)
                    },
                    new NavigationPage(new View.BalancePage())
                    {
                        Title = "Balance",
                        Icon = Device.OnPlatform("ic_account_balance_wallet.png", null, null)
                    },
                    new NavigationPage(new View.RatesPage())
					{
						Title = "Rates",
						Icon = Device.OnPlatform("ic_monetization_on.png", null, null)
					},
                }
            };
        }
	}
}
