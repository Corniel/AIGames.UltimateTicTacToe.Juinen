using System;
using System.Diagnostics.CodeAnalysis;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public class Program
	{
		[ExcludeFromCodeCoverage]
		public static void Main(string[] args)
		{
			Communication.ConsolePlatform.Run(new Juinen.JuinenBot());
		}
	}
}
