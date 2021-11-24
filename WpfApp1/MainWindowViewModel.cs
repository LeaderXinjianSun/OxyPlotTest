using Microsoft.Practices.Prism.ViewModel;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MainWindowViewModel : NotificationObject
    {
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
