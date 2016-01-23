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


		public int[] GetMove(int[] meta, bool oToMove, TimeSpan duration)
		{
			Watch.Restart();

			var score = Node.Evaluator.Evaluate(meta, oToMove);
			Root = oToMove ?
				(Node)new ONode(meta, 0, score) :
				(Node)new XNode(meta, 0, score);

			for(var depth = 1; depth < 81; depth++)
			{
				Root.Apply(depth, Root, Scores.InitialAlpha, Scores.InitialBeta, duration);
			}

			var tiny = 0;
			var move = Root.Best.Meta[MetaBoard.LastMove];
			for (var i = 0; i < 9; i++)
			{
				if (Root.Meta[i] != Root.Best.Meta[i])
				{
					tiny = i;
					break;
				}
			}
			return new int[] { tiny, move};
		}
	}
}
