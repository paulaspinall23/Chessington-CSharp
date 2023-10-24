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
        var directions = new List<Square>()
        {
            Square.At(1, 1),
            Square.At(1, -1), 
        };
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
            foreach (var direction in directions)
            {
                var square = Square.At(currentSquare.Row - direction.Row, currentSquare.Col - direction.Col);
                if (square.Row < 0 || square.Row > 7 || square.Col < 0 || square.Col > 7)
                {
                    break;
                }
                var pieceOnSquare = board.GetPiece(square);
                
                if (pieceOnSquare != null && pieceOnSquare.Player != this.Player)
                {
                    result.Add(square);
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
            foreach (var direction in directions)
            {
                var square = Square.At(currentSquare.Row + direction.Row, currentSquare.Col + direction.Col);
                if (square.Row < 0 || square.Row > 7 || square.Col < 0 || square.Col > 7)
                {
                    break;
                }
                var pieceOnSquare = board.GetPiece(square);
                
                if (pieceOnSquare != null && pieceOnSquare.Player != this.Player)
                {
                    result.Add(square);
                }
            }
        }
        return result;
    }
}