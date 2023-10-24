using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces;

public class Bishop : Piece
{
    public Bishop(Player player)
        : base(player)
    {
    }

    public override IEnumerable<Square> GetAvailableMoves(Board board)
    {
        var currentSquare = board.FindPiece(this);
        var result = new List<Square>();

        //directions
        var directions = new List<Square>()
        {
            Square.At(-1, 1), //top right
            Square.At(-1, -1), //top left 
            Square.At(1, 1), //bottom right
            Square.At(1, -1)  //bottom left
        };
        foreach (var direction in directions)
        {
            for (var i = 1; i < 8; i++)
            {
                //setup square = square.At, i * direction
                var square = Square.At(currentSquare.Row + i*direction.Row, currentSquare.Col + i*direction.Col);
            
                //if outside of board = break
                if (square.Row < 0 || square.Row > 7 || square.Col < 0 || square.Col > 7)
                {
                    break;
                }

                //piece on square = get piece
                var pieceOnSquare = board.GetPiece(square);

                // if the piece on square = null, add to result
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
                    break;
                }   
            }
        }
        return result;
    }
}