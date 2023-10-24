﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces;

public class Rook : Piece
{
    public Rook(Player player)
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
            Square.At(1, 0), //right
            Square.At(-1, 0), //left 
            Square.At(0, -1), //up
            Square.At(0, 1)  //down
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