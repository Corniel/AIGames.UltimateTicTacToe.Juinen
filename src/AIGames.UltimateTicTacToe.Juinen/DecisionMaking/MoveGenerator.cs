using System;
using System.Collections.Generic;

namespace AIGames.UltimateTicTacToe.Juinen.DecisionMaking
{
	public class MoveGenerator
	{
		public IEnumerable<int[]> GetMoves(int[] macro, bool oToMove, int active)
		{
			var options = oToMove ? TinyBoard.MovesO : TinyBoard.MovesX;

			if (active != 9)
			{
				var tiny = macro[active];
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
						var copy = new int[10];
						Array.Copy(macro, copy, 10);
						copy[active] = response;
						yield return copy;
					}
					yield break;
				}
			}
			for (var a = 0; a < 9; a++)
			{
				if (TinyBoard.MoveCount[macro[a]] != 0)
				{
					foreach (var response in GetMoves(macro, oToMove, a))
					{
						yield return response;
					}
				}
			}
		}
	}
}
