﻿using System;
using System.Collections.Generic;

namespace AIGames.UltimateTicTacToe.Juinen.DecisionMaking
{
	public class ONode : Node, IComparable, IComparable<ONode>
	{
		public ONode(int[] meta, int depth, int value) 
			: base(meta, depth, value) { }

		public List<XNode> Children { get; set; }
		public int Count {get { return Children.Count; }}

		public override int Apply(int depth, Node parent, int alpha, int beta, TimeSpan duration)
		{
			if (depth < Depth || Depth == 81 || duration > RootNode.Watch.Elapsed)
			{
				return Score;
			}

			if (Children == null)
			{
				Children = new List<XNode>(8);
				foreach (var response in Node.Generator.GetMoves(parent.Meta, true))
				{
					var score = Node.Evaluator.Evaluate(response, false);
					var child = new XNode(response, Depth + 1, score);
					Children.Add(child);
				}
			}

			Score = Scores.OWins[Depth];
			var i = 0;
			var count = Count - 1;
			for (/**/; i <= count; i++)
			{
				var child = Children[i];
				var test = child.Apply(depth, this, alpha, beta, duration);
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
			Children.Sort();
			return Score;
		}

		public int CompareTo(object obj)
		{
			return CompareTo((ONode)obj);
		}

		public int CompareTo(ONode other)
		{
			return Score.CompareTo(other.Score);
		}
	}
}
