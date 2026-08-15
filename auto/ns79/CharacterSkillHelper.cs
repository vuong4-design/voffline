using System;
using ns1;
using ns10;
using ns11;
using ns23;
using ns53;
using ns71;

namespace ns79;

internal class CharacterSkillHelper
{
	public static int[,] int_0;

	public static uint uint_0;

	public static uint uint_1;

	public static uint uint_2;

	public static GStruct57[] gstruct57_0;

	public static GStruct58[] gstruct58_0;

	private static int[,] int_1;

	private static int[,] int_2;

	static CharacterSkillHelper()
	{
		int_0 = null;
		uint_0 = 4u;
		uint_1 = 72u;
		uint_2 = 172u;
		gstruct57_0 = new GStruct57[11]
		{
			new GStruct57
			{
				factionId = 1,
				factionCode = "THIEULAM",
				skillIds = new int[8] { 1, 2, 3, 4, 5, 6, 62, 72 }
			},
			new GStruct57
			{
				factionId = 2,
				factionCode = "VODANG",
				skillIds = new int[8] { 7, 8, 9, 10, 11, 12, 63, 73 }
			},
			new GStruct57
			{
				factionId = 3,
				factionCode = "NGAMY",
				skillIds = new int[8] { 13, 14, 15, 16, 17, 18, 64, 74 }
			},
			new GStruct57
			{
				factionId = 4,
				factionCode = "CONLON",
				skillIds = new int[8] { 19, 20, 21, 22, 23, 24, 65, 75 }
			},
			new GStruct57
			{
				factionId = 5,
				factionCode = "DUONGMON",
				skillIds = new int[8] { 25, 26, 27, 28, 29, 30, 66, 76 }
			},
			new GStruct57
			{
				factionId = 6,
				factionCode = "THUYYEN",
				skillIds = new int[8] { 31, 32, 33, 34, 35, 36, 67, 77 }
			},
			new GStruct57
			{
				factionId = 7,
				factionCode = "CAIBANG",
				skillIds = new int[8] { 37, 38, 39, 40, 41, 42, 68, 78 }
			},
			new GStruct57
			{
				factionId = 8,
				factionCode = "THIENVUONG",
				skillIds = new int[8] { 43, 44, 45, 46, 47, 48, 69, 79 }
			},
			new GStruct57
			{
				factionId = 9,
				factionCode = "NGUDOC",
				skillIds = new int[8] { 49, 50, 51, 52, 53, 54, 70, 80 }
			},
			new GStruct57
			{
				factionId = 10,
				factionCode = "THIENNHAN",
				skillIds = new int[8] { 55, 56, 57, 58, 59, 60, 71, 81 }
			},
			new GStruct57
			{
				factionId = 11,
				factionCode = "HOASON",
				skillIds = new int[8] { 82, 83, 84, 85, 86, 87, 88, 89 }
			}
		};
		gstruct58_0 = new GStruct58[11]
		{
			new GStruct58
			{
				skillId = 10,
				skillName = "THIEULAM",
				alternateName = "ThiÕu L©m"
			},
			new GStruct58
			{
				skillId = 29,
				skillName = "THIENVUONG",
				alternateName = "Thiªn V\u00ad¬ng"
			},
			new GStruct58
			{
				skillId = 45,
				skillName = "DUONGMON",
				alternateName = "§\u00adêng M«n"
			},
			new GStruct58
			{
				skillId = 63,
				skillName = "NGUDOC",
				alternateName = "Ngò §éc"
			},
			new GStruct58
			{
				skillId = 80,
				skillName = "NGAMY",
				alternateName = "Nga My"
			},
			new GStruct58
			{
				skillId = 99,
				skillName = "THUYYEN",
				alternateName = "Thóy Yªn"
			},
			new GStruct58
			{
				skillId = 1347,
				skillName = "HOASON",
				alternateName = "Hoa S¬n"
			},
			new GStruct58
			{
				skillId = 122,
				skillName = "CAIBANG",
				alternateName = "C\u00b8i Bang"
			},
			new GStruct58
			{
				skillId = 135,
				skillName = "THIENNHAN",
				alternateName = "Thiªn NhÉn"
			},
			new GStruct58
			{
				skillId = 153,
				skillName = "VODANG",
				alternateName = "Vâ §ang"
			},
			new GStruct58
			{
				skillId = 169,
				skillName = "CONLON",
				alternateName = "C«n L«n"
			}
		};
		int[,] array_ = new int[34, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_, 348707);
		int_1 = array_;
		int_2 = new int[1, 2] { { 67, 174 } };
	}

	public static int MapNumericCodeToFactionIndex(int int_3)
	{
		int num = 0;
		if (1 <= int_3 && int_3 <= 60)
		{
			num = int_3 / 6;
			if (int_3 % 6 > 0)
			{
				num++;
			}
		}
		else if (62 <= int_3 && int_3 <= 71)
		{
			num = int_3 - 61;
		}
		else if (72 <= int_3 && int_3 <= 81)
		{
			num = int_3 - 71;
		}
		else if (82 <= int_3 && int_3 <= 89)
		{
			num = 11;
		}
		return num;
	}

	public static string MapNumericCodeToFactionIdentifier(int int_3)
	{
		string result = string.Empty;
		int num = MapNumericCodeToFactionIndex(int_3);
		if (num > 0)
		{
			result = gstruct57_0[num - 1].factionCode;
		}
		return result;
	}

    public static int[] GetDefaultRightSkillIdsForCurrentFaction(CharacterAccountConfig characterAccountConfig_0)
    {
        string text = ResolveFactionIdentifier(characterAccountConfig_0);

        if (string.IsNullOrEmpty(text)) return null;

        switch (text.ToUpper()) // Thêm ToUpper để tránh lỗi chữ hoa chữ thường
        {
            case "CONLON":
                return new int[] { 173, 171 };
            case "THIENVUONG":
                return new int[] { 42, 33 };
            case "HOASON":
                return new int[] { 1358 };
            case "VODANG":
                return new int[] { 157 };
            case "THIEULAM":
                return new int[] { 15, 273 };
            case "THUYYEN":
                return new int[] { 109, 100 };
            case "CAIBANG":
                return new int[] { 130, 277 };
            case "THIENNHAN":
                return new int[] { 150 };
            default:
                return null;
        }
    }
    

    public static int MapInfectValueToSkillId(int int_3)
	{
		int num = 0;
		while (true)
		{
			if (num < int_1.GetLength(0))
			{
				if (int_3 == int_1[num, 0])
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return int_1[num, 1];
	}

	public static uint[] GetFactionSpecificSkillIds(CharacterAccountConfig characterAccountConfig_0)
	{
		return ResolveFactionIdentifier(characterAccountConfig_0) switch
		{
			"THIEULAM" => new uint[1] { 14u }, 
			"CAIBANG" => new uint[2] { 122u, 128u }, 
			"VODANG" => new uint[2] { 153u, 164u }, 
			"CONLON" => new uint[1] { 179u }, 
			"THUYYEN" => new uint[1] { 102u }, 
			"THIENNHAN" => new uint[2] { 145u, 138u }, 
			_ => null, 
		};
	}

	public static bool SetDirectShortcutSkillSlot(CharacterAccountConfig characterAccountConfig_0, int int_3, byte byte_0, byte byte_1 = 1)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_160.resolvedValue != 0)
		{
			if (byte_0 >= 2)
			{
				if (byte_0 > 10)
				{
					byte_0 = 10;
				}
			}
			else
			{
				byte_0 = 2;
			}
			byte_0 -= 2;
			int int_4 = 0;
			byte[] bytes = BitConverter.GetBytes(int_3);
			byte[] byte_2 = new byte[4] { 4, 0, 4, 0 };
			byte[] byte_3 = new byte[4] { 1, 0, 0, 0 };
			uint num = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_160.resolvedValue;
			uint num2 = num + (uint)(byte_0 * 16);
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, byte_2, 4, ref int_4);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2 + 4, bytes, 4, ref int_4);
			bool flag3 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2 + 8, byte_3, 4, ref int_4);
			return flag && flag2 && flag3;
		}
		return false;
	}

	public static uint[] FindShortcutEntryByName(CharacterAccountConfig characterAccountConfig_0, string string_0)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_92.resolvedValue != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			byte[] array2 = new byte[string_0.Length + 3];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_92.resolvedValue + 16, array, 4, ref int_);
			int num = BitConverter.ToInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_92.resolvedValue, array, 4, ref int_);
			uint num2 = BitConverter.ToUInt32(array, 0);
			for (uint num3 = 0u; num > num3; num3++)
			{
				uint num4 = num2 + num3 * GameConfigurationManager.memorySignatureScanConfig_91.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4, array, 4, ref int_);
				uint num5 = BitConverter.ToUInt32(array, 0);
				if (num5 != 0)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_93.resolvedValue, array2, array2.Length, ref int_);
					string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2);
					if (string_0 == text)
					{
						return new uint[2] { num3, num5 };
					}
				}
			}
			return null;
		}
		return null;
	}

	public static uint ReadShortcutEntryValueByIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_3)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_92.resolvedValue != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_92.resolvedValue, array, 4, ref int_);
			uint num = BitConverter.ToUInt32(array, 0);
			uint uint_4 = num + uint_3 * GameConfigurationManager.memorySignatureScanConfig_91.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_4, array, 4, ref int_);
			return BitConverter.ToUInt32(array, 0);
		}
		return 0u;
	}

	public static string ReadShortcutEntryNameByIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_3)
	{
		string result = string.Empty;
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_92.resolvedValue != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			byte[] array2 = new byte[80];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_92.resolvedValue, array, 4, ref int_);
			uint num = BitConverter.ToUInt32(array, 0);
			uint num2 = num + uint_3 * GameConfigurationManager.memorySignatureScanConfig_91.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2, array, 4, ref int_);
			if (BitConverter.ToUInt32(array, 0) != 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + GameConfigurationManager.memorySignatureScanConfig_93.resolvedValue, array2, array2.Length, ref int_);
				result = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2);
			}
			return result;
		}
		return result;
	}

	public static void EnsureDirectShortcutSkillReference(CharacterAccountConfig characterAccountConfig_0, string string_0 = null)
	{
		int num = GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_36, 4);
		if (num > 0 && ReadShortcutEntryValueByIndex(characterAccountConfig_0, (uint)num) == 0)
		{
			num = 0;
		}
		if (num > 0)
		{
			return;
		}
		GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_36, 0, 4);
		GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_36 + 4, 0, 4);
		if (string_0 == null)
		{
			string_0 = "DirectShortcutSkill(4)";
		}
		uint[] array = FindShortcutEntryByName(characterAccountConfig_0, string_0);
		if (array == null)
		{
			int num2 = GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_36 + 8, 4);
			int second = DateTime.Now.Second;
			if (Math.Abs(second - num2) > 15)
			{
				GameProcessInteractionHelper.SetCombinedShortcutModeEnabled(characterAccountConfig_0, enabled: true);
				GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_36 + 8, second, 4);
			}
		}
		else
		{
			GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_36, (int)array[0], 4);
			GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_36 + 4, (int)array[1], 4);
		}
	}

	public static int ReadTotalSkillPoints(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		return (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_71.resolvedValue, characterAccountConfig_0.int_137);
	}

	public static bool ContainsSkillId(GStruct58[] gstruct58_1, int int_3)
	{
		if (gstruct58_1 != null)
		{
			for (int i = 0; i < gstruct58_1.Length; i++)
			{
				if (gstruct58_1[i].skillId == int_3)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static int FindSkillIdByName(GStruct58[] gstruct58_1, string string_0)
	{
		if (gstruct58_1 != null)
		{
			for (int i = 0; i < gstruct58_1.Length; i++)
			{
				if (string_0 == gstruct58_1[i].skillName)
				{
					return gstruct58_1[i].skillId;
				}
			}
		}
		return 0;
	}

	public static int ReadLeftSkillId(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		return (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_12.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_68.resolvedValue, characterAccountConfig_0.int_137);
	}

	public static int ReadRightSkillId(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		return (int)WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_12.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_70.resolvedValue, characterAccountConfig_0.int_137);
	}

	public static void WriteSelectedSkillIdToCharacterMemory(CharacterAccountConfig characterAccountConfig_0, uint uint_3 = 0u, bool bool_0 = false)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint uint_4;
		if (uint_3 == 0)
		{
			uint_4 = (bool_0 ? (num + GameConfigurationManager.memorySignatureScanConfig_12.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_70.resolvedValue) : (num + GameConfigurationManager.memorySignatureScanConfig_12.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_68.resolvedValue));
			uint_3 = WindowsInteropHelper.ReadProcessUInt32(uint_4, characterAccountConfig_0.int_137);
		}
		uint_4 = num2 + num3 + GameConfigurationManager.memorySignatureScanConfig_161.resolvedValue - (uint)(4 * (1 + Convert.ToByte(!bool_0)));
		WindowsInteropHelper.WriteProcessUIntValue(uint_4, characterAccountConfig_0.int_137, uint_3);
	}

	public static int ReadSkillLevel(CharacterAccountConfig characterAccountConfig_0, int int_3)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num4 = num2 + num3 + GameConfigurationManager.memorySignatureScanConfig_161.resolvedValue;
		num4 += GameConfigurationManager.memorySignatureScanConfig_162.resolvedValue;
		int num5 = 0;
		while (true)
		{
			if (num5 < 80)
			{
				num5++;
				uint num6 = WindowsInteropHelper.ReadProcessUInt32(num4, characterAccountConfig_0.int_137);
				if (num6 == int_3)
				{
					break;
				}
				num4 += GameConfigurationManager.memorySignatureScanConfig_163.resolvedValue;
				continue;
			}
			return -1;
		}
		return (int)WindowsInteropHelper.ReadProcessUInt32(num4 + 4, characterAccountConfig_0.int_137);
	}

	public static string GetFactionDisplayName(string string_0)
	{
		if (string_0 != null && string_0 != string.Empty)
		{
			for (int i = 0; i < gstruct58_0.Length; i++)
			{
				if (CommonUtility.FindSubstringIndex(string_0, gstruct58_0[i].skillName) != 0 && CommonUtility.FindSubstringIndex(gstruct58_0[i].skillName, string_0) != 0)
				{
					if (CommonUtility.FindSubstringIndex(string_0, gstruct58_0[i].alternateName) == 0 || CommonUtility.FindSubstringIndex(gstruct58_0[i].alternateName, string_0) == 0)
					{
						return gstruct58_0[i].alternateName;
					}
					continue;
				}
				return gstruct58_0[i].alternateName;
			}
		}
		return null;
	}

	public static string ResolveFactionIdentifier(CharacterAccountConfig characterAccountConfig_0, string string_0 = null)
	{
		if (string_0 != null && string_0 != string.Empty)
		{
			for (int i = 0; i < gstruct58_0.Length; i++)
			{
				if (CommonUtility.FindSubstringIndex(string_0, gstruct58_0[i].alternateName) != 0 && CommonUtility.FindSubstringIndex(gstruct58_0[i].alternateName, string_0) != 0)
				{
					if (CommonUtility.FindSubstringIndex(string_0, gstruct58_0[i].skillName) == 0 || CommonUtility.FindSubstringIndex(gstruct58_0[i].skillName, string_0) == 0)
					{
						return gstruct58_0[i].alternateName;
					}
					continue;
				}
				return gstruct58_0[i].skillName;
			}
		}
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num4 = num2 + num3 + GameConfigurationManager.memorySignatureScanConfig_161.resolvedValue;
		num4 += GameConfigurationManager.memorySignatureScanConfig_162.resolvedValue;
		int num5 = 0;
		while (num5 < 80)
		{
			num5++;
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(num4, characterAccountConfig_0.int_137);
			if (num6 != 0)
			{
				for (int j = 0; j < gstruct58_0.Length; j++)
				{
					if (gstruct58_0[j].skillId == num6)
					{
						return gstruct58_0[j].skillName;
					}
				}
			}
			num4 += GameConfigurationManager.memorySignatureScanConfig_163.resolvedValue;
		}
		return string.Empty;
	}

	public static string ReadSkillName(CharacterAccountConfig characterAccountConfig_0, int int_3, int int_4 = 1, bool bool_0 = false)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_263.resolvedValue == 0)
		{
			return string.Empty;
		}
		if (int_4 < 0)
		{
			int_4 = 0;
		}
		int int_5 = 0;
		byte[] array = new byte[4];
		byte[] array2 = new byte[60];
		string text = string.Empty;
		uint num = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_263.resolvedValue;
		uint num2 = (uint)(((int_3 << 6) + int_4) * 4);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + num2 - 4, array, 4, ref int_5);
		uint num3 = BitConverter.ToUInt32(array, 0);
		if (num3 != 0)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num3 + uint_0, array2, array2.Length, ref int_5);
			text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2);
		}
		if (text == null || text == string.Empty)
		{
			num2 = (uint)(int_3 << 8);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + num2, array, 4, ref int_5);
			num3 = BitConverter.ToUInt32(array, 0);
			if (num3 != 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num3 + uint_0, array2, array2.Length, ref int_5);
				text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2);
			}
		}
		if (bool_0 && text != null && text != string.Empty)
		{
			text = GameTextEncodingHelper.ConvertGameTextToDisplayText(text, 1);
		}
		return text;
	}

	public static int ReadSkillRange(CharacterAccountConfig characterAccountConfig_0, int int_3, int int_4 = 1)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_263.resolvedValue == 0)
		{
			return 0;
		}
		if (int_4 < 0)
		{
			int_4 = 0;
		}
		int int_5 = 0;
		int num = 0;
		byte[] array = new byte[4];
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_263.resolvedValue;
		uint num3 = (uint)(((int_3 << 6) + int_4) * 4);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + num3 - 4, array, 4, ref int_5);
		uint num4 = BitConverter.ToUInt32(array, 0);
		if (num4 != 0)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + uint_1, array, 4, ref int_5);
			num = BitConverter.ToInt32(array, 0);
		}
		if (num == 0)
		{
			num3 = (uint)(int_3 << 8);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + num3, array, 4, ref int_5);
			num4 = BitConverter.ToUInt32(array, 0);
			if (num4 != 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + uint_1, array, 4, ref int_5);
				num = BitConverter.ToInt32(array, 0);
			}
		}
		return num;
	}

	public static int ReadSkillRecordByteAtConfiguredOffset(CharacterAccountConfig characterAccountConfig_0, int int_3)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_263.resolvedValue != 0)
		{
			int int_4 = 0;
			int result = 0;
			byte[] array = new byte[4];
			uint num = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_263.resolvedValue;
			uint num2 = (uint)(int_3 << 8);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + num2, array, 4, ref int_4);
			uint num3 = BitConverter.ToUInt32(array, 0);
			if (num3 != 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num3 + uint_2, array, 1, ref int_4);
				result = array[0];
			}
			return result;
		}
		return 0;
	}

	public static GStruct58[] ReadLearnedSkills(CharacterAccountConfig characterAccountConfig_0, int int_3 = -1)
	{
		int int_4 = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, array, 4, ref int_4);
		uint num = BitConverter.ToUInt32(array, 0);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, array, 4, ref int_4);
		uint num2 = BitConverter.ToUInt32(array, 0) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, array, 4, ref int_4);
		uint num3 = BitConverter.ToUInt32(array, 0);
		uint num4 = num2 + num3 + GameConfigurationManager.memorySignatureScanConfig_161.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_162.resolvedValue;
		int num5 = 0;
		GStruct58[] array2 = null;
		while (num5 < 73)
		{
			num5++;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4, array, 4, ref int_4);
			int num6 = BitConverter.ToInt32(array, 0);
			if (num6 > 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + 4, array, 4, ref int_4);
				int num7 = BitConverter.ToInt32(array, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + 8, array, 4, ref int_4);
				int num8 = BitConverter.ToInt32(array, 0);
				if (num7 < num8)
				{
					num7 = num8;
				}
				if (int_3 <= num7)
				{
					if (array2 == null)
					{
						array2 = new GStruct58[1];
					}
					else
					{
						Array.Resize(ref array2, array2.Length + 1);
					}
					array2[array2.Length - 1].skillId = num6;
					array2[array2.Length - 1].skillSlotIndex = num5;
					array2[array2.Length - 1].skillLevel = num7;
					array2[array2.Length - 1].int_4 = ReadSkillRecordByteAtConfiguredOffset(characterAccountConfig_0, num6);
					array2[array2.Length - 1].skillRange = ReadSkillRange(characterAccountConfig_0, num6);
					array2[array2.Length - 1].skillName = ReadSkillName(characterAccountConfig_0, num6, num7, bool_0: true);
				}
			}
			num4 += GameConfigurationManager.memorySignatureScanConfig_163.resolvedValue;
		}
		return array2;
	}

	public static GStruct58[] CreateBuiltInSkillCatalog()
	{
		return new GStruct58[955]
		{
			new GStruct58
			{
				skillId = 1,
				skillRange = 100,
				skillName = "Công kích vật lý  "
			},
			new GStruct58
			{
				skillId = 2,
				skillRange = 320,
				skillName = "Công kích vật lý gần "
			},
			new GStruct58
			{
				skillId = 3,
				skillRange = 0,
				skillName = "Thiếu Lâm Kiếm pháp"
			},
			new GStruct58
			{
				skillId = 4,
				skillRange = 0,
				skillName = "Thiếu Lâm Côn pháp"
			},
			new GStruct58
			{
				skillId = 5,
				skillRange = 0,
				skillName = "Thiếu Lâm thương pháp"
			},
			new GStruct58
			{
				skillId = 6,
				skillRange = 0,
				skillName = "Thiếu Lâm Đao pháp"
			},
			new GStruct58
			{
				skillId = 7,
				skillRange = 0,
				skillName = "Thiếu Lâm Chùy pháp"
			},
			new GStruct58
			{
				skillId = 8,
				skillRange = 0,
				skillName = "Thiếu Lâm Quyền Pháp"
			},
			new GStruct58
			{
				skillId = 9,
				skillRange = 0,
				skillName = "Hỗn Nguyên Nhất Khí công"
			},
			new GStruct58
			{
				skillId = 10,
				skillRange = 90,
				skillName = "Kim Cang Phục Ma"
			},
			new GStruct58
			{
				skillId = 11,
				skillRange = 90,
				skillName = "Hoành Tảo Lục Hợp"
			},
			new GStruct58
			{
				skillId = 12,
				skillRange = 0,
				skillName = "Kim Cang Hộ Thể "
			},
			new GStruct58
			{
				skillId = 13,
				skillRange = 400,
				skillName = "Lập Địa Thành Phật  "
			},
			new GStruct58
			{
				skillId = 14,
				skillRange = 90,
				skillName = "Hàng Long Bất Vũ  "
			},
			new GStruct58
			{
				skillId = 15,
				skillRange = 400,
				skillName = "Bất động Minh Vương "
			},
			new GStruct58
			{
				skillId = 16,
				skillRange = 180,
				skillName = "La Hán Trận"
			},
			new GStruct58
			{
				skillId = 17,
				skillRange = 90,
				skillName = "Long Trảo Hổ Trảo"
			},
			new GStruct58
			{
				skillId = 18,
				skillRange = 400,
				skillName = "Huệ Nhãn chú "
			},
			new GStruct58
			{
				skillId = 19,
				skillRange = 200,
				skillName = "Ma Ha Vô Lượng"
			},
			new GStruct58
			{
				skillId = 20,
				skillRange = 90,
				skillName = "Sư Tử Hống "
			},
			new GStruct58
			{
				skillId = 21,
				skillRange = 0,
				skillName = "Dịch Cân kinh"
			},
			new GStruct58
			{
				skillId = 22,
				skillRange = 0,
				skillName = "Kim Ba "
			},
			new GStruct58
			{
				skillId = 23,
				skillRange = 0,
				skillName = "Thiên Vương  Thương pháp"
			},
			new GStruct58
			{
				skillId = 24,
				skillRange = 0,
				skillName = "Thiên Vương  Đao pháp"
			},
			new GStruct58
			{
				skillId = 25,
				skillRange = 0,
				skillName = "Thánh Vương Đao pháp"
			},
			new GStruct58
			{
				skillId = 26,
				skillRange = 0,
				skillName = "Thiên Vương  Chùy Pháp"
			},
			new GStruct58
			{
				skillId = 27,
				skillRange = 0,
				skillName = "Thiên Vương  Phủ pháp"
			},
			new GStruct58
			{
				skillId = 28,
				skillRange = 0,
				skillName = "Thánh Vương Phủ pháp"
			},
			new GStruct58
			{
				skillId = 29,
				skillRange = 72,
				skillName = "Trảm Long quyết"
			},
			new GStruct58
			{
				skillId = 30,
				skillRange = 90,
				skillName = "Hồi Phong Lạc Nhạn"
			},
			new GStruct58
			{
				skillId = 31,
				skillRange = 72,
				skillName = "Hàng Vân Quyết"
			},
			new GStruct58
			{
				skillId = 32,
				skillRange = 90,
				skillName = "Vô Tâm Trảm "
			},
			new GStruct58
			{
				skillId = 33,
				skillRange = 0,
				skillName = "Tĩnh Tâm Quyết"
			},
			new GStruct58
			{
				skillId = 34,
				skillRange = 72,
				skillName = "Kinh Lôi Trảm "
			},
			new GStruct58
			{
				skillId = 35,
				skillRange = 90,
				skillName = "Dương Quan Tam Điệp"
			},
			new GStruct58
			{
				skillId = 36,
				skillRange = 0,
				skillName = "Thiên Vương Chiến ý "
			},
			new GStruct58
			{
				skillId = 37,
				skillRange = 90,
				skillName = "Bát Phong Trảm"
			},
			new GStruct58
			{
				skillId = 38,
				skillRange = 90,
				skillName = "Bàn Cổ Cửu Thức"
			},
			new GStruct58
			{
				skillId = 39,
				skillRange = 0,
				skillName = "Triêm Y Thập Bát Điệt"
			},
			new GStruct58
			{
				skillId = 40,
				skillRange = 200,
				skillName = "Đoạn Hồn Thích"
			},
			new GStruct58
			{
				skillId = 41,
				skillRange = 90,
				skillName = "Huyết Chiến Bát Phương"
			},
			new GStruct58
			{
				skillId = 42,
				skillRange = 0,
				skillName = "Kim Chung Tráo"
			},
			new GStruct58
			{
				skillId = 43,
				skillRange = 0,
				skillName = "Đường Môn ám khí "
			},
			new GStruct58
			{
				skillId = 44,
				skillRange = 0,
				skillName = "Đường Môn Đao pháp"
			},
			new GStruct58
			{
				skillId = 45,
				skillRange = 400,
				skillName = "Tích Lịch đơn"
			},
			new GStruct58
			{
				skillId = 46,
				skillRange = 180,
				skillName = "Đao Nhận cơ quan"
			},
			new GStruct58
			{
				skillId = 47,
				skillRange = 450,
				skillName = "Đoạt Hồn Tiêu"
			},
			new GStruct58
			{
				skillId = 48,
				skillRange = 0,
				skillName = "Tâm Nhãn "
			},
			new GStruct58
			{
				skillId = 49,
				skillRange = 180,
				skillName = "Địa Diệm cơ quan"
			},
			new GStruct58
			{
				skillId = 50,
				skillRange = 360,
				skillName = "Truy Tâm Tiễn"
			},
			new GStruct58
			{
				skillId = 51,
				skillRange = 0,
				skillName = "Thanh Mộc"
			},
			new GStruct58
			{
				skillId = 52,
				skillRange = 180,
				skillName = "Âm Lôi Cơ quan"
			},
			new GStruct58
			{
				skillId = 53,
				skillRange = 75,
				skillName = "Công kích vật lý "
			},
			new GStruct58
			{
				skillId = 54,
				skillRange = 400,
				skillName = "Mạn Thiên Hoa Vũ "
			},
			new GStruct58
			{
				skillId = 55,
				skillRange = 0,
				skillName = "Thối Độc Thuật"
			},
			new GStruct58
			{
				skillId = 56,
				skillRange = 180,
				skillName = "Hàn Sương Cơ quan"
			},
			new GStruct58
			{
				skillId = 57,
				skillRange = 0,
				skillName = "Băng Phách Hàn Quang"
			},
			new GStruct58
			{
				skillId = 58,
				skillRange = 520,
				skillName = "Thiên La Địa Võng"
			},
			new GStruct58
			{
				skillId = 59,
				skillRange = 180,
				skillName = "Cửu Cung Địa Sát"
			},
			new GStruct58
			{
				skillId = 60,
				skillRange = 0,
				skillName = "Ngũ Độc Đao pháp"
			},
			new GStruct58
			{
				skillId = 61,
				skillRange = 0,
				skillName = "Ngũ Độc Bổng pháp"
			},
			new GStruct58
			{
				skillId = 62,
				skillRange = 0,
				skillName = "Ngũ Độc Chưởng Pháp"
			},
			new GStruct58
			{
				skillId = 63,
				skillRange = 180,
				skillName = "Độc Sa chưởng"
			},
			new GStruct58
			{
				skillId = 64,
				skillRange = 440,
				skillName = "Băng Lam Huyền Tinh"
			},
			new GStruct58
			{
				skillId = 65,
				skillRange = 400,
				skillName = "Huyết Đao Độc Sát"
			},
			new GStruct58
			{
				skillId = 66,
				skillRange = 0,
				skillName = "Tạp Nan Dược Kinh"
			},
			new GStruct58
			{
				skillId = 67,
				skillRange = 440,
				skillName = "Cửu Thiên Cuồng Lôi "
			},
			new GStruct58
			{
				skillId = 68,
				skillRange = 400,
				skillName = "U Minh Khô Lâu"
			},
			new GStruct58
			{
				skillId = 69,
				skillRange = 400,
				skillName = "Vô Hình Độc"
			},
			new GStruct58
			{
				skillId = 70,
				skillRange = 440,
				skillName = "Xích Diệm Thực Thiên"
			},
			new GStruct58
			{
				skillId = 71,
				skillRange = 420,
				skillName = "Thiên Cương Địa Sát"
			},
			new GStruct58
			{
				skillId = 72,
				skillRange = 440,
				skillName = "Xuyên Tâm Độc Thích"
			},
			new GStruct58
			{
				skillId = 73,
				skillRange = 440,
				skillName = "Vạn Độc Thực Tâm"
			},
			new GStruct58
			{
				skillId = 74,
				skillRange = 400,
				skillName = "Chu Cáp Thanh Minh"
			},
			new GStruct58
			{
				skillId = 75,
				skillRange = 0,
				skillName = "Ngũ Độc Kỳ Kinh"
			},
			new GStruct58
			{
				skillId = 76,
				skillRange = 0,
				skillName = "Di Hoa Tiếp Ngọc"
			},
			new GStruct58
			{
				skillId = 77,
				skillRange = 0,
				skillName = "Nga Mi Kiếm pháp"
			},
			new GStruct58
			{
				skillId = 78,
				skillRange = 0,
				skillName = "Tiếp Dẫn Kiếm pháp"
			},
			new GStruct58
			{
				skillId = 79,
				skillRange = 0,
				skillName = "Nga Mi Chưởng pháp"
			},
			new GStruct58
			{
				skillId = 80,
				skillRange = 240,
				skillName = "Phiêu Tuyết Xuyên Vân "
			},
			new GStruct58
			{
				skillId = 81,
				skillRange = 0,
				skillName = "Thu Phong Diệp"
			},
			new GStruct58
			{
				skillId = 82,
				skillRange = 570,
				skillName = "Tứ Tượng Đồng Quy"
			},
			new GStruct58
			{
				skillId = 83,
				skillRange = 180,
				skillName = "Vọng Nguyệt"
			},
			new GStruct58
			{
				skillId = 84,
				skillRange = 180,
				skillName = "Phong Vũ Phiêu Hương"
			},
			new GStruct58
			{
				skillId = 85,
				skillRange = 180,
				skillName = "Nhất Diệp Tri Thu"
			},
			new GStruct58
			{
				skillId = 86,
				skillRange = 180,
				skillName = "Lưu Thủy "
			},
			new GStruct58
			{
				skillId = 87,
				skillRange = 0,
				skillName = "Băng Tâm Quyết"
			},
			new GStruct58
			{
				skillId = 88,
				skillRange = 360,
				skillName = "Bất Diệt Bất Tuyệt"
			},
			new GStruct58
			{
				skillId = 89,
				skillRange = 180,
				skillName = "Mộng Điệp "
			},
			new GStruct58
			{
				skillId = 90,
				skillRange = 440,
				skillName = "Mê Tung ảo ảnh"
			},
			new GStruct58
			{
				skillId = 91,
				skillRange = 400,
				skillName = "Phật Quang Phổ Chiếu"
			},
			new GStruct58
			{
				skillId = 92,
				skillRange = 180,
				skillName = "Phật Tâm Từ Hữu"
			},
			new GStruct58
			{
				skillId = 93,
				skillRange = 400,
				skillName = "Từ Hàng Phổ D"
			},
			new GStruct58
			{
				skillId = 94,
				skillRange = 400,
				skillName = "Từ Hàng Phổ Độ11"
			},
			new GStruct58
			{
				skillId = 95,
				skillRange = 0,
				skillName = "Thúy Yên Đao pháp"
			},
			new GStruct58
			{
				skillId = 96,
				skillRange = 0,
				skillName = "Thúy Yên Kiếm pháp"
			},
			new GStruct58
			{
				skillId = 97,
				skillRange = 0,
				skillName = "Thúy Yên Song đao"
			},
			new GStruct58
			{
				skillId = 98,
				skillRange = 0,
				skillName = "Bích Yên kiếm pháp"
			},
			new GStruct58
			{
				skillId = 99,
				skillRange = 360,
				skillName = "Phong Hoa Tuyết Nguyệt"
			},
			new GStruct58
			{
				skillId = 100,
				skillRange = 0,
				skillName = "Hộ Thể Hàn Băng "
			},
			new GStruct58
			{
				skillId = 101,
				skillRange = 400,
				skillName = "Trị liệu thuật"
			},
			new GStruct58
			{
				skillId = 102,
				skillRange = 360,
				skillName = "Phong Quyển Tàn Tuyết"
			},
			new GStruct58
			{
				skillId = 103,
				skillRange = 0,
				skillName = "Thiên Lý Băng Phong "
			},
			new GStruct58
			{
				skillId = 104,
				skillRange = 0,
				skillName = "Băng Hồn"
			},
			new GStruct58
			{
				skillId = 105,
				skillRange = 300,
				skillName = "Vũ Đả Lê Hoa"
			},
			new GStruct58
			{
				skillId = 106,
				skillRange = 400,
				skillName = "Băng Tung Vụ ảnh 111"
			},
			new GStruct58
			{
				skillId = 107,
				skillRange = 180,
				skillName = "Nhiếp Tâm Thuật"
			},
			new GStruct58
			{
				skillId = 108,
				skillRange = 420,
				skillName = "Mục Dã Lưu Tinh"
			},
			new GStruct58
			{
				skillId = 109,
				skillRange = 0,
				skillName = "Tuyết ảnh"
			},
			new GStruct58
			{
				skillId = 110,
				skillRange = 180,
				skillName = "Ngũ hành độn"
			},
			new GStruct58
			{
				skillId = 111,
				skillRange = 72,
				skillName = "Bích Hải Triều Sinh"
			},
			new GStruct58
			{
				skillId = 112,
				skillRange = 0,
				skillName = "Bích Hải Triều Sinhb"
			},
			new GStruct58
			{
				skillId = 113,
				skillRange = 400,
				skillName = "Phù Vân Tán Tuyết"
			},
			new GStruct58
			{
				skillId = 114,
				skillRange = 0,
				skillName = "Băng Cốt Tuyết Tâm"
			},
			new GStruct58
			{
				skillId = 115,
				skillRange = 0,
				skillName = "Cái Bang Bổng pháp"
			},
			new GStruct58
			{
				skillId = 116,
				skillRange = 0,
				skillName = "Cái Bang Chưởng Pháp"
			},
			new GStruct58
			{
				skillId = 117,
				skillRange = 280,
				skillName = "Đầu Thạch Vấn Lộ "
			},
			new GStruct58
			{
				skillId = 118,
				skillRange = 400,
				skillName = "Cô Mộc Độn Lôi "
			},
			new GStruct58
			{
				skillId = 119,
				skillRange = 240,
				skillName = "Diên Môn Thác Bát"
			},
			new GStruct58
			{
				skillId = 120,
				skillRange = 400,
				skillName = "Bôn Lưu Đáo Hải"
			},
			new GStruct58
			{
				skillId = 121,
				skillRange = 180,
				skillName = "Diệu Thủ Không Không"
			},
			new GStruct58
			{
				skillId = 122,
				skillRange = 300,
				skillName = "Kiến Nhân Thần Thủ "
			},
			new GStruct58
			{
				skillId = 123,
				skillRange = 400,
				skillName = "Khuê Mộc Tinh Chiếu"
			},
			new GStruct58
			{
				skillId = 124,
				skillRange = 0,
				skillName = "Đả Cẩu bổng"
			},
			new GStruct58
			{
				skillId = 125,
				skillRange = 72,
				skillName = "Bổng Đả ác Cẩu"
			},
			new GStruct58
			{
				skillId = 126,
				skillRange = 400,
				skillName = "Kim Ô ánh Tuyết"
			},
			new GStruct58
			{
				skillId = 127,
				skillRange = 0,
				skillName = "Hoạt Bất Lưu Thủ 11"
			},
			new GStruct58
			{
				skillId = 128,
				skillRange = 400,
				skillName = "Kháng Long Hữu Hối"
			},
			new GStruct58
			{
				skillId = 129,
				skillRange = 400,
				skillName = "Hóa Hiểm Vi Di"
			},
			new GStruct58
			{
				skillId = 130,
				skillRange = 0,
				skillName = "Túy Điệp Cuồng Vũ "
			},
			new GStruct58
			{
				skillId = 131,
				skillRange = 0,
				skillName = "Thiên Nhẫn  Đao pháp"
			},
			new GStruct58
			{
				skillId = 132,
				skillRange = 0,
				skillName = "Thiên Nhẫn  Mâu pháp"
			},
			new GStruct58
			{
				skillId = 133,
				skillRange = 0,
				skillName = "Thiên Nhẫn  phủ pháp"
			},
			new GStruct58
			{
				skillId = 134,
				skillRange = 0,
				skillName = "Thiên Nhẫn  Chùy pháp "
			},
			new GStruct58
			{
				skillId = 135,
				skillRange = 270,
				skillName = "Tàn Dương Như Huyết"
			},
			new GStruct58
			{
				skillId = 136,
				skillRange = 440,
				skillName = "Hỏa Liên Phần Hoa"
			},
			new GStruct58
			{
				skillId = 137,
				skillRange = 440,
				skillName = "ảo ảnh Phi Hồ "
			},
			new GStruct58
			{
				skillId = 138,
				skillRange = 400,
				skillName = "Thôi sơn  Điền Hải"
			},
			new GStruct58
			{
				skillId = 139,
				skillRange = 60,
				skillName = "Hỗn Thủy Mạc Ngư "
			},
			new GStruct58
			{
				skillId = 140,
				skillRange = 440,
				skillName = "Phi Hồng Vô Tích "
			},
			new GStruct58
			{
				skillId = 141,
				skillRange = 72,
				skillName = "Liệt Hỏa Tình Thiên "
			},
			new GStruct58
			{
				skillId = 142,
				skillRange = 60,
				skillName = "Thâu Thiên Hoán Nhật"
			},
			new GStruct58
			{
				skillId = 143,
				skillRange = 440,
				skillName = "Lịch Ma Đoạt Hồn"
			},
			new GStruct58
			{
				skillId = 144,
				skillRange = 0,
				skillName = "Minh Tôn Bản Sinh"
			},
			new GStruct58
			{
				skillId = 145,
				skillRange = 280,
				skillName = "Đơn Chỉ Liệt Diệm"
			},
			new GStruct58
			{
				skillId = 146,
				skillRange = 180,
				skillName = "Ngũ hành trận"
			},
			new GStruct58
			{
				skillId = 147,
				skillRange = 60,
				skillName = "Huyền Minh Hấp Tinh"
			},
			new GStruct58
			{
				skillId = 148,
				skillRange = 570,
				skillName = "Ma Diệm Thất Sát"
			},
			new GStruct58
			{
				skillId = 149,
				skillRange = 0,
				skillName = "Thực Cốt Huyết Nhận"
			},
			new GStruct58
			{
				skillId = 150,
				skillRange = 0,
				skillName = "Thiên Ma Giải Thể "
			},
			new GStruct58
			{
				skillId = 151,
				skillRange = 0,
				skillName = "Võ Đang Kiếm pháp"
			},
			new GStruct58
			{
				skillId = 152,
				skillRange = 0,
				skillName = "Võ Đang Quyền Pháp"
			},
			new GStruct58
			{
				skillId = 153,
				skillRange = 400,
				skillName = "Nộ Lôi Chỉ "
			},
			new GStruct58
			{
				skillId = 154,
				skillRange = 0,
				skillName = "Âm Dương Khí"
			},
			new GStruct58
			{
				skillId = 155,
				skillRange = 480,
				skillName = "Thương Hải Minh Nguyệt"
			},
			new GStruct58
			{
				skillId = 156,
				skillRange = 0,
				skillName = "Thuần Dương Tâm pháp"
			},
			new GStruct58
			{
				skillId = 157,
				skillRange = 0,
				skillName = "Tọa Vọng Vô Ngã "
			},
			new GStruct58
			{
				skillId = 158,
				skillRange = 400,
				skillName = "Kiếm Phi Kinh Thiên"
			},
			new GStruct58
			{
				skillId = 159,
				skillRange = 180,
				skillName = "Thất Tinh Trận"
			},
			new GStruct58
			{
				skillId = 160,
				skillRange = 0,
				skillName = "Thế Vân Tung"
			},
			new GStruct58
			{
				skillId = 161,
				skillRange = 0,
				skillName = "Lưỡng Nghi Tâm pháp"
			},
			new GStruct58
			{
				skillId = 162,
				skillRange = 520,
				skillName = "Huyền Nhất Vô Tượng"
			},
			new GStruct58
			{
				skillId = 163,
				skillRange = 0,
				skillName = "Nhân Kiếm Hợp Nhất"
			},
			new GStruct58
			{
				skillId = 164,
				skillRange = 470,
				skillName = "Bác Cấp Nhi Phục"
			},
			new GStruct58
			{
				skillId = 165,
				skillRange = 400,
				skillName = "Vô Ngã Vô Kiếm  "
			},
			new GStruct58
			{
				skillId = 166,
				skillRange = 0,
				skillName = "Thái Cực Thần Công "
			},
			new GStruct58
			{
				skillId = 167,
				skillRange = 0,
				skillName = "Côn Lôn Đao pháp"
			},
			new GStruct58
			{
				skillId = 168,
				skillRange = 0,
				skillName = "Côn Lôn Kiếm pháp"
			},
			new GStruct58
			{
				skillId = 169,
				skillRange = 300,
				skillName = "Hô Phong Pháp"
			},
			new GStruct58
			{
				skillId = 170,
				skillRange = 0,
				skillName = "Đại Lãng Thực Không"
			},
			new GStruct58
			{
				skillId = 171,
				skillRange = 440,
				skillName = "Thanh Phong phù "
			},
			new GStruct58
			{
				skillId = 172,
				skillRange = 360,
				skillName = "Thiên Tế Tấn Lôi  "
			},
			new GStruct58
			{
				skillId = 173,
				skillRange = 440,
				skillName = "Thiên Thanh Địa Trọc"
			},
			new GStruct58
			{
				skillId = 174,
				skillRange = 440,
				skillName = "Ki Bán phù "
			},
			new GStruct58
			{
				skillId = 175,
				skillRange = 440,
				skillName = "Khi Hàn Ngạo Tuyết"
			},
			new GStruct58
			{
				skillId = 176,
				skillRange = 180,
				skillName = "Cuồng Phong Sậu Điện"
			},
			new GStruct58
			{
				skillId = 177,
				skillRange = 440,
				skillName = "Bách Xuyên Nạp Hải"
			},
			new GStruct58
			{
				skillId = 178,
				skillRange = 440,
				skillName = "Nhất Khí Tam Thanh"
			},
			new GStruct58
			{
				skillId = 179,
				skillRange = 400,
				skillName = "Cuồng Lôi Chấn Địa "
			},
			new GStruct58
			{
				skillId = 180,
				skillRange = 0,
				skillName = "Độc Tê Tị Tà "
			},
			new GStruct58
			{
				skillId = 181,
				skillRange = 440,
				skillName = "Khí Tâm phù "
			},
			new GStruct58
			{
				skillId = 182,
				skillRange = 470,
				skillName = "Ngũ Lôi Chánh Pháp"
			},
			new GStruct58
			{
				skillId = 183,
				skillRange = 180,
				skillName = "Tuế Nguyệt Vô Tình phù "
			},
			new GStruct58
			{
				skillId = 184,
				skillRange = 0,
				skillName = "Kim Thiền Thoát Xác "
			},
			new GStruct58
			{
				skillId = 185,
				skillRange = 180,
				skillName = "Lam Ba "
			},
			new GStruct58
			{
				skillId = 186,
				skillRange = 180,
				skillName = "Hồng Ba "
			},
			new GStruct58
			{
				skillId = 187,
				skillRange = 180,
				skillName = "Lục Ba "
			},
			new GStruct58
			{
				skillId = 188,
				skillRange = 180,
				skillName = "Bạch Ba "
			},
			new GStruct58
			{
				skillId = 189,
				skillRange = 180,
				skillName = "Vũ Đả Lê Hoa "
			},
			new GStruct58
			{
				skillId = 190,
				skillRange = 180,
				skillName = "Mục Dã Lưu Tinh "
			},
			new GStruct58
			{
				skillId = 191,
				skillRange = 180,
				skillName = "Quan Âm Tán Tuyết "
			},
			new GStruct58
			{
				skillId = 192,
				skillRange = 400,
				skillName = "Thất Thương Thần Quyền "
			},
			new GStruct58
			{
				skillId = 193,
				skillRange = 180,
				skillName = "Kiếm Phi Kinh Thiên "
			},
			new GStruct58
			{
				skillId = 194,
				skillRange = 180,
				skillName = "Thiên La Địa VõngPhi Đao"
			},
			new GStruct58
			{
				skillId = 195,
				skillRange = 180,
				skillName = "Thiên Cương Địa Sát "
			},
			new GStruct58
			{
				skillId = 196,
				skillRange = 180,
				skillName = "Ném đá"
			},
			new GStruct58
			{
				skillId = 197,
				skillRange = 180,
				skillName = "Ném lông "
			},
			new GStruct58
			{
				skillId = 198,
				skillRange = 180,
				skillName = "Thổi lông "
			},
			new GStruct58
			{
				skillId = 199,
				skillRange = 180,
				skillName = "Phun nước bọt "
			},
			new GStruct58
			{
				skillId = 200,
				skillRange = 180,
				skillName = "Phun nước độc "
			},
			new GStruct58
			{
				skillId = 201,
				skillRange = 180,
				skillName = "Bắn tên "
			},
			new GStruct58
			{
				skillId = 202,
				skillRange = 180,
				skillName = "La Hán Trận "
			},
			new GStruct58
			{
				skillId = 203,
				skillRange = 180,
				skillName = "Vô Hình Độc "
			},
			new GStruct58
			{
				skillId = 204,
				skillRange = 180,
				skillName = "Thu Phong Diệp "
			},
			new GStruct58
			{
				skillId = 205,
				skillRange = 180,
				skillName = "Vọng Nguyệt "
			},
			new GStruct58
			{
				skillId = 206,
				skillRange = 180,
				skillName = "Lưu Thủy "
			},
			new GStruct58
			{
				skillId = 207,
				skillRange = 180,
				skillName = "Mộng Điệp  "
			},
			new GStruct58
			{
				skillId = 208,
				skillRange = 180,
				skillName = "Phật Tâm Từ Hữu"
			},
			new GStruct58
			{
				skillId = 209,
				skillRange = 180,
				skillName = "Đả Cẩu bổng "
			},
			new GStruct58
			{
				skillId = 210,
				skillRange = 400,
				skillName = "Khinh công "
			},
			new GStruct58
			{
				skillId = 211,
				skillRange = 180,
				skillName = "Thất Tinh Trận "
			},
			new GStruct58
			{
				skillId = 212,
				skillRange = 180,
				skillName = "Thanh Tâm Phạn Âm"
			},
			new GStruct58
			{
				skillId = 213,
				skillRange = 180,
				skillName = "Bất động Minh Vương "
			},
			new GStruct58
			{
				skillId = 214,
				skillRange = 180,
				skillName = "Huệ Nhãn chú "
			},
			new GStruct58
			{
				skillId = 215,
				skillRange = 0,
				skillName = "Nhân Kiếm Hợp Nhất "
			},
			new GStruct58
			{
				skillId = 216,
				skillRange = 75,
				skillName = "Kim Cang Phục Ma "
			},
			new GStruct58
			{
				skillId = 217,
				skillRange = 75,
				skillName = "Hoành Tảo Lục Hợp "
			},
			new GStruct58
			{
				skillId = 218,
				skillRange = 75,
				skillName = "Long Trảo Hổ Trảo "
			},
			new GStruct58
			{
				skillId = 219,
				skillRange = 75,
				skillName = "Hồi Phong Lạc Nhạn "
			},
			new GStruct58
			{
				skillId = 220,
				skillRange = 75,
				skillName = "Vô Tâm Trảm  "
			},
			new GStruct58
			{
				skillId = 221,
				skillRange = 75,
				skillName = "Dương Quan Tam Điệp "
			},
			new GStruct58
			{
				skillId = 222,
				skillRange = 75,
				skillName = "Bát Phong Trảm "
			},
			new GStruct58
			{
				skillId = 223,
				skillRange = 75,
				skillName = "Bàn Cổ Cửu Thức "
			},
			new GStruct58
			{
				skillId = 224,
				skillRange = 75,
				skillName = "Đoạn Hồn Thích "
			},
			new GStruct58
			{
				skillId = 225,
				skillRange = 75,
				skillName = "Huyết Chiến Bát Phương "
			},
			new GStruct58
			{
				skillId = 226,
				skillRange = 180,
				skillName = "Ngũ hành trận "
			},
			new GStruct58
			{
				skillId = 227,
				skillRange = 180,
				skillName = "Thiên La Địa Võng tiểu Phi Đao"
			},
			new GStruct58
			{
				skillId = 228,
				skillRange = 180,
				skillName = "Thiên La Địa Võng"
			},
			new GStruct58
			{
				skillId = 229,
				skillRange = 75,
				skillName = "Công kích Côn bổng "
			},
			new GStruct58
			{
				skillId = 230,
				skillRange = 75,
				skillName = "Công kích Song chùy "
			},
			new GStruct58
			{
				skillId = 231,
				skillRange = 75,
				skillName = "Công kích tay không"
			},
			new GStruct58
			{
				skillId = 232,
				skillRange = 75,
				skillName = "Song đaocông kích "
			},
			new GStruct58
			{
				skillId = 233,
				skillRange = 270,
				skillName = "Tàn Dương Như Huyết npc"
			},
			new GStruct58
			{
				skillId = 234,
				skillRange = 180,
				skillName = "Độc Sa chưởng npc"
			},
			new GStruct58
			{
				skillId = 235,
				skillRange = 450,
				skillName = "Truy Tâm Tiễn npc"
			},
			new GStruct58
			{
				skillId = 236,
				skillRange = 360,
				skillName = "Phong Hoa Tuyết Nguyệt npc"
			},
			new GStruct58
			{
				skillId = 237,
				skillRange = 300,
				skillName = "Hô Phong Pháp npc"
			},
			new GStruct58
			{
				skillId = 238,
				skillRange = 72,
				skillName = "Kinh Lôi Trảm npc"
			},
			new GStruct58
			{
				skillId = 239,
				skillRange = 400,
				skillName = "Nộ Lôi Chỉ npc"
			},
			new GStruct58
			{
				skillId = 240,
				skillRange = 320,
				skillName = "Tích Lịch đơn npc"
			},
			new GStruct58
			{
				skillId = 241,
				skillRange = 180,
				skillName = "Phiêu Tuyết Xuyên Vân npc"
			},
			new GStruct58
			{
				skillId = 242,
				skillRange = 72,
				skillName = "Trảm Long quyết npc"
			},
			new GStruct58
			{
				skillId = 243,
				skillRange = 400,
				skillName = "Tứ Tượng Đồng Quy "
			},
			new GStruct58
			{
				skillId = 244,
				skillRange = 400,
				skillName = "Ma Ha Vô Lượng npc"
			},
			new GStruct58
			{
				skillId = 245,
				skillRange = 400,
				skillName = "Huyền Nhất Vô Tượng npc"
			},
			new GStruct58
			{
				skillId = 246,
				skillRange = 600,
				skillName = "Bất Diệt Bất Tuyệt npc"
			},
			new GStruct58
			{
				skillId = 247,
				skillRange = 400,
				skillName = "Đơn Chỉ Liệt Diệm npc"
			},
			new GStruct58
			{
				skillId = 248,
				skillRange = 400,
				skillName = "Thiên la Địa võng  npc"
			},
			new GStruct58
			{
				skillId = 249,
				skillRange = 350,
				skillName = "Tiểu Lý Phi Đao"
			},
			new GStruct58
			{
				skillId = 250,
				skillRange = 400,
				skillName = "Tiểu Lý Phi Đao "
			},
			new GStruct58
			{
				skillId = 251,
				skillRange = 800,
				skillName = "Pháo Hoa"
			},
			new GStruct58
			{
				skillId = 252,
				skillRange = 0,
				skillName = "Phật Pháp Vô Biên "
			},
			new GStruct58
			{
				skillId = 253,
				skillRange = 0,
				skillName = "Ngự Độc Thực Cốt"
			},
			new GStruct58
			{
				skillId = 254,
				skillRange = 0,
				skillName = "Tam Muội Chân Hỏa"
			},
			new GStruct58
			{
				skillId = 255,
				skillRange = 400,
				skillName = "Sư Tử hựu Hống "
			},
			new GStruct58
			{
				skillId = 266,
				skillRange = 360,
				skillName = "NPC Phong Quyển Tàn Tuyết"
			},
			new GStruct58
			{
				skillId = 267,
				skillRange = 90,
				skillName = "Tam Hoàn Thao Nguyệt"
			},
			new GStruct58
			{
				skillId = 268,
				skillRange = 75,
				skillName = "Tam Hoàn Thao Nguyệt "
			},
			new GStruct58
			{
				skillId = 269,
				skillRange = 0,
				skillName = "Băng Tâm Trái ảnh"
			},
			new GStruct58
			{
				skillId = 270,
				skillRange = 0,
				skillName = "Đạp Tuyết Vô Ngân "
			},
			new GStruct58
			{
				skillId = 271,
				skillRange = 90,
				skillName = "Long Trảo Hổ Trảo"
			},
			new GStruct58
			{
				skillId = 272,
				skillRange = 75,
				skillName = "Long Trảo Hổ Trảo "
			},
			new GStruct58
			{
				skillId = 273,
				skillRange = 0,
				skillName = "Như Lai Thiên Diệp "
			},
			new GStruct58
			{
				skillId = 274,
				skillRange = 0,
				skillName = "Giáng Long Chưởng "
			},
			new GStruct58
			{
				skillId = 275,
				skillRange = 0,
				skillName = "Sương Ngạo Côn Lôn "
			},
			new GStruct58
			{
				skillId = 276,
				skillRange = 480,
				skillName = "Tuế Nguyệt Vô Tình "
			},
			new GStruct58
			{
				skillId = 277,
				skillRange = 0,
				skillName = "Hoạt Bất Lưu Thủ "
			},
			new GStruct58
			{
				skillId = 278,
				skillRange = 400,
				skillName = "Phong Vân Giáng "
			},
			new GStruct58
			{
				skillId = 279,
				skillRange = 0,
				skillName = "Phong Vân Giáng "
			},
			new GStruct58
			{
				skillId = 280,
				skillRange = 180,
				skillName = "Ba La Tâm Kinh"
			},
			new GStruct58
			{
				skillId = 281,
				skillRange = 180,
				skillName = "Ba La Tâm Kinh "
			},
			new GStruct58
			{
				skillId = 282,
				skillRange = 180,
				skillName = "Thanh Âm Phạn Xướng"
			},
			new GStruct58
			{
				skillId = 283,
				skillRange = 400,
				skillName = "Kháng Long Hữu Hối "
			},
			new GStruct58
			{
				skillId = 290,
				skillRange = 470,
				skillName = "Hoa Hồng trên mặt đất "
			},
			new GStruct58
			{
				skillId = 291,
				skillRange = 0,
				skillName = "Hạnh Vận Tinh "
			},
			new GStruct58
			{
				skillId = 292,
				skillRange = 180,
				skillName = "Hạnh Vận Tinh"
			},
			new GStruct58
			{
				skillId = 301,
				skillRange = 400,
				skillName = "Truy Tinh Trục Điện"
			},
			new GStruct58
			{
				skillId = 302,
				skillRange = 470,
				skillName = "Bạo Vũ Lê Hoa"
			},
			new GStruct58
			{
				skillId = 303,
				skillRange = 50,
				skillName = "Độc Thích Cốt "
			},
			new GStruct58
			{
				skillId = 304,
				skillRange = 0,
				skillName = "Độc Thích Cốt  "
			},
			new GStruct58
			{
				skillId = 305,
				skillRange = 180,
				skillName = "Thanh Mộc Công "
			},
			new GStruct58
			{
				skillId = 306,
				skillRange = 180,
				skillName = "Thanh Mộc Công "
			},
			new GStruct58
			{
				skillId = 307,
				skillRange = 200,
				skillName = "Công Thành xa"
			},
			new GStruct58
			{
				skillId = 308,
				skillRange = 600,
				skillName = "Đầu Thạch Xa công kích (vật lý) "
			},
			new GStruct58
			{
				skillId = 309,
				skillRange = 600,
				skillName = "Tất cả trạng thái miễn dịch"
			},
			new GStruct58
			{
				skillId = 310,
				skillRange = 600,
				skillName = "Đầu Thạch Xa công kích (Hỏa) "
			},
			new GStruct58
			{
				skillId = 311,
				skillRange = 600,
				skillName = "Đầu Thạch Xa công kích (băng) "
			},
			new GStruct58
			{
				skillId = 312,
				skillRange = 600,
				skillName = "Đầu Thạch Xacông kích (độc) "
			},
			new GStruct58
			{
				skillId = 313,
				skillRange = 180,
				skillName = "Hào quang tăng kháng tính "
			},
			new GStruct58
			{
				skillId = 314,
				skillRange = 180,
				skillName = "Hào quang tăng Sinh lực và Nội lực"
			},
			new GStruct58
			{
				skillId = 315,
				skillRange = 180,
				skillName = "Vòng tròn  tăng Sinh lực và Nội lực "
			},
			new GStruct58
			{
				skillId = 316,
				skillRange = 180,
				skillName = "Vòng tròn  tăng kháng tính "
			},
			new GStruct58
			{
				skillId = 317,
				skillRange = 75,
				skillName = "Kim Phật Xuất Kích"
			},
			new GStruct58
			{
				skillId = 318,
				skillRange = 90,
				skillName = "Đạt Ma Độ Giang"
			},
			new GStruct58
			{
				skillId = 319,
				skillRange = 75,
				skillName = "Hoành Tảo Thiên Quân"
			},
			new GStruct58
			{
				skillId = 320,
				skillRange = 90,
				skillName = "Hoành Tảo Lục Hợp 111"
			},
			new GStruct58
			{
				skillId = 321,
				skillRange = 400,
				skillName = "Vô Tướng Trảm "
			},
			new GStruct58
			{
				skillId = 322,
				skillRange = 90,
				skillName = "Phá Thiên Trảm "
			},
			new GStruct58
			{
				skillId = 323,
				skillRange = 90,
				skillName = "Truy Tinh Trục Nguyệt "
			},
			new GStruct58
			{
				skillId = 324,
				skillRange = 72,
				skillName = "Thừa Long Quyết "
			},
			new GStruct58
			{
				skillId = 325,
				skillRange = 72,
				skillName = "Truy Phong Quyết "
			},
			new GStruct58
			{
				skillId = 326,
				skillRange = 75,
				skillName = "Phá Thiên Trảm "
			},
			new GStruct58
			{
				skillId = 327,
				skillRange = 75,
				skillName = "Truy Tinh Trục Nguyệt "
			},
			new GStruct58
			{
				skillId = 328,
				skillRange = 360,
				skillName = "Tam Nga Tề Tuyết "
			},
			new GStruct58
			{
				skillId = 329,
				skillRange = 400,
				skillName = "Ngọc Tuyền Tẩy Trần "
			},
			new GStruct58
			{
				skillId = 330,
				skillRange = 0,
				skillName = "Thiên Phật Thiên Diệp "
			},
			new GStruct58
			{
				skillId = 331,
				skillRange = 400,
				skillName = "Kim Đỉnh Phật Quang "
			},
			new GStruct58
			{
				skillId = 332,
				skillRange = 180,
				skillName = "Phổ Độ Chúng Sinh "
			},
			new GStruct58
			{
				skillId = 333,
				skillRange = 180,
				skillName = "Phổ Độ Chúng Sinh "
			},
			new GStruct58
			{
				skillId = 334,
				skillRange = 180,
				skillName = "Thanh Âm Phạn Xướng 11"
			},
			new GStruct58
			{
				skillId = 335,
				skillRange = 180,
				skillName = "Thanh Âm Phạn Xướng "
			},
			new GStruct58
			{
				skillId = 336,
				skillRange = 360,
				skillName = "Băng Tung Vô ảnh "
			},
			new GStruct58
			{
				skillId = 337,
				skillRange = 240,
				skillName = "Băng Tâm Tiên Tử  "
			},
			new GStruct58
			{
				skillId = 338,
				skillRange = 400,
				skillName = "Phong Tuyết Băng Thiên "
			},
			new GStruct58
			{
				skillId = 339,
				skillRange = 360,
				skillName = "Nhiếp Hồn Nguyệt ảnh"
			},
			new GStruct58
			{
				skillId = 340,
				skillRange = 400,
				skillName = "Ngân Đao Xạ Nguyệt "
			},
			new GStruct58
			{
				skillId = 341,
				skillRange = 400,
				skillName = "Tán Hoa Tiêu "
			},
			new GStruct58
			{
				skillId = 342,
				skillRange = 360,
				skillName = "Cửu Cung Phi Tinh"
			},
			new GStruct58
			{
				skillId = 343,
				skillRange = 50,
				skillName = "Xuyên Tâm Thích "
			},
			new GStruct58
			{
				skillId = 344,
				skillRange = 0,
				skillName = "Xuyên Tâm Thích "
			},
			new GStruct58
			{
				skillId = 345,
				skillRange = 50,
				skillName = "Hàn Băng Thích "
			},
			new GStruct58
			{
				skillId = 346,
				skillRange = 0,
				skillName = "Hàn Băng Thích "
			},
			new GStruct58
			{
				skillId = 347,
				skillRange = 50,
				skillName = "Địa Diệm Hỏa "
			},
			new GStruct58
			{
				skillId = 348,
				skillRange = 0,
				skillName = "Địa Diệm Hỏa "
			},
			new GStruct58
			{
				skillId = 349,
				skillRange = 50,
				skillName = "Lôi Kích Thuật "
			},
			new GStruct58
			{
				skillId = 350,
				skillRange = 0,
				skillName = "Lôi Kích Thuật "
			},
			new GStruct58
			{
				skillId = 351,
				skillRange = 50,
				skillName = "Loạn Hoàn Kích"
			},
			new GStruct58
			{
				skillId = 352,
				skillRange = 0,
				skillName = "Loạn Hoàn Kích "
			},
			new GStruct58
			{
				skillId = 353,
				skillRange = 420,
				skillName = "Âm Phong Thực Cốt "
			},
			new GStruct58
			{
				skillId = 354,
				skillRange = 420,
				skillName = "Thiên Cương Độc Thủ "
			},
			new GStruct58
			{
				skillId = 355,
				skillRange = 180,
				skillName = "Huyền Âm Trảm "
			},
			new GStruct58
			{
				skillId = 356,
				skillRange = 440,
				skillName = "Xuyên Y Phá Giáp "
			},
			new GStruct58
			{
				skillId = 357,
				skillRange = 400,
				skillName = "Phi Long Tại Thiên "
			},
			new GStruct58
			{
				skillId = 358,
				skillRange = 570,
				skillName = "Tiềm Long Tại Uyên"
			},
			new GStruct58
			{
				skillId = 359,
				skillRange = 400,
				skillName = "Thiên Hạ Vô Cẩu "
			},
			new GStruct58
			{
				skillId = 360,
				skillRange = 0,
				skillName = "Tiêu Diêu Công "
			},
			new GStruct58
			{
				skillId = 361,
				skillRange = 60,
				skillName = "Vân Long Kích"
			},
			new GStruct58
			{
				skillId = 362,
				skillRange = 420,
				skillName = "Thiên Ngoại Lưu Tinh"
			},
			new GStruct58
			{
				skillId = 363,
				skillRange = 570,
				skillName = "Nghiệp Hỏa Phàn Thành "
			},
			new GStruct58
			{
				skillId = 364,
				skillRange = 440,
				skillName = "Bi Tô Thanh Phong "
			},
			new GStruct58
			{
				skillId = 365,
				skillRange = 470,
				skillName = "Thiên Địa Vô Cực "
			},
			new GStruct58
			{
				skillId = 366,
				skillRange = 470,
				skillName = "Thái Cực Vô ý "
			},
			new GStruct58
			{
				skillId = 367,
				skillRange = 400,
				skillName = "Kiếm Khí Tung Hoành "
			},
			new GStruct58
			{
				skillId = 368,
				skillRange = 90,
				skillName = "Nhân Kiếm Hợp Nhất  "
			},
			new GStruct58
			{
				skillId = 369,
				skillRange = 480,
				skillName = "Minh Nguyệt Vô Tâm "
			},
			new GStruct58
			{
				skillId = 370,
				skillRange = 400,
				skillName = "Vạn Kiếm Tề Phát "
			},
			new GStruct58
			{
				skillId = 371,
				skillRange = 470,
				skillName = "Thái Cực Kiếm ý "
			},
			new GStruct58
			{
				skillId = 372,
				skillRange = 400,
				skillName = "Ngạo Tuyết Tiêu Phong "
			},
			new GStruct58
			{
				skillId = 373,
				skillRange = 470,
				skillName = "Khiếu Phong Tam Liên Kích"
			},
			new GStruct58
			{
				skillId = 374,
				skillRange = 400,
				skillName = "Vụ Tỏa Côn Lôn "
			},
			new GStruct58
			{
				skillId = 375,
				skillRange = 470,
				skillName = "Lôi động Cửu Thiên "
			},
			new GStruct58
			{
				skillId = 376,
				skillRange = 400,
				skillName = "Túy Tiên Tá Cốt 99"
			},
			new GStruct58
			{
				skillId = 377,
				skillRange = 400,
				skillName = "Nộ Lôi Liên hoàn Kích "
			},
			new GStruct58
			{
				skillId = 378,
				skillRange = 400,
				skillName = "Phong Hỏa Liên Thiên "
			},
			new GStruct58
			{
				skillId = 379,
				skillRange = 400,
				skillName = "Ma Viêm Tại Thiên  "
			},
			new GStruct58
			{
				skillId = 380,
				skillRange = 400,
				skillName = "Phong Sương Toái ảnh "
			},
			new GStruct58
			{
				skillId = 381,
				skillRange = 400,
				skillName = "Băng Tâm Ngọc Lăng "
			},
			new GStruct58
			{
				skillId = 382,
				skillRange = 400,
				skillName = "Băng Tâm Tuyết Liên "
			},
			new GStruct58
			{
				skillId = 383,
				skillRange = 420,
				skillName = "Tinh Không Phá "
			},
			new GStruct58
			{
				skillId = 384,
				skillRange = 180,
				skillName = "Bách Độc Xuyên Tâm "
			},
			new GStruct58
			{
				skillId = 385,
				skillRange = 360,
				skillName = "Thôi Song Vọng Nguyệt"
			},
			new GStruct58
			{
				skillId = 386,
				skillRange = 300,
				skillName = "Ngự Phong thuật"
			},
			new GStruct58
			{
				skillId = 387,
				skillRange = 400,
				skillName = "Bình Địa Hám Lôi "
			},
			new GStruct58
			{
				skillId = 388,
				skillRange = 180,
				skillName = "Truy Phong Độc Cát "
			},
			new GStruct58
			{
				skillId = 389,
				skillRange = 570,
				skillName = "Long Chiến Ư Dã "
			},
			new GStruct58
			{
				skillId = 390,
				skillRange = 440,
				skillName = "Đoạn Cân Hủ Cốt "
			},
			new GStruct58
			{
				skillId = 391,
				skillRange = 440,
				skillName = "Nhiếp Hồn Loạn Tâm "
			},
			new GStruct58
			{
				skillId = 392,
				skillRange = 470,
				skillName = "Thúc Phược Chú "
			},
			new GStruct58
			{
				skillId = 393,
				skillRange = 440,
				skillName = "Bắc Minh Đáo Hải"
			},
			new GStruct58
			{
				skillId = 394,
				skillRange = 440,
				skillName = "Túy Tiên Tá Cốt"
			},
			new GStruct58
			{
				skillId = 395,
				skillRange = 90,
				skillName = "Dã Cầu Quyền "
			},
			new GStruct58
			{
				skillId = 396,
				skillRange = 180,
				skillName = "Xuân Phong Vũ Lộ "
			},
			new GStruct58
			{
				skillId = 397,
				skillRange = 180,
				skillName = "Vũ Lộ Xuân Phong  "
			},
			new GStruct58
			{
				skillId = 398,
				skillRange = 360,
				skillName = "Phong Quyển Tàn Tuyết (ảnh động) "
			},
			new GStruct58
			{
				skillId = 399,
				skillRange = 360,
				skillName = "Thiên Tế Tấn Lôi (ảnh động) "
			},
			new GStruct58
			{
				skillId = 400,
				skillRange = 360,
				skillName = "Kiếp Phú Tế Bần "
			},
			new GStruct58
			{
				skillId = 404,
				skillRange = 75,
				skillName = "Kinh Lôi Trảm  "
			},
			new GStruct58
			{
				skillId = 405,
				skillRange = 75,
				skillName = "Trảm Long quyết "
			},
			new GStruct58
			{
				skillId = 406,
				skillRange = 75,
				skillName = "Hàng Vân Quyết "
			},
			new GStruct58
			{
				skillId = 407,
				skillRange = 72,
				skillName = "Thừa Long Quyết  "
			},
			new GStruct58
			{
				skillId = 408,
				skillRange = 72,
				skillName = "Truy Phong Quyết  "
			},
			new GStruct58
			{
				skillId = 409,
				skillRange = 75,
				skillName = "Dã Cầu Quyền  "
			},
			new GStruct58
			{
				skillId = 410,
				skillRange = 0,
				skillName = "Bánh chưng May mắn "
			},
			new GStruct58
			{
				skillId = 411,
				skillRange = 0,
				skillName = "Nê Thu Công "
			},
			new GStruct58
			{
				skillId = 412,
				skillRange = 0,
				skillName = "Trường Sinh Quy Mệnh Quyết"
			},
			new GStruct58
			{
				skillId = 413,
				skillRange = 0,
				skillName = "Linh Hồ Khai Thần thuật "
			},
			new GStruct58
			{
				skillId = 414,
				skillRange = 180,
				skillName = "Kê Khuyển Thăng Thiên "
			},
			new GStruct58
			{
				skillId = 415,
				skillRange = 180,
				skillName = "Kê Khuyển Thăng Thiên "
			},
			new GStruct58
			{
				skillId = 416,
				skillRange = 200,
				skillName = "Đoạn Hồn Thích npc"
			},
			new GStruct58
			{
				skillId = 417,
				skillRange = 75,
				skillName = "Đoạn Hồn Thích npc"
			},
			new GStruct58
			{
				skillId = 418,
				skillRange = 100,
				skillName = "Công kích vật lý  npc"
			},
			new GStruct58
			{
				skillId = 429,
				skillRange = 360,
				skillName = "Tam Nga Tề Tuyết npc"
			},
			new GStruct58
			{
				skillId = 430,
				skillRange = 400,
				skillName = "Ngọc Tuyền Tẩy Trần npc"
			},
			new GStruct58
			{
				skillId = 431,
				skillRange = 470,
				skillName = "Thiên Địa Vô Cực npc"
			},
			new GStruct58
			{
				skillId = 432,
				skillRange = 400,
				skillName = "Kiếm Khí Tung Hoành npc"
			},
			new GStruct58
			{
				skillId = 433,
				skillRange = 420,
				skillName = "Thiên Ngoại Lưu Tinh npc"
			},
			new GStruct58
			{
				skillId = 434,
				skillRange = 570,
				skillName = "Nghiệp Hỏa Phàn Thành npc"
			},
			new GStruct58
			{
				skillId = 435,
				skillRange = 400,
				skillName = "Ma Viêm Tại Thiên npc"
			},
			new GStruct58
			{
				skillId = 436,
				skillRange = 470,
				skillName = "Bạo Vũ Lê Hoa npc"
			},
			new GStruct58
			{
				skillId = 437,
				skillRange = 400,
				skillName = "Truy Tinh Trục Điện npc"
			},
			new GStruct58
			{
				skillId = 438,
				skillRange = 470,
				skillName = "Thái Cực Vô ý npc"
			},
			new GStruct58
			{
				skillId = 439,
				skillRange = 400,
				skillName = "Nộ Lôi Liên Hoàn kích npc"
			},
			new GStruct58
			{
				skillId = 440,
				skillRange = 0,
				skillName = "Tiên Thảo Lộ "
			},
			new GStruct58
			{
				skillId = 441,
				skillRange = 0,
				skillName = "Thiên sơn  Bảo Lộ "
			},
			new GStruct58
			{
				skillId = 442,
				skillRange = 0,
				skillName = "Bách Quả Lộ "
			},
			new GStruct58
			{
				skillId = 443,
				skillRange = 0,
				skillName = "Bạch Câu hoàn"
			},
			new GStruct58
			{
				skillId = 444,
				skillRange = 0,
				skillName = "Phúc Tinh Cao Chiếu "
			},
			new GStruct58
			{
				skillId = 445,
				skillRange = 90,
				skillName = "công kích cơ bản (kim) "
			},
			new GStruct58
			{
				skillId = 446,
				skillRange = 90,
				skillName = "công kích cơ bản (mộc) "
			},
			new GStruct58
			{
				skillId = 447,
				skillRange = 90,
				skillName = "công kích cơ bản (thủy) "
			},
			new GStruct58
			{
				skillId = 448,
				skillRange = 90,
				skillName = "công kích cơ bản (hỏa) "
			},
			new GStruct58
			{
				skillId = 449,
				skillRange = 90,
				skillName = "công kích cơ bản (thổ) "
			},
			new GStruct58
			{
				skillId = 534,
				skillRange = 90,
				skillName = "Ngũ hành công kích. Kim"
			},
			new GStruct58
			{
				skillId = 535,
				skillRange = 90,
				skillName = "Ngũ hành công kích. Mộc"
			},
			new GStruct58
			{
				skillId = 536,
				skillRange = 90,
				skillName = "Ngũ hành công kích. Thủy"
			},
			new GStruct58
			{
				skillId = 537,
				skillRange = 90,
				skillName = "Ngũ hành công kích. Hỏa"
			},
			new GStruct58
			{
				skillId = 538,
				skillRange = 90,
				skillName = "Ngũ hành công kích. Thổ "
			},
			new GStruct58
			{
				skillId = 539,
				skillRange = 180,
				skillName = "Vòng tròn  miễn dịch "
			},
			new GStruct58
			{
				skillId = 540,
				skillRange = 180,
				skillName = "Vòng tròn  miễn dịch "
			},
			new GStruct58
			{
				skillId = 549,
				skillRange = 0,
				skillName = "Kim Cang Bất Phá "
			},
			new GStruct58
			{
				skillId = 550,
				skillRange = 0,
				skillName = "Bách Độc Bất Xâm"
			},
			new GStruct58
			{
				skillId = 551,
				skillRange = 0,
				skillName = "Băng Tuyết Sơ Dung"
			},
			new GStruct58
			{
				skillId = 552,
				skillRange = 0,
				skillName = "Chân Hỏa Kháng Lực"
			},
			new GStruct58
			{
				skillId = 553,
				skillRange = 0,
				skillName = "Lôi Đình Hộ giáp"
			},
			new GStruct58
			{
				skillId = 554,
				skillRange = 75,
				skillName = "Ngân Câu Thiết Hoạch "
			},
			new GStruct58
			{
				skillId = 555,
				skillRange = 75,
				skillName = "Hải Thiên Nhất Tuyến "
			},
			new GStruct58
			{
				skillId = 556,
				skillRange = 75,
				skillName = "Phá Không Trảm ảnh "
			},
			new GStruct58
			{
				skillId = 557,
				skillRange = 75,
				skillName = "Bất Diệt Sát ý "
			},
			new GStruct58
			{
				skillId = 558,
				skillRange = 600,
				skillName = "Trấn Ngục Phá Thiên. "
			},
			new GStruct58
			{
				skillId = 559,
				skillRange = 600,
				skillName = "Đại Bi Chú "
			},
			new GStruct58
			{
				skillId = 560,
				skillRange = 300,
				skillName = "Hắc Sát Thần Sa "
			},
			new GStruct58
			{
				skillId = 561,
				skillRange = 300,
				skillName = "Thiên Thù Vạn Độc  "
			},
			new GStruct58
			{
				skillId = 562,
				skillRange = 300,
				skillName = "Bi Ma Huyết Quang "
			},
			new GStruct58
			{
				skillId = 563,
				skillRange = 350,
				skillName = "Cô Yên Trục Vân "
			},
			new GStruct58
			{
				skillId = 564,
				skillRange = 600,
				skillName = "Luyện Ngục Hủ Cốt "
			},
			new GStruct58
			{
				skillId = 565,
				skillRange = 600,
				skillName = "Thực Cốt Huyết Nhẫn "
			},
			new GStruct58
			{
				skillId = 566,
				skillRange = 280,
				skillName = "Triều Khởi Nguyệt Doanh "
			},
			new GStruct58
			{
				skillId = 567,
				skillRange = 280,
				skillName = "Vạn Liễu Phiêu Phong "
			},
			new GStruct58
			{
				skillId = 568,
				skillRange = 300,
				skillName = "Tuyết ánh Hồng Trần  "
			},
			new GStruct58
			{
				skillId = 569,
				skillRange = 320,
				skillName = "Sương Dã Tiên Tung "
			},
			new GStruct58
			{
				skillId = 570,
				skillRange = 600,
				skillName = "Nghịch Chuyển Tâm Kinh "
			},
			new GStruct58
			{
				skillId = 571,
				skillRange = 600,
				skillName = "Huyền Băng Âm Khí "
			},
			new GStruct58
			{
				skillId = 572,
				skillRange = 180,
				skillName = "Viêm Long Chi Bào  "
			},
			new GStruct58
			{
				skillId = 573,
				skillRange = 180,
				skillName = "Triều Dương Liệt Diệm"
			},
			new GStruct58
			{
				skillId = 574,
				skillRange = 200,
				skillName = "Như Nhật Trung Thiên "
			},
			new GStruct58
			{
				skillId = 575,
				skillRange = 200,
				skillName = "Xí Không Hỏa Vũ "
			},
			new GStruct58
			{
				skillId = 576,
				skillRange = 600,
				skillName = "Trần Không Phạm Tẫn "
			},
			new GStruct58
			{
				skillId = 577,
				skillRange = 600,
				skillName = "Hỏa Phụng Khinh Ngâm  "
			},
			new GStruct58
			{
				skillId = 578,
				skillRange = 220,
				skillName = "Hỗn Nguyên Càn Khôn "
			},
			new GStruct58
			{
				skillId = 579,
				skillRange = 240,
				skillName = "Trường Hà Lạc Nhật "
			},
			new GStruct58
			{
				skillId = 580,
				skillRange = 260,
				skillName = "Tật Phong Tấn Lôi"
			},
			new GStruct58
			{
				skillId = 581,
				skillRange = 260,
				skillName = "Vô ảnh Kiếm Quyết "
			},
			new GStruct58
			{
				skillId = 582,
				skillRange = 600,
				skillName = "Thuần Dương Vô Cực"
			},
			new GStruct58
			{
				skillId = 583,
				skillRange = 600,
				skillName = "Vân Sinh Kết Hải "
			},
			new GStruct58
			{
				skillId = 584,
				skillRange = 0,
				skillName = "Bình Hoà Khí Quyết"
			},
			new GStruct58
			{
				skillId = 585,
				skillRange = 0,
				skillName = "Hư Không Thiểm ảnh"
			},
			new GStruct58
			{
				skillId = 586,
				skillRange = 0,
				skillName = "Hội Thần Tĩnh tâm"
			},
			new GStruct58
			{
				skillId = 587,
				skillRange = 400,
				skillName = "Vô Niệm Vô Kinh"
			},
			new GStruct58
			{
				skillId = 588,
				skillRange = 0,
				skillName = "Ngũ Hành Vô Tướng"
			},
			new GStruct58
			{
				skillId = 589,
				skillRange = 0,
				skillName = "Di Khí Phiêu Tung"
			},
			new GStruct58
			{
				skillId = 590,
				skillRange = 0,
				skillName = "Hoa Phi Điệp Vũ "
			},
			new GStruct58
			{
				skillId = 591,
				skillRange = 400,
				skillName = "Lưu Quang Phi Vũ"
			},
			new GStruct58
			{
				skillId = 592,
				skillRange = 400,
				skillName = "Hoàn Bỉ Chi Thân"
			},
			new GStruct58
			{
				skillId = 593,
				skillRange = 400,
				skillName = "Đảo Hành Nghịch Thi"
			},
			new GStruct58
			{
				skillId = 594,
				skillRange = 0,
				skillName = "Tính Ngạo Tam Đông"
			},
			new GStruct58
			{
				skillId = 595,
				skillRange = 400,
				skillName = "Điểm Huyết Tiệt Mạch"
			},
			new GStruct58
			{
				skillId = 596,
				skillRange = 0,
				skillName = "Vạn Độc Bất Phục"
			},
			new GStruct58
			{
				skillId = 597,
				skillRange = 0,
				skillName = "Thân Khinh Như Yến"
			},
			new GStruct58
			{
				skillId = 598,
				skillRange = 0,
				skillName = "Ngưng Âm Quy Nguyên"
			},
			new GStruct58
			{
				skillId = 599,
				skillRange = 0,
				skillName = "Dịch Cân Kinh"
			},
			new GStruct58
			{
				skillId = 600,
				skillRange = 400,
				skillName = "Thúc Thân Thuật"
			},
			new GStruct58
			{
				skillId = 601,
				skillRange = 400,
				skillName = "Hoãn Thân Thuật"
			},
			new GStruct58
			{
				skillId = 602,
				skillRange = 400,
				skillName = "Huyền Mục Định Thân Thuật"
			},
			new GStruct58
			{
				skillId = 603,
				skillRange = 0,
				skillName = "ích Thọ Âm Dương"
			},
			new GStruct58
			{
				skillId = 604,
				skillRange = 400,
				skillName = "An Phủ Chi Ngữ "
			},
			new GStruct58
			{
				skillId = 605,
				skillRange = 0,
				skillName = "Nữu Chuyển Càn Khôn"
			},
			new GStruct58
			{
				skillId = 606,
				skillRange = 0,
				skillName = "Tam Sinh Hữu Hạnh"
			},
			new GStruct58
			{
				skillId = 607,
				skillRange = 400,
				skillName = "Quỷ Mê Ma Hoặc"
			},
			new GStruct58
			{
				skillId = 608,
				skillRange = 400,
				skillName = "Đoạt Mệnh Triền Nhiễu "
			},
			new GStruct58
			{
				skillId = 609,
				skillRange = 400,
				skillName = "Yêu Hồ Trái ảnh"
			},
			new GStruct58
			{
				skillId = 610,
				skillRange = 400,
				skillName = "Hoặc Thần Loạn Tâm"
			},
			new GStruct58
			{
				skillId = 611,
				skillRange = 400,
				skillName = "Cô Thân Toái ảnh"
			},
			new GStruct58
			{
				skillId = 612,
				skillRange = 400,
				skillName = "Tử Vong Ki Bán"
			},
			new GStruct58
			{
				skillId = 613,
				skillRange = 400,
				skillName = "Thâm Hồn Niệm Xướng"
			},
			new GStruct58
			{
				skillId = 614,
				skillRange = 400,
				skillName = "Cập Hồn Chú "
			},
			new GStruct58
			{
				skillId = 615,
				skillRange = 400,
				skillName = "Hóa Tủy Vô ý "
			},
			new GStruct58
			{
				skillId = 616,
				skillRange = 400,
				skillName = "Dung Cốt Vô Tung "
			},
			new GStruct58
			{
				skillId = 617,
				skillRange = 400,
				skillName = "Âm Triều Chi Khí"
			},
			new GStruct58
			{
				skillId = 618,
				skillRange = 400,
				skillName = "ám Độc Chi Thủ "
			},
			new GStruct58
			{
				skillId = 619,
				skillRange = 400,
				skillName = "Tam Phục Chi Khí "
			},
			new GStruct58
			{
				skillId = 620,
				skillRange = 0,
				skillName = "Đấu Chuyển Tinh Di"
			},
			new GStruct58
			{
				skillId = 621,
				skillRange = 200,
				skillName = "Nam Minh Tam Đoạn Kích "
			},
			new GStruct58
			{
				skillId = 629,
				skillRange = 0,
				skillName = "Lăng Ba Vi Bộ "
			},
			new GStruct58
			{
				skillId = 630,
				skillRange = 0,
				skillName = "Huyền Thiên Vô Cực"
			},
			new GStruct58
			{
				skillId = 657,
				skillRange = 280,
				skillName = "Vạn Liễu Phiêu Phong  "
			},
			new GStruct58
			{
				skillId = 658,
				skillRange = 320,
				skillName = "Sương Dã Tiên Tung  "
			},
			new GStruct58
			{
				skillId = 659,
				skillRange = 260,
				skillName = "Tật Phong Tấn Lôi "
			},
			new GStruct58
			{
				skillId = 660,
				skillRange = 400,
				skillName = "Vô Nhân Vô Ngã "
			},
			new GStruct58
			{
				skillId = 668,
				skillRange = 50,
				skillName = "Bẫy choáng (Giáng Sinh) "
			},
			new GStruct58
			{
				skillId = 669,
				skillRange = 50,
				skillName = "Bẫy giảm tốc (Giáng Sinh) "
			},
			new GStruct58
			{
				skillId = 670,
				skillRange = 0,
				skillName = "Bẫy tăng tốc (Giáng Sinh) "
			},
			new GStruct58
			{
				skillId = 671,
				skillRange = 50,
				skillName = "Bẫy hôn mê (Giáng Sinh) "
			},
			new GStruct58
			{
				skillId = 672,
				skillRange = 50,
				skillName = "Bẫy giảm tốc (Giáng Sinh) "
			},
			new GStruct58
			{
				skillId = 673,
				skillRange = 0,
				skillName = "Bẫy hôn mê (Giáng Sinh) "
			},
			new GStruct58
			{
				skillId = 674,
				skillRange = 0,
				skillName = "Bẫy giảm tốc (Giáng Sinh) "
			},
			new GStruct58
			{
				skillId = 707,
				skillRange = 0,
				skillName = "Thiên Cơ Lệnh"
			},
			new GStruct58
			{
				skillId = 708,
				skillRange = 0,
				skillName = "Đảo Hư Thiên"
			},
			new GStruct58
			{
				skillId = 709,
				skillRange = 0,
				skillName = "Đại Thừa Như Lai Chú"
			},
			new GStruct58
			{
				skillId = 710,
				skillRange = 0,
				skillName = "Mê ảnh Tung"
			},
			new GStruct58
			{
				skillId = 711,
				skillRange = 0,
				skillName = "Hấp Tinh Yểm"
			},
			new GStruct58
			{
				skillId = 712,
				skillRange = 180,
				skillName = "Bế Nguyệt Phất Trần"
			},
			new GStruct58
			{
				skillId = 713,
				skillRange = 0,
				skillName = "Ngự Tuyết ẩn"
			},
			new GStruct58
			{
				skillId = 714,
				skillRange = 0,
				skillName = "Hỗn Thiên Khí Công"
			},
			new GStruct58
			{
				skillId = 715,
				skillRange = 0,
				skillName = "Ma Âm Phệ Phách"
			},
			new GStruct58
			{
				skillId = 716,
				skillRange = 0,
				skillName = "Xuất ứ Bất Nhiễm"
			},
			new GStruct58
			{
				skillId = 717,
				skillRange = 0,
				skillName = "Lưỡng Nghi Chân Khí"
			},
			new GStruct58
			{
				skillId = 718,
				skillRange = 180,
				skillName = "Kỹ năng phụ - Bế Nguyệt Phất Trần"
			},
			new GStruct58
			{
				skillId = 719,
				skillRange = 0,
				skillName = "Hấp Tinh Yểm_Quyết Chú"
			},
			new GStruct58
			{
				skillId = 720,
				skillRange = 440,
				skillName = "Hỗn Thiên Khí Công_Quyết Chú"
			},
			new GStruct58
			{
				skillId = 721,
				skillRange = 0,
				skillName = "Lưỡng Nghi Chân Khí_Ma Pháp Độn"
			},
			new GStruct58
			{
				skillId = 722,
				skillRange = 0,
				skillName = "Lưỡng Nghi Chân Khí_Gia Tốc"
			},
			new GStruct58
			{
				skillId = 723,
				skillRange = 180,
				skillName = "Ma Âm Phệ Phách - Hoảng loạn"
			},
			new GStruct58
			{
				skillId = 724,
				skillRange = 0,
				skillName = "Đảo Hư Thiên_Kháng bùa chú"
			},
			new GStruct58
			{
				skillId = 725,
				skillRange = 0,
				skillName = "Đại Thừa Như Lai Chú_Phản đòn bùa chú"
			},
			new GStruct58
			{
				skillId = 726,
				skillRange = 0,
				skillName = "Vòng sáng Thương Dăng"
			},
			new GStruct58
			{
				skillId = 727,
				skillRange = 0,
				skillName = "Vòng sáng Hương Tiêu"
			},
			new GStruct58
			{
				skillId = 728,
				skillRange = 0,
				skillName = "Vòng sáng Thương Ưng"
			},
			new GStruct58
			{
				skillId = 729,
				skillRange = 0,
				skillName = "Vòng sáng Hỏa Diệm"
			},
			new GStruct58
			{
				skillId = 730,
				skillRange = 0,
				skillName = "Vòng sáng ám ảnh"
			},
			new GStruct58
			{
				skillId = 731,
				skillRange = 0,
				skillName = "Vòng sáng Thất Kiếm"
			},
			new GStruct58
			{
				skillId = 732,
				skillRange = 0,
				skillName = "GM di chuyển"
			},
			new GStruct58
			{
				skillId = 733,
				skillRange = 0,
				skillName = "GM ẩn thân"
			},
			new GStruct58
			{
				skillId = 734,
				skillRange = 0,
				skillName = "Kỹ năng phụ - Sư Tử Hống"
			},
			new GStruct58
			{
				skillId = 735,
				skillRange = 0,
				skillName = "Linh Sâm Lực"
			},
			new GStruct58
			{
				skillId = 736,
				skillRange = 500,
				skillName = "Bang hội_Ném trùng đỏ"
			},
			new GStruct58
			{
				skillId = 737,
				skillRange = 500,
				skillName = "Kỹ năng ngụy trang"
			},
			new GStruct58
			{
				skillId = 738,
				skillRange = 0,
				skillName = "Kỹ năng phụ - Xuất ứ Bất Nhiễm"
			},
			new GStruct58
			{
				skillId = 739,
				skillRange = 0,
				skillName = "Kỹ năng bang hội_Phụng Hoàng ấn"
			},
			new GStruct58
			{
				skillId = 740,
				skillRange = 0,
				skillName = "Kỹ năng bang hội_Đoạn Võ Hồn"
			},
			new GStruct58
			{
				skillId = 741,
				skillRange = 0,
				skillName = "Kỹ năng bang hội_Vô Song Sát Trận"
			},
			new GStruct58
			{
				skillId = 742,
				skillRange = 0,
				skillName = "Kỹ năng bang hội_Đào Chu Tiền Đái"
			},
			new GStruct58
			{
				skillId = 743,
				skillRange = 0,
				skillName = "Kỹ năng bang hội_Thị Vệ Doanh"
			},
			new GStruct58
			{
				skillId = 744,
				skillRange = 0,
				skillName = "Kỹ năng bang hội_Linh Sâm Lực"
			},
			new GStruct58
			{
				skillId = 745,
				skillRange = 0,
				skillName = "Kỹ năng bang hội_Hoàng Kim Lệnh"
			},
			new GStruct58
			{
				skillId = 749,
				skillRange = 0,
				skillName = "Thiên Nhãn Phù_IB"
			},
			new GStruct58
			{
				skillId = 750,
				skillRange = 0,
				skillName = "Tăng điểm kinh nghiệm kỹ năng 120"
			},
			new GStruct58
			{
				skillId = 751,
				skillRange = 0,
				skillName = "Tăng Sinh, Nội lực (kỹ năng) "
			},
			new GStruct58
			{
				skillId = 752,
				skillRange = 400,
				skillName = "Quả cầu tuyết"
			},
			new GStruct58
			{
				skillId = 753,
				skillRange = 440,
				skillName = "Boss Dã Tẩu làm choáng"
			},
			new GStruct58
			{
				skillId = 754,
				skillRange = 440,
				skillName = "Boss Dã Tẩu giật lùi"
			},
			new GStruct58
			{
				skillId = 755,
				skillRange = 440,
				skillName = "Boss Dã Tẩu làm chậm"
			},
			new GStruct58
			{
				skillId = 756,
				skillRange = 160,
				skillName = "Kinh nghiệm pháo hoa Tết 1"
			},
			new GStruct58
			{
				skillId = 757,
				skillRange = 0,
				skillName = "Hiệu quả pháo hoa Tết"
			},
			new GStruct58
			{
				skillId = 758,
				skillRange = 0,
				skillName = "Chữ pháo hoa Tết 1a"
			},
			new GStruct58
			{
				skillId = 759,
				skillRange = 0,
				skillName = "Chữ pháo hoa Tết 1b"
			},
			new GStruct58
			{
				skillId = 760,
				skillRange = 160,
				skillName = "Kinh nghiệm pháo hoa Tết 2"
			},
			new GStruct58
			{
				skillId = 763,
				skillRange = 60,
				skillName = "Pháo nổ"
			},
			new GStruct58
			{
				skillId = 840,
				skillRange = 160,
				skillName = "ảậẻỗẹèằăắưẹộ"
			},
			new GStruct58
			{
				skillId = 874,
				skillRange = 180,
				skillName = "ạƠ³ầếẵ³àạõằã"
			},
			new GStruct58
			{
				skillId = 875,
				skillRange = 180,
				skillName = "ạƠ³ầếẵ³àạõằãìểà\u00af"
			},
			new GStruct58
			{
				skillId = 876,
				skillRange = 180,
				skillName = "ÄĐềụấẫặầ_BOSSìăểÃ"
			},
			new GStruct58
			{
				skillId = 877,
				skillRange = 400,
				skillName = "Súng nước"
			},
			new GStruct58
			{
				skillId = 930,
				skillRange = 400,
				skillName = "ảẽằờ\u00b4è_BOSSìăểÃ"
			},
			new GStruct58
			{
				skillId = 931,
				skillRange = 420,
				skillName = "èỡÍõÁữéầ_boss"
			},
			new GStruct58
			{
				skillId = 932,
				skillRange = 160,
				skillName = "ãÅ±ơệủèỉéĐ"
			},
			new GStruct58
			{
				skillId = 933,
				skillRange = 400,
				skillName = "Cuồng nộ ngưu"
			},
			new GStruct58
			{
				skillId = 934,
				skillRange = 400,
				skillName = "¿ủÅÊệđÅưìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 935,
				skillRange = 400,
				skillName = "Mãnh ngưu cường tập"
			},
			new GStruct58
			{
				skillId = 936,
				skillRange = 400,
				skillName = "ÃÍÅÊầ¿ẽđìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 937,
				skillRange = 72,
				skillName = "Tiểu ngưu lưu tinh đan"
			},
			new GStruct58
			{
				skillId = 938,
				skillRange = 50,
				skillName = "éĂÅÊÁữéầà\u00afìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 939,
				skillRange = 180,
				skillName = "Hào quang Ngưu Ma Vương"
			},
			new GStruct58
			{
				skillId = 940,
				skillRange = 180,
				skillName = "Hào quang hình viên đạn của Ngưu Ma Vương"
			},
			new GStruct58
			{
				skillId = 941,
				skillRange = 180,
				skillName = "Hào quang mãnh ngưu"
			},
			new GStruct58
			{
				skillId = 942,
				skillRange = 180,
				skillName = "ÃÍÅÊạõằãìểà\u00af"
			},
			new GStruct58
			{
				skillId = 943,
				skillRange = 180,
				skillName = "Hào quang thái ngưu"
			},
			new GStruct58
			{
				skillId = 944,
				skillRange = 180,
				skillName = "²ậÅÊạõằãìểà\u00af"
			},
			new GStruct58
			{
				skillId = 945,
				skillRange = 180,
				skillName = "Hào quang ẩn thân"
			},
			new GStruct58
			{
				skillId = 946,
				skillRange = 180,
				skillName = "testạõằã"
			},
			new GStruct58
			{
				skillId = 947,
				skillRange = 400,
				skillName = "testskill1"
			},
			new GStruct58
			{
				skillId = 948,
				skillRange = 400,
				skillName = "testskill2"
			},
			new GStruct58
			{
				skillId = 949,
				skillRange = 72,
				skillName = "testskill3"
			},
			new GStruct58
			{
				skillId = 950,
				skillRange = 180,
				skillName = "Hào quang ẩn thân"
			},
			new GStruct58
			{
				skillId = 951,
				skillRange = 50,
				skillName = "¿ỉệặéÍẹÊễẻẽíÚồ"
			},
			new GStruct58
			{
				skillId = 964,
				skillRange = 180,
				skillName = "ẳừ¿ạạõằã"
			},
			new GStruct58
			{
				skillId = 965,
				skillRange = 180,
				skillName = "ẳừ¿ạạõằãìểà\u00af"
			},
			new GStruct58
			{
				skillId = 966,
				skillRange = 180,
				skillName = "Tăng võ công"
			},
			new GStruct58
			{
				skillId = 967,
				skillRange = 180,
				skillName = "Tăng kinh nghiệm"
			},
			new GStruct58
			{
				skillId = 968,
				skillRange = 400,
				skillName = "GM\u00b4úãảẻĐạƠằữẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 969,
				skillRange = 400,
				skillName = "GM\u00b4úãảẻĐạƠằữẳẳÄĩìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 970,
				skillRange = 400,
				skillName = "GMằự\u00b4ĂạƠằữẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 971,
				skillRange = 400,
				skillName = "GMéĂãảẻĐạƠằữẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 972,
				skillRange = 180,
				skillName = "GMạõằã"
			},
			new GStruct58
			{
				skillId = 973,
				skillRange = 180,
				skillName = "GMạõằãìểà\u00af"
			},
			new GStruct58
			{
				skillId = 974,
				skillRange = 400,
				skillName = "GMẻ±ạƠằữẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 975,
				skillRange = 400,
				skillName = "GMẻ±ạƠằữẳẳÄĩìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 979,
				skillRange = 180,
				skillName = "Hồng Nguyệt"
			},
			new GStruct58
			{
				skillId = 980,
				skillRange = 180,
				skillName = "ÀảễÂ"
			},
			new GStruct58
			{
				skillId = 981,
				skillRange = 0,
				skillName = "Nến Cát Tường"
			},
			new GStruct58
			{
				skillId = 982,
				skillRange = 0,
				skillName = "Nến Như ý"
			},
			new GStruct58
			{
				skillId = 983,
				skillRange = 180,
				skillName = "La Hán Trận"
			},
			new GStruct58
			{
				skillId = 984,
				skillRange = 180,
				skillName = "La Hán Trận "
			},
			new GStruct58
			{
				skillId = 985,
				skillRange = 448,
				skillName = "ạưặùẳẳÄĩ1"
			},
			new GStruct58
			{
				skillId = 986,
				skillRange = 448,
				skillName = "ạư±ứẳẳÄĩ1"
			},
			new GStruct58
			{
				skillId = 993,
				skillRange = 0,
				skillName = "Đại Diệp Khí Tráo"
			},
			new GStruct58
			{
				skillId = 994,
				skillRange = 0,
				skillName = "Đại Diệp Khí Tráo (bị động )"
			},
			new GStruct58
			{
				skillId = 995,
				skillRange = 0,
				skillName = "Huyễn Anh Mê Tung Bộ"
			},
			new GStruct58
			{
				skillId = 996,
				skillRange = 0,
				skillName = "Huyễn Anh Mê Tung Bộ ( bị động )"
			},
			new GStruct58
			{
				skillId = 997,
				skillRange = 0,
				skillName = "Huyễn Anh Mê Tung Bộ"
			},
			new GStruct58
			{
				skillId = 998,
				skillRange = 0,
				skillName = "Trọng kích tuyệt đối"
			},
			new GStruct58
			{
				skillId = 999,
				skillRange = 0,
				skillName = "Công kích tuyệt đối ( bị động )"
			},
			new GStruct58
			{
				skillId = 1000,
				skillRange = 1000,
				skillName = "tianchiằỳạỉ"
			},
			new GStruct58
			{
				skillId = 1001,
				skillRange = 400,
				skillName = "tianchi3²ó"
			},
			new GStruct58
			{
				skillId = 1002,
				skillRange = 800,
				skillName = "tianchi3²óìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1003,
				skillRange = 400,
				skillName = "èỡ³ỉẽíÚồ"
			},
			new GStruct58
			{
				skillId = 1004,
				skillRange = 180,
				skillName = "èỡ³ỉẽíÚồìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1006,
				skillRange = 400,
				skillName = "èỡ³ỉboss"
			},
			new GStruct58
			{
				skillId = 1007,
				skillRange = 400,
				skillName = "èỡ³ỉbossìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1009,
				skillRange = 180,
				skillName = "ẩôẳẳÄĩ+1ì\u00b4èơ"
			},
			new GStruct58
			{
				skillId = 1010,
				skillRange = 0,
				skillName = "Kim Cang Bất Hoại Thần Đơn"
			},
			new GStruct58
			{
				skillId = 1011,
				skillRange = 0,
				skillName = "Huyết ảnh Thần Hành Đơn"
			},
			new GStruct58
			{
				skillId = 1012,
				skillRange = 0,
				skillName = "Ngự Tuyết Băng Tâm Đơn"
			},
			new GStruct58
			{
				skillId = 1013,
				skillRange = 800,
				skillName = "Àọ±ựẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1014,
				skillRange = 800,
				skillName = "Àọ±ự±ựầẵ"
			},
			new GStruct58
			{
				skillId = 1015,
				skillRange = 800,
				skillName = "ÁỳắÅèỡ±ọẫớẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1016,
				skillRange = 800,
				skillName = "ÁỳắÅèỡ±ọẫớẳẳÄĩìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1017,
				skillRange = 1000,
				skillName = "ắứẫ±XºÅẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1018,
				skillRange = 800,
				skillName = "ắứẫ±XºÅìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1021,
				skillRange = 800,
				skillName = "Thúy Ngọc Băng Huyền"
			},
			new GStruct58
			{
				skillId = 1022,
				skillRange = 800,
				skillName = "\u00b4ọểủ±ựéỵìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1024,
				skillRange = 400,
				skillName = "Ngưng Tuyết Hàn Sương"
			},
			new GStruct58
			{
				skillId = 1025,
				skillRange = 420,
				skillName = "Phát ra Tri Thù tơ"
			},
			new GStruct58
			{
				skillId = 1026,
				skillRange = 420,
				skillName = "ạÅắứẫ±ảắấệ"
			},
			new GStruct58
			{
				skillId = 1027,
				skillRange = 448,
				skillName = "Không cử động được"
			},
			new GStruct58
			{
				skillId = 1029,
				skillRange = 400,
				skillName = "ẵÊÚÊ23ºÅẻịéẻạặ"
			},
			new GStruct58
			{
				skillId = 1030,
				skillRange = 180,
				skillName = "ẵÊÚÊ23ºÅẻịéẻạặìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1031,
				skillRange = 360,
				skillName = "ẫòÍừẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1032,
				skillRange = 480,
				skillName = "ÍÂảắậđẳểầ¿"
			},
			new GStruct58
			{
				skillId = 1033,
				skillRange = 400,
				skillName = "¿ủÅÊệđÅư5minCD"
			},
			new GStruct58
			{
				skillId = 1034,
				skillRange = 400,
				skillName = "ÃÍÅÊầ¿ẽđ5minCD"
			},
			new GStruct58
			{
				skillId = 1035,
				skillRange = 400,
				skillName = "éĂÅÊÁữéầà\u00af5minCD"
			},
			new GStruct58
			{
				skillId = 1036,
				skillRange = 180,
				skillName = "ÂịººếúNPCạ²ẽớ"
			},
			new GStruct58
			{
				skillId = 1037,
				skillRange = 180,
				skillName = "Âịººếúìểà\u00afNPCạ²ẽớ"
			},
			new GStruct58
			{
				skillId = 1043,
				skillRange = 180,
				skillName = "La Hán Trận"
			},
			new GStruct58
			{
				skillId = 1044,
				skillRange = 180,
				skillName = "Âịººếúìểà\u00afNPCạ²ẽớ"
			},
			new GStruct58
			{
				skillId = 1045,
				skillRange = 480,
				skillName = "Cửu Long Tại Thiên"
			},
			new GStruct58
			{
				skillId = 1046,
				skillRange = 480,
				skillName = "Song Long Hý Châu"
			},
			new GStruct58
			{
				skillId = 1047,
				skillRange = 480,
				skillName = "Đại Phong Khởi Hề"
			},
			new GStruct58
			{
				skillId = 1048,
				skillRange = 480,
				skillName = "Tả Tuyền Lam Kiếm Khí"
			},
			new GStruct58
			{
				skillId = 1049,
				skillRange = 480,
				skillName = "Hữu Tuyền Lam Kiếm Khí"
			},
			new GStruct58
			{
				skillId = 1050,
				skillRange = 800,
				skillName = "Lôi Điện Hạ Lạc"
			},
			new GStruct58
			{
				skillId = 1051,
				skillRange = 260,
				skillName = "\u00b4úãỗặð\u00a0õìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1052,
				skillRange = 470,
				skillName = "Tiêu Diêu Tán"
			},
			new GStruct58
			{
				skillId = 1053,
				skillRange = 470,
				skillName = "130"
			},
			new GStruct58
			{
				skillId = 1054,
				skillRange = 470,
				skillName = "140"
			},
			new GStruct58
			{
				skillId = 1055,
				skillRange = 200,
				skillName = "Đại Lực Kim Cang Chưởng"
			},
			new GStruct58
			{
				skillId = 1056,
				skillRange = 180,
				skillName = "Vi Đà Hiến Xử"
			},
			new GStruct58
			{
				skillId = 1057,
				skillRange = 400,
				skillName = "Tam Giới Quy Thiền"
			},
			new GStruct58
			{
				skillId = 1058,
				skillRange = 280,
				skillName = "Hào Hùng Trảm"
			},
			new GStruct58
			{
				skillId = 1059,
				skillRange = 72,
				skillName = "Tung Hoành Bát Hoang"
			},
			new GStruct58
			{
				skillId = 1060,
				skillRange = 108,
				skillName = "Bá Vương Tạm Kim"
			},
			new GStruct58
			{
				skillId = 1061,
				skillRange = 360,
				skillName = "Kiếm Hoa Vãn Tinh"
			},
			new GStruct58
			{
				skillId = 1062,
				skillRange = 400,
				skillName = "Băng Vũ Lạc Tinh"
			},
			new GStruct58
			{
				skillId = 1063,
				skillRange = 360,
				skillName = "Băng Tước Hoạt Kỳ"
			},
			new GStruct58
			{
				skillId = 1064,
				skillRange = 400,
				skillName = "Băng Ngưng Hàn Yên"
			},
			new GStruct58
			{
				skillId = 1065,
				skillRange = 240,
				skillName = "Thủy Anh Man Tú"
			},
			new GStruct58
			{
				skillId = 1066,
				skillRange = 420,
				skillName = "Hình Tiêu Cốt Lập"
			},
			new GStruct58
			{
				skillId = 1067,
				skillRange = 420,
				skillName = "U Hồn Phệ ảnh"
			},
			new GStruct58
			{
				skillId = 1068,
				skillRange = 420,
				skillName = "ểÄằờấẫể°2"
			},
			new GStruct58
			{
				skillId = 1069,
				skillRange = 360,
				skillName = "Vô ảnh Xuyên"
			},
			new GStruct58
			{
				skillId = 1070,
				skillRange = 470,
				skillName = "Thiết Liên Tứ Sát"
			},
			new GStruct58
			{
				skillId = 1071,
				skillRange = 360,
				skillName = "Càn Khôn Nhất Trịch"
			},
			new GStruct58
			{
				skillId = 1072,
				skillRange = 570,
				skillName = "Ngũ Diệu Càn Khôn"
			},
			new GStruct58
			{
				skillId = 1073,
				skillRange = 400,
				skillName = "Thời Thặng Lục Long"
			},
			new GStruct58
			{
				skillId = 1074,
				skillRange = 400,
				skillName = "Bổng Huýnh Lược Địa"
			},
			new GStruct58
			{
				skillId = 1075,
				skillRange = 60,
				skillName = "Giang Hải Nộ Lan"
			},
			new GStruct58
			{
				skillId = 1076,
				skillRange = 570,
				skillName = "Tật Hỏa Liệu Nguyên"
			},
			new GStruct58
			{
				skillId = 1077,
				skillRange = 280,
				skillName = "Hào Hùng Trảm Địa Liệt"
			},
			new GStruct58
			{
				skillId = 1078,
				skillRange = 470,
				skillName = "Tạo Hóa Thái Thanh"
			},
			new GStruct58
			{
				skillId = 1079,
				skillRange = 470,
				skillName = "Kiếm Thùy Tinh Hà"
			},
			new GStruct58
			{
				skillId = 1080,
				skillRange = 400,
				skillName = "Cửu Thiên Cương Phong"
			},
			new GStruct58
			{
				skillId = 1081,
				skillRange = 470,
				skillName = "Thiên Lôi Chấn Nhạc"
			},
			new GStruct58
			{
				skillId = 1082,
				skillRange = 180,
				skillName = "ÃðìùảẫẫỳàỉÁẹ"
			},
			new GStruct58
			{
				skillId = 1083,
				skillRange = 200,
				skillName = "Long Thừa Bát Nhã Thủ"
			},
			new GStruct58
			{
				skillId = 1084,
				skillRange = 280,
				skillName = "ºÀéÛếảìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1085,
				skillRange = 400,
				skillName = "ÍũÚéạộềằìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1086,
				skillRange = 280,
				skillName = "ºÀéÛếảẫÂ¿ê"
			},
			new GStruct58
			{
				skillId = 1087,
				skillRange = 72,
				skillName = "ìíºỏ°ậằÄẫậºƯ"
			},
			new GStruct58
			{
				skillId = 1088,
				skillRange = 108,
				skillName = "°ễÍừửẫẵðẫậºƯ"
			},
			new GStruct58
			{
				skillId = 1089,
				skillRange = 800,
				skillName = "Kiếm Tâm Tĩnh Điển"
			},
			new GStruct58
			{
				skillId = 1090,
				skillRange = 400,
				skillName = "ìẽẻÂ±ựằêẫậºƯ"
			},
			new GStruct58
			{
				skillId = 1091,
				skillRange = 800,
				skillName = "Áữãỗằỉẹâ±ựệự"
			},
			new GStruct58
			{
				skillId = 1092,
				skillRange = 400,
				skillName = "±ựẩáÂềẹâẫậºƯ"
			},
			new GStruct58
			{
				skillId = 1093,
				skillRange = 400,
				skillName = "Khinh Sa Phù Thủy"
			},
			new GStruct58
			{
				skillId = 1094,
				skillRange = 420,
				skillName = "éẻẽỳạầÁÂẫậºƯ"
			},
			new GStruct58
			{
				skillId = 1095,
				skillRange = 420,
				skillName = "Hồn ảnh Tùng Sanh"
			},
			new GStruct58
			{
				skillId = 1096,
				skillRange = 420,
				skillName = "éẻẽỳạầÁÂẫậºƯ2"
			},
			new GStruct58
			{
				skillId = 1097,
				skillRange = 400,
				skillName = "Truy Tâm Tỏa Mệnh"
			},
			new GStruct58
			{
				skillId = 1098,
				skillRange = 400,
				skillName = "Thiết Sa Xạ Tinh"
			},
			new GStruct58
			{
				skillId = 1099,
				skillRange = 360,
				skillName = "ầơÀÔềằệÀ2"
			},
			new GStruct58
			{
				skillId = 1100,
				skillRange = 360,
				skillName = "ầơÀÔềằệÀ3"
			},
			new GStruct58
			{
				skillId = 1101,
				skillRange = 400,
				skillName = "ấ±³ậÁựÁỳáẵấụ"
			},
			new GStruct58
			{
				skillId = 1102,
				skillRange = 240,
				skillName = "ằăìễặđÁóáẵấụ"
			},
			new GStruct58
			{
				skillId = 1103,
				skillRange = 280,
				skillName = "Thời Thặng Lục Long Hỏa"
			},
			new GStruct58
			{
				skillId = 1104,
				skillRange = 420,
				skillName = "ẳ²ằðÁầễư2"
			},
			new GStruct58
			{
				skillId = 1105,
				skillRange = 520,
				skillName = "Kiếm Vũ Diệu Nguyệt"
			},
			new GStruct58
			{
				skillId = 1106,
				skillRange = 400,
				skillName = "ễỡằ\u00afèôầồẫậºƯ"
			},
			new GStruct58
			{
				skillId = 1107,
				skillRange = 470,
				skillName = "Kiếm Minh Thương Khung"
			},
			new GStruct58
			{
				skillId = 1108,
				skillRange = 470,
				skillName = "Phong Minh Ngọc Toái"
			},
			new GStruct58
			{
				skillId = 1109,
				skillRange = 470,
				skillName = "Lôi Động Càn Khôn"
			},
			new GStruct58
			{
				skillId = 1110,
				skillRange = 420,
				skillName = "Tích Lịch Loạn Hoàn Kích"
			},
			new GStruct58
			{
				skillId = 1111,
				skillRange = 400,
				skillName = "Ãễạơệựìểằðầẵ"
			},
			new GStruct58
			{
				skillId = 1112,
				skillRange = 180,
				skillName = "ệéễẵPKẩỹẩôẳẳÄĩ+1"
			},
			new GStruct58
			{
				skillId = 1113,
				skillRange = 420,
				skillName = "Tích Lịch Loạn Hoàn Hãm Tĩnh"
			},
			new GStruct58
			{
				skillId = 1114,
				skillRange = 470,
				skillName = "Ngọc Tuyền Tâm Kinh"
			},
			new GStruct58
			{
				skillId = 1115,
				skillRange = 400,
				skillName = "Minh Tâm Kiến Tính"
			},
			new GStruct58
			{
				skillId = 1120,
				skillRange = 0,
				skillName = "Kích Công Trợ Lực Hoàn"
			},
			new GStruct58
			{
				skillId = 1121,
				skillRange = 0,
				skillName = "Âm Dương Hoạt Huyết Đơn"
			},
			new GStruct58
			{
				skillId = 1122,
				skillRange = 480,
				skillName = "ÂíéýẵÊặứ"
			},
			new GStruct58
			{
				skillId = 1123,
				skillRange = 0,
				skillName = "Vũ Uy Thuật"
			},
			new GStruct58
			{
				skillId = 1124,
				skillRange = 0,
				skillName = "Nhược Thủy Thuật"
			},
			new GStruct58
			{
				skillId = 1125,
				skillRange = 0,
				skillName = "Trấn Nhạc Thuật"
			},
			new GStruct58
			{
				skillId = 1126,
				skillRange = 0,
				skillName = "Yên Ba Thuật"
			},
			new GStruct58
			{
				skillId = 1127,
				skillRange = 0,
				skillName = "Trường Sinh Thuật"
			},
			new GStruct58
			{
				skillId = 1128,
				skillRange = 0,
				skillName = "Bột Hải Thuật"
			},
			new GStruct58
			{
				skillId = 1129,
				skillRange = 0,
				skillName = "Thần Tuệ Thuật"
			},
			new GStruct58
			{
				skillId = 1130,
				skillRange = 0,
				skillName = "Truy ảnh Thuật"
			},
			new GStruct58
			{
				skillId = 1131,
				skillRange = 60,
				skillName = "Ma Âm Kích"
			},
			new GStruct58
			{
				skillId = 1132,
				skillRange = 400,
				skillName = "ằỉÁƯãẫùÚ"
			},
			new GStruct58
			{
				skillId = 1133,
				skillRange = 400,
				skillName = "ằỉÁƯãẫùÚìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1134,
				skillRange = 800,
				skillName = "ẩôặÁéĂẫÁàỗ"
			},
			new GStruct58
			{
				skillId = 1135,
				skillRange = 400,
				skillName = "ệĩẫớ±ựẵỹẫớ1"
			},
			new GStruct58
			{
				skillId = 1136,
				skillRange = 400,
				skillName = "ệĩẫớảăàóãẫùÚ"
			},
			new GStruct58
			{
				skillId = 1137,
				skillRange = 100,
				skillName = "ằỉéýéýãỗonly"
			},
			new GStruct58
			{
				skillId = 1138,
				skillRange = 100,
				skillName = "ằỉÁƯéĂẫÁàỗ"
			},
			new GStruct58
			{
				skillId = 1139,
				skillRange = 400,
				skillName = "ệĩẫớ±ựẵỹẫớ2"
			},
			new GStruct58
			{
				skillId = 1140,
				skillRange = 400,
				skillName = "ệĩẫớ±ựẵỹẫớ3"
			},
			new GStruct58
			{
				skillId = 1141,
				skillRange = 400,
				skillName = "ệĩẫớ±ựẵỹẫớ4"
			},
			new GStruct58
			{
				skillId = 1142,
				skillRange = 400,
				skillName = "ệ±ẽò±ựÀõ"
			},
			new GStruct58
			{
				skillId = 1143,
				skillRange = 400,
				skillName = "ằỉéýéýãỗ"
			},
			new GStruct58
			{
				skillId = 1144,
				skillRange = 360,
				skillName = "ằỉéýéýãỗẫÁàỗ"
			},
			new GStruct58
			{
				skillId = 1145,
				skillRange = 800,
				skillName = "ệ±ẽò±ựÀõìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1146,
				skillRange = 200,
				skillName = "\u00b4úÁƯẵðáếếặnpc"
			},
			new GStruct58
			{
				skillId = 1147,
				skillRange = 180,
				skillName = "ẻÔÍểẽìốặnpc"
			},
			new GStruct58
			{
				skillId = 1148,
				skillRange = 400,
				skillName = "ẩỵẵọạộỡứnpc"
			},
			new GStruct58
			{
				skillId = 1149,
				skillRange = 280,
				skillName = "ºÀéÛếảnpc"
			},
			new GStruct58
			{
				skillId = 1150,
				skillRange = 72,
				skillName = "ìíºỏ°ậằÄnpc"
			},
			new GStruct58
			{
				skillId = 1151,
				skillRange = 108,
				skillName = "°ễÍừửẫẵðnpc"
			},
			new GStruct58
			{
				skillId = 1152,
				skillRange = 360,
				skillName = "ẵÊằăÍỡắĐnpc"
			},
			new GStruct58
			{
				skillId = 1153,
				skillRange = 400,
				skillName = "±ựểờỗúắĐnpc"
			},
			new GStruct58
			{
				skillId = 1154,
				skillRange = 360,
				skillName = "±ựẩáễẵệƯnpc"
			},
			new GStruct58
			{
				skillId = 1155,
				skillRange = 240,
				skillName = "ậđể³Âỹéónpc"
			},
			new GStruct58
			{
				skillId = 1156,
				skillRange = 420,
				skillName = "éẻẽỳạầÁÂnpc"
			},
			new GStruct58
			{
				skillId = 1157,
				skillRange = 420,
				skillName = "ểÄằờấẫể°npc"
			},
			new GStruct58
			{
				skillId = 1158,
				skillRange = 360,
				skillName = "ẻịể°\u00b4ânpc"
			},
			new GStruct58
			{
				skillId = 1159,
				skillRange = 470,
				skillName = "èỳÁôậÄẫ±npc"
			},
			new GStruct58
			{
				skillId = 1160,
				skillRange = 360,
				skillName = "ầơÀÔềằệÀnpc"
			},
			new GStruct58
			{
				skillId = 1161,
				skillRange = 400,
				skillName = "ấ±³ậÁựÁỳnpc"
			},
			new GStruct58
			{
				skillId = 1162,
				skillRange = 400,
				skillName = "°ụồÄÂểàỉnpc"
			},
			new GStruct58
			{
				skillId = 1163,
				skillRange = 60,
				skillName = "ẵưºÊÅưÀẵnpc"
			},
			new GStruct58
			{
				skillId = 1164,
				skillRange = 570,
				skillName = "ẳ²ằðÁầễưnpc"
			},
			new GStruct58
			{
				skillId = 1165,
				skillRange = 470,
				skillName = "ễỡằ\u00afèôầồnpc"
			},
			new GStruct58
			{
				skillId = 1166,
				skillRange = 470,
				skillName = "ẵÊ\u00b4ạéầºểnpc"
			},
			new GStruct58
			{
				skillId = 1167,
				skillRange = 400,
				skillName = "ắÅèỡợáãỗnpc"
			},
			new GStruct58
			{
				skillId = 1168,
				skillRange = 470,
				skillName = "èỡÀìếðễÀnpc"
			},
			new GStruct58
			{
				skillId = 1169,
				skillRange = 180,
				skillName = "Vòng Sáng Long Câu"
			},
			new GStruct58
			{
				skillId = 1170,
				skillRange = 180,
				skillName = "Áỳắễạõằãìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1171,
				skillRange = 0,
				skillName = "Chiến ý Thiên Thu"
			},
			new GStruct58
			{
				skillId = 1172,
				skillRange = 800,
				skillName = "éÄéÍẹèằă"
			},
			new GStruct58
			{
				skillId = 1173,
				skillRange = 600,
				skillName = "ÃÍ°²éĂếé"
			},
			new GStruct58
			{
				skillId = 1175,
				skillRange = 420,
				skillName = "2012ẹèằă1"
			},
			new GStruct58
			{
				skillId = 1176,
				skillRange = 420,
				skillName = "2012ẹèằă2"
			},
			new GStruct58
			{
				skillId = 1177,
				skillRange = 420,
				skillName = "2012ẹèằă3"
			},
			new GStruct58
			{
				skillId = 1178,
				skillRange = 400,
				skillName = "Hồi Xuân"
			},
			new GStruct58
			{
				skillId = 1179,
				skillRange = 400,
				skillName = "ẳểẹêẫẽẽịìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1180,
				skillRange = 400,
				skillName = "Khô Mộc"
			},
			new GStruct58
			{
				skillId = 1181,
				skillRange = 400,
				skillName = "ẳừẹêẫẽẽịìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1182,
				skillRange = 400,
				skillName = "Lưu Vân "
			},
			new GStruct58
			{
				skillId = 1183,
				skillRange = 400,
				skillName = "ẳểÅĩậ\u00a0ẫẽà\u00af"
			},
			new GStruct58
			{
				skillId = 1184,
				skillRange = 400,
				skillName = "Nê Trạch"
			},
			new GStruct58
			{
				skillId = 1185,
				skillRange = 400,
				skillName = "ẳừÅĩậ\u00a0ìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1186,
				skillRange = 50,
				skillName = "Lôi Hỏa Kiếp"
			},
			new GStruct58
			{
				skillId = 1187,
				skillRange = 50,
				skillName = "Lôi Hỏa Kiếp 1"
			},
			new GStruct58
			{
				skillId = 1188,
				skillRange = 50,
				skillName = "Lôi Hỏa Kiếp 2"
			},
			new GStruct58
			{
				skillId = 1189,
				skillRange = 50,
				skillName = "Lôi Hỏa Kiếp 3"
			},
			new GStruct58
			{
				skillId = 1193,
				skillRange = 90,
				skillName = "Thanh Bình Lạc"
			},
			new GStruct58
			{
				skillId = 1194,
				skillRange = 440,
				skillName = "Điệp Vũ Hoa Phi"
			},
			new GStruct58
			{
				skillId = 1195,
				skillRange = 50,
				skillName = "Mê Túy Thiên Hương"
			},
			new GStruct58
			{
				skillId = 1196,
				skillRange = 50,
				skillName = "Mê Túy Thiên Hương 1"
			},
			new GStruct58
			{
				skillId = 1197,
				skillRange = 50,
				skillName = "Mê Túy Thiên Hương 2"
			},
			new GStruct58
			{
				skillId = 1198,
				skillRange = 50,
				skillName = "Mê Túy Thiên Hương 3"
			},
			new GStruct58
			{
				skillId = 1201,
				skillRange = 180,
				skillName = "ẻÔÍểằÔãă"
			},
			new GStruct58
			{
				skillId = 1202,
				skillRange = 800,
				skillName = "ầĐệỉÂƠÅÚÊă1-7ẳảÊâ"
			},
			new GStruct58
			{
				skillId = 1203,
				skillRange = 800,
				skillName = "ầĐệỉÂƠÅÚÊă\u00b4úếéÊâ"
			},
			new GStruct58
			{
				skillId = 1204,
				skillRange = 800,
				skillName = "1-7ẳảÅÚà\u00af±ơếă"
			},
			new GStruct58
			{
				skillId = 1208,
				skillRange = 440,
				skillName = "ẹÊễẻấỉẻÀẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1209,
				skillRange = 400,
				skillName = "±ựả³ấỉẻÀạõằã"
			},
			new GStruct58
			{
				skillId = 1210,
				skillRange = 400,
				skillName = "±ựả³ấỉẻÀậÄẽúÍơạộ"
			},
			new GStruct58
			{
				skillId = 1211,
				skillRange = 180,
				skillName = "\u00b4ẩºẵấỉẻÀạõằã"
			},
			new GStruct58
			{
				skillId = 1212,
				skillRange = 400,
				skillName = "ằðầẵấỉẻÀẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1213,
				skillRange = 600,
				skillName = "ÁộàỷẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1214,
				skillRange = 400,
				skillName = "ốẫàỷẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1215,
				skillRange = 600,
				skillName = "ÃễàỷẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1216,
				skillRange = 420,
				skillName = "àặàỷ\u00b4úếéềừ²ĩàỉìƯ"
			},
			new GStruct58
			{
				skillId = 1217,
				skillRange = 420,
				skillName = "àặàỷ\u00b4úếéềừ²ĩàỉìƯệéẳọ"
			},
			new GStruct58
			{
				skillId = 1218,
				skillRange = 420,
				skillName = "àặàỷ\u00b4úếéềừ²ĩàỉìƯàÚảỵ²ó"
			},
			new GStruct58
			{
				skillId = 1219,
				skillRange = 420,
				skillName = "ềừ²ĩàỉìƯìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1220,
				skillRange = 0,
				skillName = "Kim Quyên La Hán"
			},
			new GStruct58
			{
				skillId = 1221,
				skillRange = 0,
				skillName = "Chinh Chiến Bát Phương"
			},
			new GStruct58
			{
				skillId = 1222,
				skillRange = 0,
				skillName = "Sâm La Độc Hải"
			},
			new GStruct58
			{
				skillId = 1223,
				skillRange = 0,
				skillName = "Hấp Tinh trận"
			},
			new GStruct58
			{
				skillId = 1224,
				skillRange = 0,
				skillName = "Ba La Tâm Kinh"
			},
			new GStruct58
			{
				skillId = 1225,
				skillRange = 0,
				skillName = "Huyền Băng Vô Tức"
			},
			new GStruct58
			{
				skillId = 1226,
				skillRange = 0,
				skillName = "Liệt Hỏa Phẫn Thiên"
			},
			new GStruct58
			{
				skillId = 1227,
				skillRange = 0,
				skillName = "Ô Y Quyết"
			},
			new GStruct58
			{
				skillId = 1228,
				skillRange = 0,
				skillName = "Chân Vũ Thất Tiệt"
			},
			new GStruct58
			{
				skillId = 1229,
				skillRange = 0,
				skillName = "Thiên Cương Khất Kính"
			},
			new GStruct58
			{
				skillId = 1230,
				skillRange = 0,
				skillName = "Minh Kính Vô Di"
			},
			new GStruct58
			{
				skillId = 1231,
				skillRange = 0,
				skillName = "Du Long Chân Khí"
			},
			new GStruct58
			{
				skillId = 1232,
				skillRange = 420,
				skillName = "Hồn ảnh Tùng Sanh"
			},
			new GStruct58
			{
				skillId = 1233,
				skillRange = 0,
				skillName = "Xác suất hóa giảI sát thương hoàn toàn"
			},
			new GStruct58
			{
				skillId = 1234,
				skillRange = 400,
				skillName = "Từ Hàng Phổ D"
			},
			new GStruct58
			{
				skillId = 1235,
				skillRange = 0,
				skillName = "Dung Tuyết Vô Tung"
			},
			new GStruct58
			{
				skillId = 1236,
				skillRange = 0,
				skillName = "Ma Âm Phệ Phách"
			},
			new GStruct58
			{
				skillId = 1237,
				skillRange = 0,
				skillName = "Thiên Hành Khí Công"
			},
			new GStruct58
			{
				skillId = 1238,
				skillRange = 0,
				skillName = "Âm Dương Khí Quyết"
			},
			new GStruct58
			{
				skillId = 1239,
				skillRange = 0,
				skillName = "Tiên Thiên Cương Khí"
			},
			new GStruct58
			{
				skillId = 1249,
				skillRange = 0,
				skillName = "Khôi ẩn - Hắc Thần"
			},
			new GStruct58
			{
				skillId = 1250,
				skillRange = 440,
				skillName = "ºÚẫủÍã¿ứìỗệọ"
			},
			new GStruct58
			{
				skillId = 1251,
				skillRange = 0,
				skillName = "Tụ ẩn - Hắc Thần"
			},
			new GStruct58
			{
				skillId = 1252,
				skillRange = 440,
				skillName = "ºÚẫủằÔÍúìỗệọ"
			},
			new GStruct58
			{
				skillId = 1262,
				skillRange = 0,
				skillName = "Càn Khôn Vô Lượng"
			},
			new GStruct58
			{
				skillId = 1263,
				skillRange = 800,
				skillName = "ẹèằăéƯểù"
			},
			new GStruct58
			{
				skillId = 1264,
				skillRange = 0,
				skillName = "Phong Ma Quyết"
			},
			new GStruct58
			{
				skillId = 1265,
				skillRange = 440,
				skillName = "ằÔÍú7ºÅáăệỳ"
			},
			new GStruct58
			{
				skillId = 1266,
				skillRange = 0,
				skillName = "Triệt Vũ Phong Thế"
			},
			new GStruct58
			{
				skillId = 1269,
				skillRange = 400,
				skillName = "Người Tuyết"
			},
			new GStruct58
			{
				skillId = 1270,
				skillRange = 400,
				skillName = "Ông Già Noel"
			},
			new GStruct58
			{
				skillId = 1271,
				skillRange = 400,
				skillName = "Thiên Sứ Giáng Sinh"
			},
			new GStruct58
			{
				skillId = 1272,
				skillRange = 400,
				skillName = "\u00b4ú°ìéĩ"
			},
			new GStruct58
			{
				skillId = 1273,
				skillRange = 400,
				skillName = "<<ẻ\u00b4ãưềở>>"
			},
			new GStruct58
			{
				skillId = 1274,
				skillRange = 400,
				skillName = "Tinh Linh"
			},
			new GStruct58
			{
				skillId = 1275,
				skillRange = 400,
				skillName = "Heo trắng"
			},
			new GStruct58
			{
				skillId = 1276,
				skillRange = 400,
				skillName = "Bạch Hổ "
			},
			new GStruct58
			{
				skillId = 1278,
				skillRange = 800,
				skillName = "Äắẩậẽù\u00b4úếăà\u00af3"
			},
			new GStruct58
			{
				skillId = 1279,
				skillRange = 800,
				skillName = "Äắẩậẽù\u00b4úếăà\u00af2"
			},
			new GStruct58
			{
				skillId = 1280,
				skillRange = 800,
				skillName = "Äắẩậẽù\u00b4úếăà\u00af"
			},
			new GStruct58
			{
				skillId = 1288,
				skillRange = 800,
				skillName = "ễẵÄẽàụầđẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1291,
				skillRange = 800,
				skillName = "ÄờấịÅÚ"
			},
			new GStruct58
			{
				skillId = 1292,
				skillRange = 800,
				skillName = "ÄờấịÅÚ±ơếă"
			},
			new GStruct58
			{
				skillId = 1295,
				skillRange = 180,
				skillName = "Hồi phục thuộc tính"
			},
			new GStruct58
			{
				skillId = 1296,
				skillRange = 440,
				skillName = "Tự hào ý chí chiến đấu"
			},
			new GStruct58
			{
				skillId = 1297,
				skillRange = 440,
				skillName = "°Áẩằếẵềõìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1317,
				skillRange = 0,
				skillName = "Sát khí quyết"
			},
			new GStruct58
			{
				skillId = 1318,
				skillRange = 0,
				skillName = "Trường sinh quyết"
			},
			new GStruct58
			{
				skillId = 1319,
				skillRange = 600,
				skillName = "Hổ kích"
			},
			new GStruct58
			{
				skillId = 1320,
				skillRange = 600,
				skillName = "Xuyên Thạch"
			},
			new GStruct58
			{
				skillId = 1321,
				skillRange = 0,
				skillName = "Ngọc Thạch Phiến"
			},
			new GStruct58
			{
				skillId = 1322,
				skillRange = 400,
				skillName = "Hư Nhược Vô Lực"
			},
			new GStruct58
			{
				skillId = 1323,
				skillRange = 0,
				skillName = "Lăng Phong"
			},
			new GStruct58
			{
				skillId = 1324,
				skillRange = 440,
				skillName = "Nhật Nhiên"
			},
			new GStruct58
			{
				skillId = 1325,
				skillRange = 0,
				skillName = "Nhật Như Sơn"
			},
			new GStruct58
			{
				skillId = 1326,
				skillRange = 440,
				skillName = "Huyết Dũng"
			},
			new GStruct58
			{
				skillId = 1327,
				skillRange = 0,
				skillName = "Đẩu Uyển"
			},
			new GStruct58
			{
				skillId = 1328,
				skillRange = 400,
				skillName = "Tàn Phong Vân Quyền"
			},
			new GStruct58
			{
				skillId = 1329,
				skillRange = 0,
				skillName = "Đoạn Nguyệt"
			},
			new GStruct58
			{
				skillId = 1330,
				skillRange = 440,
				skillName = "phiến"
			},
			new GStruct58
			{
				skillId = 1331,
				skillRange = 0,
				skillName = "Tâm Tinh Thức"
			},
			new GStruct58
			{
				skillId = 1332,
				skillRange = 440,
				skillName = "Vô Ngã"
			},
			new GStruct58
			{
				skillId = 1333,
				skillRange = 440,
				skillName = "Kết băng"
			},
			new GStruct58
			{
				skillId = 1334,
				skillRange = 440,
				skillName = "ễẵÄẽ9áăệỳ1"
			},
			new GStruct58
			{
				skillId = 1335,
				skillRange = 440,
				skillName = "ễẵÄẽ9áăệỳ2"
			},
			new GStruct58
			{
				skillId = 1336,
				skillRange = 0,
				skillName = "Vũ Uy Thuật (trùng sinh 6)"
			},
			new GStruct58
			{
				skillId = 1337,
				skillRange = 0,
				skillName = "Nhược Thủy Thuật (trùng sinh 6)"
			},
			new GStruct58
			{
				skillId = 1338,
				skillRange = 0,
				skillName = "Trấn Sơn Thuật (trùng sinh 6)"
			},
			new GStruct58
			{
				skillId = 1339,
				skillRange = 0,
				skillName = "Yên Ba Thuật (trùng sinh 6)"
			},
			new GStruct58
			{
				skillId = 1340,
				skillRange = 0,
				skillName = "Trường Sinh Thuật (trùng sinh 6)"
			},
			new GStruct58
			{
				skillId = 1341,
				skillRange = 0,
				skillName = "Bá Hải Thuật (trùng sinh 6)"
			},
			new GStruct58
			{
				skillId = 1342,
				skillRange = 0,
				skillName = "Thần Tuệ Thuật(trùng sinh 6)"
			},
			new GStruct58
			{
				skillId = 1343,
				skillRange = 0,
				skillName = "Truy Cảnh Thuật (trùng sinh 6)"
			},
			new GStruct58
			{
				skillId = 1344,
				skillRange = 0,
				skillName = "Càn Khôn Vô Lượng"
			},
			new GStruct58
			{
				skillId = 1347,
				skillRange = 400,
				skillName = "Bạch Hồng Quán Nhật"
			},
			new GStruct58
			{
				skillId = 1348,
				skillRange = 400,
				skillName = "Vân Chưng Hà úy"
			},
			new GStruct58
			{
				skillId = 1349,
				skillRange = 0,
				skillName = "Kiếm Tông Tổng Quyết"
			},
			new GStruct58
			{
				skillId = 1350,
				skillRange = 0,
				skillName = "Dưỡng Ngô Kiếm Pháp"
			},
			new GStruct58
			{
				skillId = 1351,
				skillRange = 480,
				skillName = "Kim Nhạn Hoành Không"
			},
			new GStruct58
			{
				skillId = 1352,
				skillRange = 0,
				skillName = "Hữu Phụng Lai Nghi"
			},
			new GStruct58
			{
				skillId = 1354,
				skillRange = 0,
				skillName = "Hi Di Kiếm Pháp"
			},
			new GStruct58
			{
				skillId = 1355,
				skillRange = 360,
				skillName = "Thiên Thân Đảo Huyền"
			},
			new GStruct58
			{
				skillId = 1357,
				skillRange = 0,
				skillName = "Cao Sơn Lưu Thủy "
			},
			new GStruct58
			{
				skillId = 1358,
				skillRange = 450,
				skillName = "Huyễn Nhãn Vân Yên"
			},
			new GStruct58
			{
				skillId = 1360,
				skillRange = 480,
				skillName = "Thương Tùng Nghênh Khách"
			},
			new GStruct58
			{
				skillId = 1361,
				skillRange = 480,
				skillName = "²ễậẫểư¿Í2"
			},
			new GStruct58
			{
				skillId = 1362,
				skillRange = 480,
				skillName = "²ễậẫểư¿Í3"
			},
			new GStruct58
			{
				skillId = 1363,
				skillRange = 480,
				skillName = "Thái Nhạc Tam Thanh Phong"
			},
			new GStruct58
			{
				skillId = 1364,
				skillRange = 0,
				skillName = "Đoạt Mệnh Liên Hoàn Tam Tiên Kiếm"
			},
			new GStruct58
			{
				skillId = 1365,
				skillRange = 0,
				skillName = "Tử Hà Kiếm Khí"
			},
			new GStruct58
			{
				skillId = 1366,
				skillRange = 0,
				skillName = "Lạc Nhạn Kinh Hồng"
			},
			new GStruct58
			{
				skillId = 1368,
				skillRange = 480,
				skillName = "Độc Cô Cửu Kiếm"
			},
			new GStruct58
			{
				skillId = 1369,
				skillRange = 0,
				skillName = "Cửu kiếm hợp nhất"
			},
			new GStruct58
			{
				skillId = 1370,
				skillRange = 0,
				skillName = "Hạo Nhiên Chi Khí"
			},
			new GStruct58
			{
				skillId = 1372,
				skillRange = 400,
				skillName = "Thanh Vân Tống Sảng"
			},
			new GStruct58
			{
				skillId = 1373,
				skillRange = 0,
				skillName = "Kỹ năng vô hiệu Thanh Phong Chiếm Vị"
			},
			new GStruct58
			{
				skillId = 1374,
				skillRange = 0,
				skillName = "Long Nhiễu Thân"
			},
			new GStruct58
			{
				skillId = 1375,
				skillRange = 0,
				skillName = "Hải Nạp Bách Xuyên"
			},
			new GStruct58
			{
				skillId = 1376,
				skillRange = 360,
				skillName = "Long Huyền Kiếm Khí"
			},
			new GStruct58
			{
				skillId = 1377,
				skillRange = 0,
				skillName = "Long Huyền Kiếm Khí 2"
			},
			new GStruct58
			{
				skillId = 1378,
				skillRange = 0,
				skillName = "Khí Chấn Sơn Hà"
			},
			new GStruct58
			{
				skillId = 1379,
				skillRange = 0,
				skillName = "Khí Quán Trường Hồng"
			},
			new GStruct58
			{
				skillId = 1380,
				skillRange = 360,
				skillName = "Ma Vân Kiếm Khí"
			},
			new GStruct58
			{
				skillId = 1381,
				skillRange = 360,
				skillName = "Kiếm Khí Vô Cấp"
			},
			new GStruct58
			{
				skillId = 1382,
				skillRange = 380,
				skillName = "Phách Thạch Phá Ngọc"
			},
			new GStruct58
			{
				skillId = 1383,
				skillRange = 220,
				skillName = "Åỹấ\u00afặặểủ2"
			},
			new GStruct58
			{
				skillId = 1384,
				skillRange = 600,
				skillName = "Thần Quang Toàn Nhiễu"
			},
			new GStruct58
			{
				skillId = 1385,
				skillRange = 360,
				skillName = "ẫủạõéýẩặ2"
			},
			new GStruct58
			{
				skillId = 1386,
				skillRange = 400,
				skillName = "³ơẳảảẽằờ\u00b4è"
			},
			new GStruct58
			{
				skillId = 1388,
				skillRange = 600,
				skillName = "³ơẳảẻịéẻạặ"
			},
			new GStruct58
			{
				skillId = 1389,
				skillRange = 180,
				skillName = "³ơẳảẻịéẻạặìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1390,
				skillRange = 50,
				skillName = "³ơẳảÂềằãằữ"
			},
			new GStruct58
			{
				skillId = 1392,
				skillRange = 180,
				skillName = "³ơẳả±ếễÂãữ³ắ"
			},
			new GStruct58
			{
				skillId = 1393,
				skillRange = 180,
				skillName = "³ơẳả±ếễÂãữ³ắìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1394,
				skillRange = 400,
				skillName = "³ơẳả¿ºÁỳểéằÚ"
			},
			new GStruct58
			{
				skillId = 1395,
				skillRange = 72,
				skillName = "³ơẳảÁềằðầộèỡ"
			},
			new GStruct58
			{
				skillId = 1397,
				skillRange = 440,
				skillName = "³ơẳảặỳéÄãỷ"
			},
			new GStruct58
			{
				skillId = 1398,
				skillRange = 180,
				skillName = "³ơẳảÂịººếú"
			},
			new GStruct58
			{
				skillId = 1399,
				skillRange = 180,
				skillName = "³ơẳảÂịººếúìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1401,
				skillRange = 72,
				skillName = "³ơẳả±èºÊ³±ẫỳ"
			},
			new GStruct58
			{
				skillId = 1402,
				skillRange = 72,
				skillName = "³ơẳả°ụ\u00b4ũảủạã"
			},
			new GStruct58
			{
				skillId = 1403,
				skillRange = 400,
				skillName = "³ơẳảẵÊãẫắêèỡ"
			},
			new GStruct58
			{
				skillId = 1404,
				skillRange = 400,
				skillName = "³ơẳảẵÊãẫắêèỡẫậºƯ"
			},
			new GStruct58
			{
				skillId = 1406,
				skillRange = 600,
				skillName = "³ơẳảÄĐềụấẫặầ_ẩºèồậổằỳìòả\u00af"
			},
			new GStruct58
			{
				skillId = 1415,
				skillRange = 400,
				skillName = "ÁữéầÂềằãằữ"
			},
			new GStruct58
			{
				skillId = 1416,
				skillRange = 50,
				skillName = "ÁữéầÂềằãằữìểẳẳÄĩ"
			},
			new GStruct58
			{
				skillId = 1417,
				skillRange = 75,
				skillName = "³ơẳảảẽằờ\u00b4èẫậºƯ"
			},
			new GStruct58
			{
				skillId = 1420,
				skillRange = 480,
				skillName = "Kiếm Pháp - Thái Nhạc Tam Thanh Phong"
			},
			new GStruct58
			{
				skillId = 1421,
				skillRange = 480,
				skillName = "Kiếm pháp - Độc Cô Cửu Kiếm"
			},
			new GStruct58
			{
				skillId = 1426,
				skillRange = 72,
				skillName = "Bích Hải Triều Sinh (Kiếm Tiên Lý Bạch)"
			},
			new GStruct58
			{
				skillId = 1427,
				skillRange = 180,
				skillName = "Bế Nguyệt Phất Trần (Kiếm Tiên Lý Bạch)"
			},
			new GStruct58
			{
				skillId = 1428,
				skillRange = 180,
				skillName = "Kĩ năng Bế Nguyệt Phất Trần (Kiếm Tiên Lý Bạch)"
			},
			new GStruct58
			{
				skillId = 1443,
				skillRange = 400,
				skillName = "Tham Lang"
			},
			new GStruct58
			{
				skillId = 1444,
				skillRange = 400,
				skillName = "ìứặùẳẳÄĩ1ìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1445,
				skillRange = 400,
				skillName = "Chiết Cốt"
			},
			new GStruct58
			{
				skillId = 1446,
				skillRange = 400,
				skillName = "ìứặùẳẳÄĩ3ìểà\u00af"
			},
			new GStruct58
			{
				skillId = 1447,
				skillRange = 180,
				skillName = "Vòng hào quang Thần Lộc"
			},
			new GStruct58
			{
				skillId = 1453,
				skillRange = 180,
				skillName = "ệéễẵểẹềờẩỹẩôẳẳÄĩ+1"
			},
			new GStruct58
			{
				skillId = 1457,
				skillRange = 440,
				skillName = "ÃÍằÂéƠẹÀàÚềằấẵìỗệọ"
			},
			new GStruct58
			{
				skillId = 1458,
				skillRange = 0,
				skillName = "Mãnh Hổ Khiếu Nha chiêu thứ hai"
			},
			new GStruct58
			{
				skillId = 1459,
				skillRange = 440,
				skillName = "ÃÍằÂéƠẹÀàÚảỵấẵìỗệọ"
			},
			new GStruct58
			{
				skillId = 1460,
				skillRange = 0,
				skillName = "Mãnh Hổ Khiếu Nha chiêu thứ ba"
			},
			new GStruct58
			{
				skillId = 1461,
				skillRange = 440,
				skillName = "ÃÍằÂéƠẹÀàÚẩýấẵìỗệọ"
			},
			new GStruct58
			{
				skillId = 1462,
				skillRange = 0,
				skillName = "Mãnh Hổ Khiếu Nha chiêu thứ tư"
			},
			new GStruct58
			{
				skillId = 1463,
				skillRange = 440,
				skillName = "ÃÍằÂéƠẹÀàÚậÄấẵìỗệọ"
			},
			new GStruct58
			{
				skillId = 1464,
				skillRange = 0,
				skillName = "Mãnh Hổ Khiếu Nha chiêu thứ năm"
			},
			new GStruct58
			{
				skillId = 1465,
				skillRange = 440,
				skillName = "ÃÍằÂéƠẹÀàÚẻồấẵìỗệọ"
			},
			new GStruct58
			{
				skillId = 1471,
				skillRange = 800,
				skillName = "Pháo"
			}
		};
	}
}
