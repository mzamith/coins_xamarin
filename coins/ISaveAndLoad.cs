using System;
namespace coins
{
	public interface ISaveAndLoad
	{
		void SaveText(string filename, string text);
		string LoadText(string filename);
	}
}
