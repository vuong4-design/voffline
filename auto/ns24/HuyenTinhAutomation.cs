using System;
using System.Threading;
using ns1;
using ns100;
using ns11;
using ns23;
using ns28;
using ns31;
using ns35;
using ns44;
using ns53;
using ns61;
using ns63;
using ns71;
using ns81;
using ns83;
using ns85;

namespace ns24;

internal class HuyenTinhAutomation
{
	public static int ActiveCharacterId = 0;

	public static int UseGuildStorageMaterials = WindowsRegistryHelper.ReadApplicationRegistryInt32("flagNguyenlieuBH", 0, "0");

	public void UpgradeHuyenTinh()
	{
		int num = ActiveCharacterId;
		ActiveCharacterId = 0;
		bool flag = false;
		bool flag2 = false;
		int int_ = 0;
		string text = "HuyÒn Tinh Kho\u00b8ng Th¹ch".ToLower();
		byte[] array = new byte[text.Length + 3];
		byte[] array2 = new byte[1];
		byte[] array3 = new byte[4];
		CharacterAccountConfig characterAccountConfig_ = default(CharacterAccountConfig);
		int num2 = 0;
		int num3;
		while (true)
		{
			Thread.Sleep(300);
			num3 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
			if (CommonUtility.bool_0 || num3 < 0 || !Form1.characterAccountConfig_1[num3].bool_25 || Form1.characterAccountConfig_1[num3].byte_0[0] == 0)
			{
				break;
			}
			characterAccountConfig_ = Form1.characterAccountConfig_1[num3];
			uint num4 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_.int_137);
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_.int_137);
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_.int_137);
			uint num7 = num6 + num5 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			int num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig_.int_137);
			int num9 = (int)WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig_.int_137);
			int num10 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_);
			if (num8 == 10 || num8 == 21 || num9 == 0 || num10 <= 1)
			{
				continue;
			}
			uint num11 = num4 + GameConfigurationManager.memorySignatureScanConfig_12.uint_0 + GameConfigurationManager.memorySignatureScanConfig_75.uint_0;
			if (!flag)
			{
				num3 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
				if (0 <= num3)
				{
					Form1.characterAccountConfig_1[num3].bool_15 = true;
				}
				if (characterAccountConfig_.string_15 != null && characterAccountConfig_.string_15 != string.Empty)
				{
					uint num12 = CommonUtility.ParseUInt32OrZero(characterAccountConfig_.string_15);
					if (num12 != 0)
					{
						GameProcessInteractionHelper.smethod_117(characterAccountConfig_, num12);
						Thread.Sleep(100);
					}
					Thread.Sleep(350);
				}
				long num13 = WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_74.uint_0, characterAccountConfig_.int_137);
				if (num13 > 0L)
				{
					GameProcessInteractionHelper.smethod_37(characterAccountConfig_, (uint)num13);
				}
				flag = true;
				GameProcessInteractionHelper.smethod_52(characterAccountConfig_, "<color=yellow>Bat dau nang cap Huyen tinh...");
			}
			uint num14 = num4 + GameConfigurationManager.memorySignatureScanConfig_97.uint_0;
			uint num15 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_105.uint_0, characterAccountConfig_.int_137);
			int num16 = -1;
			for (int i = 1; i < 10; i++)
			{
				if (characterAccountConfig_.byte_0[i] > 0)
				{
					num16 = i;
					break;
				}
			}
			if (num16 < 0)
			{
				break;
			}
			if (!flag2)
			{
				GameProcessInteractionHelper.smethod_52(characterAccountConfig_, GameTextEncodingHelper.ConvertDisplayTextToGameText("<color=yellow>Nâng cấp huyền tinh " + num16 + " -> " + (num16 + 1)));
				flag2 = true;
			}
			int num17 = 0;
			uint[] array4 = new uint[3];
			uint[] array5 = array4;
			int num18 = Class85.GetInventoryEntryCount(characterAccountConfig_);
			int num19 = 0;
			uint num20 = 1u;
			while (true)
			{
				if (num20 < GameConfigurationManager.int_1 && num18 > num19)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num14 + (num20 * 5 + GameConfigurationManager.memorySignatureScanConfig_99.uint_0) * 4, array3, 4, ref int_);
					uint num21 = BitConverter.ToUInt32(array3, 0);
					if (num21 != 0)
					{
						uint num22 = num15 + num21 * GameConfigurationManager.memorySignatureScanConfig_106.uint_0;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num22 + GameConfigurationManager.memorySignatureScanConfig_106.uint_0 - 4, array3, 4, ref int_);
						if (BitConverter.ToInt32(array3, 0) == 0)
						{
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num22 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, array2, 1, ref int_);
							if (array2[0] != 0)
							{
								num19++;
								uint num23 = num14 + num20 * 20;
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num23 + GameConfigurationManager.memorySignatureScanConfig_100.uint_0 - 8, array2, 1, ref int_);
								uint num24 = array2[0];
								if (num24 == 1 || num24 == 3)
								{
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num22 + GameConfigurationManager.memorySignatureScanConfig_108.uint_0, array2, 1, ref int_);
									if (array2[0] == 6)
									{
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num22 + GameConfigurationManager.memorySignatureScanConfig_111.uint_0, array2, 1, ref int_);
										int num25 = array2[0];
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num22 + GameConfigurationManager.memorySignatureScanConfig_112.uint_0, array2, 1, ref int_);
										int num26 = array2[0];
										if (num25 == 1 && num26 == 1)
										{
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num22 + GameConfigurationManager.memorySignatureScanConfig_119.uint_0, array3, 4, ref int_);
											int num27 = BitConverter.ToInt32(array3, 0);
											if (num27 > 0)
											{
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num22 + GameConfigurationManager.memorySignatureScanConfig_114.uint_0, array2, 1, ref int_);
												if (array2[0] == num16)
												{
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num22 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, array, array.Length, ref int_);
													string string_ = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array).ToLower();
													if (CommonUtility.FindSubstringIndex(string_, text) >= 0)
													{
														if (num27 != 1)
														{
															uint[] array6 = Class85.FindFreeItemGridPosition(characterAccountConfig_, 3u);
															if (array6 != null)
															{
																if (num24 != 1)
																{
																	int num28 = 0;
																	while (!CommonUtility.bool_0 && WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_123.uint_0, characterAccountConfig_.int_137) == 0)
																	{
																		if (num28 % 20 == 0)
																		{
																			GameProcessInteractionHelper.smethod_71(characterAccountConfig_, num21, 1u, 89);
																		}
																		if (num28 > 1500)
																		{
																			GameProcessInteractionHelper.smethod_52(characterAccountConfig_, GameTextEncodingHelper.ConvertDisplayTextToGameText("Không thể tách vật phẩm !"));
																			if (InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig_))
																			{
																				InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_);
																			}
																			Thread.Sleep(300);
																			num28 = 0;
																		}
																		Thread.Sleep(10);
																		num28++;
																	}
																}
																int num29 = 0;
																while (!CommonUtility.bool_0 && (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_123.uint_0, characterAccountConfig_.int_137) > 0)
																{
																	if (num29 % 20 == 0)
																	{
																		GameProcessInteractionHelper.smethod_46(characterAccountConfig_, array6[0], array6[1], 3u, array6[0], array6[1], 3u);
																	}
																	if (num29 > 1500)
																	{
																		GameProcessInteractionHelper.smethod_52(characterAccountConfig_, GameTextEncodingHelper.ConvertDisplayTextToGameText("Không thể đặt vật phẩm xuống !"));
																		if (InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig_))
																		{
																			InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_);
																		}
																		Thread.Sleep(300);
																		num29 = 0;
																	}
																	Thread.Sleep(10);
																	num29++;
																}
																break;
															}
														}
														else
														{
															bool flag3 = false;
															for (int j = 0; j < array5.Length; j++)
															{
																if (array5[j] == num21)
																{
																	flag3 = true;
																	break;
																}
															}
															if (!flag3)
															{
																array5[num17] = num21;
																num17++;
																if (num17 > 2)
																{
																	num2++;
																	GameProcessInteractionHelper.smethod_69(characterAccountConfig_, array5[0], array5[1], array5[2]);
																	if (num2 < 5)
																	{
																		break;
																	}
																	num2 = 0;
																	string string_2 = GameInterfaceMemoryHelper.ReadLatestBottomChannelText(characterAccountConfig_);
																	if (CommonUtility.MatchesGameTextPattern(string_2, "phi ph"))
																	{
																		GameInterfaceMemoryHelper.WriteLatestBottomChannelText(characterAccountConfig_, "_open");
																		if (GameProcessInteractionHelper.smethod_64(characterAccountConfig_))
																		{
																			Thread.Sleep(800);
																			InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_);
																		}
																	}
																	break;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					num20++;
					continue;
				}
				num3 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
				if (0 <= num3)
				{
					Form1.characterAccountConfig_1[num3].byte_0[num16] = 0;
					flag2 = false;
				}
				break;
			}
		}
		GameProcessInteractionHelper.smethod_52(characterAccountConfig_, "<color=yellow>Ket thuc nang cap Huyen tinh !");
		num3 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
		if (0 <= num3)
		{
			if (InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig_))
			{
				InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_);
			}
			Form1.characterAccountConfig_1[num3].byte_0 = new byte[11];
			Form1.characterAccountConfig_1[num3].byte_0[10] = 1;
			Form1.characterAccountConfig_1[num3].bool_15 = false;
		}
	}

	public void CraftHuyenTinh()
	{
		int num = ActiveCharacterId;
		ActiveCharacterId = 0;
		bool flag = false;
		bool flag2 = false;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = -1;
		int int_ = 0;
		long long_ = 0L;
		uint num6 = 0u;
		uint num7 = 0u;
		uint num8 = 0u;
		int int_2 = 0;
		byte[] array = new byte[4];
		CharacterAccountConfig characterAccountConfig_ = default(CharacterAccountConfig);
		while (true)
		{
			num2--;
			Thread.Sleep(200);
			if (num2 <= 0)
			{
				num3 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
				if (CommonUtility.bool_0 || num3 < 0)
				{
					break;
				}
				characterAccountConfig_ = Form1.characterAccountConfig_1[num3];
				if (!characterAccountConfig_.bool_25 || (num5 != -1 && num5 != characterAccountConfig_.int_26))
				{
					break;
				}
				if (!flag)
				{
					Form1.characterAccountConfig_1[num3].bool_6 = true;
					num5 = characterAccountConfig_.int_26;
					GameProcessInteractionHelper.smethod_52(characterAccountConfig_, GameTextEncodingHelper.ConvertDisplayTextToGameText("<color=yellow>Bắt đầu chế tạo Huyền tinh..."));
					flag = true;
				}
				else if (!characterAccountConfig_.bool_6)
				{
					break;
				}
				int_ = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig_.int_137);
				num2 = 10;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_2);
			uint num9 = BitConverter.ToUInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, GameConfigurationManager.memorySignatureScanConfig_105.uint_0, array, 4, ref int_2);
			uint num10 = BitConverter.ToUInt32(array, 0);
			uint num11 = num9 + GameConfigurationManager.memorySignatureScanConfig_97.uint_0;
			uint[] array2 = new uint[3];
			int num12 = Class85.GetInventoryEntryCount(characterAccountConfig_);
			int num13 = 0;
			uint num14 = 1u;
			while (num14 < GameConfigurationManager.int_1)
			{
				if (array2[0] == 0 || array2[1] == 0 || array2[2] == 0)
				{
					if (num12 <= num13)
					{
						break;
					}
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num11 + (num14 * 5 + GameConfigurationManager.memorySignatureScanConfig_99.uint_0) * 4, array, 4, ref int_2);
					uint num15 = BitConverter.ToUInt32(array, 0);
					if (num15 != 0)
					{
						uint num16 = num10 + num15 * GameConfigurationManager.memorySignatureScanConfig_106.uint_0;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num16 + GameConfigurationManager.memorySignatureScanConfig_106.uint_0 - 4, array, 4, ref int_2);
						if (BitConverter.ToInt32(array, 0) == 0)
						{
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num16 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, array, 1, ref int_2);
							if (array[0] != 0)
							{
								num13++;
								uint num17 = num11 + num14 * 20;
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num17 + GameConfigurationManager.memorySignatureScanConfig_100.uint_0 - 8, array, 1, ref int_2);
								uint num18 = array[0];
								if (num18 == 3 || (num18 == 23 && UseGuildStorageMaterials > 0))
								{
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num16 + GameConfigurationManager.memorySignatureScanConfig_108.uint_0, array, 1, ref int_2);
									if (array[0] == 0)
									{
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num16 + GameConfigurationManager.memorySignatureScanConfig_110.uint_0, array, 1, ref int_2);
										uint num19 = array[0];
										if ((array2[0] == 0 && num19 == 3) || (array2[1] == 0 && num19 == 9) || (array2[2] == 0 && num19 == 4))
										{
											switch (num19)
											{
											default:
												array2[1] = num15;
												break;
											case 4u:
												array2[2] = num15;
												break;
											case 3u:
												array2[0] = num15;
												break;
											}
										}
									}
								}
							}
						}
					}
					num14++;
					continue;
				}
				goto IL_0291;
			}
			break;
			IL_0291:
			if (num6 == array2[0] && num7 == array2[1] && num8 == array2[2])
			{
				num4++;
				string string_ = GameInterfaceMemoryHelper.ReadLatestBottomChannelText(characterAccountConfig_);
				if (!CommonUtility.MatchesGameTextPattern(string_, "phi ph"))
				{
					if (!Class32.smethod_0(int_) && CommonUtility.GetElapsedMilliseconds(long_) > 600L)
					{
						bool flag3;
						if (!(flag3 = CommonUtility.MatchesGameTextPattern(string_, "kh«ng ") && (CommonUtility.MatchesGameTextPattern(string_, "TiÒn") || CommonUtility.MatchesGameTextPattern(string_, "l\u00adîng"))))
						{
							flag3 = CurrentCharacterMemoryHelper.GetCharacterMoneyValue(characterAccountConfig_) < 1000;
						}
						else
						{
							GameInterfaceMemoryHelper.WriteLatestBottomChannelText(characterAccountConfig_, "0K..");
						}
						if (flag3)
						{
							if (!Class64.smethod_14(characterAccountConfig_) && GameProcessInteractionHelper.smethod_3(characterAccountConfig_, GameProcessInteractionHelper.uint_19, 4) > 0)
							{
								MapNavigationHelper.NavigateToDestination(characterAccountConfig_, 37, "®«ng|§«ng");
							}
							Thread.Sleep(300);
						}
						long_ = CommonUtility.GetCurrentTicks();
					}
				}
				else
				{
					GameInterfaceMemoryHelper.WriteLatestBottomChannelText(characterAccountConfig_, "0K..");
					flag2 = GameProcessInteractionHelper.smethod_64(characterAccountConfig_);
					Thread.Sleep(300);
				}
				if (num4 > 12)
				{
					GameInterfaceMemoryHelper.PublishLastChannelMessage(characterAccountConfig_, "Khong the che tao Huyen tinh");
					break;
				}
			}
			else
			{
				num6 = array2[0];
				num7 = array2[1];
				num8 = array2[2];
				num4 = 0;
			}
			GameProcessInteractionHelper.smethod_67(characterAccountConfig_, array2[0], array2[1], array2[2]);
		}
		num3 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
		if (0 <= num3)
		{
			Form1.characterAccountConfig_1[num3].bool_6 = false;
			if (flag2)
			{
				InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_);
			}
			GameProcessInteractionHelper.smethod_52(characterAccountConfig_, GameTextEncodingHelper.ConvertDisplayTextToGameText("<color=yellow>Kết thúc chế tạo !"));
		}
	}
}
