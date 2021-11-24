using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OxyPlotTest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private PlotModel plotModel1 = new PlotModel { Title = "曲线" };
        public PlotModel PlotModel1
        {
            get { return plotModel1; }
            set { SetProperty(ref plotModel1, value); }
        }
        public MainWindowViewModel()
        {
            PlotModel1.Series.Add(new LineSeries { LineStyle = LineStyle.Solid});
            Run();
        }
        public async void Run()
        {
            int i = 0;
            Random rdy = new Random();
            while (true)
            {
                var s = (LineSeries)PlotModel1.Series[0];
                if (s.Points.Count >= 100)
                {
                    s.Points.RemoveAt(0);
                }
                s.Points.Add(new DataPoint(i++, rdy.Next(100)));
                PlotModel1.InvalidatePlot(true);
                await Task.Delay(100);
            }
        }
    }
}
