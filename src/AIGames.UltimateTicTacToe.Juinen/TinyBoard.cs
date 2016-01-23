using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames.UltimateTicTacToe.Juinen
{
	[System.Runtime.InteropServices.Guid("1D877B8C-5896-4864-B624-43CC2821C420")]
	public static class TinyBoard
	{

		/// <summary>Gets the moves for a tiny board.</summary>
		/// <remarks>
		/// var response = Moves[currentboard, move];
		/// </remarks>
		public static readonly ushort[,] Moves = new ushort[5478, 9];

		/// <summary>Gets the outcome of a tiny board.</summary>
		/// <remarks>
		/// var outcome = Moves[currentboard]; // 0, no outcome yet, 1 or 2.
		/// </remarks>
		public static readonly byte[] Outcomes = new byte[5478];

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


		public static ushort GetIndex(byte[] board)
		{
			var hash = GetHash(board);
			return HashToIndex[hash];
		}

		public static uint GetHash(byte[] board)
		{
			var hash = 0U;
			var shft = 0;

			for (var index = 0; index < 9; index++)
			{
#if DEBUG
				if (board[index] > 2) { throw new Exception("Invalid state."); }
#endif
				hash |= (uint)(board[index] << shft);
				shft += 2;
			}
			return hash;
		}

		private static readonly Dictionary<uint, ushort> HashToIndex = new Dictionary<uint, ushort>();

		static TinyBoard()
		{
			var board = new byte[9];
			HashToIndex[0] = 0;
			Generate(board, 0, true);
		}
		private static void Generate(byte[] board, ushort index, bool oToMove)
		{
			for (var move = 0; move < 9; move++)
			{
				var response = new byte[9];
				Array.Copy(board, response, 9);

				// If move is possible.
				if (response[move] == 0)
				{
					byte m = (byte)(oToMove ? 1 : 2);
					response[move] = m;
					
					var responseHash = TinyBoard.GetHash(response);
					var responseIndex = (ushort)HashToIndex.Count;
					HashToIndex[responseHash] = responseIndex;
					Moves[index, move] = responseIndex;

					// rows
					if ((response[0] == m && response[1] == m && response[2] == m) ||
					(response[3] == m && response[4] == m && response[5] == m) ||
					(response[6] == m && response[7] == m && response[8] == m) ||
					// cols
					(response[0] == m && response[3] == m && response[6] == m) ||
					(response[1] == m && response[4] == m && response[7] == m) ||
					(response[2] == m && response[5] == m && response[8] == m) ||
					// crosses
					(response[0] == m && response[4] == m && response[8] == m) ||
					(response[2] == m && response[4] == m && response[6] == m))
					{
						Outcomes[responseIndex] = m;
						continue;
					}

					Generate(response, responseIndex, !oToMove);
				}
			}
		}
	}
}
