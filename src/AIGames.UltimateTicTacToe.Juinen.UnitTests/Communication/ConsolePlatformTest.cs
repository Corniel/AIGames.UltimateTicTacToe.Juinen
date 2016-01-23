﻿using NUnit.Framework;

namespace AIGames.UltimateTicTacToe.Juinen.UnitTests.Communication
{
	[TestFixture, Category(Category.IntegrationTest)]
	public class ConsolePlatformTest
	{
		[Test]
		public void DoRun_Simple_NoExceptions()
		{
			using(var platform = new ConsolePlatformTester("input.simple.txt"))
			{
				platform.DoRun(new TheDaltonsBot());
			}
		}

		[Test]
		public void DoRun_0004_NoExceptions()
		{
			using (var platform = new ConsolePlatformTester("input.0004.txt"))
			{
				platform.DoRun(new TheDaltonsBot());
			}
		}

		[Test]
		public void DoRun_0024_NoExceptions()
		{
			using (var platform = new ConsolePlatformTester("input.0024.txt"))
			{
				platform.DoRun(new TheDaltonsBot());
			}
		}

		[Test]
		public void DoRun_0034_NoExceptions()
		{
			using (var platform = new ConsolePlatformTester("input.0034.txt"))
			{
				platform.DoRun(new TheDaltonsBot());
			}
		}
	}
}
