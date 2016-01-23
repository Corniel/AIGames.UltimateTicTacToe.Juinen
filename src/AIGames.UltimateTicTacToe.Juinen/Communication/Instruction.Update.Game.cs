namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public static class UpdateGameInstruction
	{
		internal static IInstruction Parse(string[] splitted)
		{
			switch (splitted[2])
			{
				case "round": return RoundInstruction.Parse(splitted);
				case "field": return FieldInstruction.Parse(splitted);
				case "macroboard": return MacroBoardInstruction.Parse(splitted);
			}
			return null;
		}
	}
}
