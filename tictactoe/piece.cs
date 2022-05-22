namespace  tictactoe;

class Piece
{

    public State pieceState {get; set;}
    public Piece() 
    {
        pieceState = State.U;
    }
}