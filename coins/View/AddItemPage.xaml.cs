using System;
using System.Collections.Generic;
using coins.Model;
using coins.Enum;
using Xamarin.Forms;

namespace coins
{
    public partial class AddItemPage : ContentPage
    {
        private Currency currency;
        private Intent intent;
        private WalletItem item;

        public AddItemPage(Currency currency, Intent intent)
        {
            this.currency = currency;
            this.intent = intent;
            InitializeComponent();

            currencyCode.Text = currency.Code;
            currencyName.Text = currency.Name;
            currencyFlag.Source = currency.Flag;
            currencySymbol.Text = currency.Symbol;

            if (intent.Equals(Intent.EDIT)) saveButton2.Text = "Update";

        }

        public AddItemPage(WalletItem item, Intent intent)
		{
            this.item = item;
			this.intent = intent;
			InitializeComponent();

			currencyCode.Text = item.code;
			currencyName.Text = item.name;
			currencyFlag.Source = item.flag;
			currencySymbol.Text = item.symbol;
            currencyAmount.Text = item.amount.ToString();

            if(intent.Equals(Intent.EDIT)) saveButton2.Text = "Update";
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
			var text = Amount.Text;
            double num;
            bool isNum = double.TryParse(text, out num);

			if (string.IsNullOrWhiteSpace(text))
			{
				await DisplayAlert("Clumsy...!", "Fill out the field", "Dismiss");
			}
            else if (!isNum){
                await DisplayAlert("Oops", "Please enter a valid number", "Dismiss");
            } 
            else if (this.intent.Equals(Intent.ADD))
            {

                WalletItem item = new WalletItem(currency.Code, num);
                new Database().AddItem(item);

                //Careful to remove the search Page also
                this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
                await Navigation.PopAsync();
            }else {

                item.amount = num;
                new Database().EditItem(this.item);

				await Navigation.PopAsync();
            }
		}
    }
}
