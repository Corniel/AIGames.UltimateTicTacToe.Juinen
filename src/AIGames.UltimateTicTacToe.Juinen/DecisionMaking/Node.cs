using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames.UltimateTicTacToe.Juinen.DecisionMaking
{
	public abstract class Node 
	{
		internal static readonly MoveGenerator Generator = new MoveGenerator();

		protected Node(int[] macro, int depth, int score)
		{
			Macro = macro;
			Depth = depth;
			Score = score;
		}
		public int[] Macro { get; private set; }
		public int Depth { get; private set; }

		public int Score { get; protected set; }

		public int Active { get; protected set; }

		public abstract int Apply(int depth, Node parent, int alpha, int beta);
	}
}
