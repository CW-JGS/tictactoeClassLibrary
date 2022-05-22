namespace tictactoe;

class Board 
{
    private static int boardSize;
    public static int BoardSize
    {
        get => boardSize; 
        set => boardSize = value;
    }
    public Piece[][] gameBoard;
    public Board(int pBoardSize) 
    {
        BoardSize = pBoardSize == 0 ? 3 : pBoardSize;
        generateBoard();
    }
    public void generateBoard() 
    {
        gameBoard = new Piece[boardSize][];
        for(int i = 0; i < boardSize; i ++)
        {
            gameBoard[i] = new Piece[boardSize];
            for(int j = 0; j<boardSize; j++)
            {
                gameBoard[i][j] = new Piece();
            }
        }

    }
    public void takePiece(Player playerTaking, Coordinate pieceCoordinate ){
        if((playerTaking == null || pieceCoordinate == null)||(playerTaking == null && pieceCoordinate == null)) return;
        int pX = pieceCoordinate.X;
        int pY = pieceCoordinate.Y;
        if(gameBoard[pY][pX].pieceState == State.U)
        {
            if(playerTaking.playerLetter == 'X')
            {
                gameBoard[pY][pX].pieceState = State.X;
                return;
            }
            else
            {
                gameBoard[pY][pX].pieceState = State.O;
                return;
            }
        }
        else 
        {
            string msg = string.Format("piece at {0} , {1} is taken", pX, pY);
            throw new PieceTakenException(msg);
        }

    }


}