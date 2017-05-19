using System;
using System.Collections.Generic;
using coins.Enum;
using coins.Model;
using Xamarin.Forms;

namespace coins
{
    public partial class SearchPage : ContentPage
    {
        private Intent intent;
        private List<Currency> currencies;

        public SearchPage(Intent intent)
        {
            this.intent = intent;
            this.currencies = new List<Currency>();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            currencies = GetItems();
            listViewSearch.ItemsSource = currencies;
        }

        //Make sure we filter out the currencies that the user already has in his wallet if the intent is ADD.
        List<Currency> GetItems()
        {
            switch (intent)
            {
                case (Intent.ADD):
                    return CoinDictionary.Instance.FilterCoins(new List<WalletItem>(new Database().GetItems()));
                case (Intent.SETTING):
                    return CoinDictionary.Instance.Currencies;
                default:
                    return CoinDictionary.Instance.Currencies;
            }
        }

        void FilterList(object sender, EventArgs e)
        {
            listViewSearch.ItemsSource = CoinDictionary.Instance.FilterCoins(currencies, sbSearch.Text);
        }

        async public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var wi = (Currency)((ListView)sender).SelectedItem;

            switch (intent)
            {
                case Intent.ADD:
                    await Navigation.PushAsync(new AddItemPage(wi, Intent.ADD));
                    break;
                case Intent.SETTING:
                    Helpers.Settings.GeneralSettings = wi.Code;
                    await Navigation.PopAsync();
                    break;
            }

        ((ListView)sender).SelectedItem = null;
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //Navigation.PopAsync();
        }
    }
}
