using System;
using System.Globalization;

namespace AIGames.UltimateTicTacToe.Juinen.DecisionMaking
{
	public static class Scores
	{
		public const int InitialAlpha = int.MinValue;
		public const int InitialBeta = int.MaxValue;

		public const int MaximumDepth = 82;

		public const int Draw = 0;
		private const int O = 1000000;
		private const int X = -1000000;

		public static readonly int[] OWins = GetOWins();
		public static readonly int[] XWins = GetXWins();

		public const int OWin = O - MaximumDepth;
		public const int XWin = X + MaximumDepth - 1;

		private static int[] GetOWins()
		{
			var sc = new int[MaximumDepth + 1];

			for (var ply = 0; ply < sc.Length; ply++)
			{
				sc[ply] = O - ply;
			}
			return sc;

		}
		private static int[] GetXWins()
		{
			var sc = new int[MaximumDepth];

			for (var ply = 0; ply < sc.Length; ply++)
			{
				sc[ply] = X + ply;
			}
			return sc;
		}

		/// <summary>Returns the requiO ply for winning.</summary>
		/// <returns>
		/// returns 255 if no win could be given else the ply requiO for winning.
		/// </returns>
		public static byte GetPlyToWinning(int score)
		{
			if (score >= OWin)
			{
				return (byte)(O - score);
			}
			if (score <= XWin)
			{
				return (byte)(score - X);
			}
			return Byte.MaxValue;
		}

		/// <summary>Return true if the score indicates a winning (or losing) position.</summary>
		public static bool IsWinning(int score)
		{
			return score >= OWin || score <= XWin;
		}

		public static string GetFormatted(int score)
		{
			if (score >= Scores.OWin)
			{
				var ply = (Scores.O - score);
				return String.Format(CultureInfo.InvariantCulture, "+oo {0}", ply);
			}
			if (score <= Scores.XWin)
			{
				var ply = (score - Scores.X);
				return String.Format(CultureInfo.InvariantCulture, "-oo {0}", ply);
			}

			var str = "";
			if (score > 0) { str = "+"; }
			else if (score == 0) { str = "="; }
			str += (score / 100m).ToString("0.00", CultureInfo.InvariantCulture);
			return str;
		}
	}
}
