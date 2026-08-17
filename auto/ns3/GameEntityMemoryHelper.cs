using System;
using System.Threading;
using ns1;
using ns11;
using ns23;
using ns53;
using ns61;

namespace ns3;

internal class GameEntityMemoryHelper
{
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

	public static int GetEntityCount(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue != 0 && GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 4, ref int_);
			return BitConverter.ToInt32(array, 0);
		}
		return -1;
	}

	public static int ReadEntityInt32AtOffset48(CharacterAccountConfig characterAccountConfig_0, uint uint_0)
	{
		int int_ = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, array, 4, ref int_);
		uint num = BitConverter.ToUInt32(array, 0);
		uint num2 = num + uint_0 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + GameConfigurationManager.memorySignatureScanConfig_85.resolvedValue, array, 4, ref int_);
		return BitConverter.ToInt32(array, 0);
	}

	private static uint ReadEntityUInt32Field(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137) + (uint)(int)(int_0 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue);
		return WindowsInteropHelper.ReadProcessUInt32(num + uint_0, characterAccountConfig_0.int_137);
	}

	private static void WriteEntityInt32Field(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0, int int_1)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137) + (uint)(int)(int_0 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue);
		WindowsInteropHelper.WriteProcessUIntValue(num + uint_0, characterAccountConfig_0.int_137, (uint)int_1);
	}

	private static string ReadEntityStringField(CharacterAccountConfig characterAccountConfig_0, int int_0, uint uint_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137) + (uint)(int)(int_0 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue);
		return WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num + uint_0, characterAccountConfig_0.int_137, 255);
	}

	public static int ReadEntityUInt32AtNpcGoldOffsetPlus8(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_26.resolvedValue + 8);
	}

	public static int ReadQuarteredEntityUInt32AtNpcGoldOffsetPlus12(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_26.resolvedValue + 12) / 4;
	}

	public static int GetEntityCombatStateByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue);
	}

	public static int GetEntityTypeByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue);
	}

	public static int ReadEntitySexValue(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_17.resolvedValue);
	}

	public static int GetEntityPresenceValueByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue);
	}

	public static int GetEntityActionStateByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue);
	}

	public static int FindMatchingEntityIndexByNameAndType(CharacterAccountConfig characterAccountConfig_0, string string_0, int int_0 = -1, bool bool_0 = false, int int_1 = -1, int int_2 = 80)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			string[] array = string_0.Split('|');
			string[] array2 = new string[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = array[i].Trim().ToLower();
			}
			uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
			uint num4 = num3 + num2;
			int num5 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137);
			int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137);
			int int_3 = 0;
			byte[] array3 = new byte[int_2];
			byte[] array4 = new byte[4];
			uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array4, 4, ref int_3);
			int num7 = BitConverter.ToInt32(array4, 0);
			if (num7 <= 0)
			{
				return -1;
			}
			int num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137);
			int num9 = 0;
			for (uint num10 = 1u; num10 < 256 && num7 > num9; num10++)
			{
				if (num10 == num8)
				{
					num9++;
					continue;
				}
				uint num11 = num3 + num10 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array4, 4, ref int_3);
				if (array4[0] == 0)
				{
					continue;
				}
				num9++;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array4, 4, ref int_3);
				if (BitConverter.ToInt32(array4, 0) <= 0)
				{
					continue;
				}
				if (0 <= int_0)
				{
					int num12 = (int)WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, characterAccountConfig_0.int_137);
					if (num12 != int_0)
					{
						continue;
					}
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array3, array3.Length, ref int_3);
				string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array3);
				if (text == string.Empty)
				{
					continue;
				}
				string string_1 = text.Trim().ToLower();
				bool flag = false;
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j] == text || (!bool_0 && 0 <= CommonUtility.FindSubstringIndex(string_1, array2[j])))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				if (int_1 > 0 && num5 > 0 && num6 > 0)
				{
					int num13 = (int)WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137);
					int num14 = (int)WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137);
					if (num13 > 0 && num14 > 0)
					{
						long num15 = num5 - num13;
						long num16 = num6 - num14;
						if (num15 * num15 + num16 * num16 <= int_1)
						{
							return (int)num10;
						}
					}
					continue;
				}
				return (int)num10;
			}
			return -1;
		}
		return -1;
	}

	public static int FindEntityIndexByNameAndType(CharacterAccountConfig characterAccountConfig_0, string string_0, ref uint[] uint_0, int int_0 = 1)
	{
		uint_0 = null;
		if (string_0 != null && !(string_0 == string.Empty))
		{
			int int_1 = 0;
			byte[] array = new byte[80];
			uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
			byte[] array2 = new byte[4];
			uint uint_1 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_1, array2, 4, ref int_1);
			int num2 = BitConverter.ToInt32(array2, 0);
			if (num2 > 0)
			{
				int num3 = 0;
				for (uint num4 = 1u; num4 < 256; num4++)
				{
					if (num2 <= num3)
					{
						break;
					}
					uint num5 = num + num4 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array2, 4, ref int_1);
					if (array2[0] == 0)
					{
						continue;
					}
					num3++;
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array2, 4, ref int_1);
					if (BitConverter.ToInt32(array2, 0) > 0 && WindowsInteropHelper.ReadProcessUInt32(num5 + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, characterAccountConfig_0.int_137) == int_0)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array, array.Length, ref int_1);
						if (!(GameTextEncodingHelper.DecodeNullTerminatedUtf7(array) != string_0))
						{
							uint_0 = new uint[2]
							{
								WindowsInteropHelper.ReadProcessUInt32(num5 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
								WindowsInteropHelper.ReadProcessUInt32(num5 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
							};
							return (int)num4;
						}
					}
				}
				return -1;
			}
			return -1;
		}
		return -1;
	}

	public static int FindNearestEntityIndexByNameAndType(CharacterAccountConfig characterAccountConfig_0, string string_0, ref uint[] uint_0, int int_0 = 3, bool bool_0 = true, int int_1 = -1, int[] int_2 = null)
	{
		uint_0 = null;
		if (string_0 != null && !(string_0 == string.Empty))
		{
			string[] array = string_0.Split('|');
			string[] array2 = new string[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i].Trim();
				array2[i] = array[i].ToUpper();
			}
			uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
			uint num4 = num3 + num2;
			uint[] uint_1 = new uint[2]
			{
				WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
				WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
			};
			int int_3 = 0;
			byte[] array3 = new byte[80];
			byte[] array4 = new byte[4];
			uint uint_2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_2, array4, 4, ref int_3);
			int num5 = BitConverter.ToInt32(array4, 0);
			if (num5 <= 0)
			{
				return 0;
			}
			long num6 = 0L;
			long num7 = 0L;
			uint num8 = 0u;
			int num9 = 0;
			for (uint num10 = 1u; num10 < 256; num10++)
			{
				if (num10 % 50 == 0)
				{
					Thread.Sleep(30);
				}
				if (num5 <= num9)
				{
					break;
				}
				uint num11 = num3 + num10 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array4, 4, ref int_3);
				if (array4[0] == 0)
				{
					continue;
				}
				num9++;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array4, 4, ref int_3);
				if (BitConverter.ToInt32(array4, 0) <= 0 || WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, characterAccountConfig_0.int_137) != int_0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array3, array3.Length, ref int_3);
				string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array3).Trim();
				string string_1 = text.ToUpper();
				bool flag = false;
				for (int j = 0; j < array.Length; j++)
				{
					if (text == array[j] || (!bool_0 && 0 <= CommonUtility.FindSubstringIndex(string_1, array2[j])))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				if (int_2 != null)
				{
					for (int k = 0; k < int_2.Length; k++)
					{
						if (int_2[k] == num10)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					uint[] array5 = new uint[2]
					{
						WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
						WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
					};
					num7 = Class64.GetSquaredCoordinateDistance(uint_1, array5);
					if ((int_1 <= 0 || num7 <= int_1 * int_1) && (num8 == 0 || num7 < num6))
					{
						num8 = num10;
						uint_0 = new uint[2]
						{
							array5[0],
							array5[1]
						};
						num6 = num7;
					}
				}
			}
			return (int)num8;
		}
		return -1;
	}

	public static string GetEntityNameAndPositionByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0, ref uint[] uint_0, int int_1 = 60)
	{
		uint_0 = null;
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num3 = num2 + (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue);
		if ((int)WindowsInteropHelper.ReadProcessUInt32(num3 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_0.int_137) <= 0)
		{
			return string.Empty;
		}
		int int_2 = 0;
		byte[] array = new byte[1];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num3 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array, 1, ref int_2);
		if (array[0] == 0)
		{
			return string.Empty;
		}
		array = new byte[int_1];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num3 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array, int_1, ref int_2);
		uint_0 = new uint[2]
		{
			WindowsInteropHelper.ReadProcessUInt32(num3 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
			WindowsInteropHelper.ReadProcessUInt32(num3 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
		};
		return GameTextEncodingHelper.DecodeNullTerminatedUtf7(array);
	}

	public static bool IsEntityPresentByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num3 = num2 + (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue);
		int int_1 = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num3 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array, 4, ref int_1);
		return BitConverter.ToInt32(array, 0) > 0;
	}

	public static int FindNearestEntityIndexByNamePrefix(CharacterAccountConfig characterAccountConfig_0, string string_0, ref uint[] uint_0, int int_0 = 60000, uint[] uint_1 = null)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137);
		uint num3 = num2 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num5 = num4 + num3;
		if (uint_1 == null)
		{
			uint_1 = new uint[2]
			{
				WindowsInteropHelper.ReadProcessUInt32(num5 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
				WindowsInteropHelper.ReadProcessUInt32(num5 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
			};
		}
		char[] array = string_0.ToCharArray();
		int int_1 = 0;
		byte[] array2 = new byte[80];
		byte[] array3 = new byte[4];
		uint uint_2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_2, array3, 4, ref int_1);
		int num6 = BitConverter.ToInt32(array3, 0);
		if (num6 <= 1)
		{
			return 0;
		}
		uint num7 = 0u;
		long num8 = 0L;
		long num9 = 0L;
		int num10 = 0;
		for (uint num11 = 1u; num11 < 256; num11++)
		{
			if (num6 <= num10)
			{
				break;
			}
			if (num11 == num2)
			{
				num10++;
				continue;
			}
			uint num12 = num4 + num11 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num12 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array3, 4, ref int_1);
			if (array3[0] == 0)
			{
				continue;
			}
			num10++;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num12 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array3, 4, ref int_1);
			if (BitConverter.ToInt32(array3, 0) <= 0 || WindowsInteropHelper.ReadProcessUInt32(num12 + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, characterAccountConfig_0.int_137) != 3)
			{
				continue;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num12 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array2, 1, ref int_1);
			if (array2[0] != array[0])
			{
				continue;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num12 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array2, array2.Length, ref int_1);
			if (GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2).IndexOf(string_0) == 0)
			{
				uint[] array4 = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num12 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num12 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
				};
				num9 = GetSquaredCoordinateDistance(uint_1, array4);
				if (num9 > 0L && num9 < int_0 && (num7 == 0 || num9 < num8))
				{
					num7 = num11;
					num8 = num9;
					uint_0 = array4;
				}
			}
		}
		return (int)num7;
	}

	public static uint[] GetEntityPositionByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		uint num = ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue);
		uint num2 = ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue);
		if (num != 0 && num2 != 0)
		{
			return new uint[2] { num, num2 };
		}
		return null;
	}

	public static long[] GetEntityHitPointValuesByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return new long[2]
		{
			ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_45.resolvedValue),
			ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_47.resolvedValue)
		};
	}

	public static long[] GetEntityManaPointValuesByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return new long[2]
		{
			ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_46.resolvedValue),
			ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_48.resolvedValue)
		};
	}

	public static string GetEntityNameByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0, int int_1 = 0)
	{
		string result = "";
		int num = GetEntityPresenceValueByIndex(characterAccountConfig_0, int_0);
		int num2 = GetEntityTypeByIndex(characterAccountConfig_0, int_0);
		if (num > 0 && (int_1 < 0 || num2 == int_1))
		{
			result = ReadEntityStringField(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue);
		}
		return result;
	}

	public static string GetEntityGuildNameByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = num + (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue);
		int int_1 = 0;
		byte[] array = new byte[30];
		byte[] array2 = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + GameConfigurationManager.memorySignatureScanConfig_88.resolvedValue, array2, 4, ref int_1);
		uint num3 = BitConverter.ToUInt32(array2, 0);
		if (num3 != 0)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + GameConfigurationManager.memorySignatureScanConfig_89.resolvedValue, array, array.Length, ref int_1);
			string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array);
			if (!(text == string.Empty))
			{
				if (CommonUtility.ComputeLegacyStringHash(text) != num3)
				{
					string text2 = string.Empty;
					int num4 = 0;
					while (true)
					{
						if (num4 < text.Length)
						{
							text2 += text[num4];
							if (CommonUtility.ComputeLegacyStringHash(text2) == num3)
							{
								break;
							}
							num4++;
							continue;
						}
						return string.Empty;
					}
					return text2;
				}
				return text;
			}
			return string.Empty;
		}
		return string.Empty;
	}

	public static void CollectEntityGuildNames(CharacterAccountConfig characterAccountConfig_0, ref string[] string_0)
	{
		byte[] array = new byte[48];
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		int int_ = 0;
		byte[] array2 = new byte[4];
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array2, 4, ref int_);
		int num2 = BitConverter.ToInt32(array2, 0);
		int num3 = 0;
		for (uint num4 = 1u; num4 < 256; num4++)
		{
			if (num2 <= num3)
			{
				break;
			}
			uint num5 = num + num4 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array2, 4, ref int_);
			if (array2[0] == 0)
			{
				continue;
			}
			num3++;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array2, 4, ref int_);
			if (BitConverter.ToInt32(array2, 0) <= 0)
			{
				continue;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_88.resolvedValue, array2, 4, ref int_);
			uint num6 = BitConverter.ToUInt32(array2, 0);
			if (num6 == 0)
			{
				continue;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_89.resolvedValue, array, array.Length, ref int_);
			string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array);
			if (text == null || text == string.Empty)
			{
				continue;
			}
			string text2 = string.Empty;
			if (CommonUtility.ComputeLegacyStringHash(text) != num6)
			{
				string text3 = string.Empty;
				for (int i = 0; i < text.Length; i++)
				{
					text3 += text[i];
					if (CommonUtility.ComputeLegacyStringHash(text3) == num6)
					{
						text2 = text3;
						break;
					}
				}
			}
			else
			{
				text2 = text;
			}
			if (text2 == string.Empty)
			{
				continue;
			}
			if (string_0 != null)
			{
				bool flag = false;
				for (int j = 0; j < string_0.Length; j++)
				{
					if (text2 == string_0[j])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Array.Resize(ref string_0, string_0.Length + 1);
					string_0[string_0.Length - 1] = text2;
				}
			}
			else
			{
				string_0 = new string[1] { text2 };
			}
		}
	}

	public static void CollectEntityNames(CharacterAccountConfig characterAccountConfig_0, ref string[] string_0, int int_0 = -1, string[] string_1 = null)
	{
		byte[] array = new byte[53];
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		int int_1 = 0;
		byte[] array2 = new byte[4];
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array2, 4, ref int_1);
		int num2 = BitConverter.ToInt32(array2, 0);
		int num3 = 0;
		for (uint num4 = 1u; num4 < 256 && num2 > num3; num4++)
		{
			uint num5 = num + num4 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array2, 4, ref int_1);
			if (array2[0] == 0)
			{
				continue;
			}
			num3++;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array2, 4, ref int_1);
			if (BitConverter.ToInt32(array2, 0) <= 0)
			{
				continue;
			}
			if (0 <= int_0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, array2, 4, ref int_1);
				uint num6 = BitConverter.ToUInt32(array2, 0);
				if (num6 != int_0)
				{
					continue;
				}
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array, array.Length, ref int_1);
			string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array);
			if (text == string.Empty)
			{
				continue;
			}
			if (string_1 != null)
			{
				bool flag = false;
				for (int i = 0; i < string_1.Length; i++)
				{
					if (text == string_1[i])
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
			}
			if (string_0 != null)
			{
				bool flag2 = false;
				for (int j = 0; j < string_0.Length; j++)
				{
					if (text == string_0[j])
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					Array.Resize(ref string_0, string_0.Length + 1);
					string_0[string_0.Length - 1] = text;
				}
			}
			else
			{
				string_0 = new string[1] { text };
			}
		}
	}

	public static void CollectEntityLocationRecords(CharacterAccountConfig characterAccountConfig_0, ref NamedMapLocation[] gstruct25_0, int int_0 = -1, string[] string_0 = null)
	{
		byte[] array = new byte[53];
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		int int_1 = 0;
		byte[] array2 = new byte[4];
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array2, 4, ref int_1);
		int num2 = BitConverter.ToInt32(array2, 0);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, array2, 4, ref int_1);
		int int_2 = BitConverter.ToInt32(array2, 0);
		int num3 = 0;
		for (uint num4 = 1u; num4 < 256 && num2 > num3; num4++)
		{
			uint num5 = num + num4 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array2, 4, ref int_1);
			if (array2[0] == 0)
			{
				continue;
			}
			num3++;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array2, 4, ref int_1);
			if (BitConverter.ToInt32(array2, 0) <= 0)
			{
				continue;
			}
			if (0 <= int_0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, array2, 4, ref int_1);
				uint num6 = BitConverter.ToUInt32(array2, 0);
				if (num6 != int_0)
				{
					continue;
				}
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array, array.Length, ref int_1);
			string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array);
			if (text == string.Empty)
			{
				continue;
			}
			if (string_0 != null)
			{
				bool flag = false;
				for (int i = 0; i < string_0.Length; i++)
				{
					if (text == string_0[i])
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, array2, 4, ref int_1);
			uint num7 = BitConverter.ToUInt32(array2, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, array2, 4, ref int_1);
			uint num8 = BitConverter.ToUInt32(array2, 0);
			if (gstruct25_0 != null)
			{
				bool flag2 = false;
				for (int j = 0; j < gstruct25_0.Length; j++)
				{
					if (text == gstruct25_0[j].name)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					Array.Resize(ref gstruct25_0, gstruct25_0.Length + 1);
					gstruct25_0[gstruct25_0.Length - 1].name = text;
					gstruct25_0[gstruct25_0.Length - 1].coordinates = new uint[2] { num7, num8 };
					gstruct25_0[gstruct25_0.Length - 1].mapId = int_2;
				}
			}
			else
			{
				gstruct25_0 = new NamedMapLocation[1]
				{
					new NamedMapLocation
					{
						name = text,
						coordinates = new uint[2] { num7, num8 },
						mapId = int_2
					}
				};
			}
		}
	}

	public static int GetEntityProfileStatusByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_66.resolvedValue);
	}

	public static int GetEntityKillerStatusByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_56.resolvedValue);
	}

	public static int GetEntityColorCodeByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		int num = (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, GameConfigurationManager.memorySignatureScanConfig_54.resolvedValue);
		if (num > 4)
		{
			num = 5;
		}
		return num;
	}

	public static int GetEntityActiveEffectIdBySlot(CharacterAccountConfig characterAccountConfig_0, int int_0, int int_1)
	{
		uint uint_ = GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_2.resolvedValue + (uint)((int)GameConfigurationManager.memorySignatureScanConfig_3.resolvedValue * int_1);
		return (int)ReadEntityUInt32Field(characterAccountConfig_0, int_0, uint_);
	}

	public static int GetEntityActiveEffectIdForSkill(CharacterAccountConfig characterAccountConfig_0, int int_0, int int_1)
	{
		int num = 0;
		if (characterAccountConfig_0.int_4 == null)
		{
			return -1;
		}
		for (int i = 0; i < characterAccountConfig_0.int_4.GetLength(0); i++)
		{
			if (int_1 == characterAccountConfig_0.int_4[i, 0])
			{
				num = characterAccountConfig_0.int_4[i, 1];
				break;
			}
		}
		if (num == 0)
		{
			return -1;
		}
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num3 = num2 + (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue);
		for (uint num4 = 0u; num4 < 6; num4++)
		{
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(num3 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_2.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_3.resolvedValue * num4, characterAccountConfig_0.int_137);
			if (num5 == num)
			{
				return num;
			}
		}
		return 0;
	}
}
