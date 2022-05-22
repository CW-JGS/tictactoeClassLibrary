namespace tictactoe;

class UserInputException: Exception
{
    public UserInputException()
    {

    }
    public UserInputException(string msg):base(msg) 
    {

    }
    public UserInputException(string msg, Exception inner):base(msg, inner)
    {
        
    }
}