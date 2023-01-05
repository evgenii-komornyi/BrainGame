using BrainGame;

Board board = new Board(5, 3);

List<Figure> figures = new List<Figure>();

int[,] firstFigureForm = {
    { 1, 1 },
    { 0, 1 }, 
    { 1, 1 }
};

int[,] secondFigureForm =
{
    { 0, 2, 0 },
    { 2, 2, 2 },
    { 0, 2, 0 },
};

int[,] thirdFigureForm =
{
    { 3, 3 },
    { 3, 0 },
    { 3, 3 }
};

/*int[,] firstFigureForm = {
    { 1, 1, 1, 1 }
};

int[,] secondFigureForm =
{
    { 2, 0 },
    { 2, 0 },
    { 2, 0 },
    { 2, 2 },
};

int[,] thirdFigureForm =
{
    { 0, 3, 0 },
    { 3, 3, 3 },
    { 0, 3, 0 }
};

int[,] fourthFigureForm =
{
    { 4 },
    { 4 },
    { 4 },
    { 4 }
};

int[,] fifthFigureForm =
{
    { 5 }
};

int[,] sixthFigureForm =
{
    { 0, 6 },
    { 6, 6 }
};*/

Figure firstFigure = new Figure(firstFigureForm, ConsoleColor.Green);
Figure secondFigure = new Figure(secondFigureForm, ConsoleColor.Gray);
Figure thirdFigure = new Figure(thirdFigureForm, ConsoleColor.Magenta);

/*
Figure fourthFigure = new Figure(fourthFigureForm, ConsoleColor.DarkGreen);
Figure fifthFigure = new Figure(fifthFigureForm, ConsoleColor.Cyan);
Figure sixthFigure = new Figure(sixthFigureForm, ConsoleColor.DarkRed);*/

figures.Add(firstFigure);
figures.Add(secondFigure);
figures.Add(thirdFigure);
/*figures.Add(fourthFigure);
figures.Add(fifthFigure);
figures.Add(sixthFigure);
*/

if (!board.IsPossibleToPutAllFiguresOnBoard(figures, board.GameField))
{
    Console.WriteLine("Too many figures for this board.");
}
else
{
    var permutedList = Permutation.permute(figures);

    int numberOfFailedAttempts = board.TryAllListsOfFigures(board, permutedList);

    if (numberOfFailedAttempts != -1)
    {
        Console.SetCursorPosition(0, 50);
        Console.WriteLine($"Numbers of failed attempts: {numberOfFailedAttempts}");
        Console.WriteLine($"Success attempt in: {numberOfFailedAttempts + 1}");
        Console.WriteLine("All figures on the board.");
    }
    else
    {
        Console.WriteLine("Cannot put figure on the board.");
    }

    Drawer.DrawBoard(board);
    Console.WriteLine("____________________");
}