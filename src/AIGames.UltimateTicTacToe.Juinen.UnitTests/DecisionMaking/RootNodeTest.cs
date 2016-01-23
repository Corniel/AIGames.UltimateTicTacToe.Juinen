using AIGames.UltimateTicTacToe.Juinen.DecisionMaking;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames.UltimateTicTacToe.Juinen.UnitTests.DecisionMaking
{
	[TestFixture]
	public class RootNodeTest
	{
		[Test, Category(Category.IntegrationTest)]
		public void GetMove_()
		{
			var root = new RootNode();

			var meta = new int[11];
			meta[10] = 9;

			var response = root.GetMove(meta, true, TimeSpan.MaxValue);
		}
	}
}
