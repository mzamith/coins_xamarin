using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace coins
{
    public partial class WalletItemPage : ContentPage
    {
        public WalletItemPage()
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
