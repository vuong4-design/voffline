using System;
using System.Threading;
using ns100;
using ns11;
using ns23;
using ns53;
using ns71;
using ns79;
using ns83;
using ns85;

namespace ns8;

internal class SkillSwitchAutomation
{
	public static int ActiveRightSkillCharacterId = 0;

	public static int ActiveLeftSkillCharacterId = 0;

	public static void RunRightSkillRotation()
	{
		int int_ = ActiveRightSkillCharacterId;
		ActiveRightSkillCharacterId = 0;
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
						Form1.characterAccountConfig_1[num].bool_38 = false;
					}
					break;
				}
				if (!flag)
				{
					if (Form1.characterAccountConfig_1[num].bool_38)
					{
						break;
					}
					Form1.characterAccountConfig_1[num].bool_38 = true;
					flag = true;
				}
				RunRightSkillRotationForCharacter(int_);
			}
			catch
			{
			}
			Thread.Sleep(300);
		}
	}

	private static void RunRightSkillRotationForCharacter(int int_2)
	{
		int num = -1;
		int num2 = 0;
		int num3 = 0;
		long num4 = 0L;
		CharacterAccountConfig characterAccountConfig_ = default(CharacterAccountConfig);
		while (true)
		{
			num3--;
			Thread.Sleep(100);
			if (num3 <= 0)
			{
				int num5 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
				if (CommonUtility.bool_0 || num5 < 0 || !Form1.characterAccountConfig_1[num5].bool_25)
				{
					break;
				}
				characterAccountConfig_ = Form1.characterAccountConfig_1[num5];
				num3 = 10;
			}
			if (DateTime.Now.Ticks < num4 + num2 * 10000)
			{
				continue;
			}
			num4 = DateTime.Now.Ticks;
			num2 = 1000;
			int num6 = -1;
			while (true)
			{
				num++;
				if (num < 0 || num > 2)
				{
					num = 0;
				}
				if (characterAccountConfig_.gstruct48_1[num].int_0 > 0)
				{
					uint num7 = (uint)characterAccountConfig_.gstruct48_1[num].int_1;
					if (num7 != 0)
					{
						num2 = characterAccountConfig_.gstruct48_1[num].int_2;
						int num8 = CharacterSkillHelper.ReadRightSkillId(characterAccountConfig_);
						if (num8 != num7)
						{
							GameProcessInteractionHelper.SetRightSkillIdViaRemoteScript(characterAccountConfig_, num7);
							CharacterSkillHelper.smethod_15(characterAccountConfig_, num7, bool_0: true);
						}
						break;
					}
				}
				if (num6 >= 0)
				{
					if (num == num6)
					{
						num = -1;
						break;
					}
				}
				else
				{
					num6 = num;
				}
			}
		}
	}

	public static void RunLeftSkillSwitching()
	{
		int int_ = ActiveLeftSkillCharacterId;
		ActiveLeftSkillCharacterId = 0;
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
						Form1.characterAccountConfig_1[num].bool_37 = false;
					}
					break;
				}
				if (!flag)
				{
					if (Form1.characterAccountConfig_1[num].bool_37)
					{
						break;
					}
					Form1.characterAccountConfig_1[num].bool_37 = true;
					flag = true;
				}
				RunLeftSkillSwitchingForCharacter(int_);
			}
			catch
			{
			}
			Thread.Sleep(300);
		}
	}

	private static void RunLeftSkillSwitchingForCharacter(int int_2)
	{
		int int_3 = 0;
		int num = -1;
		int num2 = -1;
		int num3 = 0;
		int num4 = -1;
		long num5 = 0L;
		byte[] array = new byte[4];
		int num6 = -1;
		uint num7 = 0u;
		uint num8 = 0u;
		CharacterAccountConfig characterAccountConfig_ = default(CharacterAccountConfig);
		int num9 = 0;
		while (true)
		{
			num9--;
			Thread.Sleep(300);
			if (num9 <= 0)
			{
				int num10 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
				if (CommonUtility.bool_0 || num10 < 0 || !Form1.characterAccountConfig_1[num10].bool_25)
				{
					break;
				}
				characterAccountConfig_ = Form1.characterAccountConfig_1[num10];
				num9 = 4;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array, 4, ref int_3);
			int num11 = BitConverter.ToInt32(array, 0);
			if (num11 != 0)
			{
				if (num6 != num11 || num7 == 0)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_3);
					uint num12 = BitConverter.ToUInt32(array, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num12 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array, 4, ref int_3);
					uint num13 = BitConverter.ToUInt32(array, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array, 4, ref int_3);
					num8 = BitConverter.ToUInt32(array, 0);
					num7 = num8 + num13 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
					num6 = num11;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array, 4, ref int_3);
				int num14 = BitConverter.ToInt32(array, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array, 4, ref int_3);
				int num15 = BitConverter.ToInt32(array, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array, 4, ref int_3);
				int num16 = BitConverter.ToInt32(array, 0);
				int num17 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_);
				if (num14 != 0 && num17 > 1)
				{
					GStruct48 gStruct;
					uint num18;
					switch (num15)
					{
					default:
						if (characterAccountConfig_.gstruct48_2.int_0 > 0)
						{
							num18 = (uint)characterAccountConfig_.gstruct48_2.int_1;
							if (num16 != 0 && num18 != 0)
							{
								if (characterAccountConfig_.gstruct48_2.int_3 > 0 && characterAccountConfig_.gstruct48_2.int_2 > 0)
								{
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_46.uint_0, array, 4, ref int_3);
									long num19 = BitConverter.ToInt32(array, 0);
									if (num19 <= characterAccountConfig_.gstruct48_2.int_2)
									{
										goto IL_0355;
									}
								}
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, array, 4, ref int_3);
								uint num20 = BitConverter.ToUInt32(array, 0);
								if (num20 != 0)
								{
									uint num21 = num8 + num20 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num21 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array, 4, ref int_3);
									if (BitConverter.ToInt32(array, 0) != 0)
									{
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num21 + GameConfigurationManager.memorySignatureScanConfig_52.uint_0, array, 4, ref int_3);
										if (BitConverter.ToInt32(array, 0) == 0)
										{
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num21 + GameConfigurationManager.memorySignatureScanConfig_26.uint_0 + 8, array, 4, ref int_3);
											if (BitConverter.ToInt32(array, 0) != 0)
											{
												int num22 = CharacterSkillHelper.ReadLeftSkillId(characterAccountConfig_);
												if (num22 != num18)
												{
													GameProcessInteractionHelper.SetLeftSkillIdViaRemoteScript(characterAccountConfig_, num18);
													CharacterSkillHelper.smethod_15(characterAccountConfig_, num18);
												}
												GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_, GameProcessInteractionHelper.uint_44, 1, 4);
												continue;
											}
										}
									}
								}
							}
							goto IL_0355;
						}
						goto IL_0358;
					case 10:
					case 21:
						Thread.Sleep(300);
						continue;
					case 0:
						break;
						IL_0355:
						num18 = 0u;
						goto IL_0358;
						IL_0358:
						GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_, GameProcessInteractionHelper.uint_44, 0, 4);
						num2++;
						if (num2 < 0 || num2 > 2)
						{
							num2 = 0;
						}
						gStruct = characterAccountConfig_.gstruct48_0[num2];
						if (gStruct.int_0 > 0)
						{
							int int_4 = gStruct.int_3;
							num18 = (uint)gStruct.int_1;
							if (int_4 > 0 && num18 != 0)
							{
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_45.uint_0, array, 4, ref int_3);
								long num23 = BitConverter.ToInt32(array, 0);
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_46.uint_0, array, 4, ref int_3);
								long num24 = BitConverter.ToInt32(array, 0);
								double num25 = -1.0;
								double num26 = -1.0;
								int num27 = 0;
								switch (int_4)
								{
								case 6:
								case 7:
								{
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.uint_7, array, 4, ref int_3);
									num27 = BitConverter.ToInt32(array, 0);
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.uint_8, array, 4, ref int_3);
									int num32 = BitConverter.ToInt32(array, 0);
									if (num27 < num32 && num32 < num27 * 3)
									{
										num27 = num32;
									}
									break;
								}
								case 5:
								{
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_47.uint_0, array, 4, ref int_3);
									long num28 = BitConverter.ToInt32(array, 0);
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_47.uint_0 + 4, array, 4, ref int_3);
									long num29 = BitConverter.ToInt32(array, 0);
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_48.uint_0, array, 4, ref int_3);
									long num30 = BitConverter.ToInt32(array, 0);
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_48.uint_0 + 4, array, 4, ref int_3);
									long num31 = BitConverter.ToInt32(array, 0);
									if (num29 > num28 && num29 < 5000000L)
									{
										num28 = num29;
									}
									if (num31 > num30 && num31 < 5000000L)
									{
										num30 = num31;
									}
									num25 = num23 * 100L / num28;
									num26 = num24 * 100L / num30;
									break;
								}
								}
								bool flag = (int_4 == 1 && num24 <= gStruct.int_2) || (int_4 == 2 && num24 > gStruct.int_2) || (int_4 == 3 && num23 <= gStruct.int_2) || (int_4 == 4 && num23 > gStruct.int_2) || (int_4 == 5 && num25 >= (double)gStruct.int_2 && num26 >= (double)gStruct.int_2) || (int_4 == 6 && num27 <= gStruct.int_2) || (int_4 == 7 && num27 > gStruct.int_2);
								int num33 = CharacterSkillHelper.ReadLeftSkillId(characterAccountConfig_);
								if (flag && num33 != num18)
								{
									GameProcessInteractionHelper.SetLeftSkillIdViaRemoteScript(characterAccountConfig_, num18);
									CharacterSkillHelper.smethod_15(characterAccountConfig_, num18);
								}
							}
						}
						if (DateTime.Now.Ticks < num3 * 10000 + num5)
						{
							continue;
						}
						num5 = DateTime.Now.Ticks;
						num3 = 1000;
						num4 = -1;
						while (true)
						{
							num++;
							if (num < 0 || num > 2)
							{
								num = 0;
							}
							gStruct = characterAccountConfig_.gstruct48_0[num];
							if (gStruct.int_0 > 0 && gStruct.int_3 == 0)
							{
								num18 = (uint)gStruct.int_1;
								if (num18 != 0)
								{
									num3 = gStruct.int_2;
									int num34 = CharacterSkillHelper.ReadLeftSkillId(characterAccountConfig_);
									if (num34 != num18)
									{
										GameProcessInteractionHelper.SetLeftSkillIdViaRemoteScript(characterAccountConfig_, num18);
										CharacterSkillHelper.smethod_15(characterAccountConfig_, num18);
									}
									break;
								}
							}
							if (num4 >= 0)
							{
								if (num == num4)
								{
									num = -1;
									break;
								}
							}
							else
							{
								num4 = num;
							}
						}
						continue;
					}
				}
				num6 = -1;
				Thread.Sleep(300);
			}
			else
			{
				Thread.Sleep(300);
			}
		}
	}
}
