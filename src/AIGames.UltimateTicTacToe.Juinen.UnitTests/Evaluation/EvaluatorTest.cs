using AIGames.UltimateTicTacToe.Juinen.Communication;
using AIGames.UltimateTicTacToe.Juinen.Evaluation;
using NUnit.Framework;

namespace AIGames.UltimateTicTacToe.Juinen.UnitTests.Evaluation
{
	[TestFixture]
	public class EvaluatorTest
	{
		[Test]
		public void Evaluate_Test()
		{
			var boards = EmptyBoard;
			var playableBoards = PlayableEmptyBoard;
			var score = new Evaluator().Evaluate(boards, playableBoards, PlayerName.Player1);
			Assert.AreEqual(80, score);
		}

		private static int[][] EmptyBoard
		{
			get
			{
				return new int[][] { 
					new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
					new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
				};
			}
		}

		private static bool[] PlayableEmptyBoard
		{
			get
			{
				return new bool[] {
					true, true, true,
					true, true, true, 
					true, true, true,
				};
			}
		}
}
}
