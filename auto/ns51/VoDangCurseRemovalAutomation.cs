using System;
using System.Threading;
using ns100;
using ns11;
using ns23;
using ns53;
using ns71;
using ns83;

namespace ns51;

internal class VoDangCurseRemovalAutomation
{
	public static int ActiveCharacterId = 0;

	public static void Run()
	{
		int int_ = ActiveCharacterId;
		ActiveCharacterId = 0;
		bool flag = false;
		while (true)
		{
			try
			{
				int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
				if (CommonUtility.bool_0 || num < 0 || !Form1.characterAccountConfig_1[num].bool_25)
				{
					if (0 <= num)
					{
						Form1.characterAccountConfig_1[num].bool_30 = false;
					}
					break;
				}
				if (!flag)
				{
					if (Form1.characterAccountConfig_1[num].bool_30)
					{
						break;
					}
					Form1.characterAccountConfig_1[num].bool_30 = true;
					flag = true;
				}
				RunForCharacter(int_);
			}
			catch
			{
			}
			Thread.Sleep(300);
		}
	}

	private static void RunForCharacter(int int_1)
	{
		int int_2 = 0;
		byte[] array = new byte[1];
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		int num = 0;
		long num2 = 0L;
		long long_ = 0L;
		byte[] array2 = new byte[4];
		byte[] byte_ = array2;
		byte[] array3 = null;
		byte[] byte_2 = new byte[4];
		byte[] byte_3 = new byte[4] { 5, 0, 0, 0 };
		byte[] bytes = BitConverter.GetBytes(716);
		byte[] byte_4 = new byte[4];
		byte[] byte_5 = new byte[4];
		int num3 = 0;
		while (true)
		{
			num--;
			Thread.Sleep(300);
			if (num < 0)
			{
				num3 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_1);
				if (CommonUtility.bool_0 || num3 < 0 || !Form1.characterAccountConfig_1[num3].bool_25)
				{
					break;
				}
				num = 10;
			}
			characterAccountConfig = Form1.characterAccountConfig_1[num3];
			if (characterAccountConfig.int_80 <= 0 || !characterAccountConfig.bool_57 || characterAccountConfig.gstruct49_0.pickupEnabled > 0 || GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_6, 4) > 0)
			{
				continue;
			}
			uint num4 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig.int_137);
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig.int_137);
			uint num6 = num5 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			uint num7 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig.int_137);
			uint num8 = num7 + num6;
			int num9 = (int)WindowsInteropHelper.ReadProcessUInt32(num8 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig.int_137);
			int num10 = (int)WindowsInteropHelper.ReadProcessUInt32(num8 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig.int_137);
			int num11 = (int)WindowsInteropHelper.ReadProcessUInt32(num8 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig.int_137);
			if (num11 <= 0 || num10 == 0)
			{
				continue;
			}
			switch (num9)
			{
			case 10:
			case 21:
				long_ = 0L;
				num2 = 0L;
				continue;
			case 0:
				continue;
			}
			array3 = null;
			if (characterAccountConfig.int_82 > 0)
			{
				if (CommonUtility.GetElapsedMilliseconds(long_) < characterAccountConfig.int_87)
				{
					continue;
				}
			}
			else
			{
				if (CommonUtility.GetElapsedMilliseconds(long_) < characterAccountConfig.long_9)
				{
					continue;
				}
				if (characterAccountConfig.int_81 > 0 && num9 == 9)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_38.resolvedValue + 4, array, 1, ref int_2);
					if (array[0] == 0)
					{
						goto IL_02ad;
					}
				}
				if (num2 == 0L)
				{
					for (int i = 0; i < GameConfigurationManager.int_2.Length; i++)
					{
						for (uint num12 = 0u; num12 < 6; num12++)
						{
							uint num13 = WindowsInteropHelper.ReadProcessUInt32(num8 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_2.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_3.resolvedValue * num12, characterAccountConfig.int_137);
							if (num13 == GameConfigurationManager.int_2[i])
							{
								num2 = CommonUtility.GetCurrentTicks();
								break;
							}
						}
					}
					continue;
				}
				if (CommonUtility.GetElapsedMilliseconds(num2) <= characterAccountConfig.int_85)
				{
					continue;
				}
			}
			goto IL_02ad;
			IL_02ad:
			int num14 = 0;
			GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig, GameProcessInteractionHelper.uint_6, 1, 4);
			byte[] array4 = new byte[4];
			if (array3 == null)
			{
				array3 = new byte[4];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_31.resolvedValue, array3, 4, ref int_2);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_12.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_68.resolvedValue, byte_2, 4, ref int_2);
			}
			while (true)
			{
				int j = 0;
				int num15 = -1;
				for (; j < 300; j++)
				{
					WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_2);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, array4, 1, ref int_2);
					if (array4[0] < 4 && (num15 == -1 || num15 > 80))
					{
						break;
					}
					num15 = ((array4[0] <= 3) ? (num15 + 1) : 0);
					Thread.Sleep(1);
				}
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_31.resolvedValue, byte_, 4, ref int_2);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, byte_4, 4, ref int_2);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, byte_5, 4, ref int_2);
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_37.resolvedValue, byte_4, 4, ref int_2);
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_38.resolvedValue, byte_5, 4, ref int_2);
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_36.resolvedValue, bytes, bytes.Length, ref int_2);
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_35.resolvedValue, byte_3, 4, ref int_2);
				for (j = 0; j < 60; j++)
				{
					for (uint num16 = 0u; num16 < 6; num16++)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_2.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_3.resolvedValue * num16, array4, 4, ref int_2);
						if (BitConverter.ToInt32(array4, 0) == 122)
						{
							goto end_IL_0503;
						}
					}
					Thread.Sleep(10);
				}
				if (num14 > 0)
				{
					break;
				}
				num14++;
				continue;
				end_IL_0503:
				break;
			}
			if (array3 != null)
			{
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_31.resolvedValue, array3, 4, ref int_2);
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_161.resolvedValue - 8, byte_2, 4, ref int_2);
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_35.resolvedValue, byte_, 4, ref int_2);
				array3 = null;
			}
			GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig, GameProcessInteractionHelper.uint_6, 0, 4);
			num2 = 0L;
			long_ = CommonUtility.GetCurrentTicks();
		}
	}
}
