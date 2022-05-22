namespace tictactoe;

class Renderer 
{
    public Board gBoard;
    public Renderer(Board pBoard)
    {
        gBoard = pBoard;
        Console.WriteLine("renderer initialised");
    }
    public void renderBoard() 
    {
        DansAlgorithm(gBoard.gameBoard.Length, flattenArray());
        Console.Clear();
    }
    void DansAlgorithm(int boardSize, List<Piece> flatArr) 
    {
        int tbs = boardSize == 0 ? gBoard.gameBoard.Length : boardSize;
        int width = tbs;
        int height = tbs;
        if(flatArr.Count != width * height)
            return; 
        char[] grid = new char[width * height];

        for (int i = 0; i < grid.Length; i++)
        {
            char pieceLetter = flatArr[i].pieceState == State.X ? 'X' : flatArr[i].pieceState == State.O ? 'O' : 'U';

            grid[i] = 'X';
        }

        // //inserting y at (0,2)
        // grid[0 + 2 * width] = 'Y';

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write($"| {grid[x + y * width]} ");
            }
            Console.Write("|");
            var lineAmount = 5 + (width - 1) * 4;
            var line = String.Concat(Enumerable.Repeat("-", lineAmount));
            Console.Write("\n" + line + "\n");

        }

    }
    List<Piece> flattenArray()
    {
        List<Piece> flattenedArr = new List<Piece>();
        foreach(var row in gBoard.gameBoard)
        {
            foreach(var val in row)
            {
                flattenedArr.Add(val);
            }
        }
        return flattenedArr;
    }
}