using AIGames.UltimateTicTacToe.Juinen.Communication;
using System;
using System.Linq;

namespace AIGames.UltimateTicTacToe.Juinen.Evaluation
{
	public class Evaluator
	{
		public int Evaluate(int[] meta, bool oToMove)
		{
			return 0;
		}
		/// <summary>
		/// Calculates the score for the current boards
		/// </summary>
		/// <param name="boards">array of 10 boards (9 tiny boards + 1 macroboard), each of which with 9 ints (0 = not played, 1 = player1, 2 = player2)</param>
		/// <param name="playableBoards">array of playable tiny boards</param>
		/// <param name="player">Current player</param>
		/// <returns>Score</returns>
		public int Evaluate(int[][] boards, bool[] playableBoards, PlayerName player)
		{
			if (boards.Length != 10) throw new Exception("boards must have 10 elements");
			if (playableBoards.Length != 9) throw new Exception("playableboards must have 9 elements");
			int score = 0;
			foreach(int i in Enumerable.Range(0, 9).Where(i => playableBoards[i]))
			{
				score += EvaluateBoard(boards[i], player);
			}
			score += EvaluateMacroBoard(boards[9], player);
			return score;
		}

		public static int[][] TicTacToes = { 
			new int[] { 0, 1, 2 }, 
			new int[] { 3, 4, 5 },
			new int[] { 6, 7, 8 },
			new int[] { 0, 3, 6 },
			new int[] { 1, 4, 7 },
			new int[] { 2, 5, 8 },
			new int[] { 0, 4, 8 },
			new int[] { 2, 4, 6 },
		};

		public int EvaluateBoard(int[] board, PlayerName player)
		{
			if (board.Length != 9) throw new Exception("board must have 9 elements");
			int score = 0;
			int playerId = (int)player;
			int opponentPlayerId = 3 - playerId;
			foreach(var tictactoe in TicTacToes)
			{
				int mine = (board[tictactoe[0]] == playerId ? 1 : 0)
					+ (board[tictactoe[1]] == playerId ? 1 : 0)
					+ (board[tictactoe[2]] == playerId ? 1 : 0);
				int his = (board[tictactoe[0]] == opponentPlayerId ? 1 : 0)
					+ (board[tictactoe[1]] == opponentPlayerId  ? 1 : 0)
					+ (board[tictactoe[2]] == opponentPlayerId  ? 1 : 0);

				if (mine == 0 && his == 0) score += 1;		//Both empty
				else if (mine > 0 && his > 0) score += 0;	//Neither
				else if (mine == 1) score += 3;				//Mine: 1
				else if (mine == 2) score += 5;				//Mine: 2
				else if (his == 1) score += 2;				//His: 1
				else if (his == 2) score += 4;				//His: 2
			}

			return score;
		}

		public int EvaluateMacroBoard(int[] board, PlayerName player)
		{
			return EvaluateBoard(board, player);
		}
	}
}
