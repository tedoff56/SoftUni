using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string _model;
        private int _horsePower;
        private int _minHorsePower;
        private int _maxHorsePower;
        
        protected Car(
            string model, 
            int horsePower, 
            double cubicCentimeters, 
            int minHorsePower, 
            int maxHorsePower)
        {
            Model = model;
            _minHorsePower = minHorsePower;
            _maxHorsePower = maxHorsePower;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => _model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                _model = value;
            }
        }

        public int HorsePower
        {
            get => _horsePower;
            private set
            {
                if (value < _minHorsePower || value > _maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                _horsePower = value;
            }
        }
        
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps) 
            => CubicCentimeters / HorsePower * laps;
    }
}