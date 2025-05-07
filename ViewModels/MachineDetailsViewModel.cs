using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DigitalTwin.Models;

namespace DigitalTwin.ViewModels
{
    public class MachineDetailsViewModel : INotifyPropertyChanged
    {
        private readonly Machine _machine;

        public string Name => _machine.Name;
        public string Type => _machine.Type.ToString();
        public double Temperature => _machine.Temperature;
        public double Vibration => _machine.Vibration;
        public double ProductionRate => _machine.ProductionRate;
        public bool IsRunning => _machine.IsRunning;

        public MachineDetailsViewModel(Machine machine)
        {
            _machine = machine;
            _machine.PropertyChanged += (s, e) => OnPropertyChanged(e.PropertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
