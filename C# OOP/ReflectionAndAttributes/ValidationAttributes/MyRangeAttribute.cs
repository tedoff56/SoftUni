using System;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int _minValue;
        private int _maxValue;
        
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this._minValue = minValue;
            this._maxValue = maxValue;
        }
        
        public override bool IsValid(object obj)
        {
            bool isInt = obj is int;
            if (!isInt)
            {
                throw new ArgumentException();
            }

            int value = (int) obj;

            bool isInRange = value >= _minValue && value <= _maxValue;
            if (!isInRange)
            {
                return false;
            }

            return true;
        }
    }
}