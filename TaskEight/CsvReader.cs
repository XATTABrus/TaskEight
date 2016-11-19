using System;
using System.Collections.Generic;
using System.IO;

namespace TaskEight
{
    public static class CsvReader
    {
        public static IEnumerable<T> ReadCsv<T>(string path, Func<string[], string[], T> func)
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

                    yield return func(header, values);
                }
            }
        }
    }
}