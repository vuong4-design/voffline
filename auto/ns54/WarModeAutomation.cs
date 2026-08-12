using System;
using System.Threading;
using ns100;
using ns104;
using ns109;
using ns11;
using ns111;
using ns121;
using ns13;
using ns133;
using ns19;
using ns23;
using ns28;
using ns29;
using ns3;
using ns31;
using ns33;
using ns34;
using ns35;
using ns38;
using ns39;
using ns4;
using ns40;
using ns41;
using ns42;
using ns43;
using ns50;
using ns53;
using ns56;
using ns61;
using ns65;
using ns68;
using ns71;
using ns77;
using ns79;
using ns81;
using ns83;
using ns85;
using ns86;
using ns88;
using ns91;
using ns94;

namespace ns54;

internal class WarModeAutomation
{
	private static uint[,] uint_0 = new uint[13, 2]
	{
		{ 50433u, 104412u },
		{ 50027u, 103844u },
		{ 49690u, 103522u },
		{ 49325u, 103208u },
		{ 49854u, 102662u },
		{ 50190u, 102302u },
		{ 50527u, 102664u },
		{ 50894u, 102996u },
		{ 51373u, 103342u },
		{ 50797u, 103175u },
		{ 50557u, 102976u },
		{ 50157u, 103470u },
		{ 50308u, 104008u }
	};

	public static void Run(int int_0)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool bool_ = false;
		bool bool_2 = false;
		bool flag4 = false;
		bool flag5 = false;
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		int num5 = 0;
		int num6 = 0;
		long long_ = 0L;
		long long_2 = 0L;
		long long_3 = 0L;
		long long_4 = 0L;
		GStruct28 gstruct28_ = default(GStruct28);
		int int_1 = -1;
		uint[] uint_ = null;
		uint[] uint_2 = null;
		new Random();
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		uint num7 = 0u;
		uint uint_3 = 0u;
		uint[] array = null;
		int int_2 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		int num11 = 0;
		int int_3 = 0;
		long num12 = 0L;
		long num13 = 0L;
		long long_5 = 0L;
		long long_6 = 0L;
		int num14 = 0;
		int num15 = -1;
		int num16 = 0;
		int num17 = 0;
		int num18 = 0;
		int int_4 = 0;
		int int_5 = 0;
		bool flag6 = false;
		uint[] array2 = null;
		bool flag7 = false;
		bool flag8 = false;
		bool flag9 = false;
		bool flag10 = false;
		bool flag11 = false;
		bool flag12 = false;
		bool flag13 = false;
		int num19 = 0;
		int num20 = 0;
		int num21 = 0;
		int num22 = 0;
		int[] array3 = new int[5];
		int int_6 = 0;
		byte[] byte_ = new byte[4];
		byte[] array4 = new byte[4];
		int int_7 = -1;
		int num23 = 0;
		int num24 = 0;
		int num25 = 0;
		int num26 = -1;
		int num27 = -1;
		int num28 = 0;
		int num29 = 0;
		bool flag14 = false;
		int num30 = 0;
		int[] array5 = new int[10];
		for (int i = 0; i < array5.Length; i++)
		{
			array5[i] = 4;
		}
		int num31 = 0;
		while (true)
		{
			Thread.Sleep(100);
			num19 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_0);
			if (CommonUtility.bool_0 || num19 < 0 || Form1.int_24 != 0)
			{
				break;
			}
			characterAccountConfig = Form1.characterAccountConfig_1[num19];
			if (!characterAccountConfig.bool_25 || characterAccountConfig.int_20[0] > 0 || characterAccountConfig.int_133[0] > 0 || characterAccountConfig.bool_54 || characterAccountConfig.int_25 > 0 || characterAccountConfig.bool_55)
			{
				break;
			}
			if (!characterAccountConfig.bool_15 && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_48, 4) <= 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_42 * 4, array4, 1, ref int_6);
				if (array4[0] <= 0 && !characterAccountConfig.bool_0)
				{
					if (CharacterStateSyncCoordinator.bool_0 && characterAccountConfig.bool_26)
					{
						Form1.characterAccountConfig_1[num19].bool_26 = false;
						CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
					}
					if (characterAccountConfig.gstruct49_0.int_0 > 0 && !characterAccountConfig.bool_45 && EventFruitPickupAutomation.ActiveCharacterId <= 0)
					{
						EventFruitPickupAutomation.ActiveCharacterId = int_0;
						new Thread(EventFruitPickupAutomation.Run).Start();
						Thread.Sleep(300);
					}
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array4, 4, ref array5[0]);
					uint num32 = BitConverter.ToUInt32(array4, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num32 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array4, 4, ref array5[1]);
					uint num33 = BitConverter.ToUInt32(array4, 0);
					uint num34 = num33 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array4, 4, ref array5[2]);
					uint num35 = BitConverter.ToUInt32(array4, 0);
					uint num36 = num35 + num34;
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36, array4, 4, ref array5[3]);
					num7 = BitConverter.ToUInt32(array4, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array4, 4, ref array5[4]);
					int num37 = BitConverter.ToInt32(array4, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array4, 4, ref array5[5]);
					int num38 = BitConverter.ToInt32(array4, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array4, 4, ref array5[6]);
					int num39 = BitConverter.ToInt32(array4, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref array5[7]);
					int num40 = BitConverter.ToInt32(array4, 0);
					num30 = 7;
					int num41 = GameInterfaceMemoryHelper.smethod_12(characterAccountConfig);
					if ((characterAccountConfig.int_136 != ApplicationRuntimeCoordinator.characterAccountConfig_0.int_136 && characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0) || (num41 != 1 && num41 != 2))
					{
						if (num27 != characterAccountConfig.int_122)
						{
							num26 = -1;
							num27 = characterAccountConfig.int_122;
						}
						if (num22 <= 0)
						{
							array3[0] = 0;
							array3[1] = 0;
							array3[2] = 0;
							array3[3] = 0;
							array3[4] = 0;
						}
						num22 = 0;
						int num42 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig);
						if (num38 != 0 && num37 != 0 && num39 != 0 && num42 > 1)
						{
							if (num37 != 10 && num37 != 21)
							{
								int num43 = 0;
								while (true)
								{
									if (num43 <= num30)
									{
										if (array5[num43] == 0)
										{
											break;
										}
										num43++;
										continue;
									}
									uint[] array6 = new uint[2]
									{
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
									};
									if (array6[0] == 0 || array6[1] == 0)
									{
										break;
									}
									int num48;
									bool flag15;
									bool flag16;
									bool flag17;
									int num51;
									uint num66;
									uint[] uint_4;
									uint[] array11;
									uint[] array12;
									bool flag19;
									bool flag20;
									bool flag21;
									bool flag22;
									int num49;
									if (!flag9)
									{
										if (num == num39 && (num2 == CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 || Form1.int_25 <= 0))
										{
											if (num3 != num40)
											{
												num14 = 0;
												num16 = 0;
												int_2 = 0;
												array = null;
												flag11 = false;
												int num44 = 0;
												while (num40 == 0 && num44 < 30 && num40 != num3)
												{
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array4, 4, ref int_6);
													num32 = BitConverter.ToUInt32(array4, 0);
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num32 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array4, 4, ref int_6);
													num33 = BitConverter.ToUInt32(array4, 0);
													num34 = num33 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array4, 4, ref int_6);
													num35 = BitConverter.ToUInt32(array4, 0);
													num36 = num35 + num34;
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_6);
													num40 = BitConverter.ToInt32(array4, 0);
													Thread.Sleep(30);
													num44++;
												}
												num3 = num40;
												if (num40 <= 0)
												{
													break;
												}
											}
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_23 * 4, array4, 1, ref int_6);
											if (array4[0] > 0)
											{
												flag3 = false;
												array4[0] = 0;
												WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_23 * 4, array4, 1, ref int_6);
											}
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_33 * 4, array4, 1, ref int_6);
											int num45 = array4[0];
											if (num45 > 0)
											{
												bool value = false;
												if (num40 == 0)
												{
													int num46 = StorageChestAccessHelper.OpenStorageChest(characterAccountConfig, bool_0: true);
													value = num46 != 1;
												}
												array4[0] = Convert.ToByte(value);
												WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_33 * 4, array4, 1, ref int_6);
												break;
											}
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num32 + GameConfigurationManager.memorySignatureScanConfig_30.uint_0 + GameConfigurationManager.memorySignatureScanConfig_65.uint_0, array4, 4, ref int_6);
											int num47 = BitConverter.ToInt32(array4, 0);
											num48 = 600;
											if (characterAccountConfig.int_98 > 0)
											{
												num48 = characterAccountConfig.int_99;
											}
											if (characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0)
											{
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_43 * 4, array4, 4, ref int_6);
												characterAccountConfig.int_97 = BitConverter.ToInt32(array4, 0);
											}
											num49 = characterAccountConfig.int_97;
											if (characterAccountConfig.int_95 > 0 && characterAccountConfig.int_96 > 0)
											{
												num49 = characterAccountConfig.int_96;
											}
											if (num49 <= 0)
											{
												num49 = 500;
											}
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_44 * 4, array4, 1, ref int_6);
											int num50 = array4[0];
											if (num50 > 0 && num49 > characterAccountConfig.int_97 && characterAccountConfig.int_97 > 0)
											{
												num49 = characterAccountConfig.int_97;
											}
											num20 = Form1.int_27;
											if (characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0)
											{
												if (num49 <= 180 && num20 < Form1.int_57)
												{
													num20 = Form1.int_57;
												}
												if (characterAccountConfig.int_131[0] > 0 && Form1.int_31 > 0 && num20 > 180)
												{
													num20 = 180;
												}
												if (flag14)
												{
													if (num40 > 0)
													{
														num20 = characterAccountConfig.gstruct50_0.int_9;
													}
													flag14 = false;
												}
											}
											flag15 = 464 <= num39 && num39 <= 499;
											array2 = array6;
											flag6 = false;
											flag16 = false;
											flag17 = false;
											bool flag18 = false;
											num51 = 0;
											if (num39 == 998 || num39 == 997)
											{
												string text = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(characterAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_28.uint_0 + GameConfigurationManager.memorySignatureScanConfig_29.uint_0, characterAccountConfig.int_137, 20);
												flag18 = 0 <= text.IndexOf("Tr\u00adêng B¹ch");
											}
											if (!flag18 && characterAccountConfig.int_105 > 0 && (num39 == 333 || num39 == 998) && CommonUtility.GetElapsedMilliseconds(long_6) > 6000L)
											{
												if (num14 <= 0)
												{
													int[] array7 = MedicineRestockAutomation.GetConfiguredMedicineCounts(characterAccountConfig);
													num14 = ((array7 != null && (array7[0] <= 0 || array7[1] <= 0 || array7[2] <= 0)) ? 1 : 0);
												}
												if (num14 > 0)
												{
													uint[] array8 = null;
													num4 = -1;
													array6 = new uint[2]
													{
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
													};
													if (0 <= Form1.int_4 && Form1.int_4 < Form1.string_7.GetLength(0) && (num39 == 998 || 0 <= Form1.string_7[Form1.int_4, 0].IndexOf("jxbisu")))
													{
														int num52 = MapRouteCatalog.FindRouteEntryIndex(num39);
														if (0 <= num52)
														{
															array8 = MapRouteCatalog.FindNearestNamedWaypoint(MapRouteCatalog.RouteEntries[num52], array6, "HIEUTHUOC");
														}
													}
													if (array8 == null)
													{
														array8 = MapTravelDataHelper.FindNearestNamedMapPointCoordinates(array6, num39, "HIEUTHUOC");
													}
													if (array8 != null)
													{
														if (num21 > 0)
														{
															WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
														}
														num21 = 0;
														long num53 = Class64.GetSquaredCoordinateDistance(array6, array8);
														if (num53 > 160000L)
														{
															uint[,] array9 = MapRouteCatalog.FindRoute(num39, array6, array8);
															if (array9 != null)
															{
																Class64.smethod_22(characterAccountConfig, array9, array6, array8, num39, bool_0: false, 8000, bool_1: true);
																break;
															}
														}
													}
												}
												num14 = 0;
												long_6 = CommonUtility.GetCurrentTicks();
											}
											if (characterAccountConfig.bool_1 && (flag3 || num40 > 0) && num15 != characterAccountConfig.int_0)
											{
												if (FormChayBoss.smethod_2(characterAccountConfig) > 0)
												{
													num15 = characterAccountConfig.int_0;
													if (flag3)
													{
														flag3 = num40 <= 0;
													}
													if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 == characterAccountConfig.int_136)
													{
														CharacterStateSyncCoordinator.characterSyncSnapshot_0.bool_1 = false;
													}
												}
												array4[0] = 0;
												WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_33 * 4, array4, 1, ref int_6);
												break;
											}
											if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 == characterAccountConfig.int_136)
											{
												CharacterStateSyncCoordinator.characterSyncSnapshot_0.bool_1 = false;
											}
											if (num40 <= 0)
											{
												Thread.Sleep(100);
												if (characterAccountConfig.int_104[0] > 0 && characterAccountConfig.int_104[1] <= num47)
												{
													int j = 0;
													byte[] array10 = CommonUtility.ConvertStringToSingleByteArray("Kh«ng thÓ tiÕp tôc v× PK qu\u00b8 cao (vao Hau can -> phuc hoi, un-check pk cao).");
													for (; j < 6; j++)
													{
														WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_251.uint_0, array10, array10.Length, ref int_6);
														Thread.Sleep(100);
													}
													break;
												}
												int num54 = Class85.GetInventoryEntryCount(characterAccountConfig);
												if (characterAccountConfig.int_133[0] <= 0 && (!flag3 || num4 < 0 || num4 != num54))
												{
													if (TongKimBattlefieldHelper.FindBattlefieldMapGroupPosition(num39) != null && CommonUtility.GetElapsedMilliseconds(long_5) > 8000L)
													{
														string text2 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(characterAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_28.uint_0 + GameConfigurationManager.memorySignatureScanConfig_29.uint_0, characterAccountConfig.int_137, 20);
														if ((num39 != 989 || 0 > text2.IndexOf("Ph\u00adîng Ho")) && (num39 != 977 || (0 > text2.IndexOf("Cæ L") && 0 > text2.IndexOf("Hßa B"))))
														{
															string text3 = "§ang ë b¶n ®å Tèng Kim, h·y chuyÓn auto tõ WAR -> TK ®Ó tèi \u00adu h¬n.";
															GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "<bclr=blue><color=green>" + text3);
															if (characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.string_0 != null && CharacterStateSyncCoordinator.characterSyncSnapshot_0.string_0 != string.Empty)
															{
																GameProcessInteractionHelper.SendPrivatePlayerMessage(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.string_0, text3);
															}
															long_5 = CommonUtility.GetCurrentTicks();
														}
													}
													if (!Form1.bool_18)
													{
														if (ItemPurchaseUseAutomation.EnsureReturnScrollAvailable(characterAccountConfig) == 0)
														{
															Thread.Sleep(300);
															break;
														}
														int num55 = MedicineRestockAutomation.RestockConfiguredMedicines(characterAccountConfig, Form1.int_105 <= 0);
														if (num55 < 0 && !flag5)
														{
															Thread.Sleep(300);
															flag5 = num55 < 0;
															break;
														}
													}
													flag3 = true;
													flag5 = false;
													flag10 = false;
													flag11 = false;
													num31 = 0;
													num4 = Class85.GetInventoryEntryCount(characterAccountConfig);
													break;
												}
												if (characterAccountConfig.int_65 > 0 && !flag11)
												{
													uint num56 = num32 + GameConfigurationManager.memorySignatureScanConfig_12.uint_0 + GameConfigurationManager.memorySignatureScanConfig_75.uint_0;
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num56 + GameConfigurationManager.memorySignatureScanConfig_73.uint_0, array4, 4, ref int_6);
													uint num57 = BitConverter.ToUInt32(array4, 0);
													if (characterAccountConfig.int_66 != num57)
													{
														Class64.smethod_3(characterAccountConfig, ref bool_2);
													}
													flag11 = true;
												}
												if (flag7)
												{
													long num58 = WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_45.uint_0, characterAccountConfig.int_137);
													long num59 = WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_47.uint_0, characterAccountConfig.int_137) + 1;
													long num60 = WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_47.uint_0 + 4, characterAccountConfig.int_137) + 1;
													long num61 = WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_46.uint_0, characterAccountConfig.int_137);
													long num62 = WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_48.uint_0, characterAccountConfig.int_137) + 1;
													long num63 = WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_48.uint_0 + 4, characterAccountConfig.int_137) + 1;
													if (num60 > num59 && num60 < 150000L)
													{
														num59 = num60;
													}
													if (num63 > num62 && num63 < 150000L)
													{
														num62 = num63;
													}
													double num64 = num58 * 100L / num59;
													double num65 = num61 * 100L / num62;
													if (((num59 > 100L && characterAccountConfig.int_106[0] > 0 && characterAccountConfig.int_106[1] > 0 && num58 <= characterAccountConfig.int_106[1]) || (characterAccountConfig.int_109[0] > 0 && characterAccountConfig.int_109[1] > 0 && num64 <= (double)characterAccountConfig.int_109[1])) && Class32.UseInventoryItemsByGenre(characterAccountConfig, 0) > 0)
													{
														Thread.Sleep(300);
													}
													if (((num62 > 50L && characterAccountConfig.int_107[0] > 0 && characterAccountConfig.int_107[1] > 0 && num61 <= characterAccountConfig.int_107[1]) || (characterAccountConfig.int_111[0] > 0 && characterAccountConfig.int_111[1] > 0 && num65 <= (double)characterAccountConfig.int_111[1])) && Class32.UseInventoryItemsByGenre(characterAccountConfig, 1) > 0)
													{
														Thread.Sleep(300);
													}
													num4 = Class85.GetInventoryEntryCount(characterAccountConfig);
													flag7 = false;
												}
											}
											else
											{
												flag = false;
												flag3 = false;
												flag7 = true;
												if (((Form1.int_121 > 0 && !ChienLongDongNavigationHelper.IsChienLongDongMap(num39)) || (characterAccountConfig.int_104[0] > 0 && characterAccountConfig.int_104[1] <= num47)) && !Class64.smethod_14(characterAccountConfig) && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
												{
													MapNavigationHelper.NavigateToDestination(characterAccountConfig, 162, "b¾c");
												}
											}
											num66 = 0u;
											uint_4 = null;
											array11 = new uint[2];
											array12 = new uint[2];
											flag19 = false;
											flag20 = false;
											flag21 = false;
											num39 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
											num40 = (int)WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig.int_137);
											flag22 = AuxiliaryMachineManager.bool_7 || (AuxiliaryMachineManager.bool_6 && TongKimBattlefieldHelper.FindBattlefieldMapGroupPosition(num39) != null);
											if (Form1.int_120 > 0 && num40 <= 0)
											{
												if (flag22 && (characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 || CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 == 0) && num40 == 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 <= 0)
												{
													if (CommonUtility.GetElapsedMilliseconds(long_5) > 10000L)
													{
														GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, CommonUtility.DecodeLengthShiftedString(CommonUtility.string_0));
														long_5 = CommonUtility.GetCurrentTicks();
													}
												}
												else
												{
													if (FormTapKet.gstruct64_0 == null || FormTapKet.gstruct64_0.Length == 0)
													{
														if (!flag13)
														{
															flag13 = true;
															FormTapKet.smethod_2();
														}
														if (FormTapKet.gstruct64_0 == null || FormTapKet.gstruct64_0.Length == 0)
														{
															goto IL_138c;
														}
													}
													if (!bool_2 && characterAccountConfig.string_15 != null && characterAccountConfig.string_15 != string.Empty)
													{
														uint num67 = CommonUtility.ParseUInt32OrZero(characterAccountConfig.string_15);
														if (num67 != 0)
														{
															GameProcessInteractionHelper.UnlockInventoryBoxWithPasswordCode(characterAccountConfig, num67);
															Thread.Sleep(150);
															bool_2 = true;
														}
													}
													if (CommonUtility.GetElapsedMilliseconds(long_5) > 8000L)
													{
														GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "Ra diem tap ket.");
														long_5 = CommonUtility.GetCurrentTicks();
													}
													num43 = 0;
													while (num43 < FormTapKet.gstruct64_0.Length)
													{
														if (num39 != FormTapKet.gstruct64_0[num43].int_1 && FormTapKet.gstruct64_0[num43].int_0 <= 0)
														{
															num43++;
															continue;
														}
														goto IL_1349;
													}
												}
												goto IL_138c;
											}
											goto IL_138f;
										}
										num16 = 0;
										int_2 = 0;
										num23 = 0;
										num24 = 0;
										array = null;
										bool_2 = false;
										flag4 = false;
										flag = false;
										flag10 = false;
										flag11 = false;
										int num68 = 0;
										int num69 = 0;
										while (true)
										{
											if (num != num39 && num69 < 15)
											{
												num69++;
												Thread.Sleep(100);
												num42 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig);
												WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
												num21 = 0;
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array4, 4, ref int_6);
												num32 = BitConverter.ToUInt32(array4, 0);
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num32 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array4, 4, ref int_6);
												if (int_6 != 4)
												{
													break;
												}
												num33 = BitConverter.ToUInt32(array4, 0);
												num34 = num33 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array4, 4, ref int_6);
												if (int_6 != 4)
												{
													break;
												}
												num35 = BitConverter.ToUInt32(array4, 0);
												num36 = num35 + num34;
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array4, 4, ref int_6);
												num38 = BitConverter.ToInt32(array4, 0);
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array4, 4, ref int_6);
												num39 = BitConverter.ToInt32(array4, 0);
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_6);
												num40 = BitConverter.ToInt32(array4, 0);
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array4, 4, ref int_6);
												num37 = BitConverter.ToInt32(array4, 0);
												if (num42 <= 1 || num38 <= 0 || num39 <= 0 || num37 <= 0)
												{
													num68 = 0;
													continue;
												}
												if (num40 <= 0 && num68 <= 3)
												{
													num68++;
													continue;
												}
											}
											if (flag2)
											{
												flag2 = num3 == num40 && num3 <= 0;
											}
											if (num40 == 0 && num3 > 0)
											{
												flag3 = false;
											}
											num = num39;
											num2 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4;
											flag12 = false;
											num31 = 0;
											break;
										}
										break;
									}
									Thread.Sleep(300);
									flag9 = false;
									bool_ = false;
									flag12 = false;
									num31 = 0;
									break;
									IL_51df:
									if (flag17)
									{
										if (!CharacterStateSyncCoordinator.smethod_7(characterAccountConfig, ref int_7) && GameInterfaceMemoryHelper.smethod_12(characterAccountConfig) != 1)
										{
											num39 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
											array6 = new uint[2]
											{
												WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
												WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
											};
											uint_4 = array6;
											if (flag19 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == num39 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4 != null)
											{
												uint_4 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
												num48 += num20;
											}
											num66 = 0u;
											if (Form1.int_37 > 0 && (flag20 || flag19))
											{
												if (!flag20)
												{
													if (flag19 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == num39 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_3 != num7)
													{
														num66 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_3;
													}
												}
												else if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_4 == num39 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_3 != num7)
												{
													num66 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_3;
												}
												if (num66 == 0 && Form1.int_38 <= 0)
												{
													goto IL_671c;
												}
											}
											goto IL_535d;
										}
										Thread.Sleep(100);
										num21 = 0;
									}
									goto IL_671c;
									IL_138f:
									array6 = new uint[2]
									{
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
									};
									bool flag23 = characterAccountConfig.int_125 != null && characterAccountConfig.int_125.Length > 4 && (Form1.int_81 > 0 || characterAccountConfig.int_125[0] > 0) && characterAccountConfig.int_125[2] > 0 && characterAccountConfig.int_125[3] > 0 && characterAccountConfig.int_125[4] > 0;
									bool flag24 = (Form1.int_10 > 0 || Form1.int_11 > 0) && (Form1.int_81 > 0 || characterAccountConfig.int_125[0] > 0) && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11 != null && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11[0] > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11[1] > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11[2] > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11[3] > 0;
									bool flag25;
									if ((flag25 = flag23 || flag24) && (!flag10 || Form1.int_82 <= 0) && (!AuxiliaryMachineManager.bool_1 || (Form1.int_11 <= 0 && Form1.int_10 <= 0)))
									{
										if (!flag22)
										{
											int num70 = characterAccountConfig.int_125[2];
											uint[] array13 = new uint[2]
											{
												(uint)characterAccountConfig.int_125[3],
												(uint)characterAccountConfig.int_125[4]
											};
											if (flag24)
											{
												num70 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11[1];
												array13[0] = (uint)CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11[2];
												array13[1] = (uint)CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11[3];
											}
											if (num39 == num70)
											{
												bool_ = true;
												num18 = 0;
												num17 = 0;
												for (num25 = 0; num25 < GameConfigurationManager.int_0; num25++)
												{
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_6 * 4, array4, 1, ref int_6);
													if (array4[0] == 0)
													{
														break;
													}
													Thread.Sleep(1);
												}
												long num71 = Class64.GetSquaredCoordinateDistance(array6, array13);
												if (num71 < 48400L)
												{
													num8 = 0;
													flag10 = true;
													goto IL_4aff;
												}
												if (num21 > 0)
												{
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
												}
												num21 = 0;
												if (num71 < 900000L && num8 < 5)
												{
													CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
													GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array13);
													Thread.Sleep(150);
													num8++;
													break;
												}
												Class64.SwitchHorseStateIfNeeded(characterAccountConfig, bool_0: false);
												if (CommonUtility.GetElapsedMilliseconds(long_3) > 4000L)
												{
													CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array13);
													long_3 = CommonUtility.GetCurrentTicks();
												}
												break;
											}
											if (Form1.int_90 > 0 || GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) == 0)
											{
												if (bool_)
												{
													bool_ = false;
													if (InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, "®iÓm c", array13) > 0)
													{
														Class64.smethod_11(characterAccountConfig);
													}
													break;
												}
												if (!flag2)
												{
													flag2 = true;
													InterMapTravelHelper.UseTravelMenuForDestinationMap(characterAccountConfig, num70);
													break;
												}
											}
											if (num40 == 0 && TongKimBattlefieldHelper.FindBattlefieldMapGroupPosition(num39) != null)
											{
												goto IL_324b;
											}
											if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
											{
												int num72 = num70;
												int num73 = MapNavigationHelper.FindNavigationEntryIndex(num72);
												if (num73 < 0 && num70 == 76)
												{
													num72 = 75;
													num73 = MapNavigationHelper.FindNavigationEntryIndex(75);
												}
												if (0 <= num73 && MapNavigationHelper.NavigateToDestination(characterAccountConfig, num72))
												{
													Thread.Sleep(300);
													Class64.smethod_11(characterAccountConfig);
													Thread.Sleep(600);
													int num74 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
													if (num74 != num39)
													{
														break;
													}
												}
												else if (num39 != 103 && num39 != 114 && num39 != 110 && (num70 == 110 || num70 == 114) && MapNavigationHelper.NavigateToDestination(characterAccountConfig, 103))
												{
													Thread.Sleep(300);
													Class64.smethod_11(characterAccountConfig);
													Thread.Sleep(600);
													int num75 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
													if (num75 != num39)
													{
														break;
													}
												}
												int num76 = Class64.smethod_7(num39, num70, ref gstruct28_);
												if (num76 == 0)
												{
													goto IL_43fe;
												}
												if (flag2 && num76 > 0 && num17 < 5)
												{
													uint[] uint_5 = array13;
													if (Class64.smethod_7(num76, num70, ref gstruct28_) == 0 && gstruct28_.uint_0 != null)
													{
														uint_5 = new uint[2]
														{
															gstruct28_.uint_0[0, 0],
															gstruct28_.uint_0[0, 1]
														};
													}
													num17++;
													CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
													MapNavigationHelper.NavigateToDestination(characterAccountConfig, num76, null, uint_5);
													break;
												}
											}
											if (num18 < 3)
											{
												int[] array14 = Class64.smethod_9(num39);
												if (array14 != null && InterMapTravelHelper.UseTravelMenuForDestinationMap(characterAccountConfig, num70) > 0)
												{
													num18++;
													break;
												}
											}
											int num77 = Class64.smethod_7(num39, num70, ref gstruct28_);
											if (num77 != 0)
											{
												if (flag2 && num77 > 0 && num17 < 5)
												{
													uint[] uint_6 = array13;
													if (Class64.smethod_7(num77, num70, ref gstruct28_) == 0 && gstruct28_.uint_0 != null)
													{
														uint_6 = new uint[2]
														{
															gstruct28_.uint_0[0, 0],
															gstruct28_.uint_0[0, 1]
														};
													}
													num17++;
													CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
													MapNavigationHelper.NavigateToDestination(characterAccountConfig, num77, null, uint_6);
												}
												else if (CommonUtility.GetElapsedMilliseconds(long_3) > 15000L)
												{
													GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "<color=yellow>Khong the den toa do dinh san...");
													long_3 = CommonUtility.GetCurrentTicks();
												}
												break;
											}
											goto IL_43fe;
										}
										flag25 = false;
										flag24 = false;
										flag23 = false;
										if (CommonUtility.GetElapsedMilliseconds(long_5) > 10000L)
										{
											GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, CommonUtility.DecodeLengthShiftedString(CommonUtility.string_0));
											long_5 = CommonUtility.GetCurrentTicks();
										}
									}
									if (Form1.int_121 > 0 && !ChienLongDongNavigationHelper.IsChienLongDongMap(num39))
									{
										int[] array15 = Class64.smethod_9(num39);
										if (array15 != null && array15[1] == 0)
										{
											ChienLongDongNavigationHelper.NavigateChienLongDong(characterAccountConfig);
											break;
										}
										if (num16 < 5 && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
										{
											num16++;
											CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
											if (MapNavigationHelper.NavigateToDestination(characterAccountConfig, 176, "b¾c"))
											{
												array4[0] = 1;
												WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_33 * 4, array4, 1, ref int_6);
												break;
											}
										}
										if (num40 > 0)
										{
											Class64.smethod_14(characterAccountConfig);
										}
										else if (InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig, 176) > 0)
										{
											array4[0] = 1;
											WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_33 * 4, array4, 1, ref int_6);
										}
										break;
									}
									flag21 = false;
									bool flag31;
									int num86;
									long num81;
									if ((flag19 = (!characterAccountConfig.bool_1 || characterAccountConfig.int_0 < 0 || FormChayBoss.string_2.GetLength(0) <= characterAccountConfig.int_0 || FormChayBoss.string_2[characterAccountConfig.int_0, 0][0] == '.' || (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == num39 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 > 0 && !CharacterStateSyncCoordinator.characterSyncSnapshot_0.bool_1)) && Form1.int_25 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 != characterAccountConfig.int_136 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_6 > 0 && CommonUtility.IsNonZeroCoordinatePair(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4) && (Form1.int_26 > 0 || CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 > 0)) && characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0)
									{
										if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == num39)
										{
											if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4 != null)
											{
												if (num40 > 0)
												{
													bool_ = true;
													num23 = 0;
												}
												num5 = 0;
												if (Form1.int_26 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 <= 0 && num40 <= 0 && CommonUtility.FindSubstringIndex(CharacterStateSyncCoordinator.characterSyncSnapshot_0.string_1, "m b\u00b8o d") > 0)
												{
													long num78 = 0L;
													long num79 = 0L;
													array6 = new uint[2]
													{
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
													};
													uint[] array16 = new uint[2] { 49213u, 101084u };
													uint[] array17 = new uint[2] { 50192u, 98662u };
													uint[] uint_7 = new uint[2] { 49318u, 101744u };
													uint[] uint_8 = new uint[2] { 50579u, 98932u };
													num78 = Class64.GetSquaredCoordinateDistance(array6, uint_8);
													num79 = Class64.GetSquaredCoordinateDistance(array6, uint_7);
													bool flag26 = num79 < num78;
													num78 = Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, uint_8);
													num79 = Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, uint_7);
													if (num79 < num78 != flag26)
													{
														uint[] array18 = array17;
														if (flag26)
														{
															array18 = array16;
														}
														long num80 = Class64.GetSquaredCoordinateDistance(array6, array18);
														if (num80 <= 360000L)
														{
															for (int k = 0; k < 10; k++)
															{
																array6 = new uint[2]
																{
																	WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
																	WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
																};
																num80 = Class64.GetSquaredCoordinateDistance(array6, array18);
																if (num80 < 22500L)
																{
																	break;
																}
																GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array18);
																Thread.Sleep(300);
															}
															InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, "m b\u00b8o danh|hi danh|(T)|(K)");
														}
														else if (CommonUtility.GetElapsedMilliseconds(long_3) > 3000L)
														{
															CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array18);
															long_3 = CommonUtility.GetCurrentTicks();
														}
														break;
													}
												}
												num81 = Class64.GetSquaredCoordinateDistance(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
												if (characterAccountConfig.int_130[0] > 0 && characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 && num40 == CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 && num40 > 0)
												{
													int num82 = characterAccountConfig.int_130[1] + Form1.int_27;
													if (num81 <= num82 * num82 && CircularMovementHelper.MoveToNextPointAroundCenter(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, characterAccountConfig.int_130[1]) > 0)
													{
														goto IL_678f;
													}
												}
												if (flag8 || num81 > num20 * num20)
												{
													goto IL_2225;
												}
												CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
												int num83 = num8;
												num8 = 0;
												num23 = 0;
												num24 = 0;
												int_2 = 0;
												num31 = 0;
												if (num40 > 0 && !characterAccountConfig.bool_22 && characterAccountConfig.int_93 == 1 && Form1.int_109 > 0 && (Form1.int_35 > 0 || Form1.int_34 > 0 || Form1.int_36 > 0) && WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig.int_137) != 0)
												{
													Class64.ApplyConfiguredHorseSwitching(characterAccountConfig);
												}
												if (num13 <= 0L || CommonUtility.GetElapsedMilliseconds(num13) >= 1500L)
												{
													uint[] array19 = new uint[2]
													{
														array6[0],
														array6[1]
													};
													if (CharacterStateSyncCoordinator.smethod_5(num7, ref array6, ref uint_3) > 0)
													{
														long num84 = Class64.GetSquaredCoordinateDistance(array19, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
														long num85 = Class64.GetSquaredCoordinateDistance(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
														if (num85 <= num20 * num20)
														{
															num13 = CommonUtility.GetCurrentTicks();
															if (num21 > 0)
															{
																WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
															}
															num21 = 0;
															CharacterStateSyncCoordinator.smethod_6(characterAccountConfig, array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, num84 <= 5625L);
															goto IL_671c;
														}
														if (num83 > 0)
														{
															uint[] uint_9 = Class64.GetCoordinateOffsetAlongLine(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, -100);
															GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, uint_9);
															Thread.Sleep(120);
														}
														goto IL_2225;
													}
													num13 = 0L;
													if (num21 == 0 && Class64.GetSquaredCoordinateDistance(array19, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4) > Form1.int_27 * Form1.int_27)
													{
														num11++;
														if (num11 > 3)
														{
															GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
															Thread.Sleep(150);
															num11 = 0;
														}
													}
													if (Form1.int_31 > 0 && num40 > 0 && characterAccountConfig.int_131[0] > 0 && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_31, 4) == 0)
													{
														GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig, GameProcessInteractionHelper.uint_31, 1, 4);
													}
												}
											}
											goto IL_33f1;
										}
										if (num39 != Map878NavigationHelper.MapId && (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == Map878NavigationHelper.MapId || ((Form1.int_10 > 0 || Form1.int_11 > 0) && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_4 == Map878NavigationHelper.MapId)))
										{
											Map878NavigationHelper.EnterMap878(characterAccountConfig);
											Thread.Sleep(300);
											break;
										}
										if (num39 == Map878NavigationHelper.MapId)
										{
											bool flag27;
											if (!(flag27 = Form1.int_26 > 0))
											{
												bool flag28 = (Form1.int_10 > 0 || Form1.int_11 > 0) && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_4 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_4 != Map878NavigationHelper.MapId && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_3 > 0;
												bool flag29 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 != Map878NavigationHelper.MapId && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 > 0;
												flag27 = flag28 || flag29;
											}
											if (flag27)
											{
												Map878NavigationHelper.ExitMap878(characterAccountConfig);
												Thread.Sleep(300);
												break;
											}
										}
										if (Form1.int_121 <= 0)
										{
											for (int l = 0; l < InterMapTravelHelper.struct21_0.GetLength(0); l++)
											{
												if (num39 == InterMapTravelHelper.struct21_0[l].int_0)
												{
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
													if (InterMapTravelHelper.UseCurrentMapTransportNpc(characterAccountConfig) > 0)
													{
														goto end_IL_04fe;
													}
												}
											}
											num86 = 0;
											if (num39 == 336 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == 341)
											{
												long num87 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_0, array6);
												long num88 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_1, array6);
												if (num87 > num88)
												{
													flag21 = true;
													flag19 = false;
													goto IL_469d;
												}
												gstruct28_ = MapTravelDataHelper.FindTravelConnection(num39, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
											}
											else
											{
												if (num39 == 175 || num39 == 195)
												{
													string string_ = "Tèng Kim Chiªu th|Phong V©n Chiªu\u00ad th";
													if (GameProcessInteractionHelper.UseMatchingInventoryItem(characterAccountConfig, string_))
													{
														Thread.Sleep(300);
														NpcDialogHelper.SelectMenuOption(characterAccountConfig, 0);
														break;
													}
												}
												if (num39 != 175)
												{
													if (MapTravelDataHelper.smethod_1(num39) && !MapTravelDataHelper.smethod_1(CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4))
													{
														int int_8 = 11;
														int[] array20 = Class64.smethod_9(CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
														if (array20 != null)
														{
															int_8 = Class64.int_0[array20[0], 0];
														}
														InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig, int_8);
														break;
													}
													if (flag15 || (Form1.int_26 <= 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 <= 0))
													{
														flag21 = true;
														flag19 = false;
														goto IL_469d;
													}
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_6);
													num40 = BitConverter.ToInt32(array4, 0);
													if (num40 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 <= 0)
													{
														gstruct28_ = MapTravelDataHelper.FindTravelConnection(num39, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
														if (gstruct28_.int_0 != num39 || gstruct28_.int_1 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4)
														{
															if (CommonUtility.FindSubstringIndex(CharacterStateSyncCoordinator.characterSyncSnapshot_0.string_1, "Õn thuyÒ") <= 0)
															{
																if (Form1.int_90 > 0 && num39 != 195)
																{
																	if (!flag)
																	{
																		if (!CharacterStateSyncCoordinator.characterSyncSnapshot_0.bool_0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 <= 0)
																		{
																			num9++;
																			if (num9 > 3)
																			{
																				flag = true;
																				num9 = 0;
																				if (Class64.smethod_14(characterAccountConfig))
																				{
																					break;
																				}
																			}
																			Thread.Sleep(80);
																		}
																		if (!flag)
																		{
																			num5 = 0;
																			goto IL_469d;
																		}
																	}
																	if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
																	{
																		CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
																		if (MapNavigationHelper.NavigateToDestination(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, null, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4))
																		{
																			break;
																		}
																	}
																}
																else
																{
																	if (num5 < 3 && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
																	{
																		CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
																		if (MapNavigationHelper.NavigateToDestination(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, null, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4))
																		{
																			num5++;
																			if (num39 == 195)
																			{
																				try
																				{
																					array4[0] = 1;
																					WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_33 * 4, array4, 1, ref int_6);
																				}
																				catch
																				{
																				}
																			}
																			break;
																		}
																		num5 = 3;
																	}
																	if (!CharacterStateSyncCoordinator.characterSyncSnapshot_0.bool_0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 <= 0)
																	{
																		num9++;
																		if (num9 > 3)
																		{
																			num9 = 0;
																			num5 = 0;
																			if (Class64.smethod_14(characterAccountConfig))
																			{
																				break;
																			}
																		}
																		Thread.Sleep(80);
																	}
																}
																flag21 = true;
																flag19 = false;
															}
															goto IL_469d;
														}
														num9 = 0;
													}
													else
													{
														if (num40 == 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 <= 0)
														{
															if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
															{
																num16++;
																if (num16 < 5)
																{
																	CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
																	if (MapNavigationHelper.NavigateToDestination(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, null, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4))
																	{
																		Thread.Sleep(180);
																		break;
																	}
																}
																else if (num16 == 15 && 0 <= NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig))
																{
																	NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
																}
																else if (num16 > 100)
																{
																	num16 = 0;
																}
															}
															int num89 = MapNavigationHelper.FindNavigationEntryIndex(CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
															if (0 <= num89)
															{
																string string_2 = MapNavigationProfileProvider.mapNavigationEntry_0[num89].string_3;
																if (string_2 != null && string_2 != string.Empty)
																{
																	InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, string_2);
																}
															}
															InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
															break;
														}
														if (num40 == 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 > 0)
														{
															if (Form1.int_90 > 0 || GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) == 0)
															{
																if (bool_)
																{
																	bool_ = false;
																	uint[] uint_10 = null;
																	if (Form1.int_25 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == num39)
																	{
																		uint_10 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
																	}
																	if (InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, "®iÓm c", uint_10) > 0)
																	{
																		Class64.smethod_11(characterAccountConfig);
																	}
																	break;
																}
																if (!flag2)
																{
																	flag2 = true;
																	InterMapTravelHelper.UseTravelMenuForDestinationMap(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
																	break;
																}
															}
															bool flag30 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == 181 && MapNavigationProfileProvider.int_0 > 0;
															flag31 = false;
															if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) <= 0 || flag30)
															{
																goto IL_3e43;
															}
															int num90 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4;
															int num91 = MapNavigationHelper.FindNavigationEntryIndex(num90);
															if (num91 < 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == 76)
															{
																num90 = 75;
																num91 = MapNavigationHelper.FindNavigationEntryIndex(75);
															}
															uint[] array21 = null;
															if (num90 == CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4)
															{
																array21 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
															}
															if (0 > num91)
															{
																if (num39 != 103 && num39 != 114 && num39 != 110 && (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == 110 || CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == 114) && MapNavigationHelper.NavigateToDestination(characterAccountConfig, 103))
																{
																	Thread.Sleep(300);
																	Class64.smethod_11(characterAccountConfig);
																	Thread.Sleep(600);
																	int num92 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
																	if (num92 != num39)
																	{
																		break;
																	}
																}
															}
															else
															{
																CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
																bool flag32;
																if (((flag32 = MapNavigationProfileProvider.mapNavigationEntry_0[num91].string_3 == null || MapNavigationProfileProvider.mapNavigationEntry_0[num91].string_3 == string.Empty) || num16 < 10) && MapNavigationHelper.NavigateToDestination(characterAccountConfig, num90, null, array21))
																{
																	if (!flag32)
																	{
																		num16++;
																	}
																	Thread.Sleep(300);
																	Class64.smethod_11(characterAccountConfig);
																	Thread.Sleep(600);
																	break;
																}
																if (!flag32)
																{
																	num16 = 0;
																	InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, MapNavigationProfileProvider.mapNavigationEntry_0[num91].string_3, array21, null, 0, MapNavigationProfileProvider.mapNavigationEntry_0[num91].string_2);
																	break;
																}
															}
															num86 = Class64.smethod_7(num39, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, ref gstruct28_);
															if (num86 != 0)
															{
																gstruct28_ = MapTravelDataHelper.FindTravelConnection(num39, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
																if (gstruct28_.int_0 != num39 || gstruct28_.int_1 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4)
																{
																	if (flag2 && num86 > 0 && num16 < 7)
																	{
																		uint[] uint_11 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
																		if (Class64.smethod_7(num86, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, ref gstruct28_) == 0 && gstruct28_.uint_0 != null)
																		{
																			uint_11 = new uint[2]
																			{
																				gstruct28_.uint_0[0, 0],
																				gstruct28_.uint_0[0, 1]
																			};
																		}
																		num16++;
																		MapNavigationHelper.NavigateToDestination(characterAccountConfig, num86, null, uint_11);
																		break;
																	}
																	flag31 = num91 < 0;
																	goto IL_3e43;
																}
																num9 = 0;
															}
														}
														else
														{
															if (Form1.int_15 > 0)
															{
																gstruct28_ = MapTravelDataHelper.FindTravelConnection(num39, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
																if (gstruct28_.int_0 == num39 && gstruct28_.int_1 == CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4)
																{
																	goto IL_43fe;
																}
															}
															if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
															{
																num16++;
																if (num16 >= 5)
																{
																	if (num16 == 15 && 0 <= NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig))
																	{
																		NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
																	}
																	else if (num16 > 200)
																	{
																		num16 = 0;
																	}
																}
																else
																{
																	CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
																	if (MapNavigationHelper.NavigateToDestination(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, null, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4))
																	{
																		Thread.Sleep(180);
																		break;
																	}
																}
															}
															gstruct28_ = MapTravelDataHelper.FindTravelConnection(num39, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
															if (gstruct28_.int_0 != num39 || gstruct28_.int_1 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4)
															{
																num86 = Class64.smethod_7(num39, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, ref gstruct28_);
																if (num86 != 0)
																{
																	bool_ = false;
																	if (num86 > 0)
																	{
																		flag = false;
																		if (CommonUtility.GetElapsedMilliseconds(long_4) > 3000L)
																		{
																			flag = true;
																			long_4 = CommonUtility.GetCurrentTicks();
																			if (Class64.smethod_14(characterAccountConfig))
																			{
																				break;
																			}
																		}
																		if (num39 == 336)
																		{
																			long num93 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_0, array6);
																			long num94 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_1, array6);
																			if (num93 > num94)
																			{
																				gstruct28_ = MapTravelDataHelper.FindTravelConnection(num39, 121);
																				goto IL_43fe;
																			}
																		}
																		flag21 = true;
																		flag19 = false;
																	}
																	else
																	{
																		flag21 = true;
																		flag19 = false;
																		num10++;
																		if (num10 > 2)
																		{
																			num16 = 0;
																			if (num10 > 3)
																			{
																				Class64.TryShowStatusMessageIfDue(characterAccountConfig, "Ch\u00ada ®Þnh nghÜa ®\u00adêng ®i, ®ang thö T§P ®Ó dß ®\u00adêng !");
																				if (!Class64.smethod_14(characterAccountConfig) && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
																				{
																					MapNavigationHelper.NavigateToDestination(characterAccountConfig, 1, "t©m");
																				}
																				num10 = 0;
																			}
																			break;
																		}
																	}
																	goto IL_469d;
																}
															}
														}
													}
												}
												else
												{
													gstruct28_ = MapTravelDataHelper.FindTravelConnection(num39, 195);
												}
											}
											goto IL_43fe;
										}
									}
									else
									{
										flag21 = true;
										num23 = 0;
										num24 = 0;
									}
									goto IL_469d;
									IL_678f:
									if (characterAccountConfig.bool_58 && characterAccountConfig.int_83 > 0)
									{
										if (Form1.int_106 == 0)
										{
											if (num51 > 0 && CommonUtility.GetElapsedMilliseconds(long_) > characterAccountConfig.long_9)
											{
												CurrentCharacterMemoryHelper.MoveNearSkillTargetPosition(characterAccountConfig, array11, bool_0: false);
												CurrentCharacterMemoryHelper.CastMaAmPhePhachAtCurrentPosition(characterAccountConfig);
												long_ = CommonUtility.GetCurrentTicks();
											}
										}
										else if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_7 == KeyboardKeyCatalog.gstruct42_0[Form1.int_107].int_0)
										{
											CurrentCharacterMemoryHelper.MoveNearSkillTargetPosition(characterAccountConfig, null, bool_0: true);
											if (CommonUtility.GetElapsedMilliseconds(long_) > characterAccountConfig.long_9)
											{
												CurrentCharacterMemoryHelper.CastMaAmPhePhachAtCurrentPosition(characterAccountConfig);
												long_ = CommonUtility.GetCurrentTicks();
											}
										}
									}
									if (!flag15 || flag19 || characterAccountConfig.int_122 <= 0)
									{
										break;
									}
									if (num51 <= 0)
									{
										num28++;
										if (num28 < 10)
										{
											break;
										}
										array6 = new uint[2]
										{
											WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
											WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
										};
										if (num26 < 0)
										{
											num26 = Class64.FindNearestCoordinateIndex(uint_0, array6);
											num29 = 0;
										}
										else if (uint_0.GetLength(0) <= num26)
										{
											num26 = 0;
											num29 = 0;
										}
										uint[] array22 = new uint[2]
										{
											uint_0[num26, 0],
											uint_0[num26, 1]
										};
										long num95 = Class64.GetSquaredCoordinateDistance(array6, array22);
										if (num95 < 11500L)
										{
											num26++;
											num29 = 0;
											if (uint_0.GetLength(0) <= num26)
											{
												num26 = 0;
											}
											array22 = new uint[2]
											{
												uint_0[num26, 0],
												uint_0[num26, 1]
											};
										}
										num29++;
										GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array22);
										Thread.Sleep(200);
										if (num29 > 15)
										{
											num26 = -1;
											num29 = 0;
										}
									}
									else
									{
										num28 = 0;
										num29 = 0;
										num26 = -1;
									}
									break;
									IL_4de5:
									uint num96 = 0u;
									uint[] array23 = null;
									uint[] array24 = null;
									if (!flag20)
									{
										if (characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 && characterAccountConfig.int_136 != ApplicationRuntimeCoordinator.characterAccountConfig_0.int_136 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_5 != 0)
										{
											uint num97 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_5 >> 16;
											uint int_9 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_5 - (num97 << 16);
											array23 = GameInterfaceMemoryHelper.ConvertScreenToWorldCoordinates(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, (int)int_9, (int)num97);
											uint[] array25 = GameInterfaceMemoryHelper.ConvertWorldToScreenCoordinates(array6, array23);
											num96 = (array25[1] << 16) + array25[0];
											array24 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
											GameInterfaceMemoryHelper.WritePackedMousePosition(characterAccountConfig, num96);
											Thread.Sleep(10);
										}
									}
									else
									{
										uint num98 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_5 >> 16;
										uint int_10 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_5 - (num98 << 16);
										array23 = GameInterfaceMemoryHelper.ConvertScreenToWorldCoordinates(CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4, (int)int_10, (int)num98);
										uint[] array26 = GameInterfaceMemoryHelper.ConvertWorldToScreenCoordinates(array6, array23);
										num96 = (array26[1] << 16) + array26[0];
										array24 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4;
										GameInterfaceMemoryHelper.WritePackedMousePosition(characterAccountConfig, num96);
										Thread.Sleep(10);
									}
									Class64.ApplyConfiguredHorseSwitching(characterAccountConfig);
									int num99;
									if (characterAccountConfig.int_127[0] == 2)
									{
										Class64.SendEnabledConfiguredKeys(characterAccountConfig.uint_4, characterAccountConfig.int_129, FormDame.int_12);
									}
									else
									{
										if (characterAccountConfig.int_127[0] == 1)
										{
											bool flag33 = characterAccountConfig.int_127[1] > 0 && characterAccountConfig.int_127[2] > 0;
											bool flag34 = characterAccountConfig.int_127[3] > 0 && characterAccountConfig.int_127[4] > 0;
											if (flag33 && !flag34)
											{
												num99 = characterAccountConfig.int_127[2];
											}
											else if (flag34 && !flag33)
											{
												num99 = characterAccountConfig.int_127[4];
											}
											else if (flag33 && flag34)
											{
												num99 = ((0 > num6 || num6 > 25) ? characterAccountConfig.int_127[4] : characterAccountConfig.int_127[2]);
												if (num6 > 35)
												{
													num6 = 0;
												}
												num6++;
											}
										}
										if (num99 <= 0)
										{
											num99 = CharacterSkillHelper.ReadLeftSkillId(characterAccountConfig);
										}
										if (characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 || Form1.int_10 > 0 || Form1.int_11 > 0)
										{
											CharacterSkillHelper.smethod_9(characterAccountConfig);
										}
										CharacterSkillHelper.SetDirectShortcutSkillSlot(characterAccountConfig, num99, 6, 1);
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_12 * 4, array4, 1, ref int_6);
										if (array4[0] == 0 && FormDame.int_0 <= 0)
										{
											FormDame.int_0 = int_0;
											new Thread(FormDame.smethod_0).Start();
										}
										array4[0] = 1;
										WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_12 * 4 + 1, array4, 1, ref int_6);
									}
									if (num96 != 0 && characterAccountConfig.int_136 != ApplicationRuntimeCoordinator.characterAccountConfig_0.int_136)
									{
										if (characterAccountConfig.int_95 <= 0)
										{
											WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, characterAccountConfig.int_137);
											int num100 = CharacterSkillHelper.ReadLeftSkillId(characterAccountConfig);
											if (num100 == 53 || num100 <= 1)
											{
												goto IL_671c;
											}
										}
										string string_3 = GameInterfaceMemoryHelper.ReadLatestBottomChannelText(characterAccountConfig);
										if (CommonUtility.MatchesGameTextPattern(string_3, "iÓm qu\u00b8 x"))
										{
											uint[] array27 = Class64.GetCoordinateOffsetAlongLine(array24, array23, -1 * (Form1.int_27 - 50));
											long num101 = Class64.GetSquaredCoordinateDistance(array6, array27);
											if (num101 > 7000L)
											{
												GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array27);
												Thread.Sleep(150);
												GameInterfaceMemoryHelper.WriteLatestBottomChannelText(characterAccountConfig, "0K..");
											}
										}
									}
									goto IL_671c;
									IL_671c:
									if (!flag17 && characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 && CurrentCharacterMemoryHelper.GetCurrentTargetEntityIndexByTypes(characterAccountConfig, new int[2] { 0, 1 }) != 0)
									{
										if (num21 > 0)
										{
											WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
										}
										num21 = 0;
									}
									if (flag16 && num51 <= 0)
									{
										FormDuongMon.smethod_0(characterAccountConfig, ref int_4, array2, ref int_5, flag6);
									}
									goto IL_678f;
									IL_3e43:
									bool flag35 = false;
									int[] array28 = Class64.smethod_9(num39);
									if (array28 == null && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 > 0 && TongKimBattlefieldHelper.smethod_1(num39) != null && TongKimBattlefieldHelper.FindBattlefieldMapGroupPosition(CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4) == null)
									{
										InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig, 11);
										Thread.Sleep(600);
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array4, 4, ref int_6);
										int num102 = BitConverter.ToInt32(array4, 0);
										if (num102 != num39)
										{
											array4[0] = 1;
											WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_33 * 4, array4, 1, ref int_6);
											break;
										}
									}
									if (!ChienLongDongNavigationHelper.IsChienLongDongMap(CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4))
									{
										if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == 181)
										{
											InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, "h÷ng n¬i ®· ®i q|L\u00adìng Thñy|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.string_1);
											flag35 = true;
										}
										else if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == 224)
										{
											InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, "h÷ng n¬i ®· ®i q|Sa M¹c");
											flag35 = true;
										}
										else if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 != 993)
										{
											if (num40 <= 0 && !flag2 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 != num39 && array28 != null)
											{
												InterMapTravelHelper.UseTravelMenuForDestinationMap(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
												flag2 = true;
												flag35 = true;
											}
										}
										else
										{
											InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, "NguyÖt Ca");
											flag35 = true;
										}
									}
									else
									{
										InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, "ChiÕn Long|H\u00b8i Qu¶ H|L\u00adìng Thñy ");
										flag35 = true;
									}
									if (flag35)
									{
										Thread.Sleep(150);
										Class64.smethod_11(characterAccountConfig);
										int num103 = 0;
										while (num103 < 5)
										{
											int num104 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
											if (num104 == num39)
											{
												num103++;
												Thread.Sleep(100);
												continue;
											}
											goto IL_4056;
										}
									}
									int num105 = -1;
									if (Form1.int_23 > 0)
									{
										num105 = -1;
									}
									if (0 <= num105)
									{
										break;
									}
									num86 = Class64.smethod_7(num39, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, ref gstruct28_);
									if (num86 != 0)
									{
										if (num86 > 0)
										{
											if (array28 != null)
											{
												if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0 && num16 < 5)
												{
													num16++;
													if (MapNavigationHelper.NavigateToDestination(characterAccountConfig, num86))
													{
														break;
													}
												}
												InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig, num86);
											}
											else if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
											{
												uint[] uint_12 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
												if (Class64.smethod_7(num86, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, ref gstruct28_) == 0 && gstruct28_.uint_0 != null)
												{
													uint_12 = new uint[2]
													{
														gstruct28_.uint_0[0, 0],
														gstruct28_.uint_0[0, 1]
													};
												}
												if (!MapNavigationHelper.NavigateToDestination(characterAccountConfig, num86, null, uint_12))
												{
													MapNavigationHelper.NavigateToDestination(characterAccountConfig, 1, "t©m");
												}
												break;
											}
										}
										if (flag31 && Form1.int_125 <= 0)
										{
											MapNavigationHelper.smethod_2(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
										}
										break;
									}
									goto IL_43fe;
									IL_469d:
									flag16 = false;
									flag20 = (Form1.int_10 > 0 || Form1.int_11 > 0) && Form1.int_25 > 0 && (CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_3 > 0 || Form1.int_26 > 0) && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_4 > 0 && CommonUtility.IsNonZeroCoordinatePair(CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4) && (characterAccountConfig.int_136 == CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 || CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 <= 0);
									array6 = new uint[2]
									{
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
									};
									if (flag21)
									{
										uint[] array29 = null;
										long num106 = 0L;
										if (num12 <= 0L || CommonUtility.GetElapsedMilliseconds(num12) >= 800L)
										{
											array29 = Class64.smethod_26(characterAccountConfig, ref int_3);
											if (array29 == null)
											{
												num12 = CommonUtility.GetCurrentTicks();
											}
											else
											{
												num12 = 0L;
												num106 = Class64.GetSquaredCoordinateDistance(array6, array29);
												if (num106 >= 8000L)
												{
													if (num106 >= 15000L && num106 >= characterAccountConfig.int_68[1] * characterAccountConfig.int_68[1])
													{
														if (num106 < 360000L)
														{
															if (num21 > 0)
															{
																WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
															}
															num21 = 0;
															CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
															GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array29);
															Thread.Sleep(200);
															break;
														}
														if (num106 < 1200000L)
														{
															if (CommonUtility.GetElapsedMilliseconds(long_3) > 3000L)
															{
																CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array29);
																long_3 = CommonUtility.GetCurrentTicks();
															}
															break;
														}
													}
													else
													{
														num37 = (int)WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig.int_137);
														if (num37 < 3 && num106 > 7500L)
														{
															if (num21 > 0)
															{
																WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
															}
															num21 = 0;
															GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array29);
															Thread.Sleep(200);
															goto IL_671c;
														}
														num106 = 4L;
													}
												}
												else
												{
													num106 = 4L;
												}
											}
										}
										if (flag20)
										{
											if (num106 != 4L)
											{
												num106 = AuxiliaryMachineManager.smethod_11(characterAccountConfig, ref bool_, ref long_3, ref int_2, ref array);
											}
											num37 = (int)WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig.int_137);
											if (num106 == 4L && num37 < 3)
											{
												array6 = new uint[2]
												{
													WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
													WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
												};
												if (Class64.GetSquaredCoordinateDistance(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4) > 5625L)
												{
													if (num21 > 0)
													{
														WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
													}
													num21 = 0;
													GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4);
													Thread.Sleep(200);
												}
											}
											WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_56.uint_0, characterAccountConfig.int_137);
											if (num106 <= 0L)
											{
												break;
											}
											if (num106 == 2L)
											{
												int_2++;
												if (int_2 < 3)
												{
													break;
												}
											}
											if (num40 > 0 && num106 == 4L && Form1.int_109 > 0 && characterAccountConfig.int_93 == 1)
											{
												Class64.ApplyConfiguredHorseSwitching(characterAccountConfig);
											}
										}
										array = null;
										int_2 = 0;
									}
									goto IL_4aff;
									IL_535d:
									int[,] array30 = null;
									if (characterAccountConfig.int_119 > 0 && characterAccountConfig.int_3 != null)
									{
										array30 = ((characterAccountConfig.int_5 > 0) ? CombatTargetSelectionHelper.smethod_5(characterAccountConfig, num66, num48, uint_4, CombatTargetSelectionHelper.int_0) : CombatTargetSelectionHelper.smethod_6(characterAccountConfig, num66, num48, uint_4));
										if (array30 != null && array30[0, 0] >= 0)
										{
											int num107 = -1;
											int int_11 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4;
											num21 = 0;
											bool flag36 = false;
											bool flag37 = false;
											while (true)
											{
												int num108 = 0;
												int num109 = 400;
												uint num110 = 0u;
												while (num108 <= 0)
												{
													num107++;
													if (characterAccountConfig.int_3 != null && characterAccountConfig.int_3.GetLength(0) > num107 && characterAccountConfig.int_4 != null)
													{
														num108 = characterAccountConfig.int_3[num107, 0];
														if (num108 > 0)
														{
															num109 = CharacterSkillHelper.ReadSkillRange(characterAccountConfig, num108, characterAccountConfig.int_3[num107, 1]);
															break;
														}
														continue;
													}
													goto IL_59b3;
												}
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array4, 4, ref int_6);
												num37 = BitConverter.ToInt32(array4, 0);
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array4, 4, ref int_6);
												num38 = BitConverter.ToInt32(array4, 0);
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_6);
												num40 = BitConverter.ToInt32(array4, 0);
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array4, 4, ref int_6);
												int num111 = BitConverter.ToInt32(array4, 0);
												if (num40 > 0 && num39 == num111 && num37 != 11 && num37 != 22 && num38 != 0)
												{
													for (int m = 0; m < array30.GetLength(0); m++)
													{
														if (CharacterStateSyncCoordinator.smethod_7(characterAccountConfig, ref int_7) || GameInterfaceMemoryHelper.smethod_12(characterAccountConfig) == 1)
														{
															goto IL_5976;
														}
														int num112 = array30[m, 0];
														num51 = array30[m, 1];
														if (num51 <= 0)
														{
															continue;
														}
														num110 = num35 + (uint)(num51 * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0);
														WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array4, 4, ref int_6);
														if (BitConverter.ToInt32(array4, 0) <= 0)
														{
															continue;
														}
														if (num112 > 0)
														{
															WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_6);
															if (BitConverter.ToInt32(array4, 0) <= 0)
															{
																continue;
															}
														}
														flag36 = true;
														if (!flag37 || num112 > 0)
														{
															if (num112 > 0)
															{
																flag37 = true;
															}
															if (GameEntityMemoryHelper.GetEntityActiveEffectIdForSkill(characterAccountConfig, num51, num108) != 0)
															{
																continue;
															}
															num49 = num109;
															WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, array4, 4, ref int_6);
															array11[0] = BitConverter.ToUInt32(array4, 0);
															WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, array4, 4, ref int_6);
															array11[1] = BitConverter.ToUInt32(array4, 0);
															array6 = new uint[2]
															{
																WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
																WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
															};
															if (flag19)
															{
																array6 = new uint[2]
																{
																	WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
																	WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
																};
																long num113 = Class64.GetSquaredCoordinateDistance(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
																if (int_11 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 || num113 > num20 * num20)
																{
																	goto IL_5952;
																}
																int num114 = (int)Math.Sqrt(Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array11));
																int num115 = (int)Math.Sqrt(Class64.GetSquaredCoordinateDistance(array6, array11));
																int num116 = num114 - num20 + 10;
																if (num114 > num20 && num49 < num116 && (num115 > num114 || (num115 < num114 && num49 < num115)))
																{
																	num49 = num116;
																}
															}
															if (Class64.GetSquaredCoordinateDistance(array6, array11) > num49 * num49 && characterAccountConfig.int_95 <= 0)
															{
																continue;
															}
															for (num25 = 0; num25 < GameConfigurationManager.int_0; num25++)
															{
																WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_6 * 4, array4, 1, ref int_6);
																if (array4[0] == 0)
																{
																	break;
																}
																Thread.Sleep(1);
															}
															WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_161.uint_0 - 8, BitConverter.GetBytes(num108), 4, ref int_6);
															WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, BitConverter.GetBytes(num49), 4, ref int_6);
															WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, BitConverter.GetBytes(num51), 4, ref int_6);
															Thread.Sleep(10);
															num21 = 1;
															continue;
														}
														goto IL_59b3;
													}
													continue;
												}
												if (num21 > 0)
												{
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
												}
												num21 = 0;
												break;
												IL_59b3:
												if (num21 <= 0 && characterAccountConfig.int_6 <= 0 && flag36)
												{
													long num117 = 0L;
													array6 = new uint[2]
													{
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
													};
													num51 = -1;
													int num118 = 0;
													int length = array30.GetLength(1);
													flag37 = false;
													num49 = characterAccountConfig.int_97;
													if (characterAccountConfig.int_95 > 0 && characterAccountConfig.int_96 > 0)
													{
														num49 = characterAccountConfig.int_96;
													}
													if (num49 <= 0)
													{
														num49 = 500;
													}
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_44 * 4, array4, 1, ref int_6);
													int num119 = array4[0];
													if (num119 > 0 && num49 > characterAccountConfig.int_97 && characterAccountConfig.int_97 > 0)
													{
														num49 = characterAccountConfig.int_97;
													}
													for (int n = 0; n < array30.GetLength(0); n++)
													{
														int num120 = array30[n, 0];
														int num121 = array30[n, 1];
														_ = array30[n, 2];
														int num122 = num49;
														int num123 = 0;
														if (length > 10)
														{
															num123 = array30[n, 10];
														}
														if (num121 <= 0)
														{
															continue;
														}
														num110 = num35 + (uint)(num121 * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0);
														WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array4, 4, ref int_6);
														if (BitConverter.ToInt32(array4, 0) <= 0)
														{
															continue;
														}
														if (num120 > 0)
														{
															WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_6);
															if (BitConverter.ToInt32(array4, 0) <= 0)
															{
																continue;
															}
														}
														if (flag37 && num120 <= 0 && num51 > 0)
														{
															break;
														}
														WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, array4, 4, ref int_6);
														array11[0] = BitConverter.ToUInt32(array4, 0);
														WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, array4, 4, ref int_6);
														array11[1] = BitConverter.ToUInt32(array4, 0);
														long num124 = Class64.GetSquaredCoordinateDistance(array6, array11);
														if (num51 > 0 && num117 < num124)
														{
															continue;
														}
														if (flag19)
														{
															int num125 = (int)Math.Sqrt(Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array11));
															int num126 = (int)Math.Sqrt(Class64.GetSquaredCoordinateDistance(array6, array11));
															int num127 = num125 - num20 + 10;
															if (num125 > num20 && num122 < num127 && (num126 > num125 || (num126 < num125 && num122 < num126)))
															{
																num122 = num127;
															}
														}
														if (num124 <= num122 * num122 || characterAccountConfig.int_95 > 0)
														{
															if (num120 > 0)
															{
																flag37 = true;
															}
															num51 = num121;
															num118 = num123;
															num117 = num124;
															num49 = num122;
														}
													}
													if (num51 <= 0)
													{
														break;
													}
													if (flag15 && Form1.int_122 > 0)
													{
														if (num118 <= 0)
														{
															num110 = num35 + (uint)(num51 * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0);
															WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, array4, 4, ref int_6);
															array11[0] = BitConverter.ToUInt32(array4, 0);
															WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num110 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, array4, 4, ref int_6);
															array11[1] = BitConverter.ToUInt32(array4, 0);
															if (CombatTargetSelectionHelper.IsTrackedTargetNearby(characterAccountConfig.int_137, num39, array11) == 0)
															{
																uint num128 = (uint)((int)num35 + num51 * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0 + (int)GameConfigurationManager.memorySignatureScanConfig_57.uint_0) + GameConfigurationManager.memorySignatureScanConfig_2.uint_0;
																for (uint num129 = 0u; num129 < 6; num129++)
																{
																	WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num128 + GameConfigurationManager.memorySignatureScanConfig_3.uint_0 * num129, array4, 4, ref int_6);
																	if (BitConverter.ToInt32(array4, 0) == 45)
																	{
																		num118 = 1;
																		break;
																	}
																}
															}
															else
															{
																num118 = 1;
															}
														}
														if (num118 > 0)
														{
															num51 = 0;
															num21 = 0;
															flag16 = false;
															break;
														}
													}
													Class64.ApplyConfiguredHorseSwitching(characterAccountConfig);
													for (num25 = 0; num25 < GameConfigurationManager.int_0; num25++)
													{
														WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_6 * 4, array4, 1, ref int_6);
														if (array4[0] == 0)
														{
															break;
														}
														Thread.Sleep(1);
													}
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_161.uint_0 - 8, BitConverter.GetBytes(CharacterSkillHelper.ReadLeftSkillId(characterAccountConfig)), 4, ref int_6);
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, BitConverter.GetBytes(num49), 4, ref int_6);
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, BitConverter.GetBytes(num51), 4, ref int_6);
												}
												else if (flag36 && num21 <= 0 && characterAccountConfig.int_6 > 0)
												{
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
												}
												break;
												IL_5952:
												WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
												break;
												IL_5976:
												Thread.Sleep(100);
												num21 = 0;
												break;
											}
										}
									}
									else if (flag17 = !characterAccountConfig.bool_22 && (Form1.int_35 > 0 || Form1.int_34 > 0))
									{
										array30 = CombatTargetSelectionHelper.smethod_5(characterAccountConfig, num66, num48, uint_4, CombatTargetSelectionHelper.int_0);
										if (array30 != null)
										{
											if (array30[0, 0] == -100)
											{
												break;
											}
											int num130 = 0;
											while (true)
											{
												if (array30[num130, 1] > 0)
												{
													array11 = new uint[2]
													{
														(uint)array30[num130, 4],
														(uint)array30[num130, 5]
													};
													if (!flag19)
													{
														if (Class64.GetSquaredCoordinateDistance(array6, array11) > num49 * num49 && characterAccountConfig.int_95 <= 0)
														{
															if (characterAccountConfig.int_88 != 1 || num130 != 0)
															{
																break;
															}
															num130 = 1;
															continue;
														}
													}
													else
													{
														int num131 = (int)Math.Sqrt(Class64.GetSquaredCoordinateDistance(array6, array11));
														int num132 = (int)Math.Sqrt(Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array11));
														if (num131 - num49 > 0)
														{
															if (num132 > num131)
															{
																int num133 = (int)Math.Sqrt(Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array6));
																if (num133 + (num131 - num49) <= num20 + 10)
																{
																	goto IL_619c;
																}
															}
															if (characterAccountConfig.int_88 == 1 && num130 == 0)
															{
																num130 = 1;
																continue;
															}
															if (num20 + num49 <= num132)
															{
																if (num21 > 0)
																{
																	WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
																}
																num21 = 0;
																break;
															}
														}
													}
													goto IL_619c;
												}
												if (num21 > 0)
												{
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
												}
												num21 = 0;
												break;
												IL_619c:
												int num134 = array30[num130, 0];
												num51 = array30[num130, 1];
												int num135 = array30[num130, 2];
												if (Form1.int_56 > 0 && (num134 <= 0 || num134 == array3[0]) && array3[1] > 0 && array3[2] == num39 && array3[3] > 0)
												{
													int num136 = array3[0];
													int num137 = array3[1];
													int num138 = array3[4];
													uint num139 = num35 + (uint)(num137 * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0);
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num139 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array4, 4, ref int_6);
													if (BitConverter.ToInt32(array4, 0) > 0)
													{
														WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num139 + GameConfigurationManager.memorySignatureScanConfig_45.uint_0, array4, 4, ref int_6);
														long num140 = BitConverter.ToInt32(array4, 0);
														if ((ulong)num140 > 0uL)
														{
															WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num139 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_6);
															if (num136 <= 0 || BitConverter.ToInt32(array4, 0) > 0)
															{
																array11 = new uint[2]
																{
																	WindowsInteropHelper.ReadProcessUInt32(num139 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
																	WindowsInteropHelper.ReadProcessUInt32(num139 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
																};
																long num141 = Class64.GetSquaredCoordinateDistance(array6, array11);
																if (flag19)
																{
																	int num142 = (int)Math.Sqrt(num141);
																	int num143 = (int)Math.Sqrt(Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array11));
																	if (num142 - num49 > 0)
																	{
																		if (num143 > num142)
																		{
																			int num144 = (int)Math.Sqrt(Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array6));
																			if (num144 + (num142 - num49) <= num20 + 10)
																			{
																				num134 = num136;
																				num51 = num137;
																				num135 = num138;
																			}
																		}
																	}
																	else
																	{
																		num134 = num136;
																		num51 = num137;
																		num135 = num138;
																	}
																}
																else if (num141 <= num49 * num49)
																{
																	num134 = num136;
																	num51 = num137;
																	num135 = num138;
																}
															}
														}
													}
												}
												if (flag15 && Form1.int_122 > 0)
												{
													int num145 = 0;
													uint[] array31 = new uint[2];
													uint num146 = num35 + (uint)(num51 * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0);
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num146 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, array4, 4, ref int_6);
													array31[0] = BitConverter.ToUInt32(array4, 0);
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num146 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, array4, 4, ref int_6);
													array31[1] = BitConverter.ToUInt32(array4, 0);
													if (CombatTargetSelectionHelper.IsTrackedTargetNearby(characterAccountConfig.int_137, num39, array31) != 0)
													{
														num145 = 1;
													}
													else
													{
														uint num147 = (uint)((int)num35 + num51 * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0 + (int)GameConfigurationManager.memorySignatureScanConfig_57.uint_0) + GameConfigurationManager.memorySignatureScanConfig_2.uint_0;
														for (uint num148 = 0u; num148 < 6; num148++)
														{
															WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num147 + GameConfigurationManager.memorySignatureScanConfig_3.uint_0 * num148, array4, 4, ref int_6);
															if (BitConverter.ToInt32(array4, 0) == 45)
															{
																num145 = 1;
																break;
															}
														}
													}
													if (num145 > 0)
													{
														num51 = 0;
														num135 = 0;
														num21 = 0;
													}
												}
												array3[0] = num134;
												array3[1] = num51;
												array3[2] = num39;
												array3[3] = 0;
												array3[4] = num135;
												if (num51 <= 0)
												{
													break;
												}
												array3[3] = 1;
												num21 = 1;
												num22 = 1;
												Class64.ApplyConfiguredHorseSwitching(characterAccountConfig);
												for (num25 = 0; num25 < GameConfigurationManager.int_0; num25++)
												{
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_6 * 4, array4, 1, ref int_6);
													if (array4[0] == 0)
													{
														break;
													}
													Thread.Sleep(1);
												}
												if (characterAccountConfig.gstruct50_0.int_0 == 0 || CombatTargetSelectionHelper.TryUseConfiguredPreAttackSkill(characterAccountConfig, (uint)num51) <= 0)
												{
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_161.uint_0 - 8, BitConverter.GetBytes(CharacterSkillHelper.ReadLeftSkillId(characterAccountConfig)), 4, ref int_6);
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_31.uint_0, BitConverter.GetBytes(num49), 4, ref int_6);
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, BitConverter.GetBytes(num51), 4, ref int_6);
												}
												flag14 = characterAccountConfig.gstruct50_0.int_0 > 0 && characterAccountConfig.gstruct50_0.int_1 > 0 && characterAccountConfig.gstruct50_0.int_8 > 0 && characterAccountConfig.gstruct50_0.int_9 > 0;
												break;
											}
										}
										else
										{
											flag17 = false;
										}
									}
									else
									{
										flag17 = false;
									}
									goto IL_671c;
									IL_138c:
									flag13 = true;
									goto IL_138f;
									IL_4aff:
									num40 = (int)WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig.int_137);
									if (num40 <= 0)
									{
										break;
									}
									flag3 = false;
									flag2 = false;
									flag17 = !characterAccountConfig.bool_22 && (Form1.int_35 > 0 || Form1.int_34 > 0);
									if (characterAccountConfig.int_101[0] > 0 && characterAccountConfig.int_101[1] > 0 && characterAccountConfig.string_23 == "NGAMY")
									{
										long num149 = CommonUtility.GetElapsedMilliseconds(long_2);
										if (num149 < 300L)
										{
											break;
										}
										if (num149 > characterAccountConfig.int_101[4] && CombatTargetSelectionHelper.smethod_3(characterAccountConfig))
										{
											Thread.Sleep(80);
											long_2 = CommonUtility.GetCurrentTicks();
											break;
										}
									}
									for (num25 = 0; num25 < GameConfigurationManager.int_0; num25++)
									{
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_6 * 4, array4, 1, ref int_6);
										if (array4[0] == 0)
										{
											break;
										}
										Thread.Sleep(1);
									}
									if (characterAccountConfig.bool_22)
									{
										if (characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0)
										{
											Class64.SwitchHorseStateIfNeeded(characterAccountConfig, bool_0: false);
										}
									}
									else
									{
										if (flag25)
										{
											goto IL_535d;
										}
										bool flag38 = characterAccountConfig.int_128[0] > 0 && characterAccountConfig.int_128[1] > 0 && characterAccountConfig.int_128[2] > 0;
										bool flag39 = characterAccountConfig.int_128[0] > 0 && characterAccountConfig.int_128[3] > 0 && characterAccountConfig.int_128[4] > 0;
										bool flag40 = characterAccountConfig.int_128[0] > 0 && characterAccountConfig.int_128[5] > 0 && characterAccountConfig.int_128[6] > 0;
										flag16 = (flag38 || flag39 || flag40) && characterAccountConfig.string_23 == "DUONGMON";
										if (FormDame.int_6 <= 0 || characterAccountConfig.int_126 != 0 || flag16)
										{
											goto IL_51df;
										}
										if (flag17 || FormDame.int_10 > 0)
										{
											num99 = 0;
											if (FormDame.int_9 == 0)
											{
												goto IL_4de5;
											}
											bool flag41 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_8 == 1 || (flag20 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_8 == 1);
											if (FormDame.int_9 != 1)
											{
												if (FormDame.int_9 != 2 || flag41)
												{
													goto IL_4daf;
												}
												if (num21 > 0)
												{
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
												}
												num21 = 0;
											}
											else
											{
												if (flag41)
												{
													goto IL_4de5;
												}
												if (FormDame.int_11 > 0)
												{
													goto IL_4daf;
												}
												if (num21 > 0)
												{
													WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
												}
												num21 = 0;
											}
										}
									}
									goto IL_671c;
									IL_2225:
									flag8 = num81 > 40000L;
									WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
									num21 = 0;
									if (!flag4 && num39 == 336)
									{
										flag4 = true;
										int num150 = 0;
										int num151 = 0;
										long num152 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_0, array6);
										long num153 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_1, array6);
										if (num152 < num153)
										{
											num150 = 1;
										}
										num152 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_0, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
										num153 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_1, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
										if (num152 < num153)
										{
											num151 = 1;
										}
										if (num150 != num151)
										{
											flag21 = true;
											flag19 = false;
											goto IL_33f1;
										}
									}
									if (array == null)
									{
										array = new uint[2]
										{
											array6[0],
											array6[1]
										};
										int_2 = 0;
									}
									if (int_2 > 6)
									{
										long num154 = Class64.GetSquaredCoordinateDistance(array, array6);
										array = null;
										if (num154 < 180000L)
										{
											CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
											Class64.smethod_2(characterAccountConfig, array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, 600);
											goto IL_671c;
										}
										int_2 = 0;
									}
									if (num81 > Form1.int_108 * Form1.int_108)
									{
										Class64.SwitchHorseStateIfNeeded(characterAccountConfig, bool_0: false);
									}
									array6 = new uint[2]
									{
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
									};
									num81 = Class64.GetSquaredCoordinateDistance(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
									if (num81 < 600000L)
									{
										if (num8 > 10)
										{
											uint[] array32 = new uint[2]
											{
												WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
												WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
											};
											Thread.Sleep(300);
											array6 = new uint[2]
											{
												WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
												WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
											};
											if (Class64.GetSquaredCoordinateDistance(array32, array6) > 600L)
											{
												num8 = 0;
											}
										}
										if (num8 <= 10)
										{
											num8++;
											CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
											GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
											Thread.Sleep(150);
											goto IL_671c;
										}
									}
									if (num39 != Map878NavigationHelper.MapId)
									{
										bool flag42 = false;
										if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == 1)
										{
											uint[] uint_13 = new uint[2] { 50016u, 88321u };
											long num155 = Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, uint_13);
											flag42 = num155 <= 2000000L;
										}
										else if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == 53)
										{
											uint[] uint_14 = new uint[2] { 49440u, 105824u };
											long num156 = Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, uint_14);
											flag42 = num156 <= 2000000L;
										}
										if (flag42 && !flag12)
										{
											flag12 = true;
											if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0 && MapNavigationHelper.UseVanTieuTravelOption(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4) > 0)
											{
												Thread.Sleep(300);
												break;
											}
										}
										int[] array33 = Class64.smethod_9(num39);
										if (array33 != null && num40 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 <= 0 && Form1.int_26 > 0 && !flag42)
										{
											if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
											{
												CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
												if (MapNavigationHelper.NavigateToDestination(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4, null, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4))
												{
													Thread.Sleep(300);
													break;
												}
											}
											if (Class64.smethod_14(characterAccountConfig))
											{
												Thread.Sleep(300);
												break;
											}
										}
										bool flag43 = num40 <= 0 && array33 != null && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 > 0;
										array6 = new uint[2]
										{
											WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
											WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
										};
										num81 = Class64.GetSquaredCoordinateDistance(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
										if (Form1.int_90 > 0 && bool_ && flag43)
										{
											bool_ = false;
											if (num81 < 900000L)
											{
												CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
												GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
												Thread.Sleep(200);
												goto IL_671c;
											}
											uint[] uint_15 = null;
											if (Form1.int_25 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == num39)
											{
												uint_15 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
											}
											if (InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, "®iÓm c", uint_15) > 0)
											{
												Class64.smethod_11(characterAccountConfig);
												Thread.Sleep(200);
												break;
											}
										}
										if (num40 != 0 || CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 <= 0 || TongKimBattlefieldHelper.FindBattlefieldMapGroupPosition(num39) == null)
										{
											array12 = new uint[2]
											{
												CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4[0],
												CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4[1]
											};
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_6);
											num40 = BitConverter.ToInt32(array4, 0);
											array6 = new uint[2]
											{
												WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
												WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
											};
											num81 = Class64.GetSquaredCoordinateDistance(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
											if (num39 == 998 || num39 == 997)
											{
												string text4 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(characterAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_28.uint_0 + GameConfigurationManager.memorySignatureScanConfig_29.uint_0, characterAccountConfig.int_137, 20);
												if (0 <= text4.IndexOf("Tr\u00adêng B¹ch"))
												{
													goto IL_324b;
												}
											}
											switch (num39)
											{
											default:
											{
												if (num24 > 0 || (num39 != 959 && num39 != 990 && num39 != 991 && (num40 != 0 || array33 == null)))
												{
													break;
												}
												num24 = 1;
												uint[,] array42 = MapRouteCatalog.FindRoute(num39, array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
												if (array42 != null)
												{
													num81 = Class64.GetSquaredCoordinateDistance(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
													uint[] uint_17 = new uint[2]
													{
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
													};
													int num166 = Class64.smethod_22(characterAccountConfig, array42, array6, null, num39, bool_0: false, Class64.GetTimeoutForSquaredDistance(num81));
													array6 = new uint[2]
													{
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
													};
													num81 = Class64.GetSquaredCoordinateDistance(array6, uint_17);
													if (num166 > 0 && num81 > 600000L)
													{
														num24 = 0;
														goto end_IL_04fe;
													}
												}
												break;
											}
											case 333:
											case 998:
											{
												if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0 && num81 > 15354505L && Form1.string_6 == "vltrungnguyen.com")
												{
													num81 = -1L;
													int num158 = -1;
													for (int num159 = 0; num159 < HoaSonMapRouteHelper.MapGates.Length; num159++)
													{
														long num160 = Class64.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, HoaSonMapRouteHelper.MapGates[num159].uint_0);
														if (num158 < 0 || num160 < num81)
														{
															num158 = num159;
															num81 = num160;
														}
													}
													CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
													if (MapNavigationHelper.UseTravelScrollMenuOption(characterAccountConfig, "b¶n ®å|§Æc BiÖt|" + HoaSonMapRouteHelper.MapGates[num158].string_0))
													{
														num8 = 0;
														Thread.Sleep(180);
														goto end_IL_04fe;
													}
												}
												bool flag44 = HoaSonMapRouteHelper.smethod_0(array6);
												bool flag45 = HoaSonMapRouteHelper.smethod_0(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
												if (flag44 != flag45)
												{
													uint[,] array36 = null;
													uint[,] array37 = HoaSonMapRouteHelper.GetNearestRouteSet(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
													uint[,] array38 = HoaSonMapRouteHelper.GetNearestRouteSet(array6);
													int length2 = array37.GetLength(0);
													int length3 = array38.GetLength(0);
													long num161 = 0L;
													long num162 = 0L;
													if (flag44)
													{
														num161 = Class64.GetSquaredDistanceToCoordinate(array6, array37[length2 - 1, 0], array37[length2 - 1, 1]);
														num161 += Class64.GetSquaredDistanceToCoordinate(new uint[2]
														{
															array37[0, 0],
															array37[0, 1]
														}, array37[length2 - 1, 0], array37[length2 - 1, 1]);
														num161 += Class64.GetSquaredDistanceToCoordinate(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array37[0, 0], array37[0, 1]);
														num162 = Class64.GetSquaredDistanceToCoordinate(array6, array38[length3 - 1, 0], array38[length3 - 1, 1]);
														num162 += Class64.GetSquaredDistanceToCoordinate(new uint[2]
														{
															array38[0, 0],
															array38[0, 1]
														}, array38[length3 - 1, 0], array38[length3 - 1, 1]);
														num162 += Class64.GetSquaredDistanceToCoordinate(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array38[0, 0], array38[0, 1]);
													}
													else
													{
														num161 = Class64.GetSquaredDistanceToCoordinate(array6, array37[0, 0], array37[0, 1]);
														num161 += Class64.GetSquaredDistanceToCoordinate(new uint[2]
														{
															array37[0, 0],
															array37[0, 1]
														}, array37[length2 - 1, 0], array37[length2 - 1, 1]);
														num161 += Class64.GetSquaredDistanceToCoordinate(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array37[length2 - 1, 0], array37[length2 - 1, 1]);
														num162 = Class64.GetSquaredDistanceToCoordinate(array6, array38[0, 0], array38[0, 1]);
														num162 += Class64.GetSquaredDistanceToCoordinate(new uint[2]
														{
															array38[0, 0],
															array38[0, 1]
														}, array38[length3 - 1, 0], array38[length3 - 1, 1]);
														num162 += Class64.GetSquaredDistanceToCoordinate(CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4, array38[length3 - 1, 0], array38[length3 - 1, 1]);
													}
													array36 = ((num161 <= num162) ? array37 : array38);
													uint[] array39 = new uint[2]
													{
														array36[0, 0],
														array36[0, 1]
													};
													uint[] array40 = new uint[2]
													{
														array36[array36.GetLength(0) - 1, 0],
														array36[array36.GetLength(0) - 1, 1]
													};
													num81 = Class64.GetNearestCoordinateSquaredDistance(array36, array6);
													if (num81 <= 300000L)
													{
														if (flag44)
														{
															Class64.smethod_22(characterAccountConfig, array36, array6, array39, num39, bool_0: false, 6000, bool_1: true);
														}
														else
														{
															Class64.smethod_22(characterAccountConfig, array36, array6, array40, num39, bool_0: false, 6000, bool_1: true);
														}
														num8 = 0;
														int_2++;
														goto end_IL_04fe;
													}
													if (flag44)
													{
														array12[0] = array40[0];
														array12[1] = array40[1];
													}
													else
													{
														array12[0] = array39[0];
														array12[1] = array39[1];
													}
												}
												else
												{
													if (flag44)
													{
														break;
													}
													long num163 = Class64.GetNearestCoordinateSquaredDistance(HoaSonMapRouteHelper.uint_0, array6);
													long num164 = Class64.GetNearestCoordinateSquaredDistance(HoaSonMapRouteHelper.uint_0, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
													long num165 = Class64.GetSquaredCoordinateDistance(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
													if (num163 > 1500000L && num164 > 1500000L && num165 > 1500000L)
													{
														uint[,] array41 = HoaSonMapRouteHelper.GetNearestRouteSet(array6);
														num81 = Class64.GetNearestCoordinateSquaredDistance(array41, array6);
														if (num81 <= 300000L)
														{
															Class64.smethod_22(characterAccountConfig, array41, array6, null, num39, bool_0: false, 6000, bool_1: true);
															num8 = 0;
															int_2++;
															goto end_IL_04fe;
														}
														array12[0] = array41[0, 0];
														array12[1] = array41[0, 1];
													}
												}
												break;
											}
											case 53:
												if (num23 < 6 && num40 <= 0)
												{
													uint[] uint_16 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
													if (ViSonDaoRouteHelper.gstruct23_0 == null)
													{
														ViSonDaoRouteHelper.gstruct23_0 = ViSonDaoRouteHelper.smethod_1();
													}
													if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 > 0)
													{
														uint_16 = ViSonDaoRouteHelper.smethod_0(uint_16);
													}
													uint[,] array34 = MapTravelDataHelper.SelectBestRouteCoordinates(ViSonDaoRouteHelper.gstruct23_0, array6, uint_16);
													uint[] array35 = array6;
													int num157 = Class64.smethod_22(characterAccountConfig, array34, array6, uint_16, 53, bool_0: true, 8000);
													array6 = new uint[2]
													{
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
														WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
													};
													if (array35 != null && num157 > 0 && (array35[0] != array6[0] || array35[1] != array6[1]))
													{
														num23++;
														goto end_IL_04fe;
													}
													num23 = 6;
												}
												break;
											}
										}
										goto IL_324b;
									}
									int num167 = Map878NavigationHelper.NavigateWithinMap878(characterAccountConfig);
									if (num167 <= 0 && (!CharacterMovementHelper.IsMovementActive(characterAccountConfig) || CommonUtility.GetElapsedMilliseconds(long_3) > 4000L))
									{
										CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4);
										long_3 = CommonUtility.GetCurrentTicks();
										int_2++;
										num8 = 0;
									}
									break;
									IL_324b:
									if (TongKimBattlefieldHelper.FindBattlefieldMapGroupPosition(num39) != null && Form1.int_25 > 0)
									{
										int num168 = 0;
										if (num31 < 3)
										{
											num31++;
											num168++;
											string[] array43 = new string[2];
											if (Form1.int_99 > 0 && (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 != characterAccountConfig.int_136 || flag20))
											{
												uint[] uint_18 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
												if (flag20)
												{
													uint_18 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4;
												}
												array43 = TongKimBattlefieldHelper.GetNearestBattlefieldScoutExitSelection(num39, uint_18);
											}
											if (TongKimBattlefieldHelper.ExitBattlefieldViaScoutNpc(characterAccountConfig, array43[0], array43[1]) == 1)
											{
												num31 = 3;
											}
										}
										if (num168 == 0)
										{
											int num169 = TongKimBattlefieldHelper.ExitBattlefieldThroughGate(characterAccountConfig);
											if (num169 == 2)
											{
												NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
											}
											if (num169 <= 0)
											{
												num31 = 0;
											}
										}
									}
									if (array12 != null && array12[0] != 0 && array12[1] != 0)
									{
										if (!CharacterMovementHelper.IsMovementActive(characterAccountConfig) || CommonUtility.GetElapsedMilliseconds(long_3) > 3000L)
										{
											CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array12);
											long_3 = CommonUtility.GetCurrentTicks();
											int_2++;
											num8 = 0;
										}
										break;
									}
									goto IL_33f1;
									IL_43fe:
									num40 = (int)WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig.int_137);
									num39 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
									if (num40 > 0)
									{
										bool_ = true;
									}
									else if (!flag2 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 != num39 && Class64.smethod_9(num39) != null)
									{
										InterMapTravelHelper.UseTravelMenuForDestinationMap(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4);
										flag2 = true;
										break;
									}
									if (gstruct28_.uint_0 == null)
									{
										int num170 = NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig);
										GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig, 0, Convert.ToByte(num170 != 0));
										flag19 = false;
										flag21 = true;
										goto IL_469d;
									}
									array6 = new uint[2]
									{
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
										WindowsInteropHelper.ReadProcessUInt32(num36 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
									};
									int int_12 = 0;
									if (gstruct28_.uint_0.GetLength(0) > 1)
									{
										int_12 = Class64.FindNearestCoordinateIndex(gstruct28_.uint_0, array6);
									}
									if (num21 > 0)
									{
										WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
									}
									num21 = 0;
									Class64.ExtractCoordinateRow(gstruct28_.uint_0, int_12, ref uint_, ref uint_2, ref int_1);
									long num171 = Class64.GetSquaredCoordinateDistance(array6, uint_);
									if (num171 <= 90000L)
									{
										Class64.smethod_23(characterAccountConfig, uint_, int_1, uint_2, gstruct28_.int_1);
										break;
									}
									if (array == null)
									{
										array = new uint[2]
										{
											array6[0],
											array6[1]
										};
										int_2 = 0;
									}
									if (int_2 > 6)
									{
										long num172 = Class64.GetSquaredCoordinateDistance(array, array6);
										array = null;
										if (num172 < 180000L)
										{
											Class64.smethod_2(characterAccountConfig, array6, uint_, 600);
											break;
										}
									}
									if (!CharacterMovementHelper.IsMovementActive(characterAccountConfig) || CommonUtility.GetElapsedMilliseconds(long_3) > 4000L)
									{
										int_2++;
										CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, uint_);
										Thread.Sleep(300);
										Class64.TryShowStatusMessageIfDue(characterAccountConfig, "Acc chÝnh " + CharacterStateSyncCoordinator.characterSyncSnapshot_0.string_1 + " (" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 + ")");
										long_3 = CommonUtility.GetCurrentTicks();
									}
									Class64.SwitchHorseStateIfNeeded(characterAccountConfig, bool_0: false);
									break;
									IL_1349:
									if (characterAccountConfig.int_65 > 0)
									{
										Class64.smethod_3(characterAccountConfig, ref bool_2);
									}
									int num173 = Class85.GetInventoryEntryCount(characterAccountConfig);
									if (FormTapKet.smethod_0(characterAccountConfig.int_136) <= 0 || Class85.GetInventoryEntryCount(characterAccountConfig) <= num173)
									{
										break;
									}
									goto IL_138c;
									IL_4daf:
									num99 = 0;
									goto IL_51df;
									IL_33f1:
									int_2 = 0;
									array = null;
									array2 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4;
									flag6 = true;
									goto IL_469d;
									IL_4056:
									Thread.Sleep(100);
									break;
									continue;
									end_IL_04fe:
									break;
								}
							}
							else
							{
								if (characterAccountConfig.int_94 <= 0 && (Form1.int_42 <= 0 || Form1.int_41 <= 0))
								{
									num14 = 0;
								}
								flag9 = true;
							}
						}
						else
						{
							if (num42 <= 1)
							{
								bool_2 = false;
							}
							num31 = 0;
							Thread.Sleep(60);
						}
					}
					else
					{
						if (num21 > 0)
						{
							WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_6);
						}
						if (Form1.int_127 > 0)
						{
							WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num36 + GameConfigurationManager.memorySignatureScanConfig_251.uint_0, GameConfigurationManager.byte_0, GameConfigurationManager.byte_0.Length, ref int_6);
						}
						num21 = 0;
						num22 = 0;
						num26 = -1;
					}
				}
				else
				{
					Thread.Sleep(300);
				}
			}
			else
			{
				flag3 = false;
				Thread.Sleep(300);
			}
		}
	}
}
