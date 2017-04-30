using System;
using System.Collections.Generic;
using coins.Service;
using coins.Model;

using Xamarin.Forms;

namespace coins.View
{
	public partial class BalancePage : ContentPage
	{
        private CoinDictionary currencies = CoinDictionary.Instance;

		public BalancePage()
		{
            InitializeComponent();
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
			var text = taskText2.Text;

			if (string.IsNullOrWhiteSpace(text))
			{
				//save text to user preferences 
				await DisplayAlert("Clumsy...!", "Fill out the field", "Dismiss");
			}
            else if  (!currencies.CoinExists(text.Trim().ToUpper())){
				await DisplayAlert("Sorry dude...!", "This coin does not exist", "Pick another");
			}
			else
			{
				var convertTo = "EUR";
				text = text.Trim().ToUpper();
				var service = new CurrencyService();
				var response = await service.GetYahooTaxAsync(text, convertTo);

				var display = "The conversion rate from " +
                    currencies.GetName(text) + " to " + currencies.GetName(convertTo) + " is: " + response;

				//message to user about empty box
				await DisplayAlert("Here is the current tax rate", display, "Thanks");
			}
		}

		void ShowAlert(string title, string message, string button)
		{
			DisplayAlert(title, message, button);
		}

		async void Settings_Clicked()
		{
                await Navigation.PushAsync(new SettingsPage());
		}

	}
}
