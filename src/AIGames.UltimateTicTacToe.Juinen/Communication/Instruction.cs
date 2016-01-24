using System;
using System.Collections.Generic;
using System.IO;

namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public static class Instruction
	{
		public static IInstruction Parse(string line)
		{
			var splitted = line.Split(' ');

			switch (splitted[0])
			{
				case "action": return RequestMoveInstruction.Parse(splitted);
				case "settings": return SettingsInstruction.Parse(splitted);
				case "update": return UpdateInstruction.Parse(splitted);
			}
			return null;
		}

		/// <summary>Reads the instructions from the reader.</summary>
		public static IEnumerable<IInstruction> Read(TextReader reader)
		{
			if (reader == null) { throw new ArgumentNullException("reader"); }

			string line;
			while ((line = reader.ReadLine()) != null)
			{
				var instruction = Parse(line);
				if (instruction != null)
				{
					yield return instruction;
				}
			}
		}
	}
}
