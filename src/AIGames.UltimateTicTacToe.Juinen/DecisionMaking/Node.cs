using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames.UltimateTicTacToe.Juinen.DecisionMaking
{
	public class Node
	{
		public ushort[] Board { get; set; }

		public List<Node> Children { get; set; }

		public int Score { get; private set; }
	}
}
