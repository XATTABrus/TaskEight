using System.Collections.Generic;
using System.Dynamic;

namespace TaskEight
{
    public class CsvReader4
    {
        public static IEnumerable<dynamic> ReadCsv4(string path)
        {
            return CsvReader.ReadCsv(path, (header, values) =>
            {
                var result = new ExpandoObject();
                var expandoDict = (IDictionary<string, object>)result;

                for (var i = 0; i < values.Length; i++)
                {
                    var res = Converter.Convert(header[i], values[i]);
                    expandoDict.Add(header[i], res);
                }

                return result;
            });
        }
    }
}