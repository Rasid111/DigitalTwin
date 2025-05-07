using DigitalTwin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DigitalTwin.Services
{
    public class SimulationService
    {
        private readonly Factory _factory;
        private readonly DispatcherTimer _simulationTimer;
        private readonly Random _random = new Random();

        public SimulationService(Factory factory)
        {
            _factory = factory;
            _simulationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _simulationTimer.Tick += Simulate;
        }

        public void StartSimulation()
        {
            _simulationTimer.Start();
        }

        public void StopSimulation()
        {
            _simulationTimer.Stop();
        }

        private void Simulate(object sender, EventArgs e)
        {
            foreach (var machine in _factory.Machines)
            {
                if (machine.IsRunning)
                {
                    machine.Temperature = Math.Round(25 + _random.NextDouble() * 50, 1);
                    machine.Vibration = Math.Round(_random.NextDouble() * 10, 2);
                    machine.ProductionRate = Math.Round(0.5 + _random.NextDouble() * 1.5, 1);

                    _factory.TotalProduction += _random.Next(1, 5);
                }
            }
        }
    }
}
