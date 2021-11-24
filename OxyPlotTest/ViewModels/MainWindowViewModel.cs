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
            PlotModel1.Series.Add(new LineSeries { LineStyle = LineStyle.Solid, Color = OxyColors.SpringGreen, MarkerType = MarkerType.Circle, MarkerSize = 5, MarkerStroke = OxyColors.Black,MarkerFill = OxyColors.Transparent,MarkerStrokeThickness = 4});
            PlotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom,IsZoomEnabled = false, MajorGridlineStyle = LineStyle.Dot });
            PlotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Left, IsZoomEnabled = false, MajorGridlineStyle = LineStyle.Dot });
            Run();
        }
        public async void Run()
        {          
            Random rdy = new Random();
            while (true)
            {
                var s = (LineSeries)PlotModel1.Series[0];
                double x = s.Points.Count > 0 ? s.Points[s.Points.Count - 1].X + 1 : 0;
                if (s.Points.Count >= 10)
                {
                    s.Points.RemoveAt(0);
                }

                s.Points.Add(new DataPoint(x, rdy.Next(100)));
                PlotModel1.InvalidatePlot(true);
                await Task.Delay(500);
            }
        }
    }
}
