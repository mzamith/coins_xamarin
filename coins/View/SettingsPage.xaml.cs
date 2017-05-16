using System;
using System.Collections.Generic;
using coins.Model;
using coins.Enum;
using Xamarin.Forms;

namespace coins
{
    public partial class SettingsPage : ContentPage
    {

        private const string DEFAULT_CURRENCY = "EUR";
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

            var code = (string.IsNullOrWhiteSpace(Helpers.Settings.GeneralSettings)) ? DEFAULT_CURRENCY : Helpers.Settings.GeneralSettings;

			currency = CoinDictionary.Instance.GetCoinFromCode(code);
			Code.Text = currency.Code;
			Name.Text = currency.Name_plural;
        }
    }
}
