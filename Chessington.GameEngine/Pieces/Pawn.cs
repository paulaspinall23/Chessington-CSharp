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
            result.Add (Square.At(currentSquare.Row - 1, 0));
        }
        else
        {
            result.Add (Square.At(currentSquare.Row + 1, 0));
        }
        return result;
    }
}