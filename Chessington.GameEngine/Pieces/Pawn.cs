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
        var moves = 1;
        var startingPosition = 1;
        var lastRow = 7;
        if (Player == Player.White)
        {
            moves = -1;
            startingPosition = 6;
            lastRow = 0; 
        }
        var captureDirections = new List<Square>()
        {
            Square.At(1, 1),
            Square.At(1, -1), 
        };
        var currentSquare = board.FindPiece(this);
        var result = new List<Square>();
        
        if (currentSquare.Row != lastRow && board.GetPiece(Square.At(currentSquare.Row + moves, currentSquare.Col)) == null)
        {
            if (currentSquare.Row == startingPosition && board.GetPiece(Square.At(currentSquare.Row + (moves*2), currentSquare.Col)) == null)
            {
                result.Add (Square.At(currentSquare.Row + moves, currentSquare.Col));
                result.Add (Square.At(currentSquare.Row + (moves*2), currentSquare.Col));
            }
            else
            {
                result.Add (Square.At(currentSquare.Row + moves, currentSquare.Col));
            }
        }
        foreach (var captureDirection in captureDirections)
        {
            var square = Square.At(currentSquare.Row + (captureDirection.Row * moves), currentSquare.Col + (captureDirection.Col * moves));
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
    return result;
    }
}