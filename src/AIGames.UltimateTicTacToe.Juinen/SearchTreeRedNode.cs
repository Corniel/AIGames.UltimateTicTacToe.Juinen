﻿using System;
using System.Linq;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public class SearchTreeRedNode : SearchTreeSubNode
	{
		public SearchTreeRedNode(Field field, byte depth, int value) : base(field, depth, value) { }

		protected override int ApplyChildren(byte depth, ISearchTree tree, int alpha, int beta)
		{
			Score = Scores.YelWins[Depth];
			var i = 0;
			var count = Count - 1;
			for (/**/; i <= count; i++)
			{
				var child = Children[i];
				var test = child.Apply(depth, tree, alpha, beta);
				if (test > Score)
				{
					Score = test;
					if (Score > alpha)
					{
						alpha = Score;
					}
				}
				else if (beta <= alpha)
				{
					break;
				}
			}
			if (i > count) { i = count; }
			for (/**/; i >= 0; i--)
			{
				var val = Children[i].Score;

				for (var swap = i + 1; swap <= count; swap++)
				{
					var other = Children[swap];

					if (val >= other.Score) { break; }
					Children[swap] = Children[swap - 1];
					Children[swap - 1] = other;
				}
			}
			return Score;
		}
	}
}
