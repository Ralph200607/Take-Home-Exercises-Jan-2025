using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrainSystem
{
    public class Train
    {
        private readonly List<RailCar> _railCars = new List<RailCar>();

        public Engine Engine { get; }

        public int MaximumGrossWeight => Engine.HorsePower * 2000;

        public int GrossWeight => Engine.Weight + _railCars.Sum(car => car.GrossWeight);

        public IReadOnlyList<RailCar> RailCars => _railCars.AsReadOnly();

        public int TotalCars => _railCars.Count;

        public Train(Engine engine)
        {
            Engine = engine ?? throw new ArgumentNullException(nameof(engine), "Engine cannot be null.");
        }

        public void AddCar(RailCar car)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car), "RailCar cannot be null.");

            if (_railCars.Any(c => c.SerialNumber == car.SerialNumber))
                throw new ArgumentException($"A RailCar with Serial Number {car.SerialNumber} already exists in the train.");

            _railCars.Add(car);
        }

        public RailCar DetachCar(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
                throw new ArgumentNullException(nameof(serialNumber), "Serial number cannot be null or empty.");

            RailCar carToRemove = _railCars.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (carToRemove == null)
                throw new ArgumentException($"RailCar with Serial Number {serialNumber} does not exist in the train.");

            _railCars.Remove(carToRemove);
            return carToRemove;
        }
    }
}

