﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public class SearchTree : ISearchTree
	{
		public const int MaximumDepth = 43;

		public SearchTree()
		{
			Sw = new Stopwatch();
			Logger = new StringBuilder();
			Generator = new MoveGenerator();
			Rnd = new Random();
		}

		public MoveGenerator Generator { get; set; }
		public bool TimeLeft { get { return Sw.Elapsed < Max; } }
		protected TimeSpan Max { get; set; }
		protected Random Rnd { get; set; }

		public Stopwatch Sw { get; protected set; }
		public StringBuilder Logger { get; protected set; }

		public ISearchTreeNode Root { get; set; }

		private byte depth = 1;

		public byte GetMove(Field field, TimeSpan min, TimeSpan max)
		{
			byte ply = (byte)(field.Count + 1);
			if (depth <= ply) { depth = (byte)(ply + 1); }
			var redToMove = (ply & 1) == 1;

			if (depth > MaximumDepth) { depth = MaximumDepth; }

			Sw.Restart();
			Logger.Clear();
			Max = max;

			var candidates = new MoveCandidates(redToMove);
			candidates.Add(field, ply, this);
			var move = candidates.GetMove();
			
			Root = GetNode(field, ply);
			Root.Add(candidates);

			for (/**/; depth <= MaximumDepth; depth++)
			{
				Root.Apply(depth, this, Scores.InitialAlpha, Scores.InitialBeta);

				move = candidates.GetMove();

				var log = new PlyLog(ply, move, Root.Score, depth, Sw.Elapsed);
				Logger.Append(log).AppendLine();

				// Don't spoil time.
				if (Sw.Elapsed > min || !TimeLeft) { break; }
			}
			return move;
		}

		public void Clear(int round)
		{
			for (var i = 1; i < round ; i++)
			{
				tree[i].Clear();
				trans[i] = 0;
			}
		}

		/// <summary>Gets a node with the field to search for.</summary>
		/// <param name="search">
		/// The field to search for.
		/// </param>
		/// <param name="ply">
		/// The current ply. This should be 1 higher than the discs at the field.
		/// </param>
		/// <returns>
		/// An existing node if already existing, otherwise a new one.
		/// </returns>
		public ISearchTreeNode GetNode(Field search, byte ply)
		{
			ISearchTreeNode node;

			var redToMove = (ply & 1) == 1;

			if (!tree[ply].TryGetValue(search, out node))
			{
				// Losses and draws are already added, so the missing a wins.
				if (ply == 9)
				{
					if (search.IsScoreYellow())
					{
						node = new SearchTreeEndNode(9, Scores.YelWins[9]);
					}
					else
					{
						node = new SearchTreeBookNode(search, 9, Scores.RedWin >> 3);
					}
				}
				else
				{
					var score = Evaluator.GetScore(search, ply);

					// If the node is final for the other color, no need to search deeper.
					if ((!redToMove && score == Scores.RedWins[ply -1]) ||
						(redToMove && score == Scores.YelWins[ply -1]))
					{
						node = new SearchTreeEndNode(ply, score);
					}
					// Game is done.
					else if (ply == MaximumDepth)
					{
						node = new SearchTreeEndNode(MaximumDepth, 0);
					}
					else if (redToMove)
					{
						node = new SearchTreeRedNode(search, ply, score);
					}
					else
					{
						node = new SearchTreeYellowNode(search, ply, score);
					}
					tree[ply][search] = node;
				}
			}
			else
			{
				trans[ply]++;
			}
			return node;
		}

		public Field[] GetMoves(Field field, bool IsRed)
		{
			return Generator.GetMoves(field, IsRed);
		}

		private Dictionary<Field, ISearchTreeNode>[] tree = GetTree();
		private int[] trans = new int[MaximumDepth + 1];
		private static Dictionary<Field, ISearchTreeNode>[] GetTree()
		{
			var tree = new Dictionary<Field, ISearchTreeNode>[MaximumDepth + 1];
			for (var ply = 0; ply <= MaximumDepth; ply++)
			{
				tree[ply] = new Dictionary<Field, ISearchTreeNode>();
			}
			return tree;
		}
		public int Transpositions { get { return trans.Sum(); } }
		public int NodeCount { get { return tree.Sum(item => item.Count); } }
		public int Count { get { return NodeCount + Transpositions; } }

		public void Initialize(IEnumerable<ISearchTreeNode> nodes)
		{
			foreach (var node in nodes)
			{
				var lookup = tree[node.Depth];
				lookup[node.Field] = node;
			}
		}
	}
}
