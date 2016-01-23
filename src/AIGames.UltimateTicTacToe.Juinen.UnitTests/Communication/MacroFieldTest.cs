using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames.UltimateTicTacToe.Juinen.UnitTests.Communication
{
	[TestFixture]
	public class MacroFieldTest
	{
		[Test]
		public void Parse_Test()
		{
			var field = MacroField.Parse("-1,2,0,0,0,0,0,0,0");
			Assert.AreEqual(-1, field.Board[0, 0]);
			Assert.AreEqual(2, field.Board[1, 0]);
			Assert.AreEqual(0, field.Board[0, 1]);
		}
	}
}
