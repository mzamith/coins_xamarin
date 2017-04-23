using System;
using System.Collections.Generic;
using coins.Model;
using Xamarin.Forms;

namespace coins
{
	public partial class CoinList : ContentPage
	{
		public CoinList()
		{
			InitializeComponent();
			CheckDatabasePopulated();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			listView.ItemsSource = GetToDoList();
		}


		List<Currency> GetToDoList()
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
				var items = new List<Currency>();

				for (int i = 0; i < 10; i++)
				{
					items.Add(
						new Currency()
						{
							name = CoinDictionary.GetCoinFromIndex(i),
							amount = i,
						}
					);
				}

				new Database().AddItems(items);
			}
		}
	}
}
