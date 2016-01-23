using System;

namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public class MoveInstruction : IInstruction
	{
		public MoveInstruction(int index)
		{
			X = index % 9;
			Y = index / 9;
		}

		private readonly int X;
		private readonly int Y;

		public override string ToString() { return string.Format("place_move {0} {1}", X, Y); }
	}
}
