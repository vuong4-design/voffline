using System;
using System.Threading;
using ns1;
using ns100;
using ns11;
using ns23;
using ns53;
using ns71;
using ns83;
using ns88;

namespace ns85;

internal class GameInterfaceMemoryHelper
{
	private static uint uint_0 = 19u;

	private static uint uint_1 = 11u;

	private static string string_0 = null;

	private static uint uint_2 = 4u;

	private static long long_0 = 0L;

	public static uint LoadGameSettingsFileDataAddress(CharacterAccountConfig characterAccountConfig_0, string string_1 = "\\settings\\shop\\type.txt")
	{
		uint num = WindowsInteropHelper.AllocateRemoteMemory(characterAccountConfig_0.int_137, 86016u);
		if (num != 0)
		{
			uint num2 = num + 128;
			uint num3 = num2 - 128;
			uint num4 = num2 + 32;
			int int_ = 0;
			byte[] array = new byte[6];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_4.uint_0 + 11, array, array.Length, ref int_);
			byte[] array2 = CommonUtility.ConvertStringToSingleByteArray(string_1);
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 4, array2, array2.Length, ref int_);
			string string_2 = "6068" + CommonUtility.FormatIntegerAsHex(num3 + 4, 8, bool_1: false, bool_2: true) + "B9" + CommonUtility.FormatIntegerAsHex(num4, 8, bool_1: false, bool_2: true) + "FF 15 00 00 00 0061C6 05" + CommonUtility.FormatIntegerAsHex(num3, 8, bool_1: false, bool_2: true) + "01" + GameProcessInteractionHelper.BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
			array2 = CommonUtility.ParseHexBytePattern(string_2);
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, array2, array2.Length, ref int_);
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2 + 11, array, array.Length, ref int_);
			GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_0.int_137, num2);
			int num5 = 0;
			byte[] array3 = new byte[4];
			uint result = 0u;
			bool flag = false;
			while (num5 < 10)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num3, array3, 1, ref int_);
				if (array3[0] <= 0)
				{
					num5++;
					Thread.Sleep(100);
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num4 + 12, array3, 4, ref int_);
				result = BitConverter.ToUInt32(array3, 0);
				flag = true;
				break;
			}
			if (flag)
			{
				WindowsInteropHelper.FreeRemoteMemory(characterAccountConfig_0.int_137, num);
			}
			return result;
		}
		return 0u;
	}

	public static Struct24[] ReadShopTypeEntries(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = LoadGameSettingsFileDataAddress(characterAccountConfig_0);
		if (num != 0)
		{
			int int_ = 0;
			byte[] array = new byte[512];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
			string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array).Replace("\r", "\n").Replace("\n\n", "\n");
			string[] array2 = text.Split('\n');
			if (array2.Length > 1 && CommonUtility.FindSubstringIndex(array2[0].ToUpper(), "TYPENAME") >= 0)
			{
				int num2 = 0;
				Struct24[] array3 = null;
				for (int i = 1; i < array2.Length && array2[i] != null && !(array2[i] == string.Empty); i++)
				{
					string[] array4 = array2[i].Split('\t');
					if (array4.Length == 2)
					{
						int int_2 = CommonUtility.ParseInt32OrZero(array4[1]);
						num2++;
						if (num2 == 1)
						{
							array3 = new Struct24[1]
							{
								new Struct24
								{
									int_0 = int_2,
									string_0 = array4[0]
								}
							};
						}
						else
						{
							Array.Resize(ref array3, num2);
							ref Struct24 reference = ref array3[num2 - 1];
							reference = new Struct24
							{
								int_0 = int_2,
								string_0 = array4[0]
							};
						}
					}
				}
				return array3;
			}
			return null;
		}
		return null;
	}

	public static string ReadFirstShopTypeName(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = LoadGameSettingsFileDataAddress(characterAccountConfig_0);
		if (num == 0)
		{
			return string.Empty;
		}
		int int_ = 0;
		byte[] array = new byte[80];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array).Replace("\r", "\n").Replace("\n\n", "\n");
		string[] array2 = text.Split('\n');
		text = string.Empty;
		if (array2.Length > 1 && CommonUtility.FindSubstringIndex(array2[0].ToUpper(), "TYPENAME") == 0)
		{
			array2 = array2[1].Split('\t');
			text = array2[0];
		}
		return text;
	}

	public static int ReadKeyPressCount(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_1.uint_0 != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			if (WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_1.uint_0, array, 4, ref int_))
			{
				return BitConverter.ToInt32(array, 0);
			}
			return -1;
		}
		return -1;
	}

	public static bool smethod_4(CharacterAccountConfig characterAccountConfig_0)
	{
		if (string_0 == string.Empty || string_0 == null || CommonUtility.GetElapsedMilliseconds(long_0) > 600000L)
		{
			string_0 = ReadFirstShopTypeName(characterAccountConfig_0);
			if ((string_0 == null || string_0 == string.Empty) && Form1.string_7 != null && 0 <= Form1.int_4 && Form1.int_4 < Form1.string_7.GetLength(0))
			{
				string_0 = Form1.string_7[Form1.int_4, 1];
			}
			long_0 = CommonUtility.GetCurrentTicks();
		}
		return GameProcessInteractionHelper.InvokeNamedSpecialFunction(characterAccountConfig_0, string_0);
	}

	public static uint ReadEngineHandleValue(CharacterAccountConfig characterAccountConfig_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_5.uint_0 == 0)
		{
			return 0u;
		}
		if (characterAccountConfig_0.uint_8 == 0)
		{
			characterAccountConfig_0.uint_8 = WindowsInteropHelper.FindLoadedModuleBaseAddress(characterAccountConfig_0.int_136, "engine.dll");
			if (characterAccountConfig_0.uint_8 == 0)
			{
				return 0u;
			}
			int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, characterAccountConfig_0.int_136);
			if (0 <= num)
			{
				Form1.characterAccountConfig_1[num].uint_8 = characterAccountConfig_0.uint_8;
			}
		}
		int int_ = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_8 + GameConfigurationManager.memorySignatureScanConfig_5.uint_0, array, 4, ref int_);
		return BitConverter.ToUInt32(array, 0);
	}

	public static uint ReadPackedMousePosition(CharacterAccountConfig characterAccountConfig_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_5.uint_0 == 0)
		{
			return 0u;
		}
		int int_ = 0;
		byte[] array = new byte[4];
		uint result = 0u;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_8 + GameConfigurationManager.memorySignatureScanConfig_5.uint_0, array, 4, ref int_);
		uint num = BitConverter.ToUInt32(array, 0);
		if (num != 0)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_6.uint_0, array, 4, ref int_);
			result = BitConverter.ToUInt32(array, 0);
		}
		return result;
	}

	public static bool WritePackedMousePosition(CharacterAccountConfig characterAccountConfig_0, uint uint_3)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_6.uint_0 != 0)
		{
			uint num = ReadEngineHandleValue(characterAccountConfig_0);
			if (num == 0)
			{
				return false;
			}
			int int_ = 0;
			byte[] bytes = BitConverter.GetBytes(uint_3);
			uint uint_4 = num + GameConfigurationManager.memorySignatureScanConfig_6.uint_0;
			return WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_4, bytes, bytes.Length, ref int_);
		}
		return false;
	}

	public static bool WriteMousePositionFromArray(CharacterAccountConfig characterAccountConfig_0, int[] int_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_6.uint_0 != 0)
		{
			uint num = ReadEngineHandleValue(characterAccountConfig_0);
			if (num == 0)
			{
				return false;
			}
			uint value = (uint)((int_0[1] << 16) + int_0[0]);
			int int_1 = 0;
			byte[] bytes = BitConverter.GetBytes(value);
			uint uint_ = num + GameConfigurationManager.memorySignatureScanConfig_6.uint_0;
			return WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_, bytes, bytes.Length, ref int_1);
		}
		return false;
	}

	public static bool WriteMousePosition(CharacterAccountConfig characterAccountConfig_0, int int_0, int int_1)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_6.uint_0 != 0)
		{
			uint num = ReadEngineHandleValue(characterAccountConfig_0);
			if (num == 0)
			{
				return false;
			}
			uint value = (uint)((int_1 << 16) + int_0);
			int int_2 = 0;
			byte[] bytes = BitConverter.GetBytes(value);
			uint uint_ = num + GameConfigurationManager.memorySignatureScanConfig_6.uint_0;
			return WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_, bytes, bytes.Length, ref int_2);
		}
		return false;
	}

	public static uint[] ConvertWorldToScreenCoordinates(uint[] uint_3, uint[] uint_4)
	{
		int num = (int)(400 - (uint_3[0] - uint_4[0]));
		int num2 = 300 - (int)(uint_3[1] - uint_4[1]) / 2;
		return new uint[2]
		{
			(uint)num,
			(uint)num2
		};
	}

	public static uint[] ConvertScreenToWorldCoordinates(uint[] uint_3, int int_0, int int_1)
	{
		int num = (int)uint_3[0] - (400 - int_0);
		int num2 = (int)uint_3[1] - (300 - int_1) * 2;
		return new uint[2]
		{
			(uint)num,
			(uint)num2
		};
	}

	public static int smethod_12(CharacterAccountConfig characterAccountConfig_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_5.uint_0 == 0)
		{
			return 0;
		}
		int int_ = 0;
		int result = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_8 + GameConfigurationManager.memorySignatureScanConfig_5.uint_0, array, 4, ref int_);
		uint num = BitConverter.ToUInt32(array, 0);
		if (num != 0)
		{
			uint uint_ = num + GameConfigurationManager.memorySignatureScanConfig_6.uint_0 + uint_2;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 1, ref int_);
			result = array[0];
		}
		return result;
	}

	public static int smethod_13(CharacterAccountConfig characterAccountConfig_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_6.uint_0 != 0)
		{
			uint num = ReadEngineHandleValue(characterAccountConfig_0);
			if (num == 0)
			{
				return 0;
			}
			int int_ = 0;
			byte[] array = new byte[4];
			uint uint_ = num + GameConfigurationManager.memorySignatureScanConfig_6.uint_0 + uint_2;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 4, ref int_);
			return BitConverter.ToInt32(array, 0);
		}
		return -1;
	}

	public static void smethod_14(CharacterAccountConfig characterAccountConfig_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_6.uint_0 != 0)
		{
			uint num = ReadEngineHandleValue(characterAccountConfig_0);
			if (num != 0)
			{
				int int_ = 0;
				byte[] byte_ = new byte[4];
				uint uint_ = num + GameConfigurationManager.memorySignatureScanConfig_6.uint_0 + uint_2;
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_, byte_, 4, ref int_);
			}
		}
	}

	public static void smethod_15(uint uint_3, uint uint_4)
	{
		WindowsInteropHelper.SendMessage(uint_3, WindowsInteropHelper.int_36, WindowsInteropHelper.int_39, uint_4);
		WindowsInteropHelper.SendMessage(uint_3, WindowsInteropHelper.int_37, WindowsInteropHelper.int_39, uint_4);
	}

	public static string ReadServerName(CharacterAccountConfig characterAccountConfig_0)
	{
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_94.uint_0 + GameConfigurationManager.memorySignatureScanConfig_95.uint_0;
		return WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(uint_, characterAccountConfig_0.int_137);
	}

	public static bool IsCheckStatusActive(CharacterAccountConfig characterAccountConfig_0)
	{
		return WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_96.uint_0, characterAccountConfig_0.int_137) != 0;
	}

	public static uint ReadBottomChannelEntryCount(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_208.uint_0;
		return WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
	}

	public static uint ReadTopChannelEntryCount(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_207.uint_0;
		return WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
	}

	public static string ReadLatestBottomChannelText(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_208.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
		if (num3 == 0)
		{
			return null;
		}
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + (num3 - 1) * 4, characterAccountConfig_0.int_137);
		int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num5 + 24, characterAccountConfig_0.int_137);
		num6 -= (int)uint_1;
		if (num6 <= 0)
		{
			return null;
		}
		uint uint_ = num5 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_1;
		string text = WindowsInteropHelper.ReadUtf7ProcessString(uint_, characterAccountConfig_0.int_137, num6);
		if (text.IndexOf('\0') > 0)
		{
			uint uint_2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_214.uint_0, characterAccountConfig_0.int_137) + 28;
			string text2 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(uint_2, characterAccountConfig_0.int_137, num6);
			text = text.Replace('\0'.ToString(), "<" + text2 + ">");
		}
		return ReplaceChannelControlCharacters(text, null, " ");
	}

	public static void WriteLatestBottomChannelText(CharacterAccountConfig characterAccountConfig_0, string string_1)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_208.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
		if (num3 == 0)
		{
			return;
		}
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + (num3 - 1) * 4, characterAccountConfig_0.int_137);
		int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num5 + 24, characterAccountConfig_0.int_137);
		num6 -= (int)uint_1;
		if (num6 > 0)
		{
			uint uint_ = num5 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_1;
			if (string_1 == null || string_1 == string.Empty)
			{
				string_1 = "0K...";
			}
			if (string_1.Length > num6)
			{
				string_1 = string_1.Substring(0, num6);
			}
			int int_ = 0;
			byte[] array = CommonUtility.ConvertStringToSingleByteArray(string_1);
			num6 = array.Length + (int)uint_1;
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_, array, array.Length, ref int_);
			array = BitConverter.GetBytes(num6);
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num5 + 24, array, array.Length, ref int_);
		}
	}

	public static string ReadLatestTopChannelText(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_207.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
		if (num3 == 0)
		{
			return null;
		}
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + (num3 - 1) * 4, characterAccountConfig_0.int_137);
		int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num5 + 24, characterAccountConfig_0.int_137);
		num6 -= (int)uint_0;
		if (num6 <= 0)
		{
			return null;
		}
		uint uint_ = num5 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_0;
		string text = WindowsInteropHelper.ReadUtf7ProcessString(uint_, characterAccountConfig_0.int_137, num6);
		if (CommonUtility.FindSubstringIndex(text, '\0') > 0)
		{
			uint uint_2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_214.uint_0, characterAccountConfig_0.int_137) + 28;
			string text2 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(uint_2, characterAccountConfig_0.int_137, num6);
			text = text.Replace('\0'.ToString(), "<" + text2 + ">");
		}
		return ReplaceChannelControlCharacters(text, null, " ");
	}

	public static void WriteLatestTopChannelText(CharacterAccountConfig characterAccountConfig_0, string string_1)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_207.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
		if (num3 == 0)
		{
			return;
		}
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + (num3 - 1) * 4, characterAccountConfig_0.int_137);
		int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num5 + 24, characterAccountConfig_0.int_137);
		num6 -= (int)uint_0;
		if (num6 > 0)
		{
			uint uint_ = num5 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_0;
			if (string_1 == null || string_1 == string.Empty)
			{
				string_1 = "0K..";
			}
			if (string_1.Length > num6)
			{
				string_1 = string_1.Substring(0, num6);
			}
			int int_ = 0;
			byte[] array = CommonUtility.ConvertStringToSingleByteArray(string_1);
			num6 = array.Length + (int)uint_0;
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_, array, array.Length, ref int_);
			array = BitConverter.GetBytes(num6);
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num5 + 24, array, array.Length, ref int_);
		}
	}

	public static string ReadBottomChannelTextByIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_3)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_208.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(num3 + uint_3 * 4, characterAccountConfig_0.int_137);
		int num5 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + 24, characterAccountConfig_0.int_137);
		num5 -= 11;
		if (num5 <= 0)
		{
			return null;
		}
		uint uint_4 = num4 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_1;
		string text = WindowsInteropHelper.ReadUtf7ProcessString(uint_4, characterAccountConfig_0.int_137, num5);
		if (text.IndexOf('\0') > 0)
		{
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
			if (uint_3 == num6 - 1)
			{
				uint uint_5 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_214.uint_0, characterAccountConfig_0.int_137) + 28;
				string text2 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(uint_5, characterAccountConfig_0.int_137, num5);
				text = text.Replace('\0'.ToString(), "<" + text2 + ">");
			}
		}
		return ReplaceChannelControlCharacters(text, null, " ");
	}

	public static string ReadTopChannelTextByIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_3)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_207.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(num3 + uint_3 * 4, characterAccountConfig_0.int_137);
		int num5 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + 24, characterAccountConfig_0.int_137);
		num5 -= 19;
		if (num5 <= 0)
		{
			return null;
		}
		uint uint_4 = num4 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_0;
		string text = WindowsInteropHelper.ReadUtf7ProcessString(uint_4, characterAccountConfig_0.int_137, num5);
		if (CommonUtility.FindSubstringIndex(text, '\0') > 0)
		{
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
			if (uint_3 == num6 - 1)
			{
				uint uint_5 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_214.uint_0, characterAccountConfig_0.int_137) + 28;
				string text2 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(uint_5, characterAccountConfig_0.int_137, num5);
				text = text.Replace('\0'.ToString(), "<" + text2 + ">");
			}
		}
		return ReplaceChannelControlCharacters(text, null, " ");
	}

	public static string[] ReadRecentTopChannelTexts(CharacterAccountConfig characterAccountConfig_0, uint uint_3)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_207.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		if (num3 <= uint_3)
		{
			uint_3 = num3;
		}
		uint num5 = num3 - uint_3;
		int num6 = 0;
		string[] array = new string[uint_3];
		for (uint num7 = num5; num7 < num3; num7++)
		{
			uint num8 = num5 + (num3 - num7) - 1;
			uint num9 = WindowsInteropHelper.ReadProcessUInt32(num4 + num8 * 4, characterAccountConfig_0.int_137);
			int num10 = (int)WindowsInteropHelper.ReadProcessUInt32(num9 + 24, characterAccountConfig_0.int_137);
			num10 -= 19;
			if (num10 > 0)
			{
				uint uint_4 = num9 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_0;
				string text = WindowsInteropHelper.ReadUtf7ProcessString(uint_4, characterAccountConfig_0.int_137, num10);
				if (!(text == string.Empty))
				{
					array[num6] = ReplaceChannelControlCharacters(text, null, " ");
					num6++;
				}
			}
		}
		return array;
	}

	public static string BuildBottomChannelTextDump(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_208.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		string text = null;
		for (uint num5 = 0u; num5 < num3; num5++)
		{
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(num4 + num5 * 4, characterAccountConfig_0.int_137);
			int num7 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + 24, characterAccountConfig_0.int_137);
			num7 -= 11;
			if (num7 > 0)
			{
				uint uint_ = num6 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_1;
				string text2 = WindowsInteropHelper.ReadUtf7ProcessString(uint_, characterAccountConfig_0.int_137, num7);
				if (!(text2 == ""))
				{
					object obj = text;
					text = string.Concat(obj, "(", num5, ")", ReplaceChannelControlCharacters(text2, null, " "), GameConfigurationManager.string_7);
				}
			}
		}
		return text;
	}

	public static string BuildTopChannelTextDump(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_207.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_211.uint_0, characterAccountConfig_0.int_137);
		uint num4 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		string text = string.Empty;
		for (uint num5 = 0u; num5 < num3; num5++)
		{
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(num4 + num5 * 4, characterAccountConfig_0.int_137);
			int num7 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + 24, characterAccountConfig_0.int_137);
			num7 -= 19;
			if (num7 > 0)
			{
				uint uint_ = num6 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_0;
				string text2 = WindowsInteropHelper.ReadUtf7ProcessString(uint_, characterAccountConfig_0.int_137, num7);
				if (!(text2 == ""))
				{
					object obj = text;
					text = string.Concat(obj, "(", num5, ")", ReplaceChannelControlCharacters(text2, null, " "), GameConfigurationManager.string_7);
				}
			}
		}
		return text;
	}

	public static string BuildBottomChannelSlotTextDump(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_208.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		string text = null;
		for (uint num4 = 0u; num4 < 256; num4++)
		{
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(num3 + num4 * 4, characterAccountConfig_0.int_137);
			int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num5 + 24, characterAccountConfig_0.int_137);
			num6 -= 11;
			if (num6 > 0)
			{
				uint uint_ = num5 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_1;
				string text2 = WindowsInteropHelper.ReadUtf7ProcessString(uint_, characterAccountConfig_0.int_137, num6);
				if (!(text2 == ""))
				{
					object obj = text;
					text = string.Concat(obj, "(", num4, ")", ReplaceChannelControlCharacters(text2, null, " "), GameConfigurationManager.string_7);
				}
			}
		}
		return text;
	}

	public static string BuildTopChannelSlotTextDump(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_209.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_207.uint_0;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_212.uint_0, characterAccountConfig_0.int_137);
		string text = null;
		for (uint num4 = 0u; num4 < 256; num4++)
		{
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(num3 + num4 * 4, characterAccountConfig_0.int_137);
			int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num5 + 24, characterAccountConfig_0.int_137);
			num6 -= 19;
			if (num6 > 0)
			{
				uint uint_ = num5 + GameConfigurationManager.memorySignatureScanConfig_213.uint_0 + uint_0;
				string text2 = WindowsInteropHelper.ReadUtf7ProcessString(uint_, characterAccountConfig_0.int_137, num6);
				if (!(text2 == ""))
				{
					object obj = text;
					text = string.Concat(obj, "(", num4, ")", ReplaceChannelControlCharacters(text2, null, " "), GameConfigurationManager.string_7);
				}
			}
		}
		return text;
	}

	public static void PublishLastChannelMessage(CharacterAccountConfig characterAccountConfig_0, object object_0, bool bool_0 = true, uint uint_3 = 3u)
	{
		if (object_0 != null && characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_85 != 0 && GameConfigurationManager.memorySignatureScanConfig_210.uint_0 != 0)
		{
			uint uint_4 = GameConfigurationManager.memorySignatureScanConfig_207.uint_0;
			if (bool_0)
			{
				uint_3 = 3u;
				uint_4 = GameConfigurationManager.memorySignatureScanConfig_208.uint_0;
			}
			string[] array = new string[2] { "Cong bo", "Abc" };
			string string_ = object_0.GetType().ToString().ToUpper();
			if (CommonUtility.FindSubstringIndex(string_, "[") <= 0)
			{
				array[1] = object_0.ToString();
			}
			else
			{
				array = (string[])object_0;
			}
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_85 + 2, characterAccountConfig_0.int_137, uint_3);
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_85 + 7, characterAccountConfig_0.int_137, (uint)array[1].Length);
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_85 + 19, characterAccountConfig_0.int_137, uint_4);
			int int_ = 0;
			byte[] array2 = CommonUtility.ConvertStringToSingleByteArray(array[0]);
			uint num = characterAccountConfig_0.uint_85 - GameProcessInteractionHelper.uint_1;
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array2, array2.Length, ref int_);
			array2 = CommonUtility.ConvertStringToSingleByteArray(array[1]);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 80, array2, array2.Length, ref int_);
			if (flag && flag2)
			{
				GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_85);
			}
		}
	}

	public static void SelectLastChannelTab(CharacterAccountConfig characterAccountConfig_0, uint uint_3)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_86 != 0)
		{
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_86 + 2, characterAccountConfig_0.int_137, uint_3);
			GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_86);
		}
	}

	private static string ReplaceChannelControlCharacters(string string_1, byte[] byte_0, string string_2 = "")
	{
		if (string_1 != null && string_1 != "")
		{
			if (byte_0 == null)
			{
				byte_0 = new byte[30];
				for (byte b = 0; b < byte_0.Length; b++)
				{
					byte_0[b] = b;
				}
			}
			for (int i = 0; i < byte_0.Length; i++)
			{
				string text = string_1;
				char c = (char)byte_0[i];
				string_1 = text.Replace(c.ToString(), string_2);
			}
		}
		return string_1;
	}

	public static bool PatchShowGameFlagCheck(CharacterAccountConfig characterAccountConfig_0, int int_0 = -1)
	{
		if (characterAccountConfig_0.uint_7 != 0)
		{
			int int_1 = 0;
			byte[] array = new byte[4];
			if (int_0 >= 0)
			{
				if (int_0 == 0)
				{
					array = new byte[1] { 2 };
					return WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_250.uint_0 + 6, array, 1, ref int_1);
				}
				if (int_0 <= 0)
				{
					return false;
				}
				array = new byte[1] { 235 };
				uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_250.uint_0 + 7;
				return WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_, array, 1, ref int_1);
			}
			array = new byte[2] { 1, 116 };
			return WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_250.uint_0 + 6, array, 2, ref int_1);
		}
		return false;
	}

	public static int ReadTongKimFactionPlayerCount(CharacterAccountConfig characterAccountConfig_0, bool bool_0 = false)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_252.uint_0 != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			uint num = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_252.uint_0;
			if (bool_0)
			{
				num -= 4;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num, array, 4, ref int_);
			return BitConverter.ToInt32(array, 0);
		}
		return 0;
	}

	public static int ReadTongKimBattlefieldTime(CharacterAccountConfig characterAccountConfig_0, bool bool_0 = false)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_253.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_254.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_255.uint_0 != 0)
		{
			int num = 0;
			int int_ = 0;
			byte[] array = new byte[4];
			uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_253.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 4, ref int_);
			int num2 = BitConverter.ToInt32(array, 0);
			uint uint_2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_255.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_2, array, 4, ref int_);
			int num3 = BitConverter.ToInt32(array, 0);
			int num4 = num2 - num3;
			uint uint_3 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_254.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_3, array, 4, ref int_);
			int num5 = BitConverter.ToInt32(array, 0);
			if (num4 <= num5 * 1000)
			{
				int num6 = num4 / 1000;
				int num7 = num5 - num6;
				if (bool_0)
				{
					num7 /= 60;
				}
				num = num7 + 1;
			}
			else
			{
				int num8 = num4 / 1000;
				if (bool_0)
				{
					num8 /= 60;
				}
				num = num8 + 1;
			}
			return num;
		}
		return 0;
	}

	public static int ReadTongKimCurrentPoints(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_257.uint_0 != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			int result = 0;
			uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_257.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 4, ref int_);
			uint num = BitConverter.ToUInt32(array, 0);
			if (num != 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + 4, array, 4, ref int_);
				result = BitConverter.ToInt32(array, 0);
			}
			return result;
		}
		return 0;
	}

	public static int ReadTongKimMaximumPoints(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_256.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_258.uint_0 != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_256.uint_0 + GameConfigurationManager.memorySignatureScanConfig_258.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 4, ref int_);
			return BitConverter.ToInt32(array, 0);
		}
		return 0;
	}

	public static int ReadGatewayConnectionState(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.int_136 > 0 && GameConfigurationManager.memorySignatureScanConfig_259.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_260.uint_0 != 0)
		{
			uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_259.uint_0 + GameConfigurationManager.memorySignatureScanConfig_260.uint_0;
			int int_ = 0;
			byte[] array = new byte[2];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 2, ref int_);
			if (int_ != 0)
			{
				return array[0] + array[1] * 256;
			}
			return 0;
		}
		return 999;
	}

	public static void ResetBoxAndNpcDialogState(CharacterAccountConfig characterAccountConfig_0)
	{
		int int_ = 0;
		byte[] array = new byte[4];
		byte[] byte_ = new byte[4];
		byte[] byte_2 = new byte[1];
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + NpcDialogHelper.uint_0, byte_2, 1, ref int_);
		for (uint num = 0u; num < 18; num++)
		{
			uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_179.uint_0 + num * 4;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 4, ref int_);
			if (BitConverter.ToUInt32(array, 0) != 0)
			{
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_, byte_, 4, ref int_);
			}
		}
	}

	public static void smethod_41(CharacterAccountConfig characterAccountConfig_0, bool bool_0)
	{
		if (characterAccountConfig_0.uint_7 == 0)
		{
			return;
		}
		int int_ = 0;
		uint uint_ = 24976 + characterAccountConfig_0.uint_7;
		byte[] array = new byte[3];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 3, ref int_);
		byte[] array2 = null;
		byte[] array3 = null;
		if (!bool_0)
		{
			array2 = new byte[3] { 194, 24, 0 };
			array3 = new byte[3] { 85, 139, 236 };
		}
		else
		{
			array2 = new byte[3] { 85, 139, 236 };
			array3 = new byte[3] { 194, 24, 0 };
		}
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (array[num] == array2[num])
				{
					num++;
					continue;
				}
				break;
			}
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_, array3, 3, ref int_);
			break;
		}
	}
}
