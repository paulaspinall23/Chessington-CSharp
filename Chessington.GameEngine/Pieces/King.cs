using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces;

public class King : Piece
{
    public King(Player player)
        : base(player)
    {
    }

    public override IEnumerable<Square> GetAvailableMoves(Board board)
    {
        var currentSquare = board.FindPiece(this);
        var result = new List<Square>();

        var directions = new List<Square>()
        {
            Square.At(1, 0), //right
            Square.At(-1, 0), //left 
            Square.At(0, -1), //up
            Square.At(0, 1),  //down
            Square.At(-1, 1), //top right
            Square.At(-1, -1), //top left 
            Square.At(1, 1), //bottom right
            Square.At(1, -1)  //bottom left
        };
        foreach (var direction in directions)
        {
            var square = Square.At(currentSquare.Row + direction.Row, currentSquare.Col + direction.Col);
        
            if (square.Row < 0 || square.Row > 7 || square.Col < 0 || square.Col > 7)
            {
                continue;
            }

            var pieceOnSquare = board.GetPiece(square);

            if (pieceOnSquare == null)
            {
                result.Add(square);
            }
            else
            {
                if (pieceOnSquare.Player != this.Player)
                {
                    result.Add(square);
                }
            }   
        }
        return result;
    }
}