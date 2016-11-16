using System;

namespace TaskEight
{
    static class Program
    {
        static void Main(string[] args)
        {
            foreach (var itme in CsvReader.ReadCsv1("airquality.csv"))
            {
                foreach (var s in itme)
                {
                    if(s != null)
                    Console.Write(s + " ");
                }
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
