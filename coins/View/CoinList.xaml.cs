using System;
using System.Collections.Generic;
using coins.Model;
using coins.Enum;
using Xamarin.Forms;

namespace coins
{
	public partial class CoinList : ContentPage
	{
        private CoinDictionary currencies;

		public CoinList()
		{
			InitializeComponent();
            currencies = CoinDictionary.Instance;
			CheckDatabasePopulated();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
            listView1.ItemsSource = GetItems();
		}

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage(Intent.ADD));
        }

		async public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

            await Navigation.PushAsync(new WalletItemPage());

			((ListView)sender).SelectedItem = null;
		}
       

		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
            var wi = (WalletItem)mi.CommandParameter;

            new Database().DeleteItem(wi);
            listView1.ItemsSource = GetItems();
		}


		List<WalletItem> GetItems()
		{
			var items = new Database().GetItems();
			return items;
		}

		void CheckDatabasePopulated()
		{
			//cool for testing. delete later.
			new Database().ResetTable();

			if (new Database().GetItems().Count < 1)
			{

				//fill up database with defaults
				var items = new List<WalletItem>();

				for (int i = 0; i < 10; i++)
				{
                    Currency c = currencies.GetCoinFromIndex(i);
                    items.Add(
                        new WalletItem(c.Code, i){}
					);
				}

				new Database().AddItems(items);
			}
		}
	}
}
