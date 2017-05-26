using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace coins
{
    using coins.Model;
    using coins.Service;
    using System.Collections.ObjectModel;
    using System.Linq;

    public partial class BalancePage : ContentPage
    {
        private ObservableCollection<WalletItem> items = new ObservableCollection<WalletItem>();
        private Currency currency;
        private double totalValue = 0;
        private List<WalletItemDTO> walletItems = new List<WalletItemDTO>();

        public BalancePage()
        {
            InitializeComponent();

            Xuni.Forms.Core.LicenseManager.Key = License.Key;

            items.Clear();
            GetItems();


            initModel();
            initChart();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            items.Clear();
            GetItems();

            initModel();

        }

        private void initModel()
        {

            List<string> rates = new List<string>();

            foreach (var item in items)
            {
                if (item.amount > 0)
                {
                    rates.Add(item.code);
                }
            }

            ResponseRates responseRates;

            walletItems.Clear();
            //List<WalletItemDTO> walletItems = new List<WalletItemDTO>();

            if (rates.Count > 0)
            {
                responseRates = new CurrencyService().GetAllRates(Helpers.Settings.GeneralSettings, rates).Result;
                foreach (var item in responseRates.Rates)
                {
                    if (items.Any(t => t.code.Equals(item.Conversion.To)))
                    {
                        var temp = items.Where(t => t.code.ToLower().Equals(item.Conversion.To.ToLower())).First();

                        var v = item.Value;
                        var e = temp.amount;

                        double result = e / v;

                        totalValue += result;

                        walletItems.Add(new WalletItemDTO()
                        {
                            Coin = item.Conversion.To,
                            Value =  temp.amount / item.Value
                        });
                    }
                }
            }



            // pieChart.Legend.Position = Xuni.Forms.ChartCore.ChartPositionType.Bottom;
            //pieChart.Legend.Orientation = Xuni.Forms.ChartCore.ChartLegendOrientation.Vertical;
            //pieChart.HeaderText = "";
            //pieChart.HeaderFontSize = 20;
            //   pieChart.Refresh();

            //pieChart.SelectedItemOffset = 0.2;
            //pieChart.Refresh(false);
            pieChart.ItemsSource = walletItems;
            string value_string = string.Format("{0:0.00}", totalValue);
            totalAmount.Text = "Total Value in " + Helpers.Settings.GeneralSettings + ": " + value_string;
        }

        void initChart(){

			pieChart.ItemsSource = walletItems;

			pieChart.Legend.Position = Xuni.Forms.ChartCore.ChartPositionType.Bottom;
			pieChart.Legend.Orientation = Xuni.Forms.ChartCore.ChartLegendOrientation.Vertical;
			pieChart.HeaderText = "";
			pieChart.HeaderFontSize = 20;
			//   pieChart.Refresh();

			pieChart.SelectedItemOffset = 0.2;
            
        }

        void GetItems()
        {
            foreach (var i in new Database().GetItems()){
                items.Add(i);
            }
        }

        WalletItem GetItemByCode(string code)
        {
            return new Database().GetItemByCode(code);
        }

    }
}
