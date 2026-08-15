using System;
using System.Threading;
using ns11;
using ns23;
using ns53;
using ns71;
using ns85;

namespace ns13;

internal class CharacterMovementHelper
{
	public static uint GetSquaredDistance(uint[] uint_0, uint[] uint_1)
	{
		if (uint_0 != null && uint_1 != null && uint_0[0] != 0 && uint_0[1] != 0 && uint_1[0] != 0 && uint_1[1] != 0)
		{
			long num = (int)(uint_0[0] - uint_1[0]);
			long num2 = (int)(uint_0[1] - uint_1[1]);
			long num3 = num * num + num2 * num2;
			if (num3 == 0L)
			{
				num3 = 1L;
			}
			return (uint)num3;
		}
		return 2147483647u;
	}

	public static int MoveToCoordinates(CharacterAccountConfig characterAccountConfig_0, uint[] uint_0)
	{
		if (uint_0 != null && characterAccountConfig_0.uint_88 != 0 && uint_0[0] != 0 && uint_0[1] != 0)
		{
			uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
			uint num4 = num3 + num2;
			int num5 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig_0.int_137);
			int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_0.int_137);
			int num7 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
			int num8 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
			if (num6 != 0 && num5 != 0 && num5 != 10 && num5 != 21 && num8 != 0 && num7 > 1)
			{
				if (!GameProcessInteractionHelper.InvokeCoordinateMovement(characterAccountConfig_0, uint_0))
				{
					return -1;
				}
				int num9 = 0;
				int int_ = 0;
				int num10 = 0;
				byte[] array = new byte[1];
				while (!CommonUtility.bool_0 && num9 < 60)
				{
					if (num10 != 0)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_88 - 4, array, 1, ref int_);
						if (array[0] <= 0 && WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig_0.int_137) == 3)
						{
							return 1;
						}
					}
					else if (IsMovementActive(characterAccountConfig_0))
					{
						num10 = 1;
					}
					num9++;
					Thread.Sleep(10);
				}
				return -1;
			}
			return 0;
		}
		return 0;
	}

	public static bool SetMovementActive(CharacterAccountConfig characterAccountConfig_0, bool bool_0)
	{
		return WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_178.resolvedValue, characterAccountConfig_0.int_137, Convert.ToUInt32(bool_0));
	}

	public static bool IsMovementActive(CharacterAccountConfig characterAccountConfig_0)
	{
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_178.resolvedValue;
		int num = (int)WindowsInteropHelper.ReadProcessUInt32(uint_, characterAccountConfig_0.int_137);
		return num > 0;
	}
}
