using System;
using System.Collections.Generic;
using coins.Model;
using coins.Enum;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace coins
{
	public partial class CoinList : ContentPage
	{
        private CoinDictionary currencies;
        private ObservableCollection<WalletItem> items = new ObservableCollection<WalletItem>();

		public CoinList()
		{
			InitializeComponent();
            currencies = CoinDictionary.Instance;
		//	CheckDatabasePopulated();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

            items.Clear();
            GetItems();

            listView1.ItemsSource = items;
		}

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage(Intent.ADD));
        }

		async public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

            await Navigation.PushAsync(new AddItemPage((WalletItem)((ListView)sender).SelectedItem, Intent.EDIT));

			((ListView)sender).SelectedItem = null;
		}
       

		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
            var wi = (WalletItem)mi.CommandParameter;

            new Database().DeleteItem(wi);

            items.Clear();
            GetItems();

            listView1.ItemsSource = items;
		}


		void GetItems()
		{
			items = new Database().GetItems();
		}

		void CheckDatabasePopulated()
		{
			//cool for testing. delete later.
			new Database().ResetTable();

			//if (new Database().GetItems().Count < 1)
			//{

			//	//fill up database with defaults
			//	var items = new List<WalletItem>();

			//	for (int i = 0; i < 10; i++)
			//	{
   //                 Currency c = currencies.GetCoinFromIndex(i);
   //                 items.Add(
   //                     new WalletItem(c.Code, i){}
			//		);
			//	}

			//	new Database().AddItems(items);
			//}
		}
	}
}
