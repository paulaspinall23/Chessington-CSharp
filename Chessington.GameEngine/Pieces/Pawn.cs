using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace Chessington.GameEngine.Pieces;

public class Pawn : Piece
{
    public Pawn(Player player)
        : base(player)
    {
    }

    public override IEnumerable<Square> GetAvailableMoves(Board board)
    {
        var currentSquare = board.FindPiece(this);
        var result = new List<Square>();
        
        if (Player == Player.White && currentSquare.Row > 0)
        {
            if (board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col)) == null)
            {
                if (currentSquare.Row == 6 && board.GetPiece(Square.At(currentSquare.Row - 2, currentSquare.Col)) == null)
                {
                    result.Add (Square.At(currentSquare.Row - 1, currentSquare.Col));
                    result.Add (Square.At(currentSquare.Row - 2, currentSquare.Col));
                }
                else
                {
                    result.Add (Square.At(currentSquare.Row - 1, currentSquare.Col));
                }
            }
        }
        else if (Player == Player.Black && currentSquare.Row < 7)
        {
            if (board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col)) == null)
            {
                if (currentSquare.Row == 1 && board.GetPiece(Square.At(currentSquare.Row + 2, currentSquare.Col)) == null)
                {
                    result.Add (Square.At(currentSquare.Row + 1, currentSquare.Col));
                    result.Add (Square.At(currentSquare.Row + 2, currentSquare.Col));
                }
                else
                {
                    result.Add (Square.At(currentSquare.Row + 1, currentSquare.Col));
                }
            }
        }
        return result;
    }
}