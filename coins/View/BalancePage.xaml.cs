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
        private double totalValue;

        public BalancePage()
        {
            InitializeComponent();

            Xuni.Forms.Core.LicenseManager.Key = License.Key;

            items.Clear();
            GetItems();

            //initTotal();

            initModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            items.Clear();
            GetItems();

            //initTotal();

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
            List<WalletItemDTO> walletItems = new List<WalletItemDTO>();

            if (rates.Count > 0)
            {
                responseRates = new CurrencyService().GetAllRates(Helpers.Settings.GeneralSettings, rates).Result;
                foreach (var item in responseRates.Rates)
                {
                    if (items.Any(t => t.code.ToLower().Equals(item.Currency.To)))
                    {
                        var temp = items.Where(t => t.code.ToLower().Equals(item.Currency.To)).First();
                        walletItems.Add(new WalletItemDTO()
                        {
                            Coin = temp.code,
                            Value = temp.amount / item.Amount
                        });
                    }
                }
            }

            //walletItems.Add(new WalletItemDTO()
            //{
            //    Coin = "EUR",
            //    Value = 243.98
            //});
            //walletItems.Add(new WalletItemDTO()
            //{
            //    Coin = "USD",
            //    Value = 122.98
            //});
            //walletItems.Add(new WalletItemDTO()
            //{
            //    Coin = "CAD",
            //    Value = 22.98
            //});

            pieChart.ItemsSource = walletItems;

            pieChart.Legend.Position = Xuni.Forms.ChartCore.ChartPositionType.Bottom;
            pieChart.Legend.Orientation = Xuni.Forms.ChartCore.ChartLegendOrientation.Vertical;
            pieChart.HeaderText = "Balance";
            pieChart.HeaderFontSize = 20;

            pieChart.SelectedItemOffset = 0.2;
        }

        private void initTotal()
        {

            List<WalletItemDTO> walletItems = new List<WalletItemDTO>();

            foreach (var item in items)
            {
                if (item.amount > 0)
                {
                    walletItems.Add(
                        new WalletItemDTO()
                        {
                            Coin = item.code,
                            Value = item.amount
                        });
                }
            }

            WalletItemDTO temp = new CurrencyService().GetTotalValue(walletItems, Helpers.Settings.GeneralSettings).Result;

            currency = CoinDictionary.Instance.GetCoinFromCode(temp.Coin);
            totalValue = temp.Value;
        }
        void GetItems()
        {
            items = new Database().GetItems();
        }

        WalletItem GetItemByCode(string code)
        {
            return new Database().GetItemByCode(code);
        }

    }
}
