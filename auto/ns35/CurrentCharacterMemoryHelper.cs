using System;
using System.Threading;
using ns1;
using ns11;
using ns23;
using ns43;
using ns53;
using ns71;
using ns81;
using ns85;

namespace ns35;

internal class CurrentCharacterMemoryHelper
{
	public static string string_0 = "<no name>";

	public static string[] string_1 = new string[2] { "tiÕn hµnh", "®ang" };

	public static string[] string_2 = new string[4] { "Chat('CH_NEARBY', '<color=green>XXX<color=white> YYY <color=red>cõu s\u00b8t<color=white> víi b¹n.')", "<color=white>* <color=green>XXX<color=yellow> YYY <color=red>cõu s\u00b8t<color=yellow> víi b¹n.", "------------------------------------------", "<color=white>* <color=green>KÕt thóc cõu s\u00b8t" };

	public static string string_3 = "Chat('CH_TONG', '<color=green>XXX<color=white> YYY <color=red>cõu s\u00b8t<color=white> víi b¹n.')";

	public static uint GetSquaredCoordinateDistance(uint[] uint_0, uint[] uint_1)
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

	public static uint GetCurrentCharacterEntityAddress(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		return num3 + num2;
	}

	private static void WriteCurrentCharacterInt32Field(CharacterAccountConfig characterAccountConfig_0, uint uint_0, int int_0)
	{
		uint num = GetCurrentCharacterEntityAddress(characterAccountConfig_0);
		WindowsInteropHelper.WriteProcessUIntValue(num + uint_0, characterAccountConfig_0.int_137, (uint)int_0);
	}

	private static uint ReadCurrentCharacterUInt32Field(CharacterAccountConfig characterAccountConfig_0, uint uint_0)
	{
		uint num = GetCurrentCharacterEntityAddress(characterAccountConfig_0);
		return WindowsInteropHelper.ReadProcessUInt32(num + uint_0, characterAccountConfig_0.int_137);
	}

	public static int smethod_4(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		int int_ = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_85.uint_0, array, 4, ref int_);
		return BitConverter.ToInt32(array, 0);
	}

	public static string GetCharacterName(CharacterAccountConfig characterAccountConfig_0)
	{
		string result = string_0;
		if (characterAccountConfig_0.int_137 > 0)
		{
			uint num = GetCurrentCharacterEntityAddress(characterAccountConfig_0);
			string text = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num + GameConfigurationManager.memorySignatureScanConfig_16.uint_0, characterAccountConfig_0.int_137);
			if (text != "")
			{
				result = text;
			}
		}
		return result;
	}

	public static int GetCharacterLevel(CharacterAccountConfig characterAccountConfig_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_11.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_23.uint_0 != 0)
		{
			uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
			return (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_23.uint_0, characterAccountConfig_0.int_137);
		}
		return 0;
	}

	public static bool RefreshEmbeddedNpcSnapshot(CharacterAccountConfig characterAccountConfig_0, ref GStruct45 gstruct45_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_30.uint_0;
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_61.uint_0, characterAccountConfig_0.int_137);
		if (num2 == 0)
		{
			if (gstruct45_0.uint_0 != 0)
			{
				gstruct45_0.uint_0 = 0u;
				gstruct45_0.string_0 = null;
			}
		}
		else if (gstruct45_0.uint_0 != num2)
		{
			gstruct45_0.uint_0 = num2;
			gstruct45_0.uint_1 = WindowsInteropHelper.ReadProcessUInt32(num + 12, characterAccountConfig_0.int_137);
			gstruct45_0.uint_2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_62.uint_0, characterAccountConfig_0.int_137);
			gstruct45_0.string_0 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num + GameConfigurationManager.memorySignatureScanConfig_60.uint_0, characterAccountConfig_0.int_137, 32);
			gstruct45_0.bool_0 = false;
		}
		return num2 != 0;
	}

	public static int FindActivePlayerEntityIndexById(CharacterAccountConfig characterAccountConfig_0, uint uint_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		int int_ = 0;
		byte[] array = new byte[4];
		uint uint_1 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.uint_0 + GameConfigurationManager.memorySignatureScanConfig_10.uint_0 + 4;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_1, array, 4, ref int_);
		int num4 = BitConverter.ToInt32(array, 0);
		if (num4 > 1)
		{
			int num5 = 0;
			for (int i = 1; i < 256; i++)
			{
				if (num4 <= num5)
				{
					break;
				}
				if (i == num3)
				{
					num5++;
					continue;
				}
				uint num6 = num + (uint)(i * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + GameConfigurationManager.memorySignatureScanConfig_16.uint_0, array, 4, ref int_);
				if (array[0] == 0)
				{
					continue;
				}
				num5++;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array, 4, ref int_);
				if (BitConverter.ToInt32(array, 0) <= 0 || (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137) <= 0)
				{
					continue;
				}
				int num7 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig_0.int_137);
				if (num7 != 10 && num7 != 21)
				{
					int num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_52.uint_0, characterAccountConfig_0.int_137);
					if (num8 == 1 && uint_0 == WindowsInteropHelper.ReadProcessUInt32(num6, characterAccountConfig_0.int_137))
					{
						return i;
					}
				}
			}
			return 0;
		}
		return 0;
	}

	public static int[] ReadActiveBuffIds(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_32.uint_0, characterAccountConfig_0.int_137);
		if (num == 0)
		{
			return null;
		}
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num5 = num4 + num3;
		uint num6 = WindowsInteropHelper.ReadProcessUInt32(num5 + 4160, characterAccountConfig_0.int_137);
		uint num7 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_34.uint_0, characterAccountConfig_0.int_137);
		uint num8 = WindowsInteropHelper.ReadProcessUInt32(num7 + num6 * GameConfigurationManager.memorySignatureScanConfig_33.uint_0 + GameConfigurationManager.memorySignatureScanConfig_40.uint_0, characterAccountConfig_0.int_137);
		int[] int_ = null;
		while (num8 != 0)
		{
			uint num9 = WindowsInteropHelper.ReadProcessUInt32(num8 + 4, characterAccountConfig_0.int_137);
			uint num10 = WindowsInteropHelper.ReadProcessUInt32(num8 + 16, characterAccountConfig_0.int_137);
			uint num11 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_41.uint_0, characterAccountConfig_0.int_137);
			num8 = num9;
			if (num11 == 0)
			{
				continue;
			}
			uint uint_ = num10 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0 + num11 + GameConfigurationManager.memorySignatureScanConfig_42.uint_0;
			uint num12 = WindowsInteropHelper.ReadProcessUInt32(uint_, characterAccountConfig_0.int_137);
			while (num12 != 0)
			{
				uint num13 = WindowsInteropHelper.ReadProcessUInt32(num12 + 4, characterAccountConfig_0.int_137);
				int num14 = (int)WindowsInteropHelper.ReadProcessUInt32(num12 + 24, characterAccountConfig_0.int_137);
				num12 = num13;
				if (num14 > 0 && num14 < 6001)
				{
					CommonUtility.smethod_38(ref int_, num14);
				}
			}
		}
		return int_;
	}

	public static bool SetCurrentTargetEntityIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_0)
	{
		if (!characterAccountConfig_0.bool_23)
		{
			uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
			uint uint_1 = num3 + num2 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0;
			return WindowsInteropHelper.WriteProcessUIntValue(uint_1, characterAccountConfig_0.int_137, uint_0);
		}
		return true;
	}

	public static void TriggerBuffSkill(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0 = 0u)
	{
		uint uint_1 = 5u;
		uint uint_2 = uint.MaxValue;
		uint uint_3 = uint_0;
		uint num = GetCurrentCharacterEntityAddress(characterAccountConfig_0);
		if (uint_0 == 0)
		{
			uint_2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137);
			uint_3 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137);
		}
		WindowsInteropHelper.WriteProcessUIntValue(num + GameConfigurationManager.memorySignatureScanConfig_37.uint_0, characterAccountConfig_0.int_137, uint_2);
		WindowsInteropHelper.WriteProcessUIntValue(num + GameConfigurationManager.memorySignatureScanConfig_38.uint_0, characterAccountConfig_0.int_137, uint_3);
		WindowsInteropHelper.WriteProcessUIntValue(num + GameConfigurationManager.memorySignatureScanConfig_36.uint_0, characterAccountConfig_0.int_137, (uint)int_0);
		WindowsInteropHelper.WriteProcessUIntValue(num + GameConfigurationManager.memorySignatureScanConfig_35.uint_0, characterAccountConfig_0.int_137, uint_1);
	}

	public static string GetGuildName(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = GetCurrentCharacterEntityAddress(characterAccountConfig_0);
		string result = "";
		if (characterAccountConfig_0.int_137 > 0 && num != 0)
		{
			result = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num + GameConfigurationManager.memorySignatureScanConfig_89.uint_0, characterAccountConfig_0.int_137, 32);
		}
		return result;
	}

	public static uint GetGuildNameHash(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		return WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_88.uint_0, characterAccountConfig_0.int_137);
	}

	public static int GetStatValueByIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_0 = 0u, uint uint_1 = 0u)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = 0u;
		num2 = ((uint_1 != 0) ? (uint_0 switch
		{
			0u => GameConfigurationManager.memorySignatureScanConfig_78.uint_0,
			1u => GameConfigurationManager.memorySignatureScanConfig_80.uint_0,
			2u => GameConfigurationManager.memorySignatureScanConfig_82.uint_0,
			_ => GameConfigurationManager.memorySignatureScanConfig_84.uint_0,
		}) : (uint_0 switch
		{
			0u => GameConfigurationManager.memorySignatureScanConfig_77.uint_0,
			1u => GameConfigurationManager.memorySignatureScanConfig_79.uint_0,
			2u => GameConfigurationManager.memorySignatureScanConfig_81.uint_0,
			_ => GameConfigurationManager.memorySignatureScanConfig_83.uint_0,
		}));
		return (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_12.uint_0 + num2, characterAccountConfig_0.int_137);
	}

	public static int ReadStatsTotalValue(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		return (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_12.uint_0 + GameConfigurationManager.memorySignatureScanConfig_76.uint_0, characterAccountConfig_0.int_137);
	}

	public static int ReadKPlayerBaseAddress(CharacterAccountConfig characterAccountConfig_0)
	{
		uint uint_ = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		return (int)WindowsInteropHelper.ReadProcessUInt32(uint_, characterAccountConfig_0.int_137);
	}

	public static int GetCurrentPlayerIndex(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		return (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
	}

	public static bool smethod_18(CharacterAccountConfig characterAccountConfig_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_105.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_106.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_110.uint_0 != 0)
		{
			int int_ = 0;
			byte[] array = new byte[1];
			byte[] array2 = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array2, 4, ref int_);
			uint num = BitConverter.ToUInt32(array2, 0) + GameConfigurationManager.memorySignatureScanConfig_97.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_105.uint_0, array2, 4, ref int_);
			uint num2 = BitConverter.ToUInt32(array2, 0);
			int num3 = Class85.GetInventoryEntryCount(characterAccountConfig_0);
			int num4 = 0;
			for (uint num5 = 1u; num5 < GameConfigurationManager.int_1; num5++)
			{
				if (num3 <= num4)
				{
					break;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + (num5 * 5 + GameConfigurationManager.memorySignatureScanConfig_99.uint_0) * 4, array2, 4, ref int_);
				uint num6 = BitConverter.ToUInt32(array2, 0);
				if (num6 == 0)
				{
					continue;
				}
				uint num7 = num2 + num6 * GameConfigurationManager.memorySignatureScanConfig_106.uint_0;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_106.uint_0 - 4, array2, 4, ref int_);
				if (BitConverter.ToInt32(array2, 0) != 0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, array, 1, ref int_);
				if (array[0] == 0)
				{
					continue;
				}
				num4++;
				uint num8 = num + num5 * 20;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_100.uint_0 - 8, array, 1, ref int_);
				if (array[0] == 2)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_110.uint_0, array, 1, ref int_);
					uint num9 = array[0];
					if (num9 == 10)
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	public static bool IsCharacterRidingHorse(CharacterAccountConfig characterAccountConfig_0)
	{
		int num = (int)ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_44.uint_0);
		return num > 0;
	}

	public static long GetCurrentHitPoints(CharacterAccountConfig characterAccountConfig_0)
	{
		return ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_45.uint_0);
	}

	public static long GetPrimaryHitPointCapacity(CharacterAccountConfig characterAccountConfig_0)
	{
		return ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_47.uint_0);
	}

	public static long GetAlternateHitPointCapacity(CharacterAccountConfig characterAccountConfig_0)
	{
		return ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_47.uint_0 + 4);
	}

	public static long GetCurrentManaPoints(CharacterAccountConfig characterAccountConfig_0)
	{
		return ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_46.uint_0);
	}

	public static long GetPrimaryManaPointCapacity(CharacterAccountConfig characterAccountConfig_0)
	{
		return ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_48.uint_0);
	}

	public static long GetPrimaryExperienceValue(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_12.uint_0;
		int int_ = 0;
		byte[] array = new byte[8];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + GameConfigurationManager.memorySignatureScanConfig_24.uint_0, array, 8, ref int_);
		return BitConverter.ToInt64(array, 0);
	}

	public static long GetSecondaryExperienceValue(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_12.uint_0;
		int int_ = 0;
		byte[] array = new byte[8];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + GameConfigurationManager.memorySignatureScanConfig_24.uint_0 + 8, array, 8, ref int_);
		return BitConverter.ToInt64(array, 0);
	}

	public static int GetCharacterCombatState(CharacterAccountConfig characterAccountConfig_0)
	{
		return (int)ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_43.uint_0);
	}

	public static int GetCharacterExistsFlag(CharacterAccountConfig characterAccountConfig_0)
	{
		return (int)ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_50.uint_0);
	}

	public static int GetCharacterFiveElementIndex(CharacterAccountConfig characterAccountConfig_0)
	{
		return (int)ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_53.uint_0);
	}

	public static uint[] GetCurrentCharacterPosition(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0);
		uint num2 = ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0);
		if (num != 0 && num2 != 0)
		{
			return new uint[2] { num, num2 };
		}
		return null;
	}

	public static int GetCharacterActionState(CharacterAccountConfig characterAccountConfig_0)
	{
		return (int)ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_55.uint_0);
	}

	public static int GetCharacterProfileStatus(CharacterAccountConfig characterAccountConfig_0)
	{
		return (int)ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_66.uint_0);
	}

	public static int GetCharacterColorCode(CharacterAccountConfig characterAccountConfig_0)
	{
		int num = (int)ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_54.uint_0);
		if (num > 4)
		{
			num = 5;
		}
		return num;
	}

	public static int smethod_34(CharacterAccountConfig characterAccountConfig_0)
	{
		return (int)ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_51.uint_0);
	}

	public static int GetCharacterKillerStatus(CharacterAccountConfig characterAccountConfig_0)
	{
		return (int)ReadCurrentCharacterUInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_56.uint_0);
	}

	public static bool IsEmbeddedNpcRevengeActive(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_30.uint_0 + GameConfigurationManager.memorySignatureScanConfig_62.uint_0, characterAccountConfig_0.int_137);
		return num2 == 2;
	}

	public static uint GetEmbeddedNpcEntityId(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		return WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_30.uint_0 + GameConfigurationManager.memorySignatureScanConfig_61.uint_0, characterAccountConfig_0.int_137);
	}

	public static int FindEmbeddedNpcEntityIndex(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_30.uint_0 + GameConfigurationManager.memorySignatureScanConfig_61.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		int int_ = 0;
		byte[] array = new byte[4];
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.uint_0 + GameConfigurationManager.memorySignatureScanConfig_10.uint_0 + 4;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 4, ref int_);
		int num4 = BitConverter.ToInt32(array, 0);
		if (num4 > 1)
		{
			int num5 = (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
			int num6 = 0;
			for (uint num7 = 1u; num7 < 256; num7++)
			{
				if (num4 <= num6)
				{
					break;
				}
				if (num7 == num5)
				{
					num6++;
					continue;
				}
				uint num8 = num3 + num7 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_16.uint_0, array, 4, ref int_);
				if (array[0] == 0)
				{
					continue;
				}
				num6++;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array, 4, ref int_);
				if (BitConverter.ToInt32(array, 0) > 0)
				{
					uint num9 = WindowsInteropHelper.ReadProcessUInt32(num8, characterAccountConfig_0.int_137);
					if (num9 == num2)
					{
						return (int)num7;
					}
				}
			}
			return 0;
		}
		return 0;
	}

	public static int GetCharacterPkValue(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint uint_ = num + GameConfigurationManager.memorySignatureScanConfig_30.uint_0 + GameConfigurationManager.memorySignatureScanConfig_65.uint_0;
		return (int)WindowsInteropHelper.ReadProcessUInt32(uint_, characterAccountConfig_0.int_137);
	}

	public static string GetCharacterNpcName(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		return WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num + GameConfigurationManager.memorySignatureScanConfig_30.uint_0 + GameConfigurationManager.memorySignatureScanConfig_60.uint_0, characterAccountConfig_0.int_137, 32);
	}

	public static uint GetCharacterMoneyValue(CharacterAccountConfig characterAccountConfig_0, bool bool_0 = false)
	{
		uint uint_ = GameConfigurationManager.memorySignatureScanConfig_73.uint_0;
		if (bool_0)
		{
			uint_ = GameConfigurationManager.memorySignatureScanConfig_74.uint_0;
		}
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_12.uint_0;
		uint uint_2 = num + GameConfigurationManager.memorySignatureScanConfig_75.uint_0 + uint_;
		return WindowsInteropHelper.ReadProcessUInt32(uint_2, characterAccountConfig_0.int_137);
	}

	public static void SetCharacterMoneyValue(CharacterAccountConfig characterAccountConfig_0, uint uint_0, bool bool_0 = true)
	{
		uint uint_1 = GameConfigurationManager.memorySignatureScanConfig_74.uint_0;
		if (bool_0)
		{
			uint_1 = GameConfigurationManager.memorySignatureScanConfig_73.uint_0;
		}
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_12.uint_0;
		uint uint_2 = num + GameConfigurationManager.memorySignatureScanConfig_75.uint_0 + uint_1;
		WindowsInteropHelper.WriteProcessUIntValue(uint_2, characterAccountConfig_0.int_137, uint_0);
	}

	public static int[] GetStatValuesByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		return new int[2]
		{
			(int)WindowsInteropHelper.ReadProcessUInt32((uint)((int)(num + GameConfigurationManager.memorySignatureScanConfig_12.uint_0 + GameConfigurationManager.memorySignatureScanConfig_76.uint_0) + int_0 * 4 + 8), characterAccountConfig_0.int_137),
			(int)WindowsInteropHelper.ReadProcessUInt32((uint)((int)(num + GameConfigurationManager.memorySignatureScanConfig_12.uint_0 + GameConfigurationManager.memorySignatureScanConfig_76.uint_0) + int_0 * 4 + 32), characterAccountConfig_0.int_137)
		};
	}

	public static int GetAvailableStatPoints(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		return (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_12.uint_0 + GameConfigurationManager.memorySignatureScanConfig_76.uint_0, characterAccountConfig_0.int_137);
	}

	public static bool IsCharacterStatusPanelOpen(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_96.uint_0, characterAccountConfig_0.int_137);
		return num != 0;
	}

	public static int GetCurrentCharacterActiveEffectIdBySlot(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		uint num = GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_2.uint_0 + (uint)((int)GameConfigurationManager.memorySignatureScanConfig_3.uint_0 * int_0);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num5 = num4 + num3 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		return (int)WindowsInteropHelper.ReadProcessUInt32(num5 + num, characterAccountConfig_0.int_137);
	}

	public static bool AreAllCurrentCharacterEffectSlotsOccupied(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		int num5 = 0;
		for (uint num6 = 0u; num6 < 6; num6++)
		{
			uint num7 = GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_2.uint_0 + GameConfigurationManager.memorySignatureScanConfig_3.uint_0 * num6;
			int num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + num7 + 20, characterAccountConfig_0.int_137);
			if (num8 == 1)
			{
				num5++;
			}
		}
		return num5 > 5;
	}

	public static bool smethod_48(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		int int_ = 0;
		byte[] array = new byte[1];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_38.uint_0 + 4, array, 1, ref int_);
		return array[0] > 0;
	}

	public static string ReadGuildNameField(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = GetCurrentCharacterEntityAddress(characterAccountConfig_0);
		if (characterAccountConfig_0.int_137 != 0 && num != 0)
		{
			byte[] array = new byte[80];
			int int_ = 0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_89.uint_0, array, array.Length, ref int_);
			return GameTextEncodingHelper.DecodeNullTerminatedUtf7(array);
		}
		return string.Empty;
	}

	public static void WriteGuildNameField(CharacterAccountConfig characterAccountConfig_0, string string_4)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2;
		if (characterAccountConfig_0.int_137 == 0 || num4 == 0)
		{
			return;
		}
		byte[] array = new byte[4];
		byte[] array2 = array;
		if (string_4 != "")
		{
			char[] array3 = string_4.ToCharArray();
			array2 = new byte[array3.Length + 1];
			for (int i = 0; i < array3.Length; i++)
			{
				array2[i] = (byte)array3[i];
			}
			array2[array2.Length - 1] = 0;
		}
		int int_ = 0;
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_89.uint_0, array2, array2.Length, ref int_);
	}

	public static void SetCharacterAttackRange(CharacterAccountConfig characterAccountConfig_0, int int_0 = 75)
	{
		WriteCurrentCharacterInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_31.uint_0, int_0);
	}

	public static void SetCharacterCombatState(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		WriteCurrentCharacterInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_43.uint_0, int_0);
	}

	public static void SetCharacterKillerStatus(CharacterAccountConfig characterAccountConfig_0, int int_0 = 0)
	{
		WriteCurrentCharacterInt32Field(characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_56.uint_0, int_0);
	}

	public static void MoveNearSkillTargetPosition(CharacterAccountConfig characterAccountConfig_0, uint[] uint_0, bool bool_0, int int_0 = 10)
	{
		if (!bool_0 && (uint_0 == null || uint_0[0] == 0 || uint_0[1] == 0))
		{
			return;
		}
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		int i = 0;
		int int_1 = 0;
		byte[] array = new byte[4];
		byte[] byte_ = array;
		for (; i < int_0; i++)
		{
			if (bool_0)
			{
				uint num5 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_5 >> 16;
				uint int_2 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_5 - (num5 << 16);
				uint_0 = GameInterfaceMemoryHelper.ConvertScreenToWorldCoordinates(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, (int)int_2, (int)num5);
			}
			if (uint_0 != null && uint_0[0] != 0 && uint_0[1] != 0)
			{
				if (uint_0 != null)
				{
					GameProcessInteractionHelper.smethod_61(characterAccountConfig_0, uint_0);
					Thread.Sleep(200);
				}
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_1);
				uint[] uint_1 = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
				};
				if (GetSquaredCoordinateDistance(uint_1, uint_0) < 11250)
				{
					break;
				}
				continue;
			}
			break;
		}
	}

	public static void CastMaAmPhePhachAtCurrentPosition(CharacterAccountConfig characterAccountConfig_0)
	{
		for (int i = 0; i < 80; i++)
		{
			if (GameProcessInteractionHelper.smethod_3(characterAccountConfig_0, GameProcessInteractionHelper.uint_6, 4) <= 0)
			{
				break;
			}
			Thread.Sleep(10);
		}
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		int int_ = 0;
		byte[] array = new byte[4];
		byte[] byte_ = array;
		array = new byte[4];
		byte[] byte_2 = array;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, byte_2, 4, ref int_);
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, BitConverter.GetBytes(75), 4, ref int_);
		uint uint_ = 5u;
		uint uint_2 = WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137);
		uint uint_3 = WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137);
		for (int j = 0; j < 3; j++)
		{
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_);
			Thread.Sleep(10);
			WindowsInteropHelper.WriteProcessUIntValue(num4 + GameConfigurationManager.memorySignatureScanConfig_37.uint_0, characterAccountConfig_0.int_137, uint_2);
			WindowsInteropHelper.WriteProcessUIntValue(num4 + GameConfigurationManager.memorySignatureScanConfig_38.uint_0, characterAccountConfig_0.int_137, uint_3);
			WindowsInteropHelper.WriteProcessUIntValue(num4 + GameConfigurationManager.memorySignatureScanConfig_36.uint_0, characterAccountConfig_0.int_137, 715u);
			WindowsInteropHelper.WriteProcessUIntValue(num4 + GameConfigurationManager.memorySignatureScanConfig_35.uint_0, characterAccountConfig_0.int_137, uint_);
			Thread.Sleep(210 - j * 100);
		}
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, byte_2, 4, ref int_);
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_35.uint_0, byte_, 4, ref int_);
	}

	public static bool CastVoDangCurseRemovalSkillIfEffectMissing(CharacterAccountConfig characterAccountConfig_0)
	{
		for (int i = 0; i < 80; i++)
		{
			if (GameProcessInteractionHelper.smethod_3(characterAccountConfig_0, GameProcessInteractionHelper.uint_6, 4) <= 0)
			{
				break;
			}
			Thread.Sleep(10);
		}
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		int int_ = 0;
		byte[] array = new byte[4];
		for (uint num5 = 0u; num5 < 6; num5++)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_2.uint_0 + GameConfigurationManager.memorySignatureScanConfig_3.uint_0 * num5, array, 4, ref int_);
			int num6 = BitConverter.ToInt32(array, 0);
			if (num6 == 122)
			{
				return true;
			}
		}
		byte[] array2 = new byte[4];
		byte[] byte_ = array2;
		byte[] byte_2 = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, byte_2, 4, ref int_);
		int j = 0;
		int num7 = -1;
		for (; j < 150; j++)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array, 1, ref int_);
			if (array[0] < 4 && (num7 == -1 || num7 > 80))
			{
				break;
			}
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_);
			num7 = ((array[0] <= 3) ? (num7 + 1) : 0);
			Thread.Sleep(1);
		}
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, byte_, 4, ref int_);
		byte[] byte_3 = new byte[4] { 5, 0, 0, 0 };
		byte[] bytes = BitConverter.GetBytes(716);
		byte[] byte_4 = new byte[4];
		byte[] byte_5 = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, byte_4, 4, ref int_);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, byte_5, 4, ref int_);
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_37.uint_0, byte_4, 4, ref int_);
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_38.uint_0, byte_5, 4, ref int_);
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_36.uint_0, bytes, bytes.Length, ref int_);
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_35.uint_0, byte_3, 4, ref int_);
		Thread.Sleep(100);
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, byte_2, 4, ref int_);
		return false;
	}

	public static void WriteCharacterTitleStatusText(CharacterAccountConfig characterAccountConfig_0, string string_4)
	{
		uint num = GetCurrentCharacterEntityAddress(characterAccountConfig_0);
		if (characterAccountConfig_0.int_137 != 0 && num != 0 && GameConfigurationManager.memorySignatureScanConfig_251.uint_0 != 0)
		{
			byte[] array = CommonUtility.smethod_47(string_4);
			int int_ = 0;
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_251.uint_0, array, array.Length, ref int_);
		}
	}

	public static uint GetCurrentTargetEntityIndexByTypes(CharacterAccountConfig characterAccountConfig_0, int[] int_0)
	{
		if (int_0 == null)
		{
			int_0 = new int[1] { 1 };
		}
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, characterAccountConfig_0.int_137);
		if ((int)num5 > 0)
		{
			uint num6 = num3 + num5 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			if (WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig_0.int_137) == 0)
			{
				return 0u;
			}
			int num7 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_52.uint_0, characterAccountConfig_0.int_137);
			int num8 = 0;
			while (true)
			{
				if (num8 < int_0.Length)
				{
					if (num7 == int_0[num8])
					{
						break;
					}
					num8++;
					continue;
				}
				return 0u;
			}
			return num5;
		}
		return 0u;
	}
}
