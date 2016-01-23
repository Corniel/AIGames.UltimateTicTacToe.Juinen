using System.Linq;
using System.Text;

namespace AIGames.UltimateTicTacToe.Juinen
{
	[System.Runtime.InteropServices.Guid("1D877B8C-5896-4864-B624-43CC2821C420")]
	public static class TinyBoard
	{
		public const int Empty = 0;

		public static readonly int[] Finals1 = new int[]
		{
			0x00015,
			0x00540,
			0x15000,
			0x01041,
			0x04104,
			0x10410,
			0x10101,
			0x01110,
		};
		public static readonly int[] Finals2 = new int[]
		{
			0x0002A,
			0x00A80,
			0x2A000,
			0x02082,
			0x08208,
			0x20820,
			0x20202,
			0x02220,
		};

		public const int PossiblePositions = 18754;
		public const int PossibleInts = 1 << 18;

		/// <summary>Gets the moves for a tiny board.</summary>
		/// <remarks>
		/// var response = Moves[currentboard, move];
		/// </remarks>
		public static readonly int[,] MovesO = new int[PossibleInts, 9];
		public static readonly int[,] MovesX = new int[PossibleInts, 9];
		public static readonly int[] MoveCount = new int[PossibleInts];
		/// <summary>Gets the outcome of a tiny board.</summary>
		/// <remarks>
		/// var outcome = Moves[currentboard]; // 0, no outcome yet, 1 or 2.
		/// </remarks>
		public static readonly byte[] Outcomes = new byte[PossibleInts];

		public static int ToTiny(byte[] board)
		{
			var tiny = 0;
			for (var index = 0; index < 9; index++)
			{
				var shft = index << 1;
				tiny |= ((int)board[index]) << shft;
			}
			return tiny;
		}

		public static int ToTiny(int[] board)
		{
			var tiny = 0;
			for (var index = 0; index < 9; index++)
			{
				var shft = index << 1;
				tiny |= ((int)board[index]) << shft;
			}
			return tiny;
		}

		public static string ToString(byte[] board)
		{
			var sb = new StringBuilder();
			for (var index = 0; index < 9;index++)
			{
				switch (board[index])
				{
					case 1: sb.Append('O'); break;
					case 2: sb.Append('X'); break;
					default: sb.Append('_'); break;
				}
				if (index == 2 || index == 5) { sb.Append('|'); }

			}
			return sb.ToString();
		}
		public static string ToString(int board)
		{
			var bytes = new byte[9];

			var mask = board;

			for (var i = 0; i < 9; i++)
			{
				bytes[i] = (byte)(mask & 3);
				mask >>= 2;
			}
			return ToString(bytes);
		}
		static TinyBoard()
		{
			for (var board = 0; board < PossibleInts; board++)
			{
				if(!IsValid(board))
				{
					continue;
				}
				if (Finals1.Any(mask => (mask & board) == mask))
				{
					Outcomes[board] = 1;
				}
				else if (Finals2.Any(mask => (mask & board) == mask))
				{
					Outcomes[board] = 2;
				}
				else
				{
					for (var move = 0; move < 9; move++)
					{
						var shft = move << 1;
						if ((board & (3 << shft)) == 0)
						{
							MoveCount[board]++;
							MovesO[board, move] = board | (1 << shft);
							MovesX[board, move] = board | (2 << shft);
						}
					}
				}
			}
		}

		public static bool IsValid(int board)
		{
			var mask = board;
			for (var i = 0; i < 9; i++)
			{
				if ((mask & 3) == 3)
				{
					return false;
				}
				mask <<= 2;
			}
			return true;
		}
	}
}
