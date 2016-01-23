using AIGames.UltimateTicTacToe.Juinen.Communication;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames.UltimateTicTacToe.Juinen.UnitTests.Regression
{
	[TestFixture]
	public class RegressionTests
	{
		/// <summary>
		/// TikkieTakkie game version 0: invalid move in round 13
		/// </summary>
		[Test]
		public void Regression_56a38ed1c1d43a1590b9280d_Round13()
		{
			var state = CreateGameState("2,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0",
				"0,0,0,0,-1,0,0,0,0");
			var bot = CreateBot();
			bot.Update(state);
			var response = bot.GetResponse(TheTimespan);
			AssertMove(3, 4, response);
		}

		private void AssertMove(int x, int y, BotResponse response)
		{
			string expected = string.Format("({0},{1})", x, y);
			string actual = string.Format("({0},{1})", response.Move.X, response.Move.Y);
			Assert.AreEqual(expected, actual);
		}

		private static TimeSpan TheTimespan = TimeSpan.FromSeconds(10);

		private IBot CreateBot(PlayerName player = PlayerName.Player1)
		{
			IBot bot = new JuinenBot();
			var settings = new Settings() { YourBot = player };
			bot.ApplySettings(settings);
			return bot;
		}

		private GameState CreateGameState(string field, string macroboard, int round = 1)
		{
			return new GameState() { Field = Field.Parse(field), MacroBoard = MacroField.Parse(macroboard) };
		}
	}
}
