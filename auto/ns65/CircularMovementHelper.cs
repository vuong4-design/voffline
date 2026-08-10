using System;
using System.Threading;
using ns23;
using ns53;
using ns61;
using ns71;

namespace ns65;

internal class CircularMovementHelper
{
	public static int MoveToNextPointAroundCenter(CharacterAccountConfig accountConfig, uint[] centerPosition, int radius)
	{
		int int_1 = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, accountConfig.uint_16 + GameProcessInteractionHelper.uint_37 * 4, array, 4, ref int_1);
		int num = BitConverter.ToInt32(array, 0);
		if (num != radius)
		{
			array = BitConverter.GetBytes(radius);
			WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, accountConfig.uint_16 + GameProcessInteractionHelper.uint_37 * 4, array, 4, ref int_1);
			double num2 = 200.0;
			double num3 = Math.Sqrt((double)(radius * radius) + 40000.0);
			double num4 = num2 / num3;
			int num5 = (int)Math.Round(num4 * 180.0 / 3.14, 0);
			array = BitConverter.GetBytes(num5);
			WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, accountConfig.uint_16 + (GameProcessInteractionHelper.uint_37 + 1) * 4, array, 4, ref int_1);
			array = BitConverter.GetBytes(360 / num5);
			WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, accountConfig.uint_16 + (GameProcessInteractionHelper.uint_37 + 2) * 4, array, 4, ref int_1);
			array = new byte[4];
			WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, accountConfig.uint_16 + (GameProcessInteractionHelper.uint_37 + 3) * 4, array, 4, ref int_1);
		}
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, accountConfig.uint_16 + (GameProcessInteractionHelper.uint_37 + 1) * 4, array, 4, ref int_1);
		uint num6 = BitConverter.ToUInt32(array, 0);
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, accountConfig.uint_16 + (GameProcessInteractionHelper.uint_37 + 2) * 4, array, 4, ref int_1);
		uint num7 = BitConverter.ToUInt32(array, 0);
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, accountConfig.uint_16 + (GameProcessInteractionHelper.uint_37 + 3) * 4, array, 4, ref int_1);
		uint num8 = BitConverter.ToUInt32(array, 0);
		if (num7 <= num8)
		{
			num8 = 0u;
			array = BitConverter.GetBytes(0u);
			WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, accountConfig.uint_16 + (GameProcessInteractionHelper.uint_37 + 3) * 4, array, 4, ref int_1);
		}
		uint num9 = num8 * num6;
		if (num9 == 0 || num9 > 360)
		{
			num9 = 10u;
		}
		uint[] array2 = new uint[2];
		double num10 = (double)num9 * 3.14 / 180.0;
		array2[0] = (uint)((double)centerPosition[0] + (double)radius * Math.Cos(num10));
		array2[1] = (uint)((double)centerPosition[1] - (double)radius * Math.Sin(num10));
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_1);
		uint num11 = BitConverter.ToUInt32(array, 0);
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array, 4, ref int_1);
		uint num12 = BitConverter.ToUInt32(array, 0);
		uint num13 = num12 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array, 4, ref int_1);
		uint num14 = BitConverter.ToUInt32(array, 0);
		uint num15 = num14 + num13;
		uint[] array3 = new uint[2];
		int num16 = 3;
		for (int i = 0; i <= num16; i++)
		{
			WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, num15 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, array, 4, ref int_1);
			array3[0] = BitConverter.ToUInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, num15 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, array, 4, ref int_1);
			array3[1] = BitConverter.ToUInt32(array, 0);
			if (Class64.smethod_18(array3, array2) < 11500L)
			{
				break;
			}
			GameProcessInteractionHelper.smethod_61(accountConfig, array2);
			if (i > 0 && i < num16)
			{
				Thread.Sleep(100);
			}
		}
		array = BitConverter.GetBytes((int)(num8 + 1));
		WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, accountConfig.uint_16 + (GameProcessInteractionHelper.uint_37 + 3) * 4, array, 4, ref int_1);
		return 1;
	}
}
