using System;
using System.Collections.Generic;
using System.Linq;

namespace AIGames.UltimateTicTacToe.Juinen.Communication
{
	public class GameState
	{
		public int Round { get; set; }

		public Field Field { get; set; }
		public MacroField MacroBoard { get; set; }

		/// <summary>
		/// Returns a copy of the gamestate
		/// </summary>
		public GameState Copy()
		{
			return new GameState()
			{
				Field = this.Field.Copy(),
				MacroBoard = this.MacroBoard.Copy(),
				Round = this.Round,
			};
		}

		public GameState CopyAndPlay(int x, int y, PlayerName player)
		{
			var newState = this.Copy();
			if (newState.Field.Board[x, y] != 0) throw new Exception(string.Format("Can't play ({0},{1}) because it was already played", x, y));
			newState.Field.Board[x, y] = (int)player;
			return newState;
		}

		public int[][] Boards
		{
			get
			{
				var result = new int[10][];
				for (int tinyX = 0; tinyX < 3; tinyX++)
				{
					for (int tinyY = 0; tinyY < 3; tinyY++)
					{
						var tinyBoard = new int[9];
						for (int x = 0; x < 3; x++)
						{
							for(int y = 0; y < 3; y++)
							{
								tinyBoard[x + 3 * y] = Field.Board[3 * tinyX + x, 3 * tinyY + y];
							}
						}
						result[tinyX + 3 * tinyY] = tinyBoard;
					}
				}

				//TODO: how to fill macroboard
				result[9] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

				return result;
			}
		}
		/// <summary>
		/// Returns an array of 9 elements, indicating for each tinyboard, whether it is playable
		/// </summary>
		public bool[] PlayableBoards
		{
			get
			{
				bool allPlayable = true;

				//If not all playable, then select the one and only with value == -1
				var result = new bool[9];
				for (int y = 0; y < 3; y++)
				{
					for (int x = 0; x < 3; x++)
					{
						if (MacroBoard.Board[x, y] == -1)
						{
							result[x + 3 * y] = true;
							allPlayable = false;
						}
					}
				}

				//If all playable, then select all with value == 0
				if (allPlayable)
				{
					for (int y = 0; y < 3; y++)
					{
						for (int x = 0; x < 3; x++)
						{
							result[x + 3 * y] = MacroBoard.Board[x, y] == 0;
						}
					}
				}

				return result;
			}
		}

		/// <summary>
		/// Returns the first playable board
		/// </summary>
		public int PlayableBoard
		{
			get
			{
				var board = PlayableBoards;
				for (int ix = 0; ix < 9; ix++)
					if (board[ix]) return ix;

				//Should never occur
				return 4;
			}
		}
		public bool Apply(IInstruction instruction)
		{
			if (Mapping.ContainsKey(instruction.GetType()))
			{
				Mapping[instruction.GetType()].Invoke(instruction, this);
				return true;
			}
			return false;
		}

		public static GameState Create(IEnumerable<IInstruction> instructions)
		{
			var state = new GameState();

			foreach (var instruction in instructions.Where(i => Mapping.ContainsKey(i.GetType())))
			{
				Mapping[instruction.GetType()].Invoke(instruction, state);
			}
			return state;
		}

		private static Dictionary<Type, Action<IInstruction, GameState>> Mapping = new Dictionary<Type, Action<IInstruction, GameState>>()
		{
			{ 
				typeof(FieldInstruction), (instruction, state) =>
				{
					var inst = (FieldInstruction)instruction;
					state.Field = inst.Field;
				}
			},
			{
				typeof(MacroBoardInstruction), (instruction, state) =>
				{
					var inst = (MacroBoardInstruction)instruction;
					state.MacroBoard = inst.MacroBoard;
				}
			},
			{ 
				typeof(RoundInstruction), (instruction, state) => 
				{ 
					state.Round = ((RoundInstruction)instruction).Value; 
				}
			},
		};
	}
}
