using AIGames.UltimateTicTacToe.Juinen.Communication;
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

			var response = new BotResponse()
			{
				//Move = move,
				//Log = move.ToString(),
			};
			return response;
		}


	}
}
