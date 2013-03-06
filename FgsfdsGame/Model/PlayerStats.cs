using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FgsfdsGame.Model
{
    public class PlayerStats : INotifyPropertyChanged 
    {
        private int _health = 100;
        public int Health
        {
            get { return _health; }
            set { _health = value; OnPropertyChanged(new PropertyChangedEventArgs("Health"));}
        }

        private readonly ObservableCollection<VisualTimer> _timers = new ObservableCollection<VisualTimer>();
        public ObservableCollection<VisualTimer> Timers
        {
            get { return _timers; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
}