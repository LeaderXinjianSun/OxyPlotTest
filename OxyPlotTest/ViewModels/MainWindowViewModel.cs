using OxyPlot;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        private IList<DataPoint> leftPoints;

        public IList<DataPoint> LeftPoints
        {
            get { return leftPoints; }
            set
            {
                leftPoints = value;
                this.RaisePropertyChanged("LeftPoints");
            }
        }
        public MainWindowViewModel()
        {
            LeftPoints = new ObservableCollection<DataPoint>();
            for (int i = 0; i < 1000; i++)
            {
                LeftPoints.Add(new DataPoint(i, i * i));
            }
        }
    }
}
