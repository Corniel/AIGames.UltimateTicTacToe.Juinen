using System;

namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public interface IBot
	{
		void ApplySettings(Settings settings);
		void Update(GameState state);
		BotResponse GetResponse(TimeSpan time);
	}
}
