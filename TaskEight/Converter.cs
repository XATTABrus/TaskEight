using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace TaskEight
{
    public static class Converter
    {

        public static object DynamicConvert(string value)
        {
            if (value == "NA")
                return null;

            double doubleResult;
            if (double.TryParse(value, out doubleResult))
                return doubleResult;

            int intResult;
            if (int.TryParse(value, out intResult))
                return intResult;

            return value;
        }

        // Аргумент notUsed добавлена тут для того чтоб компилятор не ругался на схожие сигнатуры методов
        // Я просто хочу показать разные подходы решения задачи конвертации
        public static object Convert(string propName, string value, Type type, object notUsed) 
        {
            var propertyType = type.GetProperty(propName)?.PropertyType;

            if(propertyType == null)
                throw new ArgumentException("Не удается найти данное свойство");
            
            var converter = TypeDescriptor.GetConverter(propertyType);

            if (!converter.IsValid(value))
                throw new Exception($"Значение {value} не подходит для свойства {propName}");

            return converter.ConvertFromString(null, CultureInfo.InvariantCulture, value);
        }


        public static object Convert(string propName, string value, Type template)
        {
            var property = template.GetProperty(propName);

            if (property == null)
                throw new ArgumentException("Не допустимое свойство!");

            if (property.PropertyType == typeof(int))
                return int.Parse(value);

            if (property.PropertyType == typeof(double))
                return double.Parse(value, CultureInfo.InvariantCulture);

            if (property.PropertyType == typeof(string))
                return value;

            if (property.PropertyType == typeof(int?))
            {
                int res;
                return int.TryParse(value, out res) ? (int?)res : null;
            }

            throw new InvalidCastException("Не удается найти тип приведения для данного свойста!");
        }

        public static object Convert(string propName, string value)
        {
            switch (propName)
            {
                case "Name":
                    return value;
                case "Ozone":
                    {
                        int res;
                        return int.TryParse(value, out res) ? (int?)res : null;
                    }
                case "Solar.R":
                    {
                        int res;
                        return int.TryParse(value, out res) ? (int?)res : null;
                    }
                case "Wind":
                    return double.Parse(value, CultureInfo.InvariantCulture);
                case "Temp":
                    return double.Parse(value, CultureInfo.InvariantCulture);
                case "Month":
                    return int.Parse(value);
                case "Day":
                    return int.Parse(value);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}