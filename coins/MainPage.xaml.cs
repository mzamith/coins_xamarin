using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace coins
{
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();

            //removed toolbar because it was bugging me
            NavigationPage.SetHasNavigationBar(this, false);
		}

	}
}
