using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace TaskEight
{
    public class CsvReader4
    {
        public static IEnumerable<dynamic> ReadCsv4(string path)
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

                    var result = new ExpandoObject();
                    var expandoDict = (IDictionary<string, object>)result;

                    for (var i = 0; i < values.Length; i++)
                    {
                        var res = Converter.Convert(header[i], values[i]);
                        expandoDict.Add(header[i], res);
                    }

                    yield return result;
                }
            }
        }
    }
}