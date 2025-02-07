using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class Engine
    {
        private int _horsePower;
        private int _weight;

        public string Model { get; }
        public string SerialNumber { get; }
        public bool InService { get; set; }

        public int Weight
        {
            get => _weight;
            set
            {
                if (InService) 
                    throw new Exception("Cannot modify weight while engine is in service.");
                if (!Utilities.IsPositiveNonZero(value) || !Utilities.InHundreds(value))
                    throw new ArgumentException("Weight must be a positive, non-zero whole number in 100pound increments.");
                _weight = value;
            }
        }

        public int HorsePower
        {
            get => _horsePower;
            set
            {
                if (InService) 
                    throw new Exception("Cannot modify horsepower while engine is in service.");
                if (value < 3500 || value > 5500 || value % 100 != 0)
                    throw new ArgumentException("Horsepower must be between 3500 and 5500 in 100 HP increments.");
                _horsePower = value;
            }
        }

        public Engine(string model, string serialNumber, int weight, int horsePower)
        {
            if (string.IsNullOrWhiteSpace(model)) 
                throw new ArgumentNullException(nameof(model), "Model cannot be empty.");
            if (string.IsNullOrWhiteSpace(serialNumber)) 
                throw new ArgumentNullException(nameof(serialNumber), "Serial Number cannot be empty.");
            if (!Utilities.IsPositiveNonZero(weight) || !Utilities.InHundreds(weight))
                throw new ArgumentException("Weight must be a positive, non-zero whole number in 100-pound increments.");
            if (horsePower < 3500 || horsePower > 5500 || horsePower % 100 != 0)
                throw new ArgumentException("Horsepower must be between 3500 and 5500 in 100 HP increments.");

            Model = model.Trim();
            SerialNumber = serialNumber.Trim();
            _weight = weight;
            _horsePower = horsePower;
            InService = true;
        }

        public override string ToString()
        {
            return $"{Model},{SerialNumber},{Weight},{HorsePower},{InService}";
        }
    }

}

