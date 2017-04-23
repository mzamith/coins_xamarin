using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace coins
{
	public partial class Total : ContentPage
	{
		public Total()
		{
			InitializeComponent();
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
			var text = taskText2.Text;

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
