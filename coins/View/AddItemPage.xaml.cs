using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace coins
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
        }

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			Navigation.PopAsync();
		}
    }
}
