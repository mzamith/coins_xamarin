using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace coins
{
	public partial class CoinList : ContentPage
	{
		public CoinList()
		{
			InitializeComponent();
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
			var text = taskText.Text;

			if (!string.IsNullOrWhiteSpace(text))
			{
				//save text to user preferences 
				ShowAlert("Success!", "Task saved...now DO IT!");
			}
			else
			{
				//message to user about empty box
				ShowAlert("Error", "No task to save...");
			}
		}

		void ShowAlert(string title, string message)
		{
			DisplayAlert(title, message, "OK");
		}
	}
}
