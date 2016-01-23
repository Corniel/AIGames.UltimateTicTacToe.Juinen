﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace AIGames.UltimateTicTacToe.Juinen.UnitTests.Book
{
	[TestFixture]
	public class BookGenerator
	{
		[Test, Category(Category.Deployment)]
		public void GenerateKnown_File_WriteOutput()
		{
			using (var stream = new FileStream(@"C:\Code\AIGames.Challenger\games\four-in-a-row\_known_nodes.bin", FileMode.Open, FileAccess.Read))
			{
				var reader = new BinaryReader(stream);

				var bytes = reader.ReadBytes((int)reader.BaseStream.Length);

				var base64 = Convert.ToBase64String(bytes);

				using (var writer = new StreamWriter("known.txt"))
				{
					writer.Write(base64);
				}
			}
		}

		[Test, Category(Category.Deployment)]
		public void GenerateBook_8ply_WriteOutput()
		{
			var wins = new HashSet<Field>();
			var draw = new HashSet<Field>();
			var loss = new HashSet<Field>();

			using (var stream = typeof(BookGenerator).Assembly.GetManifestResourceStream("AIGames.UltimateTicTacToe.Juinen.UnitTests.Book.db.dat"))
			{
				var reader = new StreamReader(stream);
				var line = String.Empty;
				while ((line = reader.ReadLine()) != null)
				{
					var tp = line.Substring(line.LastIndexOf(',') + 1);
					var str = ToFieldString(line);
					var field = Field.Parse(str);

					Assert.AreEqual(8, field.Count, field.ToString());

					switch (tp)
					{
						case "win": wins.Add(field); break;
						case "draw": draw.Add(field); break;
						case "loss": loss.Add(field); break;
						default: throw new ArgumentException("invalid string.");
					}
				}
			}

			ToBase64String(draw, "draw.txt");
			ToBase64String(loss, "loss.txt");
		}

		private static void ToBase64String(IEnumerable<Field> fields, string file)
		{
			using (var writer = new StreamWriter(file))
			{
				var bytes = new List<byte>();
				foreach (var field in fields)
				{
					bytes.AddRange(field.GetBytes());
				}
				writer.Write(Convert.ToBase64String(bytes.ToArray()));
			}
		}

		public static string ToFieldString(string line)
		{
			var str = line.Replace(",", "");
			var field = new char[42];
			for (var i = 0; i < 42; i++)
			{
				var col = i / 6;
				var row = i % 6;
				var index = col + (5 - row) * 7;

				var ch = str[i];
				switch (ch)
				{
					case 'x': field[index] = '1'; break;
					case 'o': field[index] = '2'; break;
					case 'b': field[index] = '0'; break;
					default: throw new ArgumentException("invalid character.");
				}
			}
			return new String(field);
		}
	}
}
