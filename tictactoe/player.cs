namespace tictactoe;

class Player
{
    public string Name {get;set;}
    public char playerLetter {get; set;}

    public Player(string pName,char pPlayerLetter)
    {
        this.Name = pName == "" ? Convert.ToString(playerLetter) : pName;
        playerLetter = pPlayerLetter;
    }
}