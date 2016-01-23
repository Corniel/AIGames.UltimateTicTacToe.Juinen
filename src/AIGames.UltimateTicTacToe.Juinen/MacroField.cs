using System;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public class MacroField
	{
		public const int Size = 3;

		public static readonly MacroField Empty = default(MacroField);

		public int[,] Board = new int[Size, Size];

		public MacroField(int[,] board)
		{
			this.Board = board;
		}

		/// <summary>
		/// Returns a copy of the MacroField
		/// </summary>
		public MacroField Copy()
		{
			var board = new int[Size, Size];
			for (int x = 0; x < Size; x++)
			{
				for (int y = 0; y < Size; y++)
				{
					board[x, y] = this.Board[x, y];
				}
			}
			return new MacroField(board);
		}

		public static MacroField Parse(String str)
		{
			var board = new int[Size, Size];
			int ix = 0;
			var chars = str.ToCharArray();
			for (int y = 0; y < Size; y++)
			{
				for (int x = 0; x < Size; x++)
				{
					if (chars[ix] == '-')
					{
						board[x, y] = -1;
						ix += 3;
					}
					else
					{
						board[x, y] = (int)chars[ix] - 48;
						ix += 2;
					}
				}
			}
			return new MacroField(board);
		}

	}
}
