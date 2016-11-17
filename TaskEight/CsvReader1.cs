using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaskEight
{
    public static class CsvReader1
    {
        public static IEnumerable<string[]> ReadCsv1(string path)
        {
            using(var stream = new StreamReader(path))
            {
                while (true)
                {
                    var str = stream.ReadLine();

                    if (str == null)
                    {
                        stream.Close();
                        yield break;
                    }

                    yield return 
                        str
                        .Split(',')
                        .Select(x=> x == "NA" ? null : x)
                        .ToArray();
                }
            }
        }
    }
}