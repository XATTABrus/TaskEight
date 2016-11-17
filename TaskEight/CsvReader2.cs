using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TaskEight
{
    public static class CsvReader2
    {
        public static IEnumerable<T> ReadCsv2<T>(string path) where T : new()
        {
            using (var stream = new StreamReader(path))
            {
                // Получаем заголовок файла
                var header = stream.ReadLine()?.Replace("\"", "").Split(',');

                while (true)
                {
                    // Читаем данные из файла
                    var values = stream.ReadLine()?.Split(',');

                    if (values == null || header == null)
                    {
                        stream.Close();
                        yield break;
                    }

                    if (header.Length != values.Length)
                        throw new ArgumentException("Строка не соотсетствует заголовку!");

                    yield return GetObject<T>(header, values);
                }
            }
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