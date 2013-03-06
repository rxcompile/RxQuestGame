#region

using System;
using System.ComponentModel;
using System.Timers;

#endregion

namespace FgsfdsGame.Model
{
    public class VisualTimer : INotifyPropertyChanged
    {
        private readonly Timer _checker;

        private string _name;

        private double _timeLeft;

        public VisualTimer(double time)
        {
            Interval = TimeLeft = time;
            _checker = new Timer(100);
            _checker.Elapsed += CheckerElapsed;
            _checker.Start();
        }

        public void Remove()
        {
            _checker.Stop();
        }

        public void Reset(double time)
        {
            _checker.Stop();
            Interval = TimeLeft = time;
            _checker.Start();
        }

        public double Interval { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }

        public double TimeLeft
        {
            get { return _timeLeft; }
            set
            {
                _timeLeft = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TimeLeft"));
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        #endregion

        private void CheckerElapsed(object sender, ElapsedEventArgs e)
        {
            TimeLeft -= 100;
            if (TimeLeft < 0)
            {
                TimeLeft = 0;
                OnElapsed(new EventArgs());
                _checker.Stop();
            }
        }

        public event EventHandler Elapsed;

        public void OnElapsed(EventArgs e)
        {
            EventHandler handler = Elapsed;
            if (handler != null) handler(this, e);
        }
    }
}