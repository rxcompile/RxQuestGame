#region

using System;
using System.Collections.Generic;
using System.ComponentModel;

#endregion

namespace FgsfdsGame.Model
{
    [Serializable]
    public class GameScreen : INotifyPropertyChanged
    {
        private IList<GameChoice> _choices;
        private string _description;

        private string _image;

        private string _toolTipInformation;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Description"));
            }
        }

        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Image"));
            }
        }

        public string ToolTipInformation
        {
            get { return _toolTipInformation; }
            set
            {
                _toolTipInformation = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ToolTipInformation"));
            }
        }

        public IList<GameChoice> Choices
        {
            get { return _choices; }
            set
            {
                _choices = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Choices"));
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
}