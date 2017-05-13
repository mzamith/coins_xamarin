using System;
using System.Collections.Generic;
using coins.Model;
using coins.Enum;
using Xamarin.Forms;

namespace coins
{
    public partial class SettingsPage : ContentPage
    {

        private Currency currency;

        public SettingsPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing(){
            base.OnAppearing();
            InitScreen();
        }

        async void OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage(Intent.SETTING));
        }

        private void InitScreen(){
			currency = CoinDictionary.Instance.GetCoinFromCode(Helpers.Settings.GeneralSettings);
			Code.Text = currency.Code;
			Name.Text = currency.Name_plural;
			Symbol.Text = currency.Symbol;
        }
    }
}
