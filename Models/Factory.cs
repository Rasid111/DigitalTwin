using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTwin.Models
{
    public class Factory : INotifyPropertyChanged
    {
        private string _name;
        private int _totalProduction;
        private ObservableCollection<Machine> _machines;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public int TotalProduction
        {
            get => _totalProduction;
            set { _totalProduction = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Machine> Machines
        {
            get => _machines;
            set { _machines = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
