using System;
using System.Threading;
using ns11;
using ns23;
using ns53;

namespace ns92;

internal class GameProcessRemoteCallHelper
{
	public struct Struct27
	{
		public int characterId;

		public int processHandle;

		public uint injectionAddress;
	}

	public static bool smethod_0(CharacterAccountConfig characterAccountConfig_0, uint uint_0)
	{
		Struct27 @struct = new Struct27
		{
			characterId = characterAccountConfig_0.int_136,
			processHandle = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, characterAccountConfig_0.int_136),
			injectionAddress = WindowsInteropHelper.smethod_1(characterAccountConfig_0.int_137)
		};
		if (@struct.characterId > 0 && @struct.processHandle != 0 && @struct.injectionAddress != 0)
		{
			uint num = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_192.uint_0 - (@struct.injectionAddress + 49);
			string string_ = "60 B9 " + Class11.smethod_46(@struct.injectionAddress.ToString(), 8, bool_1: false, bool_2: true) + "51 B8 " + Class11.smethod_46(uint_0.ToString(), 8, bool_1: false, bool_2: true) + "B9" + Class11.smethod_46((characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_191.uint_0).ToString(), 8, bool_1: false, bool_2: true) + "8B 1D" + Class11.smethod_46(GameConfigurationManager.memorySignatureScanConfig_11.uint_0.ToString(), 8, bool_1: false, bool_2: true) + "81 C3" + Class11.smethod_46(GameConfigurationManager.memorySignatureScanConfig_189.uint_0.ToString(), 8, bool_1: false, bool_2: true) + "8B 5B" + Class11.smethod_46(GameConfigurationManager.memorySignatureScanConfig_190.uint_0.ToString(), 2, bool_1: false, bool_2: true) + "6A 00 6A 00 50 53 6A 00E8" + Class11.smethod_46(num.ToString(), 8, bool_1: false, bool_2: true) + "83 C4 04 59 C6 01 0161 C3";
			bool result = false;
			int int_ = 0;
			byte[] array = Class11.smethod_8(string_, bool_1: false);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, @struct.injectionAddress + 4, array, array.Length, ref int_))
			{
				byte[] array2 = new byte[1];
				array = array2;
				WindowsInteropHelper.WriteProcessMemory(@struct.processHandle, @struct.injectionAddress, array, 1, ref int_);
				smethod_4(@struct.processHandle, @struct.injectionAddress + 4);
				long long_ = Class11.smethod_27();
				while (Class11.smethod_28(long_) < 10000L)
				{
					Thread.Sleep(150);
					WindowsInteropHelper.ReadProcessMemory(@struct.processHandle, @struct.injectionAddress, array, 1, ref int_);
					if (array[0] > 0)
					{
						break;
					}
				}
				Thread.Sleep(300);
				result = true;
			}
			WindowsInteropHelper.smethod_2(@struct.processHandle, @struct.injectionAddress);
			WindowsInteropHelper.smethod_32(@struct.processHandle);
			return result;
		}
		return false;
	}

	private static bool smethod_1(CharacterAccountConfig characterAccountConfig_0, uint uint_0)
	{
		return smethod_3(characterAccountConfig_0, uint_0, 0);
	}

	private static bool smethod_2(CharacterAccountConfig characterAccountConfig_0, uint uint_0)
	{
		return smethod_3(characterAccountConfig_0, uint_0, 1);
	}

	private static bool smethod_3(CharacterAccountConfig characterAccountConfig_0, uint uint_0, int int_0)
	{
		Struct27 @struct = new Struct27
		{
			characterId = characterAccountConfig_0.int_136,
			processHandle = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, characterAccountConfig_0.int_136),
			injectionAddress = WindowsInteropHelper.smethod_1(characterAccountConfig_0.int_137)
		};
		if (@struct.characterId > 0 && @struct.processHandle != 0 && @struct.injectionAddress != 0)
		{
			uint num = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_225.uint_0 - (@struct.injectionAddress + 38);
			string string_ = "60 8B EC 50 51B9 " + Class11.smethod_46(@struct.injectionAddress.ToString(), 8, bool_1: false, bool_2: true) + "51 B8 " + Class11.smethod_46(uint_0.ToString(), 8, bool_1: false, bool_2: true) + "50 B8 " + Class11.smethod_46(int_0.ToString(), 8, bool_1: false, bool_2: true) + "50 B8 05 00 00 0050 E8 " + Class11.smethod_46(num.ToString(), 8, bool_1: false, bool_2: true) + "59 C6 01 0159 58 61 C3";
			bool result = false;
			int int_1 = 0;
			byte[] array = Class11.smethod_8(string_, bool_1: false);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, @struct.injectionAddress + 4, array, array.Length, ref int_1))
			{
				byte[] array2 = new byte[1];
				array = array2;
				WindowsInteropHelper.WriteProcessMemory(@struct.processHandle, @struct.injectionAddress, array, 1, ref int_1);
				smethod_4(@struct.processHandle, @struct.injectionAddress + 4);
				long long_ = Class11.smethod_27();
				while (Class11.smethod_28(long_) < 10000L)
				{
					Thread.Sleep(150);
					WindowsInteropHelper.ReadProcessMemory(@struct.processHandle, @struct.injectionAddress, array, 1, ref int_1);
					if (array[0] > 0)
					{
						break;
					}
				}
				Thread.Sleep(300);
				result = true;
			}
			WindowsInteropHelper.smethod_2(@struct.processHandle, @struct.injectionAddress);
			WindowsInteropHelper.smethod_32(@struct.processHandle);
			return result;
		}
		return false;
	}

	private static void smethod_4(int int_0, uint uint_0)
	{
		uint uint_1 = 0u;
		uint num = WindowsInteropHelper.CreateRemoteThread(int_0, IntPtr.Zero, 0u, uint_0, 0u, 0u, out uint_1);
		WindowsInteropHelper.WaitForSingleObject(num, 30000u);
		WindowsInteropHelper.smethod_32((int)num);
	}
}
