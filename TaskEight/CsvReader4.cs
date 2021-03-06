﻿using System.Collections.Generic;
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
                    expandoDict.Add(header[i], Converter.DynamicConvert(values[i]));
                }

                return result;
            });
        }
    }
}