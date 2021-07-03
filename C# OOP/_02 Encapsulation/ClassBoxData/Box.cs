using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => _length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                _length = value;
            }
        }

        public double Width
        {
            get => _width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                _width = value;
            }
        }
        
        public double Height
        {
            get => _height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                _height = value;
            }
        }
        
        public double GetSurfaceArea() => (2 * _length * _width) + (2 * _length * _height) + (2 * _width * _height);
        
        public double GetLateralSurfaceArea() => (2 * _length * _height) + (2 * _width * _height);
        
        public double GetVolume() => _length * _width * _height;
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {GetSurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {GetLateralSurfaceArea():F2}")
                .AppendLine($"Volume - {GetVolume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}