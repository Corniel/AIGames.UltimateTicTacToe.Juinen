using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AIGames.UltimateTicTacToe.Juinen.DecisionMaking
{
	[DebuggerDisplay("{DebuggerDisplay}")]
	public class XNode : Node, IComparable, IComparable<XNode>
	{
		public XNode(int[] meta, int depth, int active, int value)
			: base(meta, depth,active, value)
		{ }

		public List<ONode> Children { get; set; }
		public int Count { get { return Children.Count; } }

		public override int Apply(int depth, Node parent, int alpha, int beta, TimeSpan duration)
		{
			if (depth < Depth || Depth == 81 || duration > RootNode.Watch.Elapsed)
			{
				return Score;
			}

			if (Children == null)
			{
				Children = new List<ONode>(8);
				foreach (var response in Node.Generator.GetMoves(parent.Meta, true, Active))
				{
					var active = 9;
					var score = Node.Evaluator.Evaluate(response, true, active);
					var child = new ONode(response, Depth + 1, active, score);
					Children.Add(child);
				}
			}
			Score = Scores.XWins[Depth];
			var i = 0;
			var count = Count - 1;
			for (/**/; i <= count; i++)
			{
				var child = Children[i];
				var test = child.Apply(depth, this, alpha, beta, duration);
				if (test < Score)
				{
					Score = test;
					if (Score < beta)
					{
						beta = Score;
					}
				}
				else if (beta <= alpha)
				{
					break;
				}
			}
			Children.Sort();
			return Score;
		}

		public int CompareTo(object obj)
		{
			return CompareTo((XNode)obj);
		}

		public int CompareTo(XNode other)
		{
			return -Score.CompareTo(other.Score);
		}
	}
}