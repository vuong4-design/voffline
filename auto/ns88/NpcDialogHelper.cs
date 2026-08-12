using System;
using System.Threading;
using ns1;
using ns11;
using ns23;
using ns53;
using ns71;

namespace ns88;

internal class NpcDialogHelper
{
	public class PrimaryMenuLayoutReader
	{
		public static int GetOptionCount(CharacterAccountConfig gstruct51_0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			uint uint_ = gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_147.uint_0;
			WindowsInteropHelper.ReadProcessMemory(gstruct51_0.int_137, uint_, array, 4, ref int_);
			uint num = BitConverter.ToUInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(gstruct51_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_148.uint_0 + GameConfigurationManager.memorySignatureScanConfig_146.uint_0, array, 4, ref int_);
			return BitConverter.ToInt32(array, 0);
		}

		public static string GetMenuText(CharacterAccountConfig gstruct51_0, int int_0 = 96)
		{
			uint num = WindowsInteropHelper.ReadProcessUInt32(gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_147.uint_0, gstruct51_0.int_137);
			uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_148.uint_0 + GameConfigurationManager.memorySignatureScanConfig_146.uint_0;
			uint num3 = num2 + 2712;
			return WindowsInteropHelper.ReadUtf7ProcessString(num3 + 4, gstruct51_0.int_137, int_0);
		}
	}

	public class SecondaryMenuLayoutHelper
	{
		public static int GetOptionCount(CharacterAccountConfig gstruct51_0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(gstruct51_0.int_137, gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_149.uint_0, array, 4, ref int_);
			uint num = BitConverter.ToUInt32(array, 0);
			uint uint_ = num + GameConfigurationManager.memorySignatureScanConfig_150.uint_0 + GameConfigurationManager.memorySignatureScanConfig_146.uint_0;
			WindowsInteropHelper.ReadProcessMemory(gstruct51_0.int_137, uint_, array, 4, ref int_);
			return BitConverter.ToInt32(array, 0);
		}

		public static string GetMenuText(CharacterAccountConfig gstruct51_0)
		{
			uint num = WindowsInteropHelper.ReadProcessUInt32(gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_149.uint_0, gstruct51_0.int_137);
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_156.uint_0, gstruct51_0.int_137);
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_156.uint_0 - 4, gstruct51_0.int_137);
			uint num4 = WindowsInteropHelper.ReadProcessUInt32(num3 + GameConfigurationManager.memorySignatureScanConfig_157.uint_0, gstruct51_0.int_137);
			int num5 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 - 12, gstruct51_0.int_137);
			if (num5 <= 10)
			{
				num5 = 512;
			}
			return WindowsInteropHelper.ReadUtf7ProcessString(num4, gstruct51_0.int_137, num5);
		}

		public static bool WriteMenuText(CharacterAccountConfig gstruct51_0, string string_0 = null)
		{
			uint num = WindowsInteropHelper.ReadProcessUInt32(gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_149.uint_0, gstruct51_0.int_137);
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_156.uint_0, gstruct51_0.int_137);
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_156.uint_0 - 4, gstruct51_0.int_137);
			uint uint_ = WindowsInteropHelper.ReadProcessUInt32(num3 + GameConfigurationManager.memorySignatureScanConfig_157.uint_0, gstruct51_0.int_137);
			int int_ = 0;
			byte[] array = CommonUtility.ConvertStringToSingleByteArray(string_0);
			return WindowsInteropHelper.WriteProcessMemory(gstruct51_0.int_137, uint_, array, array.Length, ref int_);
		}
	}

	public class PopupMessageHelper
	{
		public static string GetText(CharacterAccountConfig gstruct51_0)
		{
			uint num = WindowsInteropHelper.ReadProcessUInt32(gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_153.uint_0 + GameConfigurationManager.memorySignatureScanConfig_156.uint_0, gstruct51_0.int_137);
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_157.uint_0, gstruct51_0.int_137);
			int num3 = (int)WindowsInteropHelper.ReadProcessUInt32(num2 - 12, gstruct51_0.int_137);
			if (num3 <= 0)
			{
				return WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num2, gstruct51_0.int_137, 512);
			}
			return WindowsInteropHelper.ReadUtf7ProcessString(num2, gstruct51_0.int_137, num3);
		}

		public static bool WriteTextAndResetLength(CharacterAccountConfig gstruct51_0, string string_0 = null)
		{
			uint num = WindowsInteropHelper.ReadProcessUInt32(gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_153.uint_0 + GameConfigurationManager.memorySignatureScanConfig_156.uint_0, gstruct51_0.int_137);
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_157.uint_0, gstruct51_0.int_137);
			int int_ = 0;
			byte[] array = CommonUtility.ConvertStringToSingleByteArray(string_0);
			WindowsInteropHelper.WriteProcessMemory(gstruct51_0.int_137, num2, array, array.Length, ref int_);
			byte[] array2 = new byte[4];
			array = array2;
			return WindowsInteropHelper.WriteProcessMemory(gstruct51_0.int_137, num2 - 12, array, array.Length, ref int_);
		}

		public static int GetDialogCount(CharacterAccountConfig gstruct51_0)
		{
			return (int)WindowsInteropHelper.ReadProcessUInt32(gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_153.uint_0 + GameConfigurationManager.memorySignatureScanConfig_155.uint_0, gstruct51_0.int_137);
		}

		public static int GetDialogIndex(CharacterAccountConfig gstruct51_0)
		{
			return (int)WindowsInteropHelper.ReadProcessUInt32(gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_153.uint_0 + GameConfigurationManager.memorySignatureScanConfig_154.uint_0, gstruct51_0.int_137);
		}

		public static bool IsActive(CharacterAccountConfig gstruct51_0)
		{
			int num = GetDialogCount(gstruct51_0);
			if (num > 0)
			{
				int num2 = GetDialogIndex(gstruct51_0);
				if (num2 <= num)
				{
					return true;
				}
			}
			int int_ = 0;
			byte[] array = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(gstruct51_0.int_137, gstruct51_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_151.uint_0, array, 4, ref int_);
			uint num3 = BitConverter.ToUInt32(array, 0);
			if (num3 != 0 && SecondaryMenuLayoutHelper.GetOptionCount(gstruct51_0) > 0)
			{
				num3 = 0u;
			}
			return num3 != 0;
		}

		public static bool Dismiss(CharacterAccountConfig gstruct51_0)
		{
			int num = 0;
			while (IsActive(gstruct51_0) && num < 20)
			{
				WindowsInteropHelper.PostKeyPressWithScanCode(gstruct51_0.uint_4, 32u);
				Thread.Sleep(100);
				num++;
			}
			return !IsActive(gstruct51_0);
		}
	}

	public static uint uint_0 = 2685128u;

	public static int int_0 = -1;

	private static string[] string_0 = new string[16]
	{
		"Õt thóc", "Ta quªn", "êi khái", "nghÜ l¹i", "suy nghÜ k", "h«ng muèn", "Ch\u00ada Muèn", "h©n tiÖn", "Ta kh«ng", "Kh«ng ®",
		"Kh«ng", "L\u00b8t n÷a", "§\u00adîc råi", "biÕt råi", "Mét L\u00b8t", "chuÈn bÞ chót"
	};

	public static int GetActiveMenuLayoutState(CharacterAccountConfig characterAccountConfig_0)
	{
		int int_ = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_147.uint_0, array, 4, ref int_);
		uint num = BitConverter.ToUInt32(array, 0);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_151.uint_0, array, 4, ref int_);
		uint num2 = BitConverter.ToUInt32(array, 0);
		int result = -1;
		if (num != 0 && num2 != 0)
		{
			result = 2;
		}
		else if (num != 0)
		{
			result = 0;
		}
		else if (num2 != 0 && SecondaryMenuLayoutHelper.GetOptionCount(characterAccountConfig_0) > 0)
		{
			result = 1;
		}
		return result;
	}

	public static int GetMenuOptionCount(CharacterAccountConfig characterAccountConfig_0, int int_1 = -1)
	{
		if (int_1 < 0 || int_1 > 1)
		{
			int_1 = GetActiveMenuLayoutState(characterAccountConfig_0);
		}
		if (int_1 != 0)
		{
			if (int_1 > 0)
			{
				return SecondaryMenuLayoutHelper.GetOptionCount(characterAccountConfig_0);
			}
			return 0;
		}
		return PrimaryMenuLayoutReader.GetOptionCount(characterAccountConfig_0);
	}

	public static string GetMenuText(CharacterAccountConfig characterAccountConfig_0, int int_1 = -1)
	{
		if (int_1 < 0 || int_1 > 1)
		{
			int_1 = GetActiveMenuLayoutState(characterAccountConfig_0);
		}
		if (int_1 == 0)
		{
			return PrimaryMenuLayoutReader.GetMenuText(characterAccountConfig_0);
		}
		if (int_1 <= 0)
		{
			return string.Empty;
		}
		return SecondaryMenuLayoutHelper.GetMenuText(characterAccountConfig_0);
	}

	public static string GetMenuOptionText(CharacterAccountConfig characterAccountConfig_0, int int_1, int int_2 = -1, byte byte_0 = 128)
	{
		if (int_2 < 0 || int_2 > 1)
		{
			int_2 = GetActiveMenuLayoutState(characterAccountConfig_0);
		}
		if (int_2 != 0)
		{
			if (int_2 <= 0)
			{
				return string.Empty;
			}
			return ReadMenuOptionTextFromLayout(characterAccountConfig_0, int_1, 1, byte_0);
		}
		return ReadMenuOptionTextFromLayout(characterAccountConfig_0, int_1, 0, byte_0);
	}

	public static string ReadMenuOptionTextFromLayout(CharacterAccountConfig characterAccountConfig_0, int int_1, int int_2, byte byte_0 = 128)
	{
		uint num = GameConfigurationManager.memorySignatureScanConfig_147.uint_0;
		uint num2 = GameConfigurationManager.memorySignatureScanConfig_148.uint_0;
		if (int_2 > 0)
		{
			num = GameConfigurationManager.memorySignatureScanConfig_149.uint_0;
			num2 = GameConfigurationManager.memorySignatureScanConfig_150.uint_0;
		}
		if (characterAccountConfig_0.uint_7 != 0 && num != 0 && num2 != 0 && GameConfigurationManager.memorySignatureScanConfig_146.uint_0 != 0)
		{
			int int_3 = 0;
			byte[] array = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + num, array, 4, ref int_3);
			uint num3 = BitConverter.ToUInt32(array, 0);
			if (num3 != 0)
			{
				uint uint_ = num3 + num2 + (GameConfigurationManager.memorySignatureScanConfig_146.uint_0 - 4);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 4, ref int_3);
				uint num4 = BitConverter.ToUInt32(array, 0);
				uint uint_2 = num4 + (uint)(int_1 * 4);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_2, array, 4, ref int_3);
				uint num5 = BitConverter.ToUInt32(array, 0);
				uint uint_3 = num5 + 28;
				int int_4 = 0;
				byte[] byte_1 = new byte[byte_0];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_3, byte_1, byte_0, ref int_4);
				return GameTextEncodingHelper.DecodeNullTerminatedUtf7(byte_1);
			}
			return string.Empty;
		}
		return string.Empty;
	}

	public static bool SelectMenuOption(CharacterAccountConfig characterAccountConfig_0, int int_1)
	{
		int num = GetActiveMenuLayoutState(characterAccountConfig_0);
		if (0 > num)
		{
			return false;
		}
		return GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig_0, int_1, Convert.ToByte(num == 1));
	}

	public static int SelectMatchingMenuOptions(CharacterAccountConfig characterAccountConfig_0, string string_1, bool bool_0 = false, bool bool_1 = false, bool bool_2 = false, bool bool_3 = false)
	{
		int i = 0;
		int int_ = 0;
		byte[] array = new byte[1];
		for (; i < 150; i++)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_39 * 4, array, 1, ref int_);
			if (array[0] == 0)
			{
				break;
			}
			Thread.Sleep(10);
		}
		i = 0;
		array[0] = 1;
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_39 * 4, array, 1, ref int_);
		try
		{
			i = SelectMatchingMenuOptionsCore(characterAccountConfig_0, string_1, bool_0, bool_1, bool_2, bool_3);
		}
		catch
		{
		}
		array[0] = 0;
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_39 * 4, array, 1, ref int_);
		return i;
	}

	private static int SelectMatchingMenuOptionsCore(CharacterAccountConfig characterAccountConfig_0, string string_1, bool bool_0 = false, bool bool_1 = false, bool bool_2 = false, bool bool_3 = false)
	{
		if (string_1 != null && !(string_1 == string.Empty))
		{
			string[] string_2 = CommonUtility.ReplaceCharactersInRange(string_1, '\0', '\u0006', ' ').Split('|');
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			string text = null;
			byte[] array = new byte[4];
			num3 = 0;
			while (true)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array, 4, ref num3);
				int num5 = BitConverter.ToInt32(array, 0);
				if (num4 != 0)
				{
					if (num4 != num5)
					{
						break;
					}
				}
				else
				{
					num4 = num5;
				}
				num = GetActiveMenuLayoutState(characterAccountConfig_0);
				if (num < 0)
				{
					break;
				}
				if (num > 0)
				{
					num = 1;
				}
				num3 = GetMenuOptionCount(characterAccountConfig_0, num);
				if (num3 <= 0)
				{
					break;
				}
				int num6 = 0;
				string text2 = null;
				string[] array2 = new string[num3];
				int i;
				while (!CommonUtility.bool_0)
				{
					for (i = 0; i < num3; i++)
					{
						string text3 = GetMenuOptionText(characterAccountConfig_0, i, num, 128);
						array2[i] = CommonUtility.ReplaceCharactersInRange(text3, '\0', '\u0006', ' ');
						text2 += text3;
					}
					if (text != null && !(text != text2))
					{
						num6++;
						if (num6 > 10)
						{
							goto end_IL_0366;
						}
						text2 = null;
						continue;
					}
					text = text2;
					break;
				}
				int num7 = 0;
				string text4 = null;
				if (bool_3)
				{
					while (array2 != null && string_2 != null && string_2.Length > num7)
					{
						text4 = string_2[num7];
						if (text4 != null && !(text4 == string.Empty))
						{
							i = 0;
							while (i < array2.Length)
							{
								string text5 = array2[i];
								if (text5 == null || text5 == string.Empty || !CommonUtility.MatchesGameTextPattern(text5, text4) || ((text4 == "®«ng" || text4 == "§«ng") && 0 <= text5.IndexOf("Ho¹t ") && 0 <= string_1.IndexOf("hµnh ")))
								{
									i++;
									continue;
								}
								goto IL_01de;
							}
						}
						num7++;
					}
					break;
				}
				while (array2 != null && array2.Length > num7 && string_2 != null)
				{
					string text6 = array2[num7];
					if (text6 != null && !(text6 == string.Empty))
					{
						i = 0;
						while (i < string_2.Length)
						{
							text4 = string_2[i];
							if (text4 == null || text4 == string.Empty || !CommonUtility.MatchesGameTextPattern(text6, text4) || ((text4 == "®«ng" || text4 == "§«ng") && 0 <= text6.IndexOf("Ho¹t ") && 0 <= string_1.IndexOf("hµnh ")))
							{
								i++;
								continue;
							}
							goto IL_02fe;
						}
					}
					num7++;
				}
				break;
				IL_01de:
				num2++;
				GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig_0, i, num);
				if (bool_2)
				{
					break;
				}
				num6 = 0;
				int num8 = num;
				while (num == num8 && num6 < 60)
				{
					num6++;
					Thread.Sleep(10);
					num = GetActiveMenuLayoutState(characterAccountConfig_0);
				}
				Thread.Sleep(250 + int_0);
				if (bool_1)
				{
					CommonUtility.RemoveStringFromArray(ref string_2, text4, bool_1: true);
				}
				continue;
				IL_02fe:
				num2++;
				GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig_0, num7, num);
				if (bool_2)
				{
					break;
				}
				num6 = 0;
				num8 = num;
				while (num == num8 && num6 < 60)
				{
					num6++;
					Thread.Sleep(10);
					num = GetActiveMenuLayoutState(characterAccountConfig_0);
				}
				Thread.Sleep(250 + int_0);
				if (bool_1)
				{
					CommonUtility.RemoveStringFromArray(ref string_2, text4, bool_1: true);
				}
				continue;
				end_IL_0366:
				break;
			}
			return num2;
		}
		return 0;
	}

	public static void DismissActiveDialogsAndMenus(CharacterAccountConfig characterAccountConfig_0, int int_1 = -1)
	{
		int int_2 = 0;
		byte[] array = new byte[4];
		byte[] array2 = new byte[1];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_39 * 4, array2, 1, ref int_2);
		if (array2[0] > 0)
		{
			return;
		}
		array2[0] = 1;
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_39 * 4, array2, 1, ref int_2);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		while (PopupMessageHelper.IsActive(characterAccountConfig_0))
		{
			if (num3 < 100)
			{
				if (num3 % 10 == 0)
				{
					WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig_0.uint_4, 32u);
				}
				Thread.Sleep(10);
				num3++;
				continue;
			}
			num2 = 1;
			break;
		}
		int num4 = 0;
		while (true)
		{
			num4++;
			if (num4 > 6)
			{
				break;
			}
			int num5 = GetActiveMenuLayoutState(characterAccountConfig_0);
			if (num5 < 0)
			{
				break;
			}
			int num6 = GetMenuOptionCount(characterAccountConfig_0, num5);
			if (num6 <= 0)
			{
				break;
			}
			string[] array3 = new string[num6];
			for (int i = 0; i < num6; i++)
			{
				array3[i] = ReadMenuOptionTextFromLayout(characterAccountConfig_0, i, num5, 128);
				if (0 <= CommonUtility.FindSubstringIndex(array3[i], "100 m¶nh") || (0 <= CommonUtility.FindSubstringIndex(array3[i], "Öm vô lÇn nµy khã qu\u00b8") && 0 <= CommonUtility.FindSubstringIndex(array3[i], "a muèn hñy bá kh«ng lµm n")))
				{
					goto end_IL_01de;
				}
			}
			int num7 = num6 - 1;
			for (int j = 0; j < num6; j++)
			{
				string string_ = CommonUtility.ReplaceCharactersInRange(array3[num6 - j - 1], '\0', '\u0006', ' ').ToLower();
				int num8 = 0;
				while (num8 < string_0.Length)
				{
					if (0 > CommonUtility.FindSubstringIndex(string_, string_0[num8].ToLower()))
					{
						num8++;
						continue;
					}
					goto IL_01a6;
				}
				continue;
				IL_01a6:
				num7 = num6 - j - 1;
				break;
			}
			GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig_0, num7, num5);
			if (0 <= int_1)
			{
				Thread.Sleep(1 + int_1);
			}
			else
			{
				Thread.Sleep(10 + int_0);
			}
			num++;
			continue;
			end_IL_01de:
			break;
		}
		if (num2 > 0)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_151.uint_0, array, 4, ref int_2);
			if (BitConverter.ToUInt32(array, 0) != 0)
			{
				GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig_0, 0, 1);
				GameProcessInteractionHelper.smethod_12(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_74);
			}
		}
		array2[0] = 0;
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_39 * 4, array2, 1, ref int_2);
	}
}
