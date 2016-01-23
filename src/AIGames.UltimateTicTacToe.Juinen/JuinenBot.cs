using AIGames.UltimateTicTacToe.Juinen.Communication;
using System;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public class JuinenBot : IBot
	{
		PlayerName MyPlayerName = PlayerName.None;

		void IBot.ApplySettings(Settings settings)
		{
			MyPlayerName = settings.YourBot;
		}

		void IBot.Update(GameState state)
		{
			//TODO
		}

		BotResponse IBot.GetResponse(TimeSpan time)
		{
			return new BotResponse();
		}
	}
}
