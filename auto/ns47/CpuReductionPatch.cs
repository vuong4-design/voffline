using System;
using ns100;
using ns146;
using ns2;
using ns23;
using ns53;
using ns71;

namespace ns47;

internal class CpuReductionPatch
{
	public static void ApplyReductionLevel(CharacterAccountConfig accountConfig, int level, int displayLevelOverride = -1)
	{
		int accountState = GClass1.smethod_5(accountConfig);
		if (accountState > 0)
		{
			GameLaunchHelper.bool_0 = true;
		}
		if (accountState <= 0 || accountConfig.uint_7 == 0 || GameConfigurationManager.memorySignatureScanConfig_245.uint_0 == 0 || GameConfigurationManager.memorySignatureScanConfig_246.uint_0 == 0)
		{
			return;
		}
		uint primaryPatchAddress = accountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_245.uint_0;
		uint secondaryPatchAddress = accountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_246.uint_0;
		int bytesTransferred = 0;
		byte[] patchBytes = new byte[2];
		switch (level)
		{
		default:
			WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, primaryPatchAddress, patchBytes, 2, ref bytesTransferred);
			if (patchBytes[0] == 144 && patchBytes[1] == 144)
			{
				patchBytes = new byte[2] { 117, 237 };
				WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, primaryPatchAddress, patchBytes, patchBytes.Length, ref bytesTransferred);
			}
			WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, secondaryPatchAddress, patchBytes, 2, ref bytesTransferred);
			if (patchBytes[0] == 144 && patchBytes[1] == 233)
			{
				patchBytes = new byte[2] { 15, 132 };
				WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, secondaryPatchAddress, patchBytes, patchBytes.Length, ref bytesTransferred);
			}
			WriteCpuDelayValue(accountConfig, 20);
			break;
		case 2:
			WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, primaryPatchAddress, patchBytes, 2, ref bytesTransferred);
			if (patchBytes[0] == 144 && patchBytes[1] == 144)
			{
				patchBytes = new byte[2] { 117, 237 };
				WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, primaryPatchAddress, patchBytes, patchBytes.Length, ref bytesTransferred);
			}
			WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, secondaryPatchAddress, patchBytes, 2, ref bytesTransferred);
			if (patchBytes[0] == 15 && patchBytes[1] == 132)
			{
				patchBytes = new byte[2] { 144, 233 };
				WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, secondaryPatchAddress, patchBytes, patchBytes.Length, ref bytesTransferred);
			}
			WriteCpuDelayValue(accountConfig, 60);
			break;
		case 1:
			WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, primaryPatchAddress, patchBytes, 2, ref bytesTransferred);
			if (patchBytes[0] == 117 && patchBytes[1] == 237)
			{
				patchBytes = new byte[2] { 144, 144 };
				WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, primaryPatchAddress, patchBytes, patchBytes.Length, ref bytesTransferred);
			}
			WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, secondaryPatchAddress, patchBytes, 2, ref bytesTransferred);
			if (patchBytes[0] == 144 && patchBytes[1] == 233)
			{
				patchBytes = new byte[2] { 15, 132 };
				WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, secondaryPatchAddress, patchBytes, patchBytes.Length, ref bytesTransferred);
			}
			WriteCpuDelayValue(accountConfig, 40);
			break;
		}
		if (0 <= displayLevelOverride)
		{
			level = displayLevelOverride;
		}
		if (Form1.int_71 == 0)
		{
			int displayedLevel = Convert.ToByte(level > 0 && level < 3) * level;
			Class75.smethod_52(accountConfig, "<bclr=blue><color=green>§ang Gi¶m CPU ®en mµn h×nh: Møc " + displayedLevel + " (bÊm F10)");
		}
	}

	public static void WriteCpuDelayValue(CharacterAccountConfig accountConfig, int delayValue)
	{
		uint firstPatchAddress = accountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_247.uint_0;
		uint secondPatchAddress = accountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_248.uint_0;
		uint thirdPatchAddress = accountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_249.uint_0;
		int bytesTransferred = 0;
		byte[] opcode = new byte[1];
		byte[] delayByte = new byte[1] { (byte)delayValue };
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, firstPatchAddress, opcode, 1, ref bytesTransferred);
		if (opcode[0] == 106)
		{
			WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, firstPatchAddress + 1, delayByte, 1, ref bytesTransferred);
		}
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, secondPatchAddress, opcode, 1, ref bytesTransferred);
		if (opcode[0] == 106)
		{
			WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, secondPatchAddress + 1, delayByte, 1, ref bytesTransferred);
		}
		WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, thirdPatchAddress, opcode, 1, ref bytesTransferred);
		if (opcode[0] == 106)
		{
			WindowsInteropHelper.WriteProcessMemory(accountConfig.int_137, thirdPatchAddress + 1, delayByte, 1, ref bytesTransferred);
		}
	}
}
