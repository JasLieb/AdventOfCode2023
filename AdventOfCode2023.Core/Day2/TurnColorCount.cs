namespace AdventOfCode2023.Core
{
    public record TurnColorCount()
    {
        public int Red { get; private set; } = 0;
        public int Green { get; private set; } = 0;
        public int Blue { get; private set; } = 0;
        public int Power => Red * Green * Blue;

        public int this[string color]
        {
            get => GetProperty(color);
            set => SetProperty(color, value);
        }

        private void SetProperty(string color, int value)
        {
            switch (color)
            {
                case "red": Red = value; break;
                case "green": Green = value; break;
                case "blue": Blue = value; break;
            }
        }

        private int GetProperty(string color)
        {
            return color switch
            {
                "red" => Red,
                "green" => Green,
                "blue" => Blue,
                _ => -1
            };
        }
    }
}
