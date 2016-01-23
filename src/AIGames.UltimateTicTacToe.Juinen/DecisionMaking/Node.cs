using AIGames.UltimateTicTacToe.Juinen.Evaluation;
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
		internal static readonly Evaluator Evaluator = new Evaluator();

		protected Node(int[] meta, int depth, int score)
		{
			Meta = meta;
			Depth = depth;
			Score = score;
		}
		public int[] Meta { get; private set; }
		public int Depth { get; private set; }
		public int Score { get; protected set; }


		public abstract int Apply(int depth, Node parent, int alpha, int beta, TimeSpan duration);
	}
}
