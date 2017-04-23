using System;
using SQLite;

namespace coins
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}