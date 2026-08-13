using System;
using ns1;
using ns11;
using ns23;
using ns53;

namespace ns80;

internal class WorldObjectMemoryReader
{
	public static int ReadObjectCount(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_124.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_125.uint_0 != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_124.uint_0 + GameConfigurationManager.memorySignatureScanConfig_125.uint_0 + 4;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 4, ref int_);
			return BitConverter.ToInt32(array, 0);
		}
		return -1;
	}

	public static int FindObjectIndexByName(CharacterAccountConfig characterAccountConfig_0, string string_0, bool bool_0 = false, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		int num = 1;
		while (true)
		{
			if (num < 256)
			{
				uint num2 = uint_0 + (uint)(num * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
				string text = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num2 + GameConfigurationManager.memorySignatureScanConfig_138.uint_0, characterAccountConfig_0.int_137);
				if (string_0 == text || (!bool_0 && CommonUtility.FindSubstringIndex(text, string_0) >= 0))
				{
					break;
				}
				num++;
				continue;
			}
			return 0;
		}
		return num;
	}

	public static uint smethod_2(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		return WindowsInteropHelper.ReadProcessUInt32(uint_0, characterAccountConfig_0.int_137);
	}

	public static uint[] GetObjectPosition(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		uint[] result = null;
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		uint num = WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_133.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_134.uint_0, characterAccountConfig_0.int_137);
		if (num != 0 && num2 != 0)
		{
			result = new uint[2] { num, num2 };
		}
		return result;
	}

	public static int[] ReadObjectDimensions(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		int num = (int)WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_130.uint_0, characterAccountConfig_0.int_137);
		int num2 = (int)WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_131.uint_0, characterAccountConfig_0.int_137);
		return new int[2] { num, num2 };
	}

	public static string GetObjectName(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u, bool bool_0 = false)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		string text = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(uint_0 + GameConfigurationManager.memorySignatureScanConfig_138.uint_0, characterAccountConfig_0.int_137, 32);
		if (bool_0)
		{
			text = GameTextEncodingHelper.ConvertGameTextToDisplayText(text, 1);
		}
		return text;
	}

	public static int GetObjectKind(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		return (int)WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_128.uint_0, characterAccountConfig_0.int_137);
	}

	public static bool IsWorldObjectGrowthFlagClear(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		uint num = WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_141.uint_0, characterAccountConfig_0.int_137);
		return num == 0;
	}

	public static uint ReadObjectExistValue(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		return WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_140.uint_0, characterAccountConfig_0.int_137);
	}

	public static uint ReadObjectColor(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		return WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_129.uint_0, characterAccountConfig_0.int_137);
	}

	public static uint ReadObjectType(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		return WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_139.uint_0, characterAccountConfig_0.int_137);
	}

	public static uint ReadObjectSerialValue(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		return WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_136.uint_0, characterAccountConfig_0.int_137);
	}

	public static uint ReadObjectTimeValue(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		return WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_137.uint_0, characterAccountConfig_0.int_137);
	}

	public static uint ReadObjectStackCount(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		if (uint_0 == 0)
		{
			uint_0 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		}
		uint_0 += (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0);
		return WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_132.uint_0, characterAccountConfig_0.int_137);
	}
}
