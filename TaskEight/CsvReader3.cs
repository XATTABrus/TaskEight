using System.Collections.Generic;

namespace TaskEight
{
    public static class CsvReader3
    {
        public static IEnumerable<Dictionary<string, object>> ReadCsv3(string path)
        {
            return CsvReader.ReadCsv(path, (header, values) =>
            {
                var result = new Dictionary<string, object>();
                for (var i = 0; i < values.Length; i++)
                {
                    result.Add(header[i], Converter.Convert(header[i], values[i]));
                }

                return result;
            });
        }
    }
}