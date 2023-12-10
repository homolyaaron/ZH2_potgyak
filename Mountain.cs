using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_elbasztadgyoker
{
    public class Mountain:INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            {   if(value != _name)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }  
            }
        }
        private int _height;
        public int Height
        {
            get { return _height; }
            set
            {
                if (value != _height)
                {
                    _height = value;
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        private bool _megmaszva;
        public bool Megmaszva
        {
            get { return _megmaszva; }
            set
            {
                if (value != _megmaszva)
                {
                    _megmaszva = value;
                    OnPropertyChanged(nameof(Megmaszva));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}