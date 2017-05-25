using System;
using System.Collections.Generic;

using Xamarin.Forms;
using OxyPlot;

namespace coins
{
    using coins.Model;
    using coins.Service;
    using OxyPlot.Series;
    using OxyPlot.Xamarin.Forms;
    using System.Collections.ObjectModel;
    using System.Linq;

    public partial class BalancePage : ContentPage
    {

        private PlotModel model;
        private ObservableCollection<WalletItem> items = new ObservableCollection<WalletItem>();
        private WalletItem total;

        public PlotModel Model { get => model; }

        public BalancePage()
        {
            InitializeComponent();

            items.Clear();
            GetItems();

            initTotal();

            initModel();
        }

        private void initModel()
        {

            List<WalletItemDTO> walletItems = new List<WalletItemDTO>();

            List<string> rates = new List<string>();

            foreach (var item in walletItems)
            {
                if (item.Amount > 0)
                {
                    rates.Add(item.Code);
                }
            }

            var responseRates = new CurrencyService().GetAllRates(Helpers.Settings.GeneralSettings, rates).Result;

            model = new PlotModel
            {
                Title = "Balance"
            };

            dynamic series = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            foreach (var item in responseRates.Rates)
            {
                if (walletItems.Any(t => t.Code.ToLower().Equals(item.Currency.To)))
                {
                    var temp = walletItems.Find(t => t.Code.ToLower().Equals(item.Currency.To));
                    series.Slices.Add(
                        new PieSlice(item.Currency.To, (temp.Amount / item.Amount))
                        {
                            IsExploded = false
                        });
                }
            }

            model.Series.Add(series);
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
                            Code = item.code,
                            Amount = item.amount
                        });
                }
            }

            WalletItemDTO temp = new CurrencyService().GetTotalValue(walletItems, Helpers.Settings.GeneralSettings).Result;

            total = GetItemByCode(temp.Code);
            total.amount = temp.Amount;
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
