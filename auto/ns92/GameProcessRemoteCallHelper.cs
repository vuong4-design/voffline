using System;
using System.Threading;
using ns11;
using ns23;
using ns53;

namespace ns92;

internal class GameProcessRemoteCallHelper
{
	public struct GameRemoteCallContext
	{
		public int characterId;

		public int processHandle;

		public uint injectionAddress;
	}

	public static bool smethod_0(CharacterAccountConfig characterAccountConfig_0, uint uint_0)
	{
		GameRemoteCallContext remoteCallContext = new GameRemoteCallContext
		{
			characterId = characterAccountConfig_0.int_136,
			processHandle = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, characterAccountConfig_0.int_136),
			injectionAddress = WindowsInteropHelper.AllocateRemoteMemory(characterAccountConfig_0.int_137)
		};
		if (remoteCallContext.characterId > 0 && remoteCallContext.processHandle != 0 && remoteCallContext.injectionAddress != 0)
		{
			uint num = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_192.resolvedValue - (remoteCallContext.injectionAddress + 49);
			string string_ = "60 B9 " + CommonUtility.FormatIntegerAsHex(remoteCallContext.injectionAddress.ToString(), 8, bool_1: false, bool_2: true) + "51 B8 " + CommonUtility.FormatIntegerAsHex(uint_0.ToString(), 8, bool_1: false, bool_2: true) + "B9" + CommonUtility.FormatIntegerAsHex((characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_191.resolvedValue).ToString(), 8, bool_1: false, bool_2: true) + "8B 1D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue.ToString(), 8, bool_1: false, bool_2: true) + "81 C3" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_189.resolvedValue.ToString(), 8, bool_1: false, bool_2: true) + "8B 5B" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_190.resolvedValue.ToString(), 2, bool_1: false, bool_2: true) + "6A 00 6A 00 50 53 6A 00E8" + CommonUtility.FormatIntegerAsHex(num.ToString(), 8, bool_1: false, bool_2: true) + "83 C4 04 59 C6 01 0161 C3";
			bool result = false;
			int int_ = 0;
			byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, remoteCallContext.injectionAddress + 4, array, array.Length, ref int_))
			{
				byte[] array2 = new byte[1];
				array = array2;
				WindowsInteropHelper.WriteProcessMemory(remoteCallContext.processHandle, remoteCallContext.injectionAddress, array, 1, ref int_);
				ExecuteRemoteThreadAndWait(remoteCallContext.processHandle, remoteCallContext.injectionAddress + 4);
				long long_ = CommonUtility.GetCurrentTicks();
				while (CommonUtility.GetElapsedMilliseconds(long_) < 10000L)
				{
					Thread.Sleep(150);
					WindowsInteropHelper.ReadProcessMemory(remoteCallContext.processHandle, remoteCallContext.injectionAddress, array, 1, ref int_);
					if (array[0] > 0)
					{
						break;
					}
				}
				Thread.Sleep(300);
				result = true;
			}
			WindowsInteropHelper.FreeRemoteMemory(remoteCallContext.processHandle, remoteCallContext.injectionAddress);
			WindowsInteropHelper.CloseHandleSafely(remoteCallContext.processHandle);
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
		GameRemoteCallContext remoteCallContext = new GameRemoteCallContext
		{
			characterId = characterAccountConfig_0.int_136,
			processHandle = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, characterAccountConfig_0.int_136),
			injectionAddress = WindowsInteropHelper.AllocateRemoteMemory(characterAccountConfig_0.int_137)
		};
		if (remoteCallContext.characterId > 0 && remoteCallContext.processHandle != 0 && remoteCallContext.injectionAddress != 0)
		{
			uint num = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_225.resolvedValue - (remoteCallContext.injectionAddress + 38);
			string string_ = "60 8B EC 50 51B9 " + CommonUtility.FormatIntegerAsHex(remoteCallContext.injectionAddress.ToString(), 8, bool_1: false, bool_2: true) + "51 B8 " + CommonUtility.FormatIntegerAsHex(uint_0.ToString(), 8, bool_1: false, bool_2: true) + "50 B8 " + CommonUtility.FormatIntegerAsHex(int_0.ToString(), 8, bool_1: false, bool_2: true) + "50 B8 05 00 00 0050 E8 " + CommonUtility.FormatIntegerAsHex(num.ToString(), 8, bool_1: false, bool_2: true) + "59 C6 01 0159 58 61 C3";
			bool result = false;
			int int_1 = 0;
			byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, remoteCallContext.injectionAddress + 4, array, array.Length, ref int_1))
			{
				byte[] array2 = new byte[1];
				array = array2;
				WindowsInteropHelper.WriteProcessMemory(remoteCallContext.processHandle, remoteCallContext.injectionAddress, array, 1, ref int_1);
				ExecuteRemoteThreadAndWait(remoteCallContext.processHandle, remoteCallContext.injectionAddress + 4);
				long long_ = CommonUtility.GetCurrentTicks();
				while (CommonUtility.GetElapsedMilliseconds(long_) < 10000L)
				{
					Thread.Sleep(150);
					WindowsInteropHelper.ReadProcessMemory(remoteCallContext.processHandle, remoteCallContext.injectionAddress, array, 1, ref int_1);
					if (array[0] > 0)
					{
						break;
					}
				}
				Thread.Sleep(300);
				result = true;
			}
			WindowsInteropHelper.FreeRemoteMemory(remoteCallContext.processHandle, remoteCallContext.injectionAddress);
			WindowsInteropHelper.CloseHandleSafely(remoteCallContext.processHandle);
			return result;
		}
		return false;
	}

	private static void ExecuteRemoteThreadAndWait(int processHandle, uint startAddress)
	{
		uint uint_1 = 0u;
		uint num = WindowsInteropHelper.CreateRemoteThread(processHandle, IntPtr.Zero, 0u, startAddress, 0u, 0u, out uint_1);
		WindowsInteropHelper.WaitForSingleObject(num, 30000u);
		WindowsInteropHelper.CloseHandleSafely((int)num);
	}
}
