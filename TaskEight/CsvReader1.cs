using System.Collections.Generic;
using System.Linq;

namespace TaskEight
{
    public static class CsvReader1
    {
        public static IEnumerable<string[]> ReadCsv1(string path)
        {
            return CsvReader.ReadCsv(path, (header, values) => values.Select(x => x == "NA" ? null : x) .ToArray());
        }
    }
}