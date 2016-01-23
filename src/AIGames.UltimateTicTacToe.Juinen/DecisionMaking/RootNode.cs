using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames.UltimateTicTacToe.Juinen.DecisionMaking
{
	public class RootNode
	{
		public static Stopwatch Watch = new Stopwatch();
		public Node Root { get; set; }


		public byte GetMove(int[] meta, bool oToMove, int active, TimeSpan duration)
		{
			Watch.Restart();

			var score = Node.Evaluator.Evaluate(meta, oToMove, active);
			Root = oToMove ?
				(Node)new ONode(meta, 0, active, score) :
				(Node)new XNode(meta, 0, active, score);

			for(var depth = 1; depth < 81; depth++)
			{
				Root.Apply(depth, Root, Scores.InitialAlpha, Scores.InitialBeta, duration);
			}
			return 0;
		}
	}
}
