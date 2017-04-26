using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using coins.Model;

namespace coins
{
	public class Database
	{
		private SQLiteConnection _connection;

		public Database()
		{
			_connection = DependencyService.Get<ISQLite>().GetConnection();
			_connection.CreateTable<WalletItem>();
		}

		public List<WalletItem> GetItems()
		{
			return (from t in _connection.Table<WalletItem>()
					select t).ToList();
		}

		public void AddItem(WalletItem item)
		{
			_connection.Insert(item);
		}

		public void AddItems(List<WalletItem> items)
		{
			foreach (var item in items)
				_connection.Insert(item);
		}

		public void EditItem(WalletItem item)
		{
			_connection.Update(item);
		}

		public void DeleteItem(WalletItem item){
			_connection.Delete(item);
		}

		public void ResetTable(){
			_connection.DeleteAll<WalletItem>();
		}
	}
}
