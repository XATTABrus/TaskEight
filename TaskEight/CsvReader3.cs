using System;
using System.Collections.Generic;
using System.IO;

namespace TaskEight
{
    public static class CsvReader3
    {
        public static IEnumerable<Dictionary<string, object>> ReadCsv3(string path)
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

                    if(header.Length != values.Length)
                        throw new ArgumentException("Строка не соотсетствует заголовку!");

                    var result = new Dictionary<string, object>();
                    for (var i = 0; i < values.Length; i++)
                    {
                        result.Add(header[i], Converter.Convert(header[i], values[i]));
                    }

                    yield return result;
                }
            }
        }
    }
}