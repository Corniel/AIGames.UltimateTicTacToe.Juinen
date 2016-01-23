using NUnit.Framework;

namespace AIGames.UltimateTicTacToe.Juinen.UnitTests.Communication
{
	[TestFixture]
	public class FieldTest
	{
		[Test]
		public void ParseTest()
		{
			var input = " 0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
			var field = Field.Parse(input);
			Assert.IsNotNull(field.Board);
			Assert.AreEqual(1, field.Board[0, 1]);
			Assert.AreEqual(2, field.Board[3, 3]);
		}
	}
}
