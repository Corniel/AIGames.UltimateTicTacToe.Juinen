﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIGames.UltimateTicTacToe.Juinen
{
	public partial struct Field
	{
		public static readonly ulong[] Connect4 = { 0xf, 0x1e, 0x3c, 0x78, 0xf00, 0x1e00, 0x3c00, 0x7800, 0xf0000, 0x1e0000, 0x3c0000, 0x780000, 0x1010101, 0x1020408, 0x2020202, 0x2040810, 0x4040404, 0x4081020, 0x8040201, 0x8080808, 0x8102040, 0xf000000, 0x10080402, 0x10101010, 0x1e000000, 0x20100804, 0x20202020, 0x3c000000, 0x40201008, 0x40404040, 0x78000000, 0x101010100, 0x102040800, 0x202020200, 0x204081000, 0x404040400, 0x408102000, 0x804020100, 0x808080800, 0x810204000, 0xf00000000, 0x1008040200, 0x1010101000, 0x1e00000000, 0x2010080400, 0x2020202000, 0x3c00000000, 0x4020100800, 0x4040404000, 0x7800000000, 0x10101010000, 0x10204080000, 0x20202020000, 0x20408100000, 0x40404040000, 0x40810200000, 0x80402010000, 0x80808080000, 0x81020400000, 0xf0000000000, 0x100804020000, 0x101010100000, 0x1e0000000000, 0x201008040000, 0x202020200000, 0x3c0000000000, 0x402010080000, 0x404040400000, 0x780000000000 };
		public static readonly ulong[] Connect3Out4 = { 0x7, 0xb, 0xd, 0xe, 0xe, 0x16, 0x1a, 0x1c, 0x1c, 0x2c, 0x34, 0x38, 0x38, 0x58, 0x68, 0x70, 0x700, 0xb00, 0xd00, 0xe00, 0xe00, 0x1600, 0x1a00, 0x1c00, 0x1c00, 0x2c00, 0x3400, 0x3800, 0x3800, 0x5800, 0x6800, 0x7000, 0x70000, 0xb0000, 0xd0000, 0xe0000, 0xe0000, 0x160000, 0x1a0000, 0x1c0000, 0x1c0000, 0x2c0000, 0x340000, 0x380000, 0x380000, 0x580000, 0x680000, 0x700000, 0x10101, 0x1000101, 0x1010001, 0x1010100, 0x20408, 0x1000408, 0x1020008, 0x1020400, 0x20202, 0x2000202, 0x2020002, 0x2020200, 0x40810, 0x2000810, 0x2040010, 0x2040800, 0x40404, 0x4000404, 0x4040004, 0x4040400, 0x81020, 0x4001020, 0x4080020, 0x4081000, 0x40201, 0x8000201, 0x8040001, 0x8040200, 0x80808, 0x8000808, 0x8080008, 0x8080800, 0x102040, 0x8002040, 0x8100040, 0x8102000, 0x7000000, 0xb000000, 0xd000000, 0xe000000, 0x80402, 0x10000402, 0x10080002, 0x10080400, 0x101010, 0x10001010, 0x10100010, 0x10101000, 0xe000000, 0x16000000, 0x1a000000, 0x1c000000, 0x100804, 0x20000804, 0x20100004, 0x20100800, 0x202020, 0x20002020, 0x20200020, 0x20202000, 0x1c000000, 0x2c000000, 0x34000000, 0x38000000, 0x201008, 0x40001008, 0x40200008, 0x40201000, 0x404040, 0x40004040, 0x40400040, 0x40404000, 0x38000000, 0x58000000, 0x68000000, 0x70000000, 0x1010100, 0x100010100, 0x101000100, 0x101010000, 0x2040800, 0x100040800, 0x102000800, 0x102040000, 0x2020200, 0x200020200, 0x202000200, 0x202020000, 0x4081000, 0x200081000, 0x204001000, 0x204080000, 0x4040400, 0x400040400, 0x404000400, 0x404040000, 0x8102000, 0x400102000, 0x408002000, 0x408100000, 0x4020100, 0x800020100, 0x804000100, 0x804020000, 0x8080800, 0x800080800, 0x808000800, 0x808080000, 0x10204000, 0x800204000, 0x810004000, 0x810200000, 0x700000000, 0xb00000000, 0xd00000000, 0xe00000000, 0x8040200, 0x1000040200, 0x1008000200, 0x1008040000, 0x10101000, 0x1000101000, 0x1010001000, 0x1010100000, 0xe00000000, 0x1600000000, 0x1a00000000, 0x1c00000000, 0x10080400, 0x2000080400, 0x2010000400, 0x2010080000, 0x20202000, 0x2000202000, 0x2020002000, 0x2020200000, 0x1c00000000, 0x2c00000000, 0x3400000000, 0x3800000000, 0x20100800, 0x4000100800, 0x4020000800, 0x4020100000, 0x40404000, 0x4000404000, 0x4040004000, 0x4040400000, 0x3800000000, 0x5800000000, 0x6800000000, 0x7000000000, 0x101010000, 0x10001010000, 0x10100010000, 0x10101000000, 0x204080000, 0x10004080000, 0x10200080000, 0x10204000000, 0x202020000, 0x20002020000, 0x20200020000, 0x20202000000, 0x408100000, 0x20008100000, 0x20400100000, 0x20408000000, 0x404040000, 0x40004040000, 0x40400040000, 0x40404000000, 0x810200000, 0x40010200000, 0x40800200000, 0x40810000000, 0x402010000, 0x80002010000, 0x80400010000, 0x80402000000, 0x808080000, 0x80008080000, 0x80800080000, 0x80808000000, 0x1020400000, 0x80020400000, 0x81000400000, 0x81020000000, 0x70000000000, 0xb0000000000, 0xd0000000000, 0xe0000000000, 0x804020000, 0x100004020000, 0x100800020000, 0x100804000000, 0x1010100000, 0x100010100000, 0x101000100000, 0x101010000000, 0xe0000000000, 0x160000000000, 0x1a0000000000, 0x1c0000000000, 0x1008040000, 0x200008040000, 0x201000040000, 0x201008000000, 0x2020200000, 0x200020200000, 0x202000200000, 0x202020000000, 0x1c0000000000, 0x2c0000000000, 0x340000000000, 0x380000000000, 0x2010080000, 0x400010080000, 0x402000080000, 0x402010000000, 0x4040400000, 0x400040400000, 0x404000400000, 0x404040000000, 0x380000000000, 0x580000000000, 0x680000000000, 0x700000000000 };

		public const ulong Mask = 0x00007f7f7f7f7f7f;

		public static readonly ulong[] ColumnMasks = 
		{
			0x0000010101010101,
			0x0000020202020202,
			0x0000040404040404,
			0x0000080808080808,
			0x0000101010101010,
			0x0000202020202020,
			0x0000404040404040,
		};

		public static readonly ulong[] Scores = GetScores();

		public static ulong[] GetScores()
		{
			var scores = new HashSet<ulong>();

			// row scores.
			for (var col = 0; col < 4; col++)
			{
				for (var row = 0; row < 6; row++)
				{
					ulong line = 0x0F;
					line <<= col + (row << 3);
					scores.Add(line);
				}
			}

			// column scores.
			for (var col = 0; col < 7; col++)
			{
				for (var row = 0; row < 3; row++)
				{
					ulong line = 0x01010101;
					line <<= col + (row << 3);
					scores.Add(line);
				}
			}
			// diagonal scores.
			for (var col = 0; col < 4; col++)
			{
				for (var row = 0; row < 3; row++)
				{
					ulong dig0 = 0x08040201;
					ulong dig1 = 0x01020408;
					dig0 <<= col + (row << 3);
					dig1 <<= col + (row << 3);
					scores.Add(dig0);
					scores.Add(dig1);
				}
			}
			return scores.OrderByDescending(s => s).ToArray();
		}
	
		public static string ToString(ulong field)
		{
			var sb = new StringBuilder();

			for (var row = 5; row >= 0; row--)
			{
				var line = 127 & (field >> (row << 3));
				sb.AppendLine(ParseRows.FirstOrDefault(kvp => kvp.Value == line).Key);
			}
			return sb.ToString();
		}
	}
}