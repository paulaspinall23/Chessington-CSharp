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
        if (Player == Player.White)
        {
            if (currentSquare == Square.At(7, 5))
            {
                result.Add (Square.At(currentSquare.Row - 2, currentSquare.Col));
            }
            else
            {
                result.Add (Square.At(currentSquare.Row - 1, currentSquare.Col));
            }
        }
        else
        {
            if (currentSquare == Square.At(1, 3))
            {
                result.Add (Square.At(currentSquare.Row + 2, currentSquare.Col));
            }
            else
            {
                result.Add (Square.At(currentSquare.Row + 1, currentSquare.Col));
            }
        }
        return result;
    }
}