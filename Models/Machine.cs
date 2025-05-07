using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTwin.Models
{
    public class Machine : INotifyPropertyChanged
    {
        private string _name;
        private MachineType _type;
        private double _temperature;
        private double _vibration;
        private double _productionRate;
        private bool _isRunning;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public MachineType Type
        {
            get => _type;
            set { _type = value; OnPropertyChanged(); }
        }

        public double Temperature
        {
            get => _temperature;
            set { _temperature = value; OnPropertyChanged(); }
        }

        public double Vibration
        {
            get => _vibration;
            set { _vibration = value; OnPropertyChanged(); }
        }

        public double ProductionRate
        {
            get => _productionRate;
            set { _productionRate = value; OnPropertyChanged(); }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set { _isRunning = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
