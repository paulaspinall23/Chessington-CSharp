﻿using System.Collections.Generic;
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
        for (var i = 0; i < 8; i++)
            result.Add(Square.At(currentSquare.Row, i));

        for (var i = 0; i < 8; i++)
            result.Add(Square.At(i, currentSquare.Col));

        result.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));
        return result;
    }
}