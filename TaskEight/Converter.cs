using System;
using System.Globalization;

namespace TaskEight
{
    public static class Converter
    {
        public static object Convert(string propName, string value)
        {
            switch (propName)
            {
                case "Name":
                    return value;
                case "Ozone":
                {
                    int res;
                    return int.TryParse(value, out res) ? (int?)res : null;
                }
                case "Solar.R":
                {
                    int res;
                    return int.TryParse(value, out res) ? (int?) res : null;
                }
                case "Wind":
                    return double.Parse(value, CultureInfo.InvariantCulture);
                case "Temp":
                    return double.Parse(value, CultureInfo.InvariantCulture);
                case "Month":
                    return int.Parse(value);
                case "Day":
                    return int.Parse(value);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}