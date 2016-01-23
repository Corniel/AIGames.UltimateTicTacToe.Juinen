using System;
using System.Diagnostics;

namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public struct MacroBoardInstruction : IInstruction
	{
		public MacroBoardInstruction(String field) 
		{
			str = field;
			m_Field = MacroField.Parse(field); 
		}

		public MacroField MacroBoard { get { return m_Field; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly MacroField m_Field;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly String str;

		public override string ToString() 
		{
			return String.Format("update macroboard field", str);
		}

		internal static IInstruction Parse(string[] splited)
		{
			return new MacroBoardInstruction(splited[3]);
		}
	}
}
