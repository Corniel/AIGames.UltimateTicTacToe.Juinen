using AIGames.UltimateTicTacToe.Juinen.Communication;
using AIGames.UltimateTicTacToe.Juinen.Evaluation;
using System;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public class JuinenBot : IBot
	{
		public Settings Settings { get; set; }
		public GameState State { get; set; }

		void IBot.ApplySettings(Settings settings)
		{
			Settings = settings;
		}

		void IBot.Update(GameState state)
		{
			State = state;
		}

		BotResponse IBot.GetResponse(TimeSpan time)
		{
			var boards = State.Boards;
			int playableBoard = State.PlayableBoard;
			var evaluator = new Evaluator();

			int x0 = 3 * (playableBoard % 3);
			int y0 = 3 * (playableBoard / 3);
			int bestScore = int.MinValue;
			int bestX = -1;
			int bestY = -1;
			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					var newState = State.CopyAndPlay(x0 + x, y0 + y, Settings.YourBot);
					int score = evaluator.Evaluate(newState.Boards, newState.PlayableBoards, Settings.YourBot);
					if (score > bestScore)
					{
						bestScore = score;
						bestX = x0 + x;
						bestY = y0 + y;
					}
				}
			}

			var move = new MoveInstruction(bestX, bestY);

			var response = new BotResponse()
			{
				Move = move,
				Log = move.ToString(),
			};
			return response;
		}
	}
}
