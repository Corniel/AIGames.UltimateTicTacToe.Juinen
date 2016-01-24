﻿using System;
using System.Diagnostics;

namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public struct FieldInstruction : IInstruction
	{
		public FieldInstruction(String field) 
		{
			str = field;
			m_Field = Field.Parse(field); 
		}

		public Field Field { get { return m_Field; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Field m_Field;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly String str;

		public override string ToString() 
		{
			return String.Format("update game field", str);
		}

		internal static IInstruction Parse(string[] splited)
		{
			return new FieldInstruction(splited[3]);
		}
	}
}
