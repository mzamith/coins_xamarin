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
			_connection.CreateTable<Currency>();
		}

		public List<Currency> GetItems()
		{
			return (from t in _connection.Table<Currency>()
					select t).ToList();
		}

		public void AddItem(Currency item)
		{
			_connection.Insert(item);
		}

		public void AddItems(List<Currency> items)
		{
			foreach (var item in items)
				_connection.Insert(item);
		}

		public void EditItem(Currency item)
		{
			_connection.Update(item);
		}

		public void DeleteItem(Currency item){
			_connection.Delete(item.ID);
		}

		public void ResetTable(){
			_connection.DeleteAll<Currency>();
		}
	}
}
