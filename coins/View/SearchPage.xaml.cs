﻿using System;
using System.Collections.Generic;
using coins.Model;
using Xamarin.Forms;

namespace coins
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
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

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopAsync();
        }
    }
}
