using System;
using System.Threading;
using ns1;
using ns100;
using ns11;
using ns13;
using ns18;
using ns23;
using ns28;
using ns35;
using ns42;
using ns44;
using ns50;
using ns52;
using ns53;
using ns56;
using ns61;
using ns71;
using ns77;
using ns81;
using ns83;
using ns85;
using ns88;
using ns91;

namespace ns87;

internal class ViSonDaoAutomation
{
	public static void RunWithRetry(int int_0)
	{
		while (true)
		{
			try
			{
				Run(int_0);
				break;
			}
			catch
			{
				Thread.Sleep(300);
			}
		}
	}

	public static void Run(int int_0)
	{
		bool flag = false;
		bool flag2 = false;
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		int num = -1;
		string text = "MËt ®å thÇn bÝ";
		int num2 = -1;
		string text2 = "LÖnh bµi Vi S¬n";
		int num3 = 0;
		int num4 = -1;
		int num5 = 0;
		int num6 = 0;
		int int_1 = 0;
		byte[] array = new byte[4];
		byte[] array2 = new byte[60];
		int num7 = 0;
		int num8 = 0;
		bool flag3 = false;
		while (true)
		{
			Thread.Sleep(200);
			int num9 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_0);
			if (CommonUtility.bool_0 || num9 < 0)
			{
				break;
			}
			characterAccountConfig = Form1.characterAccountConfig_1[num9];
			uint num30;
			int num14;
			uint num19;
			uint num28;
			uint num24;
			uint num26;
			uint num27;
			int num21;
			if (characterAccountConfig.bool_25 && characterAccountConfig.bool_55 && !flag)
			{
				if (flag2)
				{
					flag2 = StorageChestAccessHelper.OpenStorageChest(characterAccountConfig, bool_0: true) <= 0;
					continue;
				}
				uint num10 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig.int_137);
				uint num11 = WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig.int_137);
				uint num12 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig.int_137);
				uint num13 = num12 + num11 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
				num14 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig.int_137);
				int num15 = (int)WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig.int_137);
				int num16 = (int)WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig.int_137);
				int num17 = (int)WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig.int_137);
				int num18 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig);
				if (num17 <= 0 || num14 <= 0 || num16 == 10 || num16 == 21 || num18 <= 1 || (characterAccountConfig.int_136 == ApplicationRuntimeCoordinator.characterAccountConfig_0.int_136 && GameInterfaceMemoryHelper.ReadEngineStateByte(characterAccountConfig) == 1))
				{
					continue;
				}
				uint[] array3 = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
				};
				if (array3[0] == 0 || array3[1] == 0)
				{
					continue;
				}
				if (num14 != 342)
				{
					if (TongKimBattlefieldHelper.FindBattlefieldMapMatrixPosition(num14) != null)
					{
						flag2 = InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig, 11) > 0;
						continue;
					}
					num19 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig.int_137) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
					uint num20 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, characterAccountConfig.int_137);
					num21 = 0;
					int num22 = Class85.GetInventoryEntryCount(characterAccountConfig);
					int num23 = 0;
					num24 = 0u;
					uint num25 = 0u;
					num26 = 0u;
					num27 = 0u;
					num28 = 0u;
					uint num29 = 0u;
					string text3 = null;
					if (num2 == -1)
					{
						num2 = 0;
						num = 0;
						for (num30 = 1u; num30 < GameConfigurationManager.int_1 && num22 > num23; num30++)
						{
							num25 = num20 + num30 * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, array, 4, ref int_1);
							if (BitConverter.ToInt32(array, 0) != 0)
							{
								continue;
							}
							num28 = Class85.FindInventoryEntryIndexByItemRecordIndex(characterAccountConfig, num30);
							if ((int)num28 <= 0)
							{
								continue;
							}
							num23++;
							num29 = num25 + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue;
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num29, array, 1, ref int_1);
							if (array[0] == 0 || (int)WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_108.resolvedValue, characterAccountConfig.int_137) <= 0)
							{
								continue;
							}
							uint num31 = WindowsInteropHelper.ReadProcessUInt32(num19 + num28 * 20 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, characterAccountConfig.int_137);
							if (num31 != 23 && num31 != 3 && num31 != 1)
							{
								continue;
							}
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num29, array2, array2.Length, ref int_1);
							text3 = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2).ToLower();
							if (0 > text3.IndexOf(text2.ToLower()))
							{
								if (num > 0)
								{
									continue;
								}
								uint num32 = WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue, characterAccountConfig.int_137);
								if (num32 != 100 || 0 > text3.IndexOf(text.ToLower()))
								{
									continue;
								}
								goto IL_042d;
							}
							goto IL_0432;
						}
					}
					num14 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig.int_137);
					switch (num14)
					{
					default:
						num4 = -1;
						num5 = 0;
						array3 = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
						};
						if (num14 == 195)
						{
							GStruct28 gStruct = MapTravelDataHelper.FindTravelConnection(195, 175);
							if (gStruct.uint_0 != null)
							{
								int int_2 = 0;
								int int_3 = 0;
								uint[] uint_ = null;
								uint[] uint_2 = null;
								if (gStruct.uint_0.GetLength(0) > 1)
								{
									int_2 = Class64.FindNearestCoordinateIndex(gStruct.uint_0, array3);
								}
								Class64.ExtractCoordinateRow(gStruct.uint_0, int_2, ref uint_2, ref uint_, ref int_3);
								long num38 = Class64.GetSquaredCoordinateDistance(array3, uint_2);
								if (num38 < 5000000L)
								{
									Class64.TriggerMapTransitionAtCoordinate(characterAccountConfig, uint_2, int_3, uint_, gStruct.int_1);
									continue;
								}
							}
						}
						if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_20, 4) == 0)
						{
							if (!flag3)
							{
								if (num15 <= 0)
								{
									flag3 = true;
									goto IL_0b1f;
								}
								if (num8 < 3 && Class64.TryUseTownTeleportItem(characterAccountConfig))
								{
									num8++;
									Thread.Sleep(300);
									continue;
								}
							}
							GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "Khong co Than Hanh phu, ket thuc !");
							flag = true;
						}
						else if (num7 > 3 && num14 == 336)
						{
							if (num8 < 3 && Class64.TryUseTownTeleportItem(characterAccountConfig))
							{
								num8++;
								Thread.Sleep(300);
								continue;
							}
							GStruct28 gStruct2 = MapTravelDataHelper.FindTravelConnection(num14, 121);
							if (gStruct2.uint_0 == null)
							{
								GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "Khong the qua map Long Mon tran, ket thuc !");
								flag = true;
								continue;
							}
							int int_4 = 0;
							int int_5 = 0;
							uint[] uint_3 = null;
							uint[] uint_4 = null;
							if (gStruct2.uint_0.GetLength(0) > 1)
							{
								int_4 = Class64.FindNearestCoordinateIndex(gStruct2.uint_0, array3);
							}
							Class64.ExtractCoordinateRow(gStruct2.uint_0, int_4, ref uint_4, ref uint_3, ref int_5);
							Class64.TriggerMapTransitionAtCoordinate(characterAccountConfig, uint_4, int_5, uint_3, gStruct2.int_1);
						}
						else
						{
							MapNavigationHelper.NavigateToDestination(characterAccountConfig, 175);
							Thread.Sleep(600);
							num7++;
							if (num7 > 6)
							{
								GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "Khong the Than Hanh Phu len Tay Son thon, ket thuc!");
								flag = true;
							}
						}
						continue;
					case 342:
						flag = true;
						continue;
					case 175:
						{
							if (num2 > 0 || num > 0)
							{
								break;
							}
							goto IL_0b1f;
						}
						IL_0b1f:
						while (true)
						{
							if (Form1.boatDockIndex > 3)
							{
								num9 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_0);
								if (CommonUtility.bool_0 || num9 < 0)
								{
									return;
								}
								characterAccountConfig = Form1.characterAccountConfig_1[num9];
								if (characterAccountConfig.bool_25 && characterAccountConfig.bool_55 && !flag)
								{
									int num33 = Class85.CountInventoryItemQuantityByName(characterAccountConfig, text2);
									if (num33 <= 0)
									{
										if (num3 <= 3)
										{
											if (0 > num4)
											{
												Struct24[] array4 = GameInterfaceMemoryHelper.ReadShopTypeEntries(characterAccountConfig);
												if (array4 == null)
												{
													flag = true;
													break;
												}
												int num34 = -1;
												string value = text2.ToLower();
												while (true)
												{
													num34++;
													if (array4.Length <= num34)
													{
														break;
													}
													GameProcessInteractionHelper.InvokeNamedSpecialFunction(characterAccountConfig, array4[num34].string_0);
													Thread.Sleep(300);
													GameProcessInteractionHelper.CloseKyTranCac(characterAccountConfig);
													GStruct1[] array5 = ShopItemMemoryReader.ReadOpenShopItems(characterAccountConfig);
													if (array5 == null || array5.Length == 0)
													{
														continue;
													}
													int num35 = 0;
													while (num35 < array5.Length)
													{
														text3 = array5[num35].itemName.ToLower().Trim();
														if (text3.IndexOf(value) != 0)
														{
															num35++;
															continue;
														}
														goto IL_0a74;
													}
													continue;
													IL_0a74:
													num4 = array5[num35].shopItemIndex;
													num5 = array4[num34].int_0 - array4[0].int_0;
													break;
												}
											}
											if (num4 >= 0)
											{
												GameMessageReader.ClearMessages(characterAccountConfig);
												int num36 = Class85.GetInventoryEntryCount(characterAccountConfig);
												GameProcessInteractionHelper.PurchaseShopItemByIndex(characterAccountConfig, num4, num5 + Form1.shopItemIndexOffset);
												int num37 = 0;
												while (num37 < 10)
												{
													num37++;
													Thread.Sleep(150);
													if (Class85.GetInventoryEntryCount(characterAccountConfig) != num36)
													{
														break;
													}
													string text4 = GameMessageReader.ReadMessages(characterAccountConfig);
													if (text4.IndexOf("kh«ng ®ñ") > 0)
													{
														num3 = 4;
														break;
													}
												}
												num3++;
												continue;
											}
											flag = true;
											GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "Khong tim thay Lenh bai Vi son dao trong Ky tran cac, ket thuc !");
											break;
										}
										flag = true;
										GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "Khong mua duoc lenh bai vi son dao, ket thuc.");
										break;
									}
									num2 = -1;
									break;
								}
								Form1.characterAccountConfig_1[num9].bool_55 = false;
								return;
							}
							flag = true;
							GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "Khong co mat do than bi hoac lenh bai vi son dao, ket thuc.");
							break;
						}
						continue;
					}
					if (num14 != 175)
					{
						continue;
					}
					uint num39 = CurrentCharacterMemoryHelper.GetCharacterMoneyValue(characterAccountConfig);
					if (num39 < 500)
					{
						GameProcessInteractionHelper.TransferStoredMoneyToCharacter(characterAccountConfig, 500 - num39);
						Thread.Sleep(300);
					}
					long long_ = 0L;
					uint[] array6 = new uint[2] { 54912u, 99968u };
					while (!CommonUtility.bool_0)
					{
						num9 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_0);
						if (!CommonUtility.bool_0 && num9 >= 0 && Form1.characterAccountConfig_1[num9].bool_25 && Form1.characterAccountConfig_1[num9].bool_55)
						{
							array3 = new uint[2]
							{
								WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
								WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
							};
							if (Class64.GetSquaredCoordinateDistance(array3, array6) < 120000L)
							{
								break;
							}
							if (CommonUtility.GetElapsedMilliseconds(long_) > 6000L)
							{
								CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array6);
								long_ = CommonUtility.GetCurrentTicks();
							}
							Thread.Sleep(600);
							continue;
						}
						return;
					}
					for (num21 = 0; num21 < 10; num21++)
					{
						array3 = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
						};
						if (Class64.GetSquaredCoordinateDistance(array3, array6) < 11500L)
						{
							break;
						}
						GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array6);
						Thread.Sleep(300);
					}
					uint num40 = FindTaySonEntityIndexOnMap175(characterAccountConfig);
					if (num40 == 0)
					{
						Class64.TryRecoverStuckMovement(characterAccountConfig);
						continue;
					}
					NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
					if (InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig))
					{
						InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig);
					}
					Thread.Sleep(100);
					int num41 = 0;
					bool flag4 = false;
					while (true)
					{
						InventoryItemHelper.PlaceHeldItemInInventory(characterAccountConfig);
						int num42 = num2;
						if (num42 <= 0)
						{
							num42 = num;
						}
						num28 = Class85.FindInventoryEntryIndexByItemRecordIndex(characterAccountConfig, (uint)num42);
						if (num28 != 0)
						{
							num20 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, characterAccountConfig.int_137);
							num25 = num20 + (uint)(num42 * (int)GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue);
							num29 = num25 + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue;
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num29, array2, array2.Length, ref int_1);
							text3 = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2).ToLower();
							uint num43 = WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue, characterAccountConfig.int_137);
							if ((num43 == 0 || num43 >= 100) && (text3.IndexOf(text2.ToLower()) >= 0 || text3.IndexOf(text.ToLower()) >= 0))
							{
								WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num13 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, BitConverter.GetBytes(num40), 4, ref int_1);
								while (NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig) < 0)
								{
									if (NpcDialogHelper.PopupMessageHelper.IsActive(characterAccountConfig))
									{
										NpcDialogHelper.PopupMessageHelper.Dismiss(characterAccountConfig);
									}
									num21++;
									Thread.Sleep(100);
									if (num21 <= 10)
									{
										continue;
									}
									goto IL_0f4f;
								}
								if (!(flag4 = !flag4))
								{
									NpcDialogHelper.SelectMenuOption(characterAccountConfig, 0);
								}
								else
								{
									NpcDialogHelper.SelectMatchingMenuOptions(characterAccountConfig, "Ta");
								}
								for (num21 = 0; num21 < 10; num21++)
								{
									Thread.Sleep(100 + NpcDialogHelper.int_0);
									if (InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig))
									{
										num21 = -1;
										break;
									}
								}
								if (num21 != -1)
								{
									string text5 = NpcDialogHelper.GetMenuText(characterAccountConfig);
									NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
									if (text5 != string.Empty && 0 < CommonUtility.FindSubstringIndex(text5, "cÊp 100 kh«ng"))
									{
										GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, text5);
										flag = true;
										break;
									}
									continue;
								}
								num19 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig.int_137) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
								num24 = num19 + num28 * 20;
								num26 = WindowsInteropHelper.ReadProcessUInt32(num24 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, characterAccountConfig.int_137);
								num27 = WindowsInteropHelper.ReadProcessUInt32(num24 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, characterAccountConfig.int_137);
								uint num44 = WindowsInteropHelper.ReadProcessUInt32(num19 + num28 * 20 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, characterAccountConfig.int_137);
								num21 = 0;
								GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig, num26, num27, num44, num26, num27, num44);
								while (true)
								{
									if ((int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, characterAccountConfig.int_137) <= 0)
									{
										Thread.Sleep(150);
										num21++;
										if (num21 > 10)
										{
											if (InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig))
											{
												InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig);
											}
											break;
										}
										continue;
									}
									num21 = 0;
									GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig, 0u, 0u, 12u, 0u, 0u, 12u);
									while (true)
									{
										if ((int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, characterAccountConfig.int_137) > 0)
										{
											Thread.Sleep(150);
											num21++;
											if (num21 > 10)
											{
												if (InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig))
												{
													InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig);
												}
												break;
											}
											continue;
										}
										GameProcessInteractionHelper.InvokeBoxAcceptAction(characterAccountConfig);
										Thread.Sleep(300);
										for (num21 = 0; num21 < 10; num21++)
										{
											int num45 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig.int_137);
											int num46 = (int)WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig.int_137);
											if (num45 != num14 || num46 > 0)
											{
												break;
											}
											Thread.Sleep(100);
										}
										break;
									}
									break;
								}
								break;
							}
							num2 = -1;
							break;
						}
						num2 = -1;
						break;
						IL_0f4f:
						num41++;
						if (num41 > 3)
						{
							Class64.TryRecoverStuckMovement(characterAccountConfig);
							break;
						}
					}
				}
				else
				{
					flag = true;
				}
				continue;
			}
			Form1.characterAccountConfig_1[num9].bool_55 = false;
			break;
			IL_042d:
			num = (int)num30;
			goto IL_0436;
			IL_0432:
			num2 = (int)num30;
			goto IL_0436;
			IL_0436:
			if (num2 <= 0)
			{
				continue;
			}
			num28 = Class85.FindInventoryEntryIndexByItemRecordIndex(characterAccountConfig, (uint)num2);
			num24 = num19 + num28 * 20;
			num26 = WindowsInteropHelper.ReadProcessUInt32(num24 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, characterAccountConfig.int_137);
			num27 = WindowsInteropHelper.ReadProcessUInt32(num24 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, characterAccountConfig.int_137);
			uint num47 = WindowsInteropHelper.ReadProcessUInt32(num19 + num28 * 20 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, characterAccountConfig.int_137);
			num21 = 0;
			if (num47 != 3)
			{
				uint[] array7 = Class85.FindFreeItemGridPosition(characterAccountConfig, 3u);
				if (array7 != null)
				{
					GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig, num26, num27, num47, array7[0], array7[1], 3u);
					for (num21 = 0; num21 < 150; num21++)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num19 + num28 * 20 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, array, 4, ref int_1);
						if (BitConverter.ToUInt32(array, 0) == 3)
						{
							break;
						}
						Thread.Sleep(10);
					}
				}
				num6++;
			}
			num47 = WindowsInteropHelper.ReadProcessUInt32(num19 + num28 * 20 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, characterAccountConfig.int_137);
			if (num47 != 3)
			{
				if (num6 >= 3)
				{
					GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "Khong the chuyen lenh bai vsd ra hanh trang, ket thuc!");
					flag = true;
				}
				else
				{
					Thread.Sleep(150);
					num2 = -1;
				}
				continue;
			}
			num26 = WindowsInteropHelper.ReadProcessUInt32(num24 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, characterAccountConfig.int_137);
			num27 = WindowsInteropHelper.ReadProcessUInt32(num24 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, characterAccountConfig.int_137);
			num21 = 0;
			while (num21 < 50)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_46 - 4, array, 1, ref int_1);
				if (array[0] == 0)
				{
					break;
				}
				num21++;
				Thread.Sleep(10);
			}
			GameProcessInteractionHelper.UseInventoryItemByRecordIndexAndPosition(characterAccountConfig, (uint)num2, (int)num26, (int)num27);
			num21 = 0;
			while (true)
			{
				if (num21 < 150)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num19 + num28 * 20 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, array, 4, ref int_1);
					if (BitConverter.ToUInt32(array, 0) != 3)
					{
						break;
					}
					int num48 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig.int_137);
					if (num48 != num14)
					{
						break;
					}
					Thread.Sleep(10);
					num21++;
					continue;
				}
				Thread.Sleep(300);
				break;
			}
		}
	}

	private static uint FindTaySonEntityIndexOnMap175(CharacterAccountConfig characterAccountConfig_0)
	{
		string text = "T©y s¬n";
		uint[] uint_ = new uint[2] { 54912u, 99968u };
		int int_ = 0;
		byte[] array = new byte[4];
		byte[] array2 = new byte[60];
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig_0.int_137);
		WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_0.int_137);
		int num5 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
		if (num5 == 175)
		{
			WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig_0.int_137);
			_ = new uint[2]
			{
				WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
				WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
			};
			uint uint_2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_2, array, 4, ref int_);
			int num6 = BitConverter.ToInt32(array, 0);
			if (num6 <= 1)
			{
				return 0u;
			}
			int num7 = 0;
			long num8 = 0L;
			uint num9 = 0u;
			uint[] array3 = new uint[2];
			for (uint num10 = 1u; num10 < 256; num10++)
			{
				if (num6 <= num7)
				{
					break;
				}
				uint num11 = num3 + num10 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array, 4, ref int_);
				if (array[0] == 0)
				{
					continue;
				}
				num7++;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, array, 4, ref int_);
				uint num12 = BitConverter.ToUInt32(array, 0);
				if (num12 == 3)
				{
					uint[] array4 = new uint[2];
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, array, 4, ref int_);
					array4[0] = BitConverter.ToUInt32(array, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, array, 4, ref int_);
					array4[1] = BitConverter.ToUInt32(array, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array2, array2.Length, ref int_);
					string text2 = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2);
					string string_ = text2.ToLower();
					if (0 <= CommonUtility.FindSubstringIndex(string_, text.ToLower()))
					{
						return num10;
					}
					long num13 = Class64.GetSquaredCoordinateDistance(uint_, array4);
					if (num13 < 40000L && (num9 == 0 || num13 < num8))
					{
						num8 = num13;
						array3[0] = array4[0];
						array3[1] = array4[1];
						num9 = num10;
					}
				}
			}
			return num9;
		}
		return 0u;
	}
}
