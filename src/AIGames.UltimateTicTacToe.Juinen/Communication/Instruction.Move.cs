using System;

namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public class MoveInstruction : IInstruction
	{
		public MoveInstruction(int x, int y)
		{
			X = x;
			Y = y;
		}

		public readonly int X;
		public readonly int Y;

		public override string ToString() { return string.Format("place_move {0} {1}", X, Y); }
	}
}
