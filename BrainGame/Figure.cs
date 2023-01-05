namespace BrainGame
{
    internal class Figure
    {
        public int[,] Form { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Symbol { get; set; } = "█";
        public ConsoleColor Color { get; set; }

        public Figure(int[,] form, ConsoleColor color)   
        {
            Form = form;
            Color = color;
        }
    }
}
