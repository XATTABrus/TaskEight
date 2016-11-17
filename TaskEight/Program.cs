using System;
using System.Collections.Generic;

namespace TaskEight
{
    static class Program
    {
        private static void Show<T>(Func<string, IEnumerable<T>> func)
        {
            foreach (var itme in func("airquality.csv"))
            {
                Console.WriteLine(itme.ToString());

                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            //Show(CsvReader.ReadCsv1);

            //Show(CsvReader2.ReadCsv2<Model>);

            Show(CsvReader3.ReadCsv3);
        }
    }
}
