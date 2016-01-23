namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public static class UpdateInstruction
	{
		internal static IInstruction Parse(string[] splited)
		{
			switch (splited[1])
			{
				case "game": return UpdateGameInstruction.Parse(splited);
			}
			return null;
		}
	}
}
