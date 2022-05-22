
namespace tictactoe;
delegate char FindWinner();
public class Game
{
    FindWinner FindWinnerDelegate;
    int player1Score = 0;
    int player2Score = 0;
    Board gameBoard;
    Renderer renderer;
    Player player1;
    Player player2; 

    public void GameRun()
    {
        bool isTurn = true;
        
        
            
            try
            {
                if(isTurn)
                {
                    Console.WriteLine("\n Player one please enter piece you would like to take");
                    Console.Write(" > ");
                    handleUserInput(player1);
                }
                else 
                {
                    Console.WriteLine("\n Player two please enter piece you would like to take");
                    Console.Write(" > ");
                    handleUserInput(player2);
                }
                isTurn = !isTurn;
            } 
            catch (UserInputException err)
            {
                Console.WriteLine(err);
            }

        

        char winner = FindWinnerDelegate.Invoke();
        if(winner == 'X'||winner=='O')
        {
            if(winner=='X')
            {
                Console.WriteLine("");
                player1Score+=1;
                setupBoard();
            }
            else 
            {
                Console.WriteLine("");
                player2Score+=1;
                setupBoard();
            }

        }
        renderer.renderBoard();
        GameRun();
    }
    public Game()
    {
        setUpGame();
    }
    public void setUpGame() 
    {
        Console.WriteLine(" Player one enter name");
        Console.Write(" > ");
        string p1Name = Console.ReadLine();
        player1 = new Player(p1Name, 'X');
        Console.WriteLine(" Player two enter name");
        Console.Write(" > ");
        string p2Name = Console.ReadLine();
        player2 = new Player(p2Name, 'O');
        Console.WriteLine(" Enter Board Size");
        Console.Write(" > ");
        int boardSize;
        int.TryParse(Console.ReadLine(), out boardSize);
        gameBoard = new Board(boardSize);
        renderer = new Renderer(gameBoard);        
    }
    void setupBoard()
    {
        int boardSize = gameBoard.gameBoard.Length;
        gameBoard = new Board(boardSize);
        renderer = new Renderer(gameBoard);
    }
    void handleUserInput(Player player)
    {

        string values = Console.ReadLine();

        string[] vals = values.Split(",");
        if(vals.Length > 2)
        {
            throw new UserInputException("incorrect user input try again");
        }     
        int x;
        int y;
        int.TryParse(vals[0], out x);
        int.TryParse(vals[1], out y);
        try
        {
            gameBoard.takePiece(player, new Coordinate(x, y));
        }
        catch (PieceTakenException err)
        {
            Console.WriteLine(err);
        }
    }
    void findWinnerHelper()
    {
        // tl -> br
        FindWinnerDelegate += () => {
            int rowSize = gameBoard.gameBoard.Length;
            State[] vals = new State[rowSize];
            for(int i = 0; i < rowSize; i++)
            {
                vals[i] = gameBoard.gameBoard[i][i].pieceState;
            }
            bool areAllSame = vals.Select(s => s).Distinct().Count()==1;
            if(areAllSame)
            {
                if(vals[0]==State.X)
                {
                    return 'X';
                }
                else 
                {
                    return 'O';
                }
            }
            else
            {
                return 'U';
            }
        };
        // tr -> bl
        FindWinnerDelegate += () => {
            int rowSize = gameBoard.gameBoard.Length;
            State[] vals = new State[rowSize];
            for(int i=0; i<rowSize; i++)
            {
                vals[i] = gameBoard.gameBoard[i][rowSize-i].pieceState;
            }
            bool areAllSame = vals.Select(v=>v).Distinct().Count()==1;
            if(areAllSame)
            {
                if(vals[0]==State.X)
                {
                    return 'X';
                }
                else
                {
                    return 'O';
                }
            }
            else
            {
                return 'U';
            }
        };
        FindWinnerDelegate += () => {
            int rowSize = gameBoard.gameBoard.Length;
            State[] vals;
            for(int i = 0;i<rowSize; i++)
            {
                vals = new State[rowSize];
                for(int j=0; j<rowSize; j++)
                {
                    vals[j] = gameBoard.gameBoard[j][i].pieceState;
                }
                bool areAllSame = vals.Select(v=>v).Distinct().Count()==1;
                if(areAllSame)
                {
                    if(vals[0] == State.X)
                    {
                        return 'X';
                    }
                    else
                    {
                        return 'O';
                    }
                }
            }
            return 'U';
        };
        FindWinnerDelegate += () => {
            int rowSize = gameBoard.gameBoard.Length;
            State[] vals;
            for(int i = 0; i<rowSize; i++)
            {
                vals = new State[rowSize];
                for(int j = 0; j < rowSize; j++)
                {
                    vals[j] = gameBoard.gameBoard[i][j].pieceState;
                }
                bool areAllSame = vals.Select(v => v).Distinct().Count()==1;
                if(areAllSame)
                {
                    if(vals[0]==State.X)
                    {
                        return 'X';
                    }
                    else
                    {
                        return 'O';
                    }
                }

            }
            return 'U';
        };


    }

}
