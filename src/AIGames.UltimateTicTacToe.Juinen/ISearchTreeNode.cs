using System;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public interface ISearchTreeNode
	{
		Field Field { get; }
		byte Depth { get;  }
		int Score { get; }

		void Add(MoveCandidates candidates);
		int Apply(byte depth, ISearchTree tree, int alpha, int beta);
	}
}
