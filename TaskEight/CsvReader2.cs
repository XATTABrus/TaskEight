using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace TaskEight
{
    public static class CsvReader2
    {
        public static IEnumerable<T> ReadCsv2<T>(string path) where T : new()
        {
            return CsvReader.ReadCsv(path, GetObject<T>);                   
        }

        private static T GetObject<T>(string[] header, string[] values) where T : new ()
        {
            var result = new T();
            var properties = result.GetType().GetProperties();

            for (var i = 0; i < header.Length; i++)
            {
                var pr = properties.FirstOrDefault(x => x.Name == header[i]);
                if (pr == null) continue;
                SetValue(pr, values[i], result);
            }

            return result;
        }

        private static void SetValue<T>(PropertyInfo property, string value, T result)
        {
            if (property.PropertyType == typeof(int))          
                property.SetValue(result, int.Parse(value));
            
            if (property.PropertyType == typeof(double))
                property.SetValue(result, double.Parse(value, CultureInfo.InvariantCulture));

            if (property.PropertyType == typeof(string))           
                property.SetValue(result, value);
            

            if (property.PropertyType == typeof(int?))
            {
                int res;
                property.SetValue(result, int.TryParse(value, out res) ? (int?)res : null);
            }
        }
    }
}