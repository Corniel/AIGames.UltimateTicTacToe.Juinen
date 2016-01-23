using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public static class MetaBoard
	{
		public const int Length = 11;
		public const int CopyLength = 10;
		public const int MacroIndex = 9;
		public const int LastMove = 10;

		public static int[] Copy(int[] meta)
		{
			var copy = new int[Length];
			Array.Copy(meta, copy, CopyLength);
			return copy;
		}
	}
}
