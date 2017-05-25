using System;
using System.Collections.Generic;

using Xamarin.Forms;
using OxyPlot;

namespace coins
{
    using coins.Model;
    using OxyPlot.Series;
    using OxyPlot.Xamarin.Forms;
    using System.Collections.ObjectModel;

    public partial class RatesPage : ContentPage
    {

        private PlotModel model;
        private ObservableCollection<WalletItem> items = new ObservableCollection<WalletItem>();

        public PlotModel Model { get => model; }

        public RatesPage()
        {
            InitializeComponent();

            initModel();

        }

        private void initModel()
        {
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

            items.Clear();
            GetItems();

            foreach (var item in items)
            {
                if (item.amount > 0)
                {
                    series.Slices.Add(
                        new PieSlice(item.code, item.amount)
                        {
                            IsExploded = false
                        });
                }
            }

            model.Series.Add(series);
        }

        void GetItems()
        {
            items = new Database().GetItems();
        }

    }
}
