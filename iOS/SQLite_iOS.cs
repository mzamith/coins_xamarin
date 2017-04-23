using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(coins.iOS.SQLite_iOS))]

namespace coins.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS()
		{
		}

		#region ISQLite implementation

		public SQLite.SQLiteConnection GetConnection()
		{
			var filename = "database.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");

			var path = Path.Combine(libraryPath, filename);

			var connection = new SQLite.SQLiteConnection(path, true);

			return connection;
		}

		#endregion
	}
}


