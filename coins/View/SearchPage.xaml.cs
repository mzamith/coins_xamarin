﻿using System;
using System.Collections.Generic;
using coins.Enum;
using coins.Model;
using Xamarin.Forms;

namespace coins
{
    public partial class SearchPage : ContentPage
    {
        private Intent intent;

        public SearchPage(Intent intent)
        {
            this.intent = intent;
            InitializeComponent();
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
            listViewSearch.ItemsSource = GetItems();
		}

        List<Currency> GetItems()
		{
            var items = CoinDictionary.Instance.Currencies;
			return items;
		}

		void FilterList(object sender, EventArgs e)
		{
            listViewSearch.ItemsSource = CoinDictionary.Instance.FilterCoins(sbSearch.Text);
		}

		async public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

            switch (intent){
                case Intent.ADD:
                    break;
                case Intent.SETTING:
                    var wi = (Currency)((ListView)sender).SelectedItem;
                    Helpers.Settings.GeneralSettings = wi.Code;
                    await Navigation.PopAsync();
                    break;
            }

			((ListView)sender).SelectedItem = null;
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopAsync();
        }
    }
}
