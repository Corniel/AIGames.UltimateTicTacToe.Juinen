using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames.UltimateTicTacToe.Juinen.UnitTests
{
	[TestFixture]
	public class TinyBoardTest
	{
		[Test]
		public void Finals_1And2_()
		{
			var r0 = new byte[] { 1, 1, 1, 0, 0, 0, 0, 0, 0 };
			var r1 = new byte[] { 0, 0, 0, 1, 1, 1, 0, 0, 0 };
			var r2 = new byte[] { 0, 0, 0, 0, 0, 0, 1, 1, 1 };

			var c0 = new byte[] { 1, 0, 0, 1, 0, 0, 1, 0, 0 };
			var c1 = new byte[] { 0, 1, 0, 0, 1, 0, 0, 1, 0 };
			var c2 = new byte[] { 0, 0, 1, 0, 0, 1, 0, 0, 1 };

			var x0 = new byte[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
			var x1 = new byte[] { 0, 0, 1, 0, 1, 0, 1, 0, 0 };

			var all = new byte[][] { r0, r1, r2, c0, c1, c2, x0, x1 };

			foreach (var board in all)
			{
				Console.WriteLine(TinyBoard.ToTiny(board).ToString("X2"));
			}
			foreach (var board in all)
			{
				Console.WriteLine((TinyBoard.ToTiny(board) * 2).ToString("X2"));
			}
		}

		[Test]
		public void GetMove_SimpleBoard_()
		{
			var board = new byte[] {
				0, 0, 0,
				0, 1, 0,
				0, 0, 0
			};

			var tiny = TinyBoard.ToTiny(board);


			var actO = GetResponses(TinyBoard.MovesO, tiny);
			var actX = GetResponses(TinyBoard.MovesX, tiny);

			var expO = new string[]
			{
				"O__|_O_|___",
				"_O_|_O_|___",
				"__O|_O_|___",
				"___|OO_|___",
				"___|___|___",
				"___|_OO|___",
				"___|_O_|O__",
				"___|_O_|_O_",
				"___|_O_|__O",
			};
			var expX = new string[]
			{
				"X__|_O_|___",
				"_X_|_O_|___",
				"__X|_O_|___",
				"___|XO_|___",
				"___|___|___",
				"___|_OX|___",
				"___|_O_|X__",
				"___|_O_|_X_",
				"___|_O_|__X",
			};

			foreach (var elm in actO)
			{
				Console.WriteLine(elm);
			}
			foreach (var elm in actX)
			{
				Console.WriteLine(elm);
			}

			CollectionAssert.AreEqual(expO, actO);
			CollectionAssert.AreEqual(expX, actX);
		}

		[Test]
		public void Outcome_SimpleBoard_0()
		{
			var board = new byte[] {
				0, 0, 0,
				0, 1, 0,
				0, 0, 0
			};

			var tiny = TinyBoard.ToTiny(board);

			Assert.AreEqual(0, TinyBoard.Outcomes[tiny]);
		}

		[Test]
		public void Outcome_SimpleBoard_1()
		{
			var board = new byte[] {
				1, 2, 0,
				0, 1, 0,
				0, 0, 1
			};

			var tiny = TinyBoard.ToTiny(board);

			Assert.AreEqual(1, TinyBoard.Outcomes[tiny]);
		}

		[Test]
		public void Outcome_SimpleBoard_2()
		{
			var board = new byte[] {
				1, 2, 0,
				2, 2, 2,
				0, 0, 1
			};

			var tiny = TinyBoard.ToTiny(board);

			Assert.AreEqual(2, TinyBoard.Outcomes[tiny]);
		}


		private static string[] GetResponses(int[,] moves, int tiny)
		{
			var responses = new string[9];
			for (var move = 0; move < 9; move++)
			{
				responses[move] = TinyBoard.ToString(moves[tiny, move]);
			}
			return responses;
		}
	}
}