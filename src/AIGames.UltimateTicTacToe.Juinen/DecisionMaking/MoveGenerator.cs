using System;
using System.Collections.Generic;

namespace AIGames.UltimateTicTacToe.Juinen.DecisionMaking
{
	public class MoveGenerator
	{
		public IEnumerable<int[]> GetMoves(int[] meta, bool oToMove)
		{
			var active = meta[MetaBoard.LastMove];
			var options = oToMove ? TinyBoard.MovesO : TinyBoard.MovesX;

			if (active != 9)
			{
				var tiny = meta[active];
				var moveCount = TinyBoard.MoveCount[tiny];
				if (moveCount != 0)
				{
					for (var move = 0; move < 9; move ++)
					{
						var response = options[tiny, move];

						if (response == TinyBoard.Empty)
						{
							continue;
						}
						var copy = MetaBoard.Copy(meta);
						copy[active] = response;
						copy[MetaBoard.LastMove] = move;
						yield return copy;
					}
					yield break;
				}
			}
			for (var a = 0; a < 9; a++)
			{
				meta[MetaBoard.LastMove] = a;
				if (TinyBoard.MoveCount[meta[a]] != 0)
				{
					foreach (var response in GetMoves(meta, oToMove))
					{
						yield return response;
					}
				}
			}
		}
	}
}
