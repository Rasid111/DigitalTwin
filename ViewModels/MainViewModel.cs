using DigitalTwin.Models;
using DigitalTwin.Services;
using DigitalTwin.Tools;
using DigitalTwin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DigitalTwin.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Factory _factory;
        private readonly SimulationService _simulationService;
        private Machine _selectedMachine;

        public Factory Factory => _factory;

        public Machine SelectedMachine
        {
            get => _selectedMachine;
            set
            {
                _selectedMachine = value;
                OnPropertyChanged();
                if (value != null)
                {
                    ShowMachineDetails(value);
                }
            }
        }

        public ICommand StartSimulationCommand { get; }
        public ICommand StopSimulationCommand { get; }

        public MainViewModel()
        {
            _factory = CreateSampleFactory();
            _simulationService = new SimulationService(_factory);

            StartSimulationCommand = new RelayCommand(StartSimulation);
            StopSimulationCommand = new RelayCommand(StopSimulation);

            _simulationService.StartSimulation();
        }

        private Factory CreateSampleFactory()
        {
            var factory = new Factory
            {
                Name = "Завод",
                Machines = new ObservableCollection<Machine>
            {
                new Machine { Name = "CNC-1", Type = MachineType.CNC, IsRunning = true },
                new Machine { Name = "Пресс-2", Type = MachineType.Press, IsRunning = true },
                new Machine { Name = "Конвейер-1", Type = MachineType.Conveyor, IsRunning = false },
                new Machine { Name = "Сварщик-3", Type = MachineType.Welder, IsRunning = true },
                new Machine { Name = "Упаковщик-1", Type = MachineType.Packer, IsRunning = true }
            }
            };

            return factory;
        }

        private void StartSimulation()
        {
            _simulationService.StartSimulation();
        }

        private void StopSimulation()
        {
            _simulationService.StopSimulation();
        }

        private void ShowMachineDetails(Machine machine)
        {
            var detailsWindow = new MachineDetailsWindow
            {
                DataContext = new MachineDetailsViewModel(machine)
            };
            detailsWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
