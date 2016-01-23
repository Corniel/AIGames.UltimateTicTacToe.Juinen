using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public partial class Field //: IEquatable<Field>, IComparable<Field>
	{
		public const int Size = 9;

		public static readonly Field Empty = default(Field);

		public int[,] Board = new int[Size, Size];

		public Field(int[,] board)
		{
			this.Board = board;
		}

		public static Field Parse(String str)
		{
			var board = new int[Size, Size];
			int ix = 0;
			var chars = str.ToCharArray();
			for (int y = 0; y < Size; y++)
			{
				for (int x = 0; x < Size; x++)
				{
					board[x, y] = (int)chars[ix] - 48;
					ix += 2;
				}
			}
			return new Field(board);
		}


		/// <summary>Gets the hash code for the field.</summary>
		/// <remarks>
		/// The hash per color is stored at the end of their ulong value.
		/// </remarks>
		public override int GetHashCode()
		{
			unchecked
			{
				//TODO
				var hash = 0;
				return (int)hash;
			}
		}

		//public override bool Equals(object obj) { return Equals((Field)obj); }
		//public bool Equals(Field other)
		//{
		//	return red == other.red && yel == other.yel;
		//}
		//public static bool operator ==(Field l, Field r) { return l.Equals(r); }
		//public static bool operator !=(Field l, Field r) { return !(l == r); }

		//public int CompareTo(Field other)
		//{
		//	var c = red.CompareTo(other.red);
		//	if (c == 0)
		//	{
		//		c = yel.CompareTo(other.yel);
		//	}
		//	return c;
		//}
		//public static bool operator <(Field l, Field r) { return l.CompareTo(r) < 0; }
		//public static bool operator >(Field l, Field r) { return l.CompareTo(r) > 0; }
		//public static bool operator <=(Field l, Field r) { return l.CompareTo(r) <= 0; }
		//public static bool operator >=(Field l, Field r) { return l.CompareTo(r) >= 0; }

		//public override string ToString()
		//{
		//	var sb = new StringBuilder((7 + 6) * 6 + 6);

		//	for (var row = 5; row >= 0; row--)
		//	{
		//		var r =( red & Mask) >> (row << 3);
		//		var y = (yel & Mask) >> (row << 3);

		//		for (var col = 6; col >= 0; col--)
		//		{
		//			if ((r & (1UL << col)) != 0)
		//			{
		//				sb.Append('1');
		//			}
		//			else if ((y & (1UL << col)) != 0)
		//			{
		//				sb.Append('2');
		//			}
		//			else { sb.Append('0'); }

		//			if (col > 0)
		//			{
		//				sb.Append(',');
		//			}
		//		}
		//		if (row > 0)
		//		{
		//			sb.Append(';');
		//		}
		//	}

		//	return sb.ToString();
		//}

		///// <summary>Debugger helper to read the field.</summary>
		//private string[] Rows
		//{
		//	get
		//	{
		//		return ToString()
		//			.Split(';')
		//			.Select(row => row.Replace(",", ""))
		//			.ToArray();
		//	}
		//}


		private static readonly Dictionary<string, ulong> ParseRows = GetParseRows();
		public static Dictionary<string, ulong> GetParseRows()
		{
			var dict = new Dictionary<string, ulong>();
			for (var i = 0; i < 128; i++)
			{
				var key = "000000" + Convert.ToString(i, 2);
				key = key.Substring(key.Length - 7);
				dict[key] = (ulong)i;
			}
			return dict;
		}
	}
}
