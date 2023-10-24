using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces;

public class Knight : Piece
{
    public Knight(Player player)
        : base(player)
    {
    }

    public override IEnumerable<Square> GetAvailableMoves(Board board)
    {
        var currentSquare = board.FindPiece(this);
        var result = new List<Square>();

        var directions = new List<Square>()
        {
            Square.At(-1, -2), //up and left
            Square.At(1, -2), //up and right 
            Square.At(-2, -1), //left and up
            Square.At(-2, 1),  //left and down
            Square.At(2, -1), //right and up
            Square.At(2, 1), //right and down
            Square.At(-1, 2), //down and left
            Square.At(1, 2)  //down and right
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