namespace BrainGame
{
    internal class Board
    {
        public int[,] GameField { get; set; }

        public Board(int columns, int rows)
        {
            GameField = new int[rows, columns];
        }   

        public int TryAllListsOfFigures(Board board, List<List<Figure>> permutedFigures)
        {
            int count = 0;

            foreach (var figures in permutedFigures)
            {
                if (!TryPutFiguresOnBoard(board, figures))
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }

            return -1; // If figures not placed.
        }

        private bool TryPutFiguresOnBoard(Board board, List<Figure> figures)
        {
            int count = 0;

            while (count < figures.Count)
            {
                if (PlaceFigureOnBoard(figures[count].Form, board, figures[count]))
                {
                    count++;
                }
                else
                {
                    ClearBoard();

                    return false;
                }
            }

            return true;
        }

        private void ClearBoard()
        {
            BoardItem boardItem = new BoardItem()
            {
                Symbol = " ",
                Color = ConsoleColor.White
            };

            for (int currentRow = 0; currentRow < GameField.GetLength(0); currentRow++)
            {
                for (int currentColumn = 0; currentColumn < GameField.GetLength(1); currentColumn++)
                {
                    GameField[currentRow, currentColumn] = default(int);
                }
            }
        }

        private bool PlaceFigureOnBoard(int[,] figureForm, Board board, Figure figure)
        {
            for (int startBoardRow = 0; startBoardRow <= board.GameField.GetLength(0) - figureForm.GetLength(0); startBoardRow++)
            {
                for (int startBoardColumn = 0; startBoardColumn <= board.GameField.GetLength(1) - figureForm.GetLength(1); startBoardColumn++)
                {
                    if (CanFigureBePlacedInCurrentPlace(figureForm, board, startBoardRow, startBoardColumn))
                    {
                        PutFigureDataIntoBoard(board, figureForm, startBoardRow, startBoardColumn);
                        figure.PositionX = startBoardRow;
                        figure.PositionY = startBoardColumn;

                        return true;
                    } 
                }
            }

            return false;
        }

        private void PutFigureDataIntoBoard(Board board, int[,] figure, int startBoardRow, int startBoardColumn)
        {
            for (int currentFigureRow = 0; currentFigureRow < figure.GetLength(0); currentFigureRow++)
            {
                for (int currentFigureColumn = 0; currentFigureColumn < figure.GetLength(1); currentFigureColumn++)
                {
                    if (figure[currentFigureRow, currentFigureColumn] != 0)
                    {
                        board.GameField[startBoardRow + currentFigureRow, startBoardColumn + currentFigureColumn] = figure[currentFigureRow, currentFigureColumn];
                    }
                }
            }
        }

        private bool CanFigureBePlacedInCurrentPlace(int[,] figure, Board board, int startBoardRow, int startBoardColumn)
        {
            for (int currentFigureRow = 0; currentFigureRow < figure.GetLength(0); currentFigureRow++)
            {
                for (int currentFigureColumn = 0; currentFigureColumn < figure.GetLength(1); currentFigureColumn++)
                {
                    if (!CanPutPixelInCurrentPosition(board, figure, currentFigureColumn, currentFigureRow, startBoardColumn + currentFigureColumn, startBoardRow + currentFigureRow))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsPossibleToPutAllFiguresOnBoard(List<Figure> figures, int[,] board)
        {
            int amount = 0;

            foreach (var figure in figures)
            {
                for (int currentFigureRow = 0; currentFigureRow < figure.Form.GetLength(0); currentFigureRow++)
                {
                    for (int currentFigureColumn = 0; currentFigureColumn < figure.Form.GetLength(1); currentFigureColumn++)
                    {
                        if (figure.Form[currentFigureRow, currentFigureColumn] != 0)
                        {
                            amount++;
                        }
                    }
                }
            }

            return board.LongLength >= amount;
        }

        private bool CanPutPixelInCurrentPosition(Board board, int[,] figure, int currentFigureColumn, int currentFigureRow, int startBoardColumn, int startBoardRow)
        {
            return (figure[currentFigureRow, currentFigureColumn] == 0 || board.GameField[startBoardRow, startBoardColumn] == 0);
        }
    }
}
