namespace BrainGame
{
    internal static class Drawer
    {
        public static void DrawBoard(Board board)
        {
            int offsetX = 0;
            int offsetY = 0;

            for (int currentRow = 0; currentRow < board.GameField.GetLength(0); currentRow++)
            {
                Console.SetCursorPosition(offsetX, currentRow + offsetY);

                for (int currentColumn = 0; currentColumn < board.GameField.GetLength(1); currentColumn++)
                {
                    Console.Write(board.GameField[currentRow, currentColumn]);
                }
                Console.WriteLine("");
            }
        }
    }
}
