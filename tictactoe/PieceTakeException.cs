namespace tictactoe;
class PieceTakenException: Exception
{
    public PieceTakenException()
    {}
    public PieceTakenException(string message):base(message)
    {

    }
    public PieceTakenException(string message, Exception inner):base(message, inner)
    {
        
    }
}