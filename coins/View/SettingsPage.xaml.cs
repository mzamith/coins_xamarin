using System;
using System.Collections.Generic;
using coins.Model;
using Xamarin.Forms;

namespace coins.View
{
    public partial class SettingsPage : ContentPage
    {

        private Currency currency;

        public SettingsPage()
        {
            InitializeComponent();

            currency = CoinDictionary.Instance.GetCoinFromCode(Helpers.Settings.GeneralSettings);
            Code.Text = currency.Code;
            Name.Text = currency.Name_plural;
            Symbol.Text = currency.Symbol;

        }

        async void OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}
