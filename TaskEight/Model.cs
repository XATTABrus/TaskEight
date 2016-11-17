namespace TaskEight
{
    public class Model
    {
        public string Name { get; set; }
        public int? Ozone { get; set; }
        public int? Solar { get; set; }
        public double Wind { get; set; }
        public int Temp { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public override string ToString()
        {
            return $"{Name} {Ozone} {Solar} {Wind} {Temp} {Month} {Day}";
        }
    }
}