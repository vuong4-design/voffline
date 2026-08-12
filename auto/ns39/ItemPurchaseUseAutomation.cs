using System;
using System.Threading;
using ns1;
using ns100;
using ns11;
using ns13;
using ns18;
using ns23;
using ns28;
using ns3;
using ns35;
using ns41;
using ns42;
using ns44;
using ns52;
using ns53;
using ns61;
using ns71;
using ns81;
using ns83;
using ns85;
using ns88;

namespace ns39;

internal class ItemPurchaseUseAutomation
{
	public static int ActivePurchaseCharacterId = 0;

	public static int ActiveUseItemCharacterId = 0;

	public static int EnsureReturnScrollAvailable(CharacterAccountConfig characterAccountConfig_0)
	{
		try
		{
			return smethod_1(characterAccountConfig_0);
		}
		catch
		{
			GameProcessInteractionHelper.smethod_2(characterAccountConfig_0, GameProcessInteractionHelper.uint_32, 0, 4);
		}
		return 0;
	}

	private static int smethod_1(CharacterAccountConfig characterAccountConfig_0)
	{
		int int_ = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_32 * 4, array, 1, ref int_);
		if (array[0] <= 0)
		{
			int int_2 = characterAccountConfig_0.int_136;
			int num = -3;
			int num2 = 0;
			int num3 = -1;
			bool flag = false;
			bool flag2 = false;
			string string_ = "Thæ ®Þa phï|Håi thµnh phï|ÍÁµØ·û";
			string text = "Chñ tiÖm t¹p hãa|T¹p Hãa|t¹p hãa";
			string[] array2 = text.Split('|');
			int num4 = 0;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			long long_ = 0L;
			long long_2 = 0L;
			int num5 = -1;
			GStruct1[] array3 = null;
			while (true)
			{
				Thread.Sleep(300);
				int num6 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
				uint num11;
				int num24;
				uint[] array6;
				uint[] array4;
				if (!CommonUtility.bool_0 && num6 >= 0 && Form1.characterAccountConfig_1[num6].bool_25)
				{
					if (Form1.int_59[0] != 0 && Form1.int_59[1] != 0)
					{
						try
						{
							array[0] = 1;
							WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_32 * 4, array, 1, ref int_);
							characterAccountConfig_0 = Form1.characterAccountConfig_1[num6];
						}
						catch
						{
						}
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_);
						uint num7 = BitConverter.ToUInt32(array, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array, 4, ref int_);
						uint num8 = BitConverter.ToUInt32(array, 0);
						uint num9 = num8 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array, 4, ref int_);
						uint num10 = BitConverter.ToUInt32(array, 0);
						num11 = num10 + num9;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array, 4, ref int_);
						int num12 = BitConverter.ToInt32(array, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array, 4, ref int_);
						int num13 = BitConverter.ToInt32(array, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array, 4, ref int_);
						int num14 = BitConverter.ToInt32(array, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num11 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array, 4, ref int_);
						int num15 = BitConverter.ToInt32(array, 0);
						int num16 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
						if (num13 != 0 && num12 != 0 && num16 > 1)
						{
							array4 = new uint[2]
							{
								WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
								WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
							};
							if (array4[0] == 0 || array4[1] == 0)
							{
								continue;
							}
							int num17 = Class85.CountInventoryEntriesByName(characterAccountConfig_0, string_);
							if (num17 <= 0)
							{
								if (num12 != 10 && num12 != 21 && num15 <= 0)
								{
									int num18 = Class85.GetFreeItemGridCellCount(characterAccountConfig_0);
									if (num18 != 0)
									{
										int[] array5 = Class64.smethod_9(num14);
										if (array5 == null && MapTravelDataHelper.smethod_0(num14) == 0)
										{
											if (!flag5)
											{
												MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, 1, "am");
												Thread.Sleep(300);
												flag5 = true;
												continue;
											}
											num = -2;
											break;
										}
										int num19 = Form1.int_59[1];
										if (!flag2)
										{
											InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_0);
											flag2 = true;
										}
										if (num19 > num18)
										{
											num19 = num18;
										}
										if (num3 == num19 && 0 < num3)
										{
											InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_0);
											num2 = 0;
											num3 = 0;
											flag = false;
											continue;
										}
										int num20 = (int)CurrentCharacterMemoryHelper.GetCharacterMoneyValue(characterAccountConfig_0);
										if (num20 < 2500)
										{
											uint num21 = CurrentCharacterMemoryHelper.GetCharacterMoneyValue(characterAccountConfig_0, bool_0: true);
											if (num21 != 0)
											{
												if (Form1.int_67[0] > 0)
												{
													if (num21 > Form1.int_67[1] * 10000)
													{
														num21 = (uint)(Form1.int_67[1] * 10000);
													}
												}
												else if (num21 > 6000000)
												{
													num21 = 6000000u;
												}
												GameProcessInteractionHelper.smethod_37(characterAccountConfig_0, num21);
												Thread.Sleep(300);
											}
										}
										if (flag)
										{
											if (!InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig_0))
											{
												flag = false;
												num2 = 0;
												continue;
											}
											flag4 = true;
											num3 = num19;
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_32 * 4 + 1, array, 1, ref int_);
											if (array[0] == 0)
											{
												array[0] = 1;
												WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_32 * 4 + 1, array, 1, ref int_);
											}
											if (num5 < 0 && array3 == null)
											{
												array3 = ShopItemMemoryReader.ReadOpenShopItems(characterAccountConfig_0);
												if (array3 != null)
												{
													string text2 = "Thæ ®Þa phï".ToUpper();
													string text3 = "Thæ §Þa Phï".ToUpper();
													int num22 = -1;
													int num23 = 0;
													while (true)
													{
														if (num23 < array3.Length)
														{
															string text4 = array3[num23].string_0.ToUpper().Trim();
															if (0 <= CommonUtility.smethod_1(text4, text2) || 0 <= CommonUtility.smethod_1(text4, text3))
															{
																num22 = array3[num23].int_0;
															}
															if (!(text2 == text4) && !(text3 == text4))
															{
																num23++;
																continue;
															}
															num5 = array3[num23].int_0;
															break;
														}
														if (num5 < 0)
														{
															num5 = num22;
															if (num5 < 0)
															{
																num5 = 0;
															}
														}
														break;
													}
												}
												else
												{
													num5 = 0;
												}
											}
											for (int i = 0; i < num19; i++)
											{
												GameProcessInteractionHelper.smethod_41(characterAccountConfig_0, num5);
												Thread.Sleep(300);
												if (i % 3 != 0)
												{
													continue;
												}
												string string_2 = GameMessageReader.ReadMessages(characterAccountConfig_0);
												if ((CommonUtility.smethod_1(string_2, "ho¶ng trèng") <= 0 && CommonUtility.smethod_1(string_2, "tói kh«ng") <= 0) || Class85.GetFreeItemGridCellCount(characterAccountConfig_0) != 0)
												{
													if (CommonUtility.smethod_1(string_2, "µng kh") <= 0 && (CommonUtility.smethod_1(string_2, "iÒn") <= 0 || CommonUtility.smethod_1(string_2, "kh«ng") <= 0))
													{
														continue;
													}
													goto IL_0a90;
												}
												goto IL_0aa7;
											}
											continue;
										}
										num24 = -1;
										array6 = null;
										num24 = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig_0, text, 3);
										if (num24 <= 0)
										{
											int num25 = 0;
											while (num25 < array2.Length)
											{
												array6 = MapTravelDataHelper.FindNearestNamedMapPointCoordinates(array4, num14, array2[num25], bool_0: false);
												if (array6 == null)
												{
													num25++;
													continue;
												}
												goto IL_0569;
											}
											num = -3;
											break;
										}
										array6 = GameEntityMemoryHelper.GetEntityPositionByIndex(characterAccountConfig_0, num24);
										GameEntityMemoryHelper.GetEntityNameByIndex(characterAccountConfig_0, num24, 3);
										goto IL_0569;
									}
									num = 3;
									break;
								}
								num = 0;
								break;
							}
							num = (flag4 ? 1 : 2);
							break;
						}
						num = 0;
						break;
					}
					num = 2;
					break;
				}
				num = 0;
				break;
				IL_0ac4:
				num = 0;
				break;
				IL_0569:
				NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
				Thread.Sleep(100);
				if (array6 != null)
				{
					long num26 = Class64.GetSquaredCoordinateDistance(array4, array6);
					if (num26 > 22500L || num24 <= 0)
					{
						int int_3 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig_0.int_137);
						array4 = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
						};
						if (!flag6 || CommonUtility.GetElapsedMilliseconds(long_) >= 8000L)
						{
							flag6 = false;
							uint[,] array7 = MapRouteCatalog.FindRoute(int_3, array4, array6, "TAPHOA");
							if (array7 != null)
							{
								Class64.SwitchHorseStateIfNeeded(characterAccountConfig_0, bool_0: false);
								int_3 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig_0.int_137);
								int num27 = 0;
								while (num27 < 3)
								{
									array4 = new uint[2]
									{
										WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
										WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
									};
									if (Class64.smethod_22(characterAccountConfig_0, array7, array4, array6, int_3, bool_0: true) <= 0)
									{
										int num28 = (int)WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
										if (num28 <= 0)
										{
											Thread.Sleep(300);
											num27++;
											continue;
										}
										goto IL_0ac4;
									}
									flag6 = true;
									long_ = CommonUtility.GetCurrentTicks();
									break;
								}
							}
						}
						array4 = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
						};
						num26 = Class64.GetSquaredCoordinateDistance(array4, array6);
						if (num26 > 90000L)
						{
							Class64.SwitchHorseStateIfNeeded(characterAccountConfig_0, bool_0: false);
							if (CommonUtility.GetElapsedMilliseconds(long_2) >= 3000L)
							{
								long_2 = CommonUtility.GetCurrentTicks();
								if (CharacterMovementHelper.MoveToCoordinates(characterAccountConfig_0, array6) <= 0)
								{
									Class64.smethod_12(characterAccountConfig_0);
								}
							}
							continue;
						}
					}
					for (int j = 0; j < 10; j++)
					{
						GameProcessInteractionHelper.smethod_61(characterAccountConfig_0, array6);
						Thread.Sleep(300);
						array4 = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
						};
						num26 = Class64.GetSquaredCoordinateDistance(array4, array6);
						if (num26 < 11250L)
						{
							break;
						}
					}
					num2++;
					if (num2 > 10)
					{
						num2 = 0;
						Class64.smethod_12(characterAccountConfig_0);
						Class64.TryShowStatusMessageIfDue(characterAccountConfig_0, "Dang tim Chu tiem tap hoa !");
						continue;
					}
					if (num24 <= 0)
					{
						num24 = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig_0, text, 3);
						if (num24 <= 0)
						{
							Class64.TryShowStatusMessageIfDue(characterAccountConfig_0, "Dang tim Chu tiem tap hoa !");
							continue;
						}
					}
					if (!flag3)
					{
						CurrentCharacterMemoryHelper.SetCurrentTargetEntityIndex(characterAccountConfig_0, (uint)num24);
					}
					else
					{
						Class64.smethod_12(characterAccountConfig_0);
						CurrentCharacterMemoryHelper.SetCurrentTargetEntityIndex(characterAccountConfig_0, (uint)num24);
					}
					Thread.Sleep(800);
					if (NpcDialogHelper.PopupMessageHelper.IsActive(characterAccountConfig_0))
					{
						NpcDialogHelper.PopupMessageHelper.Dismiss(characterAccountConfig_0);
					}
					if (0 <= NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig_0))
					{
						flag = NpcDialogHelper.SelectMatchingMenuOptions(characterAccountConfig_0, "Giao dÞch") > 0;
					}
					num4++;
					if (num4 > 3)
					{
						num4 = 0;
						flag3 = !flag3;
					}
					Thread.Sleep(300);
					continue;
				}
				num = -3;
				break;
				IL_0a90:
				num = 1;
				GameProcessInteractionHelper.smethod_12(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_56);
				break;
				IL_0aa7:
				num = 1;
				GameProcessInteractionHelper.smethod_12(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_56);
				break;
			}
			GameProcessInteractionHelper.smethod_2(characterAccountConfig_0, GameProcessInteractionHelper.uint_32, 0, 4);
			if (flag2)
			{
				InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_0);
				if (Form1.int_61 > 0 && Form1.int_63 > 0)
				{
					Class85.RepairAndCollectLowDurabilityEquipment(characterAccountConfig_0, 0, 0, bool_3: false);
				}
			}
			return num;
		}
		return 0;
	}

	public static void RunPurchase()
	{
		int int_ = ActivePurchaseCharacterId;
		ActivePurchaseCharacterId = 0;
		bool flag = false;
		bool flag2 = false;
		while (true)
		{
			try
			{
				int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
				if (CommonUtility.bool_0 || flag2 || num < 0 || !Form1.characterAccountConfig_1[num].bool_25 || !Form1.characterAccountConfig_1[num].bool_51)
				{
					if (0 <= num)
					{
						Form1.characterAccountConfig_1[num].bool_47 = false;
						Form1.characterAccountConfig_1[num].bool_51 = false;
						GameProcessInteractionHelper.smethod_52(Form1.characterAccountConfig_1[num], "* MUA VAT PHAM KET THUC !");
					}
					break;
				}
				if (!flag)
				{
					if (Form1.characterAccountConfig_1[num].bool_47)
					{
						break;
					}
					Form1.characterAccountConfig_1[num].bool_47 = true;
					GameProcessInteractionHelper.smethod_52(Form1.characterAccountConfig_1[num], "* BAT DAU MUA VAT PHAM");
					flag = true;
				}
				RunPurchaseForCharacter(int_);
				flag2 = true;
			}
			catch
			{
			}
			Thread.Sleep(300);
		}
	}

	private static void RunPurchaseForCharacter(int int_2)
	{
		int int_3 = 0;
		byte[] array = new byte[4];
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		Random random = new Random();
		int num = 0;
		int num2 = -1;
		int num3 = -1;
		int num4 = 0;
		int num5 = 0;
		string text = null;
		string empty = string.Empty;
		bool flag = false;
		long long_ = 0L;
		bool flag2 = false;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		while (true)
		{
			Thread.Sleep(300);
			int num9 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
			if (CommonUtility.bool_0 || num9 < 0 || !Form1.characterAccountConfig_1[num9].bool_25 || !Form1.characterAccountConfig_1[num9].bool_51)
			{
				break;
			}
			characterAccountConfig = Form1.characterAccountConfig_1[num9];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_3);
			uint num10 = BitConverter.ToUInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num10 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array, 4, ref int_3);
			uint num11 = BitConverter.ToUInt32(array, 0) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array, 4, ref int_3);
			uint num12 = BitConverter.ToUInt32(array, 0);
			uint num13 = num12 + num11;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num13 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array, 4, ref int_3);
			int num14 = BitConverter.ToInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num13 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array, 4, ref int_3);
			int num15 = BitConverter.ToInt32(array, 0);
			int num16 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig);
			if (num14 == 0 || num16 <= 1 || num15 == 0 || num15 == 10 || num15 == 21)
			{
				continue;
			}
			uint[] array2 = new uint[2]
			{
				WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
				WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
			};
			if (array2[0] == 0 || array2[1] == 0)
			{
				continue;
			}
			if (Form1.string_25 != null && !(Form1.string_25 == string.Empty))
			{
				if (!(text != Form1.string_25) && num3 == Form1.int_77)
				{
					goto IL_0404;
				}
				InventoryItemHelper.PlaceHeldItemInInventory(characterAccountConfig);
				num2 = -1;
				num4 = 0;
				num5 = 0;
				num8 = 0;
				flag2 = Form1.int_79[0] > 0;
				num6 = Form1.int_79[1];
				num7 = Class85.CountInventoryEntriesByName(characterAccountConfig, Form1.string_25, bool_3: true);
				string text2 = Form1.string_25.ToLower().Trim();
				if (Form1.int_77 > 0)
				{
					Struct24[] array3 = GameInterfaceMemoryHelper.ReadShopTypeEntries(characterAccountConfig);
					if (array3 != null)
					{
						int num17 = -1;
						while (true)
						{
							num17++;
							if (array3.Length <= num17)
							{
								break;
							}
							GameProcessInteractionHelper.smethod_26(characterAccountConfig, array3[num17].string_0);
							Thread.Sleep(300);
							GameProcessInteractionHelper.smethod_27(characterAccountConfig);
							GStruct1[] array4 = ShopItemMemoryReader.ReadOpenShopItems(characterAccountConfig);
							if (array4 == null || array4.Length == 0)
							{
								continue;
							}
							int num18 = 0;
							while (num18 < array4.Length)
							{
								string text3 = array4[num18].string_0.ToLower().Trim();
								if (!(text2 == text3))
								{
									num18++;
									continue;
								}
								goto IL_0330;
							}
							continue;
							IL_0330:
							num2 = array4[num18].int_0;
							num4 = array4[num18].int_1;
							text = Form1.string_25;
							num3 = Form1.int_77;
							num = array3[num17].int_0 - array3[0].int_0;
							break;
						}
						num17 = 0;
						goto IL_0404;
					}
					empty = "H·y më KTC lªn, n¬i cã b\u00b8n vËt phÈm.";
				}
				else
				{
					GStruct1[] array5 = ShopItemMemoryReader.ReadOpenShopItems(characterAccountConfig);
					if (array5 != null && array5.Length != 0)
					{
						for (int i = 0; i < array5.Length; i++)
						{
							string text4 = array5[i].string_0.ToLower().Trim();
							if (text2 == text4)
							{
								num2 = array5[i].int_0;
								text = Form1.string_25;
								num3 = Form1.int_77;
								break;
							}
						}
						goto IL_0404;
					}
					empty = "Ch\u00ada më shop (t¹p hãa, ktc...)";
				}
			}
			else
			{
				empty = "Ch\u00ada cã tªn vËt phÈm cÇn mua";
			}
			goto IL_07b6;
			IL_0404:
			if (num2 >= 0)
			{
				if (Form1.int_77 > 0 && num4 == 0 && !Form1.bool_19)
				{
					if (num5 <= 0)
					{
						num5 = random.Next(100, 1000);
					}
					if (characterAccountConfig.int_132 != num5)
					{
						if (CommonUtility.GetElapsedMilliseconds(long_) > 15000L)
						{
							GameProcessInteractionHelper.smethod_52(characterAccountConfig, "MUA <color=yellow>" + Form1.string_25 + " <color>cÇn nhËp m· KTC lµ <color=yellow>" + num5 + "<color> vµo auto (phÝa trªn cña nót <color=green>Dõng<color>). L\u00adu ý: ®iÒu nµy cã thÓ g©y diss game nªn ph¶i c©n nh¾c kü.");
							long_ = CommonUtility.GetCurrentTicks();
						}
						empty = Form1.string_25 + " cÇn nhËp m· KTC lµ " + num5 + ". Xem H\u00adíng dÉn ë tÇng sè kh\u00b8c cña game.";
						goto IL_07b6;
					}
				}
				InventoryItemHelper.PlaceHeldItemInInventory(characterAccountConfig);
				int j = 0;
				uint num19 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_165.uint_0, characterAccountConfig.int_137);
				for (; j < 3; j++)
				{
					uint num20 = WindowsInteropHelper.ReadProcessUInt32(num19 + GameConfigurationManager.memorySignatureScanConfig_167.uint_0, characterAccountConfig.int_137);
					if (num20 != 0)
					{
						uint num21 = WindowsInteropHelper.ReadProcessUInt32(num20 + (uint)(j * 4), characterAccountConfig.int_137);
						if (num21 != 0 && WindowsInteropHelper.ReadProcessUInt32(num21, characterAccountConfig.int_137) != 0)
						{
							GameProcessInteractionHelper.smethod_12(characterAccountConfig.int_137, characterAccountConfig.uint_56);
							Thread.Sleep(100);
						}
					}
				}
				bool flag3 = false;
				int num22 = Class85.GetInventoryEntryCount(characterAccountConfig);
				for (int k = 1; k < 60; k++)
				{
					int num23 = Class85.GetInventoryEntryCount(characterAccountConfig);
					if (Form1.int_77 > 0)
					{
						GameProcessInteractionHelper.smethod_28(characterAccountConfig, num2, num + Form1.int_9);
					}
					else
					{
						GameProcessInteractionHelper.smethod_41(characterAccountConfig, num2);
					}
					j = 0;
					int num24;
					for (num24 = 30; j < num24; j++)
					{
						if (Class85.GetInventoryEntryCount(characterAccountConfig) == num23)
						{
							Thread.Sleep(10);
							continue;
						}
						num6--;
						num8 = 0;
						break;
					}
					if (flag2 && num6 <= 0)
					{
						InventoryItemHelper.PlaceHeldItemInInventory(characterAccountConfig);
						int num25 = Class85.CountInventoryEntriesByName(characterAccountConfig, Form1.string_25, bool_3: true);
						int num26 = num25 - num7;
						num6 = Form1.int_79[1] - num26;
						if (num6 <= 0)
						{
							flag3 = true;
							break;
						}
					}
					if (k % 7 != 0 && j < num24)
					{
						continue;
					}
					if (Class85.GetInventoryEntryCount(characterAccountConfig) == num22)
					{
						num8++;
						if (num8 > 3)
						{
							flag3 = true;
							break;
						}
					}
					num9 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
					if (CommonUtility.bool_0 || num9 < 0 || !Form1.characterAccountConfig_1[num9].bool_25 || !Form1.characterAccountConfig_1[num9].bool_51)
					{
						return;
					}
					uint num27 = WindowsInteropHelper.ReadProcessUInt32(num19 + GameConfigurationManager.memorySignatureScanConfig_167.uint_0, characterAccountConfig.int_137);
					if (num27 != 0)
					{
						uint num28 = WindowsInteropHelper.ReadProcessUInt32(num27, characterAccountConfig.int_137);
						if (num28 != 0 && WindowsInteropHelper.ReadProcessUInt32(num28, characterAccountConfig.int_137) != 0)
						{
							GameProcessInteractionHelper.smethod_12(characterAccountConfig.int_137, characterAccountConfig.uint_56);
							break;
						}
					}
				}
				if (Form1.int_78 > 0 && (!flag || Class85.GetInventoryEntryCount(characterAccountConfig) != num22))
				{
					j = 0;
					GameProcessInteractionHelper.smethod_2(characterAccountConfig, GameProcessInteractionHelper.uint_21, 3, 4);
					while (!CommonUtility.bool_0 && GameProcessInteractionHelper.smethod_3(characterAccountConfig, GameProcessInteractionHelper.uint_21, 4) == 3 && j < 3000)
					{
						Thread.Sleep(10);
						j++;
					}
				}
				if (!flag3)
				{
					flag = true;
					continue;
				}
				break;
			}
			empty = "Kh«ng thÊy <" + Form1.string_25 + "> trong shop";
			goto IL_07b6;
			IL_07b6:
			byte[] array6 = CommonUtility.smethod_47(empty);
			for (int l = 0; l < 10; l++)
			{
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num13 + GameConfigurationManager.memorySignatureScanConfig_251.uint_0, array6, array6.Length, ref int_3);
				Thread.Sleep(100);
			}
		}
	}

	public static void RunUseItem()
	{
		int int_ = ActiveUseItemCharacterId;
		ActiveUseItemCharacterId = 0;
		bool flag = false;
		bool flag2 = false;
		while (true)
		{
			try
			{
				int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
				if (CommonUtility.bool_0 || flag2 || num < 0 || !Form1.characterAccountConfig_1[num].bool_25 || !Form1.characterAccountConfig_1[num].bool_53)
				{
					if (0 <= num)
					{
						Form1.characterAccountConfig_1[num].bool_52 = false;
						Form1.characterAccountConfig_1[num].bool_53 = false;
						GameProcessInteractionHelper.smethod_52(Form1.characterAccountConfig_1[num], "* SU DUNG KET THUC !");
					}
					break;
				}
				if (!flag)
				{
					if (Form1.characterAccountConfig_1[num].bool_52)
					{
						break;
					}
					Form1.characterAccountConfig_1[num].bool_52 = true;
					GameProcessInteractionHelper.smethod_52(Form1.characterAccountConfig_1[num], "* SU DUNG ITEM");
					flag = true;
				}
				RunUseItemForCharacter(int_);
				flag2 = true;
			}
			catch
			{
			}
			Thread.Sleep(150);
		}
	}

	public static void RunUseItemForCharacter(int int_2)
	{
		int num = 0;
		uint num2 = 1u;
		int int_3 = 0;
		byte[] array = new byte[4];
		byte[] array2 = new byte[1];
		byte[] array3 = new byte[60];
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		int num3 = 0;
		int num4 = 0;
		int num5 = -1;
		int num6 = 0;
		while (true)
		{
			num3--;
			Thread.Sleep(40);
			if (num3 <= 0)
			{
				num4 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
				if (CommonUtility.bool_0 || num4 < 0)
				{
					break;
				}
				num3 = 8;
			}
			characterAccountConfig = Form1.characterAccountConfig_1[num4];
			if (!characterAccountConfig.bool_25 || !characterAccountConfig.bool_53)
			{
				break;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_105.uint_0, array, 4, ref int_3);
			uint num7 = BitConverter.ToUInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_3);
			uint num8 = BitConverter.ToUInt32(array, 0) + GameConfigurationManager.memorySignatureScanConfig_97.uint_0;
			string text = Form1.string_25.Trim().ToLower();
			int num9 = Class85.GetInventoryEntryCount(characterAccountConfig);
			if (num9 <= 0)
			{
				break;
			}
			if (Form1.int_79[0] > 0 && num6 <= 0)
			{
				int num10 = Class85.CountInventoryEntriesByName(characterAccountConfig, Form1.string_25, bool_3: true);
				if (num5 < 0)
				{
					num5 = num10;
				}
				int num11 = num5 - num10;
				if (num11 > Form1.int_79[1])
				{
					break;
				}
				num6 = Form1.int_79[1] - num11;
				if (num6 <= 0)
				{
					break;
				}
			}
			int num12 = 0;
			uint num13 = num2;
			uint num14;
			int num17;
			int num18;
			int num19;
			while (true)
			{
				if (num13 >= GameConfigurationManager.int_1 || num9 <= num12)
				{
					return;
				}
				num14 = num7 + num13 * GameConfigurationManager.memorySignatureScanConfig_106.uint_0;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_106.uint_0 - 4, array, 4, ref int_3);
				if (BitConverter.ToInt32(array, 0) == 0)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, array, 1, ref int_3);
					if (array[0] != 0)
					{
						uint num15 = Class85.FindInventoryEntryIndexByItemRecordIndex(characterAccountConfig, num13);
						if (num15 != 0)
						{
							num12++;
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_108.uint_0, array, 4, ref int_3);
							if (BitConverter.ToInt32(array, 0) > 0)
							{
								uint num16 = num8 + num15 * 20;
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num16 + GameConfigurationManager.memorySignatureScanConfig_100.uint_0 - 8, array, 4, ref int_3);
								num17 = BitConverter.ToInt32(array, 0);
								if (num17 == 3)
								{
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, array3, array3.Length, ref int_3);
									string text2 = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array3).Trim().ToLower();
									if (!(text2 != text))
									{
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num16 + GameConfigurationManager.memorySignatureScanConfig_100.uint_0 - 4, array, 4, ref int_3);
										num18 = BitConverter.ToInt32(array, 0);
										if (num18 >= 0)
										{
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num16 + GameConfigurationManager.memorySignatureScanConfig_100.uint_0, array, 4, ref int_3);
											num19 = BitConverter.ToInt32(array, 0);
											if (num19 >= 0)
											{
												break;
											}
										}
									}
								}
							}
						}
					}
				}
				num13++;
			}
			num = 0;
			while (num < 30)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_46 - 4, array2, 1, ref int_3);
				if (array2[0] == 0)
				{
					break;
				}
				num++;
				Thread.Sleep(1);
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_119.uint_0, array, 4, ref int_3);
			int num20 = BitConverter.ToInt32(array, 0);
			int num21 = Class85.GetInventoryEntryCount(characterAccountConfig);
			if (Form1.int_80 > 0)
			{
				InventoryItemHelper.ShowCollectionBox(characterAccountConfig);
			}
			GameProcessInteractionHelper.smethod_43(characterAccountConfig, num13, num18, num19, num17);
			for (num = 0; num < 8; num++)
			{
				if (num20 <= 0)
				{
					if (Class85.GetInventoryEntryCount(characterAccountConfig) != num21)
					{
						break;
					}
				}
				else
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_119.uint_0, array, 4, ref int_3);
					if (BitConverter.ToInt32(array, 0) != num20)
					{
						break;
					}
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_106.uint_0 - 4, array, 4, ref int_3);
				if (BitConverter.ToInt32(array, 0) != 0)
				{
					break;
				}
				Thread.Sleep(5);
			}
			if (Form1.int_80 > 0)
			{
				Thread.Sleep(100);
				uint num22 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig.int_137);
				uint num23 = WindowsInteropHelper.ReadProcessUInt32(num22 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig.int_137);
				uint num24 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig.int_137);
				uint num25 = num24 + num23 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
				byte[] array4 = null;
				bool flag = false;
				int num26 = 0;
				num = 0;
				while (num < 100)
				{
					num26 = InventoryItemHelper.GetCollectionBoxProgressValue(characterAccountConfig);
					array4 = CommonUtility.smethod_47(num26.ToString());
					WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_89.uint_0, array4, array4.Length, ref int_3);
					if (num26 <= 0)
					{
						num++;
						Thread.Sleep(10);
						continue;
					}
					flag = true;
					break;
				}
				num = 0;
				int num27 = -1;
				int num28 = 0;
				while (!CommonUtility.bool_0 && flag && num < 1600)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_106.uint_0 - 4, array, 4, ref int_3);
					if (BitConverter.ToInt32(array, 0) != 0)
					{
						break;
					}
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, array, 1, ref int_3);
					if (array[0] == 0)
					{
						break;
					}
					if (num20 > 0)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_119.uint_0, array, 4, ref int_3);
						if (BitConverter.ToInt32(array, 0) != num20)
						{
							break;
						}
					}
					num26 = InventoryItemHelper.GetCollectionBoxProgressValue(characterAccountConfig);
					num28 = ((num27 == num26) ? (num28 + 1) : 0);
					num27 = num26;
					flag = 0 < num26 && num28 < 30;
					array4 = CommonUtility.smethod_47((num26 + 11).ToString());
					WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_89.uint_0, array4, array4.Length, ref int_3);
					num++;
					Thread.Sleep(10);
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, array, 1, ref int_3);
				num20 = array[0];
			}
			num2 = num13 + Convert.ToByte(num20 <= 0);
			if (0 <= num6)
			{
				num6--;
			}
		}
	}
}
