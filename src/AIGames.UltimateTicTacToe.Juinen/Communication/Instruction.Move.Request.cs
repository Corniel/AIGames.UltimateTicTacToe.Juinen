using System;
using System.Diagnostics;

namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public struct RequestMoveInstruction : IInstruction
	{
		public RequestMoveInstruction(TimeSpan time) { m_Time = time; }

		public TimeSpan Time { get { return m_Time; } }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TimeSpan m_Time;

		public override string ToString()
		{
			return String.Format("action move {0:0}", Time.TotalMilliseconds);
		}

		internal static IInstruction Parse(string[] splitted)
		{
			int ms;
			if (splitted[1] == "move" && splitted.Length == 3 && Int32.TryParse(splitted[2], out ms))
			{
				return new RequestMoveInstruction(TimeSpan.FromMilliseconds(ms));
			}
			return null;
		}
	}
}
