using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator   
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (PropertyInfo property in props)
            {
                var attribute = property.GetCustomAttribute(typeof(MyValidationAttribute), false) as MyValidationAttribute;

                bool isValid = attribute.IsValid(property.GetValue(obj));
                if (!isValid)
                {
                    return false;
                }
                
            }

            return true;
        }
    }
}