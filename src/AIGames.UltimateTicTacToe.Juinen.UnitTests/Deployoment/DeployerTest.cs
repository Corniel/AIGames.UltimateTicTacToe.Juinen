using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace AIGames.UltimateTicTacToe.Juinen.UnitTests.Deployoment
{
	[TestFixture, Category(Category.Deployment)]
	public class DeployerTest
	{
		[Test]
		public void Deploy_Bot_CompileAndZip()
		{
			var collectDir = new DirectoryInfo(@"C:\AIGames.UltimateTicTacToe.Juinen\src\AIGames.UltimateTicTacToe.Juinen");
			var full = collectDir.FullName;
			var version = typeof(JuinenBot).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
			var nr = int.Parse(version.Split('.')[0]);
			Deployer.Run(collectDir, "Juinen", nr.ToString("0000"), false);
		}
	}
}
