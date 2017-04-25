using System;
using System.Collections.Generic;
using coins.Model;
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
			listView1.ItemsSource = GetToDoList();
		}



		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

			((ListView)sender).SelectedItem = null;
		}

		public void OnMore(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
            WalletItem w = (WalletItem)mi.CommandParameter;
            DisplayAlert("More Context Action", w.name + " more context action", "OK");
		}

		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}


		List<WalletItem> GetToDoList()
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
                        new WalletItem()
                        {
                        
                            name = c.Code,
                            amount = c.Symbol,
						}
					);
				}

				new Database().AddItems(items);
			}
		}
	}
}
