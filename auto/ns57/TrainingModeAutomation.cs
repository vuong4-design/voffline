using System;
using System.IO;
using System.Text;
using System.Threading;
using ns1;
using ns10;
using ns100;
using ns11;
using ns119;
using ns13;
using ns23;
using ns24;
using ns28;
using ns29;
using ns3;
using ns31;
using ns33;
using ns35;
using ns36;
using ns39;
using ns42;
using ns43;
using ns44;
using ns50;
using ns53;
using ns59;
using ns61;
using ns68;
using ns71;
using ns79;
using ns81;
using ns83;
using ns85;
using ns88;
using ns91;

namespace ns57;

internal class TrainingModeAutomation
{
	public static int int_0 = 0;

	public static void Run(int int_1)
	{
		try
		{
			RunTrainingModeAutomation(int_1);
		}
		catch
		{
		}
	}

	public static int RunTrainingModeAutomation(int int_1)
	{
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		Random random = new Random();
		GStruct28 gStruct = default(GStruct28);
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		int int_2 = 0;
		int num4 = -1;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		uint[,] array = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array, 595);
		uint[,] array2 = array;
		bool bool_ = false;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		bool flag9 = false;
		uint[] array3 = null;
		uint[] array4 = null;
		int[,] array5 = null;
		uint[] uint_ = null;
		uint[] uint_2 = null;
		uint[] uint_3 = null;
		uint[] array6 = null;
		int num9 = -1;
		uint[] array7 = null;
		long long_ = 0L;
		int[] int_3 = null;
		long long_2 = 0L;
		long num10 = 0L;
		long long_3 = 0L;
		long long_4 = 0L;
		long long_5 = 0L;
		long long_6 = 0L;
		long long_7 = 0L;
		long long_8 = 0L;
		long long_9 = 0L;
		long long_10 = 0L;
		long long_11 = 0L;
		long num11 = 0L;
		long long_12 = 0L;
		long num12 = -1L;
		uint uint_4 = 0u;
		int num13 = -1;
		int num14 = 0;
		int int_4 = 0;
		int num15 = 0;
		int num16 = 0;
		int num17 = 0;
		int num18 = 0;
		int num19 = 0;
		byte[] byte_ = new byte[4];
		byte[] array8 = new byte[4];
		bool flag10 = false;
		while (true)
		{
			Thread.Sleep(200);
			int num20 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_1);
			if (CommonUtility.bool_0 || num20 < 0 || !Form1.characterAccountConfig_1[num20].bool_25 || Form1.characterAccountConfig_1[num20].int_25 <= 0)
			{
				break;
			}
			characterAccountConfig = Form1.characterAccountConfig_1[num20];
			if (characterAccountConfig.int_32 > 0 && characterAccountConfig.int_54 > 0 && characterAccountConfig.int_55 > 0)
			{
				FormLuomrac.RunTrashPickupAutomationSafely(int_1);
				continue;
			}
			if (characterAccountConfig.bool_15)
			{
				Thread.Sleep(100);
				continue;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, array8, 4, ref int_4);
			uint num21 = BitConverter.ToUInt32(array8, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num21 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, array8, 4, ref int_4);
			uint num22 = BitConverter.ToUInt32(array8, 0);
			uint num23 = num22 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, array8, 4, ref int_4);
			uint num24 = BitConverter.ToUInt32(array8, 0);
			uint num25 = num24 + num23;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num25, array8, 4, ref int_4);
			uint num26 = BitConverter.ToUInt32(array8, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, array8, 4, ref int_4);
			int num27 = BitConverter.ToInt32(array8, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array8, 4, ref int_4);
			int num28 = BitConverter.ToInt32(array8, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, array8, 4, ref int_4);
			int num29 = BitConverter.ToInt32(array8, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, array8, 4, ref int_4);
			int num30 = BitConverter.ToInt32(array8, 0);
			int num31 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig);
			int num37;
			int num38;
			bool flag11;
			bool flag12;
			int num57;
			uint num59;
			uint uint_6;
			int int_8;
			long long_13;
			uint[] array9;
			if (num28 != 0 && num27 != 0 && num29 != 0 && num27 != 10 && num27 != 21 && num31 > 1)
			{
				int num32 = (int)WindowsInteropHelper.ReadProcessUInt32(num21 + GameConfigurationManager.memorySignatureScanConfig_30.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_65.resolvedValue, characterAccountConfig.int_137);
				array9 = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
				};
				if (array9[0] == 0 || array9[1] == 0)
				{
					continue;
				}
				if (!flag10)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_23 * 4, array8, 1, ref int_4);
					if (array8[0] > 0)
					{
						flag2 = false;
						characterAccountConfig.bool_12 = false;
						array8[0] = 0;
						WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_23 * 4, array8, 1, ref int_4);
						num20 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_1);
						if (0 <= num20)
						{
							Form1.characterAccountConfig_1[num20].bool_12 = false;
						}
					}
					int j;
					if (num2 == num30 && num == num29)
					{
						if (CommonUtility.GetElapsedMilliseconds(long_7) > 30000L)
						{
							int_3 = null;
							long_7 = CommonUtility.GetCurrentTicks();
						}
						if (num30 > 0 && GameInterfaceMemoryHelper.ReadEngineStateByte(characterAccountConfig) > 0)
						{
							if (num19 > 0)
							{
								WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
							}
							num19 = 0;
							num17++;
							if (num17 > 2)
							{
								num4 = -1;
							}
							if (Form1.mouseDragPatchEnabled > 0)
							{
								WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_251.resolvedValue, GameConfigurationManager.byte_0, GameConfigurationManager.byte_0.Length, ref int_4);
							}
							continue;
						}
						num17 = 0;
						int num33 = Class85.GetInventoryEntryCount(characterAccountConfig);
						if (num7 != num33 || CommonUtility.GetElapsedMilliseconds(long_10) > 60000L)
						{
							num15 += Convert.ToByte(!characterAccountConfig.bool_7 && num7 != num33 && characterAccountConfig.int_37 > 0 && int_0 <= 0 && num30 > 0);
							num16 += Convert.ToByte(num7 < num33 && characterAccountConfig.int_60 != null && characterAccountConfig.int_60[0] > 0 && num30 > 0);
							num7 = num33;
							long_10 = CommonUtility.GetCurrentTicks();
						}
						if (num16 > 0)
						{
							if (num16 == 1)
							{
								int[,] array10 = Class85.GetFittableInventoryItemSizes(characterAccountConfig);
								int length = array10.GetLength(0);
								int num34 = 0;
								for (int i = 0; i < length; i++)
								{
									if (array10[i, 0] > 0)
									{
										int num35 = array10[i, 1] * array10[i, 2];
										if (num34 < num35)
										{
											num34 = num35;
										}
									}
								}
								int[] array11 = new int[5] { 1, 2, 3, 4, 6 };
								int num36 = array11[characterAccountConfig.int_60[1]];
								if (num36 <= num34)
								{
									num16 = 0;
								}
							}
							if (num16 > 0 && CommonUtility.GetElapsedMilliseconds(long_6) > 1000L)
							{
								long_6 = CommonUtility.GetCurrentTicks();
								num16 = 0;
								if (Class32.IsMapIdInSpecialAutomationSet(num29))
								{
									flag3 = true;
									continue;
								}
								if (!Class64.TryUseTownTeleportItem(characterAccountConfig) && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
								{
									MapNavigationHelper.NavigateToDestination(characterAccountConfig, 1, "t©m");
								}
							}
						}
						if (num15 > 0)
						{
							if (num14 <= 0)
							{
								num14 = characterAccountConfig.int_38;
								if (num14 > 1000)
								{
									num14 = random.Next(num14 - 1000, num14 + 1000);
								}
							}
							if (CommonUtility.GetElapsedMilliseconds(long_9) > num14)
							{
								num15 = 0;
								int_0 = int_1;
								long_9 = CommonUtility.GetCurrentTicks();
								num14 = 0;
								new Thread(RunContainerThreeInventoryCompactionLoop).Start();
							}
						}
						if (characterAccountConfig.int_104[0] > 0 && characterAccountConfig.int_104[1] <= num32)
						{
							if (num30 <= 0)
							{
								j = 0;
								byte[] array12 = CommonUtility.ConvertStringToSingleByteArray("Kh«ng thÓ tiÕp tôc v× PK qu\u00b8 cao (co the thay doi trong muc Hau can).");
								for (; j < 6; j++)
								{
									WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_251.resolvedValue, array12, array12.Length, ref int_4);
									Thread.Sleep(100);
								}
								continue;
							}
							if (Class32.IsMapIdInSpecialAutomationSet(num29))
							{
								if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.accountId > 0)
								{
									GameProcessInteractionHelper.SendPrivatePlayerMessage(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.characterName, GameTextEncodingHelper.ConvertDisplayTextToGameText("Thoát game vì PK quá cao, Thím có thể thiết lập lại trong mục Hậu cần nhé."));
									Thread.Sleep(600);
								}
								WindowsInteropHelper.TryKillProcess(characterAccountConfig.process_0);
							}
							else if (!Class64.TryUseTownTeleportItem(characterAccountConfig) && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
							{
								MapNavigationHelper.NavigateToDestination(characterAccountConfig, 162, "b¾c");
							}
						}
						num37 = 0;
						if (characterAccountConfig.uint_0 != null)
						{
							num37 = characterAccountConfig.uint_0.GetLength(0);
						}
						num38 = 302500;
						if (characterAccountConfig.int_98 > 0 && characterAccountConfig.int_99 > 0)
						{
							num38 = characterAccountConfig.int_99 * characterAccountConfig.int_99;
						}
						flag11 = characterAccountConfig.int_119 > 0 && characterAccountConfig.int_3 != null && characterAccountConfig.int_4 != null;
						flag12 = Form1.findMainAccountEnabled > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.accountId > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.accountId != characterAccountConfig.int_136 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.mapId == num29 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.fightState == num30 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.fightState > 0 && CommonUtility.IsNonZeroCoordinatePair(CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates) && CharacterStateSyncCoordinator.characterSyncSnapshot_0.bool_2;
						if (num30 > 0)
						{
							if (!flag2 && (flag3 || (flag3 = characterAccountConfig.bool_12 && (characterAccountConfig.int_115 > 0 || characterAccountConfig.int_117 > 0))))
							{
								uint[] array13 = null;
								uint[] array14 = null;
								if (!flag7 && num29 == 341)
								{
									int num39 = Class64.FindNearestCoordinateIndex(array2, array9);
									if (0 <= num39)
									{
										array14 = new uint[2]
										{
											array2[num39, 0],
											array2[num39, 1]
										};
									}
								}
								if (!flag7 && array14 != null)
								{
									if (Class64.GetSquaredCoordinateDistance(array9, array14) >= 22500L)
									{
										array13 = new uint[2]
										{
											array14[0],
											array14[1]
										};
									}
									else
									{
										flag7 = true;
									}
								}
								if (array13 == null)
								{
									array13 = MapTravelDataHelper.FindNearestNamedMapPointCoordinates(array9, num29, "HIEUTHUOC", bool_0: false);
								}
								if (array13 != null)
								{
									if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.accountId == characterAccountConfig.int_136)
									{
										CharacterStateSyncCoordinator.characterSyncSnapshot_0.bool_2 = false;
									}
									flag6 = false;
									flag9 = characterAccountConfig.int_30 <= 0;
									if (num19 > 0)
									{
										WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
									}
									num19 = 0;
									EnsureHorseStateForTrainingMode(characterAccountConfig, num25, ref long_3, bool_0: true);
									long num40 = Class64.GetSquaredCoordinateDistance(array9, array13);
									if (num40 >= 250000L)
									{
										if (CommonUtility.GetElapsedMilliseconds(long_2) > 3000L)
										{
											CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array13);
											long_2 = CommonUtility.GetCurrentTicks();
										}
									}
									else
									{
										GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array13);
										Thread.Sleep(100);
									}
									Thread.Sleep(150);
									flag3 = true;
									continue;
								}
								if (CommonUtility.GetElapsedMilliseconds(long_6) > 1000L && !Class32.IsMapIdInSpecialAutomationSet(num29))
								{
									if (!Class64.TryUseTownTeleportItem(characterAccountConfig) && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
									{
										MapNavigationHelper.NavigateToDestination(characterAccountConfig, 1, "t©m");
									}
									long_6 = CommonUtility.GetCurrentTicks();
								}
							}
							if (characterAccountConfig.int_26 > 0 && !characterAccountConfig.bool_6 && CommonUtility.GetElapsedMilliseconds(long_11) > 60000L)
							{
								HuyenTinhAutomation.ActiveCharacterId = int_1;
								new Thread(new HuyenTinhAutomation().CraftHuyenTinh).Start();
								long_11 = CommonUtility.GetCurrentTicks();
							}
						}
						else
						{
							if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.accountId == characterAccountConfig.int_136)
							{
								CharacterStateSyncCoordinator.characterSyncSnapshot_0.bool_2 = false;
							}
							num10 = 0L;
							flag6 = false;
							flag7 = false;
							flag3 = false;
							int_3 = null;
							flag8 = false;
							flag9 = characterAccountConfig.int_30 <= 0;
							num16 = 0;
							num15 = 0;
							if (!flag2)
							{
								EnsureHorseStateForTrainingMode(characterAccountConfig, num25, ref long_3, bool_0: true);
								if (characterAccountConfig.int_46 != null && characterAccountConfig.int_46[0] > 0)
								{
									ProcessConfiguredInventoryItemList(characterAccountConfig);
								}
								if (characterAccountConfig.int_53 != null && (characterAccountConfig.int_53[0] > 0 || characterAccountConfig.int_53[1] > 0 || characterAccountConfig.int_53[2] > 0 || characterAccountConfig.int_53[3] > 0 || characterAccountConfig.int_53[4] > 0))
								{
									MoveConfiguredItemsToStorageContainers(characterAccountConfig);
								}
								if (ItemPurchaseUseAutomation.EnsureReturnScrollAvailable(characterAccountConfig) == 0 || MedicineRestockAutomation.RestockConfiguredMedicines(characterAccountConfig, Form1.buyMedicineInVillageEnabled <= 0) == 0)
								{
									continue;
								}
								flag2 = true;
								long num41 = WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_45.resolvedValue, characterAccountConfig.int_137);
								long num42 = WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_47.resolvedValue, characterAccountConfig.int_137) + 1;
								long num43 = WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_47.resolvedValue + 4, characterAccountConfig.int_137) + 1;
								long num44 = WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_46.resolvedValue, characterAccountConfig.int_137);
								long num45 = WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_48.resolvedValue, characterAccountConfig.int_137) + 1;
								long num46 = WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_48.resolvedValue + 4, characterAccountConfig.int_137) + 1;
								if (num43 > num42 && num43 < 150000L)
								{
									num42 = num43;
								}
								if (num46 > num45 && num46 < 150000L)
								{
									num45 = num46;
								}
								double num47 = num41 * 100L / num42;
								double num48 = num44 * 100L / num45;
								if (num42 > 100L && num47 <= 60.0)
								{
									Class32.UseInventoryItemsByGenre(characterAccountConfig, 0);
								}
								if (num45 > 50L && num48 <= 60.0)
								{
									Class32.UseInventoryItemsByGenre(characterAccountConfig, 1);
								}
								Thread.Sleep(600);
								num7 = Class85.GetInventoryEntryCount(characterAccountConfig);
								if (characterAccountConfig.int_65 > 0)
								{
									Class64.BalanceCarriedMoneyToConfiguredAmount(characterAccountConfig, ref bool_);
								}
								if (characterAccountConfig.int_25 > 0 && characterAccountConfig.int_26 > 0 && characterAccountConfig.int_28 > 0)
								{
									uint num49 = CurrentCharacterMemoryHelper.GetCharacterMoneyValue(characterAccountConfig);
									if (num49 < 2000)
									{
										GameProcessInteractionHelper.TransferStoredMoneyToCharacter(characterAccountConfig, 2000 - num49);
									}
								}
								continue;
							}
						}
						if (num30 <= 0 && Class64.FindTravelHubGroupPosition(num29) != null)
						{
							if (flag5)
							{
								flag5 = false;
								InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig, "®iÓm c");
								Class64.WaitForGameSessionReady(characterAccountConfig);
								continue;
							}
							num4 = -1;
							if (!flag4 && num29 != characterAccountConfig.int_32)
							{
								flag4 = true;
								InterMapTravelHelper.UseTravelMenuForDestinationMap(characterAccountConfig, characterAccountConfig.int_32);
								Class64.WaitForGameSessionReady(characterAccountConfig);
								continue;
							}
						}
						if (num29 != characterAccountConfig.int_32)
						{
							num4 = -1;
							if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
							{
								int num50 = characterAccountConfig.int_32;
								int num51 = MapNavigationHelper.FindNavigationEntryIndex(num50);
								if (num51 < 0 && characterAccountConfig.int_32 == 76)
								{
									num50 = 75;
									num51 = MapNavigationHelper.FindNavigationEntryIndex(75);
								}
								if (0 <= num51 && MapNavigationHelper.NavigateToDestination(characterAccountConfig, num50))
								{
									Thread.Sleep(300);
									Class64.WaitForGameSessionReady(characterAccountConfig);
									Thread.Sleep(600);
									int num52 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig.int_137);
									if (num52 != num29)
									{
										continue;
									}
								}
								else if (num29 != 103 && num29 != 114 && num29 != 110 && (characterAccountConfig.int_32 == 110 || characterAccountConfig.int_32 == 114) && MapNavigationHelper.NavigateToDestination(characterAccountConfig, 103))
								{
									Thread.Sleep(300);
									Class64.WaitForGameSessionReady(characterAccountConfig);
									Thread.Sleep(600);
									int num53 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig.int_137);
									if (num53 != num29)
									{
										continue;
									}
								}
							}
							gStruct = MapTravelDataHelper.FindTravelConnection(num29, characterAccountConfig.int_32);
							if (gStruct.int_0 != num29 || gStruct.int_1 != characterAccountConfig.int_32)
							{
								int num54 = Class64.FindTravelHubMapTowardDestination(num29, characterAccountConfig.int_32, ref gStruct);
								if (num54 != 0)
								{
									if (num54 > 0)
									{
										int[] array15 = Class64.FindTravelHubGroupPosition(num29);
										if (array15 != null)
										{
											if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0 && num8 < 3)
											{
												num8++;
												if (MapNavigationHelper.NavigateToDestination(characterAccountConfig, num54))
												{
													continue;
												}
											}
											InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig, num54);
											num8 = 0;
										}
										else if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
										{
											uint[] uint_5 = null;
											if (Class64.FindTravelHubMapTowardDestination(num54, characterAccountConfig.int_32, ref gStruct) == 0 && gStruct.uint_0 != null)
											{
												uint_5 = new uint[2]
												{
													gStruct.uint_0[0, 0],
													gStruct.uint_0[0, 1]
												};
											}
											if (!MapNavigationHelper.NavigateToDestination(characterAccountConfig, num54, null, uint_5))
											{
												MapNavigationHelper.NavigateToDestination(characterAccountConfig, 1, "t©m");
											}
											continue;
										}
									}
									if (gStruct.int_0 != num29 || gStruct.int_1 != characterAccountConfig.int_32)
									{
										num30 = (int)WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig.int_137);
										if (num30 <= 0)
										{
											if (CommonUtility.GetElapsedMilliseconds(long_12) > 30000L)
											{
												string text = "Kh«ng t×m ®\u00adîc ®\u00adêng lªn b·i train.";
												if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
												{
													text += " Xem l¹i tab Cµi game cña auto ®· thiÕt lËp ®óng trang web sö dông hay ch\u00ada ?";
												}
												GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, text);
												long_12 = CommonUtility.GetCurrentTicks();
											}
										}
										else if (characterAccountConfig.int_59 > 0 && num29 > 0 && !Class32.IsMapIdInSpecialAutomationSet(num29))
										{
											Class64.TryUseTownTeleportItem(characterAccountConfig);
										}
										goto IL_24dc;
									}
								}
							}
							if (gStruct.uint_0 != null)
							{
								if (num19 > 0)
								{
									WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
								}
								num19 = 0;
								EnsureHorseStateForTrainingMode(characterAccountConfig, num25, ref long_3, bool_0: true);
								array9 = new uint[2]
								{
									WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
									WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
								};
								int int_5 = 0;
								int int_6 = 0;
								if (gStruct.uint_0.GetLength(0) > 1)
								{
									int_5 = Class64.FindNearestCoordinateIndex(gStruct.uint_0, array9);
								}
								Class64.ExtractCoordinateRow(gStruct.uint_0, int_5, ref uint_, ref uint_2, ref int_6);
								if (Class64.GetSquaredCoordinateDistance(array9, uint_) <= 90000L)
								{
									Class64.TriggerMapTransitionAtCoordinate(characterAccountConfig, uint_, int_6, uint_2, gStruct.int_1);
								}
								else if (CommonUtility.GetElapsedMilliseconds(long_2) > 3000L)
								{
									CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, uint_);
									Thread.Sleep(300);
									long_2 = CommonUtility.GetCurrentTicks();
								}
								continue;
							}
							int num55 = NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig);
							GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig, 0, Convert.ToByte(num55 != 0));
						}
						else
						{
							if (num30 <= 0)
							{
								num4 = -1;
							}
							if (num29 == characterAccountConfig.int_32)
							{
								if (characterAccountConfig.int_93 == 0)
								{
									EnsureHorseStateForTrainingMode(characterAccountConfig, num25, ref long_3, bool_0: true);
								}
								else if (characterAccountConfig.int_93 == 1)
								{
									if (flag6)
									{
										EnsureHorseStateForTrainingMode(characterAccountConfig, num25, ref long_3, bool_0: false);
									}
								}
								else if (WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_44.resolvedValue, characterAccountConfig.int_137) != 0)
								{
									int num56 = GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_46, 4);
									if (num56 > 0)
									{
										EnsureHorseStateForTrainingMode(characterAccountConfig, num25, ref long_3, bool_0: false);
									}
								}
								flag8 = false;
								if (num30 > 0)
								{
									flag2 = false;
									flag4 = false;
									flag5 = true;
									num57 = characterAccountConfig.int_96;
									int num58 = characterAccountConfig.int_52 * characterAccountConfig.int_52;
									num59 = (uint)CharacterSkillHelper.ReadLeftSkillId(characterAccountConfig);
									if (characterAccountConfig.int_95 <= 0)
									{
										num57 = (int)WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_31.resolvedValue, characterAccountConfig.int_137);
										if (num59 != 53 && num59 > 1)
										{
											if (num57 <= 100)
											{
												num57 = 400;
											}
										}
										else
										{
											num57 = 75;
										}
									}
									if (characterAccountConfig.int_61 > 0 && !characterAccountConfig.bool_9 && (!flag12 || !ItemPickupFilterAutomation.pickupActionInProgress))
									{
										if (!flag12 && array6 != null)
										{
											uint num60 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.resolvedValue, characterAccountConfig.int_137);
											uint num61 = num60 + array6[0] * GameConfigurationManager.memorySignatureScanConfig_127.resolvedValue;
											int int_7 = 0;
											byte[] array16 = new byte[1];
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num61 + GameConfigurationManager.memorySignatureScanConfig_138.resolvedValue, array16, 1, ref int_7);
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num61 + GameConfigurationManager.memorySignatureScanConfig_137.resolvedValue, array8, 4, ref int_7);
											if (array16[0] == 0 || BitConverter.ToInt32(array8, 0) <= 0)
											{
												array6 = null;
											}
										}
										if (flag12 || array6 == null)
										{
											array6 = ItemPickupFilterAutomation.FindPickupCandidate(characterAccountConfig, array3, !flag12, Form1.findMainAccountEnabled > 0);
										}
										if (!flag12 && array6 != null)
										{
											uint[] array17 = new uint[2]
											{
												array6[2],
												array6[3]
											};
											long num62 = Class64.GetSquaredCoordinateDistance(array9, array17);
											if (num62 <= num58)
											{
												num10 = 0L;
												if (num9 == array6[0] && array7 != null && array7[0] == array6[2] && array7[1] == array6[3])
												{
													uint_6 = array6[0];
													int_8 = (int)array6[4];
													long_13 = 0L;
													long num63 = CommonUtility.GetElapsedMilliseconds(long_);
													if (num63 > 6000L)
													{
														goto IL_1659;
													}
													if (num63 > 1500L)
													{
														if (characterAccountConfig.int_27 <= 0 || characterAccountConfig.int_99 <= 1)
														{
															flag8 = false;
															goto IL_16ce;
														}
														string string_ = GameInterfaceMemoryHelper.ReadLatestBottomChannelText(characterAccountConfig);
														if (0 < CommonUtility.FindSubstringIndex(string_, "qu\u00b8 xa") || 0 < CommonUtility.FindSubstringIndex(string_, "o¶ng trèn"))
														{
															long_13 = CommonUtility.GetCurrentTicks() - ItemPickupFilterAutomation.IgnoredGroundItemDurationMs + 6000L;
															GameInterfaceMemoryHelper.WriteLatestBottomChannelText(characterAccountConfig, "0K..");
															if (WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_44.resolvedValue, characterAccountConfig.int_137) == 0)
															{
																GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig, "Switch([[sit]])");
															}
															goto IL_1659;
														}
													}
												}
												else
												{
													num9 = (int)array6[0];
													array7 = new uint[2]
													{
														array6[2],
														array6[3]
													};
													long_ = CommonUtility.GetCurrentTicks();
												}
												flag8 = true;
												if (num62 > 40000L)
												{
													GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array17);
													Thread.Sleep(150);
												}
												GameProcessInteractionHelper.PickupGroundObjectByIndex(characterAccountConfig, array6[0]);
											}
										}
									}
									goto IL_16ce;
								}
								flag = true;
								goto IL_1ee3;
							}
						}
						goto IL_24dc;
					}
					CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
					if (num19 > 0)
					{
						WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
					}
					num19 = 0;
					j = 0;
					while (num30 == 0 && j < 3 && num30 != num2)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, array8, 4, ref int_4);
						num21 = BitConverter.ToUInt32(array8, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num21 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, array8, 4, ref int_4);
						num22 = BitConverter.ToUInt32(array8, 0);
						num23 = num22 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, array8, 4, ref int_4);
						num24 = BitConverter.ToUInt32(array8, 0);
						num25 = num24 + num23;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array8, 4, ref int_4);
						num28 = BitConverter.ToInt32(array8, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, array8, 4, ref int_4);
						num29 = BitConverter.ToInt32(array8, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, array8, 4, ref int_4);
						num30 = BitConverter.ToInt32(array8, 0);
						Thread.Sleep(100);
						j++;
					}
					num = num29;
					num2 = num30;
					if (num30 <= 0)
					{
						NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
					}
					continue;
				}
				flag10 = false;
				flag5 = false;
				Thread.Sleep(300);
				continue;
			}
			flag10 = num27 == 10 || num27 == 21;
			continue;
			IL_17b0:
			array5 = null;
			int num65;
			int num66;
			uint[] array18;
			uint num67;
			if (!characterAccountConfig.bool_22 && characterAccountConfig.int_99 > 1 && (characterAccountConfig.int_27 > 0 || Form1.attackPlayersEnabled > 0))
			{
				uint uint_7 = 0u;
				uint[] uint_8 = array9;
				if (flag12)
				{
					if (Form1.shareTargetEnabled > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.mapId == num29 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.currentTargetEntityId != 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.currentTargetEntityId != num26)
					{
						uint_7 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.currentTargetEntityId;
					}
					uint_8 = array3;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_16 + GameProcessInteractionHelper.uint_43 * 4, array8, 4, ref int_4);
				characterAccountConfig.int_97 = BitConverter.ToInt32(array8, 0);
				int int_9 = 600;
				if (characterAccountConfig.int_98 > 0)
				{
					int_9 = characterAccountConfig.int_99;
				}
				int num64 = characterAccountConfig.int_97;
				if (characterAccountConfig.int_95 > 0 && characterAccountConfig.int_96 > 0)
				{
					num64 = characterAccountConfig.int_96;
				}
				if (num64 <= 0)
				{
					num64 = 500;
				}
				array5 = CombatTargetSelectionHelper.FindTrainingTargetCandidates(characterAccountConfig, uint_7, int_9, uint_8, int_3, bool_1: true);
				if (array5 != null && array5[0, 0] >= 0)
				{
					num65 = array5[0, 0];
					num66 = array5[0, 1];
					array18 = new uint[2]
					{
						(uint)array5[0, 4],
						(uint)array5[0, 5]
					};
					num67 = num24 + (uint)(num66 * (int)GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue);
					if (num65 <= 0)
					{
						goto IL_1b6b;
					}
					bool flag13 = false;
					if (characterAccountConfig.int_33 == 1)
					{
						if (!Class32.IsMapIdInSpecialAutomationSet(num29))
						{
							if (num65 > 0)
							{
								byte[] array19 = new byte[60];
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num67 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array19, array19.Length, ref int_4);
								string string_2 = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array19);
								uint[] uint_9 = new uint[2]
								{
									array18[0],
									array18[1]
								};
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num67 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, array8, 4, ref int_4);
								int int_10 = BitConverter.ToInt32(array8, 0);
								LogDosatEventAndOptionallySendGuildAlert(characterAccountConfig, string_2, int_10, uint_9);
							}
							Class64.TryUseTownTeleportItem(characterAccountConfig);
							Thread.Sleep(150);
							if (Form1.townPortalWaitMilliseconds > 0)
							{
								Thread.Sleep(Form1.townPortalWaitMilliseconds);
							}
						}
						flag13 = true;
					}
					if (characterAccountConfig.int_33 != 0 && !flag13)
					{
						if (characterAccountConfig.int_33 != 2)
						{
							if (characterAccountConfig.int_33 != 3)
							{
								goto IL_1b6b;
							}
							string text2 = GameTextEncodingHelper.ConvertDisplayTextToGameText("Thoát game vì bị đồ sát.");
							if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.accountId > 0 && characterAccountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.accountId)
							{
								GameProcessInteractionHelper.SendPrivatePlayerMessage(characterAccountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_0.characterName, text2);
							}
							GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig, "Chat('CH_TONG', '" + text2 + "')");
							Thread.Sleep(150);
							WindowsInteropHelper.TryKillProcess(characterAccountConfig.process_0);
						}
						goto IL_1d06;
					}
					if (num19 > 0)
					{
						WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
					}
					num19 = 0;
					if (num37 <= 1)
					{
						uint[] uint_10 = ((num37 != 1 || array3 == null || Class64.GetSquaredCoordinateDistance(array9, array3) <= 500000L) ? Class64.GetCoordinateOffsetAlongLine(array18, array9, 600) : array3);
						GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, uint_10);
						Thread.Sleep(100);
						goto IL_24dc;
					}
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			goto IL_1ee3;
			IL_2483:
			if (flag12 && CharacterStateSyncCoordinator.RefreshTrackedEntityPositionAndDetectSeparation(num26, ref array9, ref uint_4) > 0)
			{
				CommonUtility.GetCurrentTicks();
				if (num19 > 0)
				{
					WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
				}
				num19 = 0;
				CharacterStateSyncCoordinator.MoveTowardCoordinateWithOffset(characterAccountConfig, array9, uint_3);
			}
			goto IL_24dc;
			IL_24dc:
			if (GameInterfaceMemoryHelper.ReadEngineStateByte(characterAccountConfig) <= 0 && WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig.int_137) != 0 && characterAccountConfig.bool_58 && characterAccountConfig.int_83 > 0 && Form1.moveNearTargetHotkeyEnabled > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.lastVirtualKeyCode == KeyboardKeyCatalog.gstruct42_0[Form1.moveNearTargetHotkeyIndex].int_0)
			{
				CurrentCharacterMemoryHelper.MoveNearSkillTargetPosition(characterAccountConfig, null, bool_0: true);
				if (CommonUtility.GetElapsedMilliseconds(long_4) > characterAccountConfig.long_9)
				{
					CurrentCharacterMemoryHelper.CastMaAmPhePhachAtCurrentPosition(characterAccountConfig);
					long_4 = CommonUtility.GetCurrentTicks();
				}
			}
			continue;
			IL_1ee3:
			if ((flag || array5 == null || array5[0, 0] < 0 || array5[0, 1] <= 0) && !flag8)
			{
				flag = false;
				num3 = -1;
				array9 = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
				};
				if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.accountId == characterAccountConfig.int_136)
				{
					CharacterStateSyncCoordinator.characterSyncSnapshot_0.bool_2 = flag6 || characterAccountConfig.uint_0 == null || num37 <= 0;
				}
				if (num11 <= 0L || CommonUtility.GetElapsedMilliseconds(num11) >= 1000L)
				{
					uint[] array20 = null;
					long num68 = 0L;
					array20 = Class64.FindConfiguredTargetCharacterCoordinates(characterAccountConfig, ref int_2);
					if (array20 != null)
					{
						num11 = 0L;
						array3 = array20;
						num68 = Class64.GetSquaredCoordinateDistance(array9, array20);
						if (num68 >= 8000L)
						{
							if (num19 > 0)
							{
								WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
							}
							num19 = 0;
							if (num68 >= 15000L && num68 >= characterAccountConfig.int_68[1] * characterAccountConfig.int_68[1])
							{
								if (num68 < 360000L)
								{
									CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
									GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array20);
									Thread.Sleep(100);
								}
								else
								{
									if (num68 >= 1200000L)
									{
										goto IL_2128;
									}
									if (CommonUtility.GetElapsedMilliseconds(long_2) > 3000L)
									{
										CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array20);
										long_2 = CommonUtility.GetCurrentTicks();
									}
								}
							}
							else if (num27 <= 3 && num68 > 7500L)
							{
								GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array20);
								Thread.Sleep(100);
							}
						}
						goto IL_24dc;
					}
					num11 = CommonUtility.GetCurrentTicks();
				}
				goto IL_2128;
			}
			goto IL_24dc;
			IL_23ec:
			flag9 = characterAccountConfig.int_30 <= 0;
			if (array4 == null || Class64.GetSquaredCoordinateDistance(array9, array4) > 90000L)
			{
				array4 = new uint[2]
				{
					array9[0],
					array9[1]
				};
				num6 = 0;
			}
			if (num6 > 5)
			{
				Class64.MoveToApproachCoordinateAndWaitForMovementState(characterAccountConfig, array9, array3, 800);
				array4 = null;
			}
			if (!flag6)
			{
				EnsureHorseStateForTrainingMode(characterAccountConfig, num25, ref long_3, bool_0: true);
			}
			if (CommonUtility.GetElapsedMilliseconds(long_2) > 2500L)
			{
				CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array3);
				long_2 = CommonUtility.GetCurrentTicks();
				num6++;
			}
			goto IL_2483;
			IL_1d06:
			long num69 = Class64.GetSquaredCoordinateDistance(array3, array18);
			long num70 = Class64.GetSquaredCoordinateDistance(array9, array3);
			if (num69 <= num38 && (!flag12 || num70 <= Form1.mainAccountSearchDistance * Form1.mainAccountSearchDistance))
			{
				if (flag11)
				{
					int num71 = -1;
					while (!CommonUtility.bool_0)
					{
						num13++;
						if (num13 < 0 || characterAccountConfig.int_3.GetLength(0) <= num13)
						{
							num13 = 0;
						}
						if (num71 >= 0)
						{
							if (num71 == num13)
							{
								num13 = -1;
								break;
							}
						}
						else
						{
							num71 = num13;
						}
						if (characterAccountConfig.int_3[num13, 0] > 0)
						{
							int num72 = CommonUtility.FindIntMatrixRowIndex(characterAccountConfig.int_4, characterAccountConfig.int_3[num13, 0], 0);
							if (num72 >= 0 && GameEntityMemoryHelper.GetEntityActiveEffectIdForSkill(characterAccountConfig, num66, characterAccountConfig.int_3[num13, 0]) != 0)
							{
								num59 = (uint)characterAccountConfig.int_3[num13, 0];
								break;
							}
						}
					}
				}
				if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_6, 4) <= 0)
				{
					CurrentCharacterMemoryHelper.SetCharacterAttackRange(characterAccountConfig, num57);
					CharacterSkillHelper.WriteSelectedSkillIdToCharacterMemory(characterAccountConfig, num59);
					WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, BitConverter.GetBytes(num66), 4, ref int_4);
				}
				if (characterAccountConfig.bool_58 && characterAccountConfig.int_83 > 0 && Form1.moveNearTargetHotkeyEnabled == 0 && CommonUtility.GetElapsedMilliseconds(long_4) > characterAccountConfig.long_9)
				{
					CurrentCharacterMemoryHelper.MoveNearSkillTargetPosition(characterAccountConfig, array18, bool_0: false);
					CurrentCharacterMemoryHelper.CastMaAmPhePhachAtCurrentPosition(characterAccountConfig);
					long_4 = CommonUtility.GetCurrentTicks();
				}
				num10 = 0L;
				num19 = 1;
				if (flag12)
				{
					goto IL_2483;
				}
				goto IL_24dc;
			}
			flag = true;
			if (num19 > 0)
			{
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
			}
			num19 = 0;
			goto IL_1ee3;
			IL_16ce:
			array9 = new uint[2]
			{
				WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
				WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
			};
			if (flag9)
			{
				flag = true;
			}
			else
			{
				if (characterAccountConfig.int_101[0] <= 0 || characterAccountConfig.int_101[1] <= 0 || !(characterAccountConfig.string_23 == "NGAMY"))
				{
					goto IL_17b0;
				}
				long num73 = CommonUtility.GetElapsedMilliseconds(long_5);
				if (num73 >= 300L)
				{
					if (num73 <= characterAccountConfig.int_101[4] || !CombatTargetSelectionHelper.TryApplyConfiguredNgamyBuff(characterAccountConfig))
					{
						goto IL_17b0;
					}
					Thread.Sleep(80);
					long_5 = CommonUtility.GetCurrentTicks();
					flag = true;
				}
				else
				{
					flag = true;
				}
			}
			goto IL_1ee3;
			IL_1659:
			ItemPickupFilterAutomation.RecordIgnoredGroundItem(ref characterAccountConfig.gstruct40_0, uint_6, int_8, long_13);
			num9 = -1;
			array6 = null;
			long_ = CommonUtility.GetCurrentTicks();
			flag8 = false;
			goto IL_16ce;
			IL_1b6b:
			int num74 = (int)WindowsInteropHelper.ReadProcessUInt32(num67 + GameConfigurationManager.memorySignatureScanConfig_26.resolvedValue + 8, characterAccountConfig.int_137);
			int num75 = (int)WindowsInteropHelper.ReadProcessUInt32(num67 + GameConfigurationManager.memorySignatureScanConfig_26.resolvedValue + 12, characterAccountConfig.int_137);
			int num76 = (int)WindowsInteropHelper.ReadProcessUInt32(num67 + GameConfigurationManager.memorySignatureScanConfig_51.resolvedValue, characterAccountConfig.int_137);
			if (characterAccountConfig.int_57 > 0 && num65 <= 0 && num74 > 0 && num75 > 15 && num76 > 0)
			{
				flag = true;
				goto IL_1ee3;
			}
			if (num74 <= 0 || num75 <= 15 || num76 <= 0)
			{
				if (num3 == num66)
				{
					long num77 = WindowsInteropHelper.ReadProcessUInt32(num67 + GameConfigurationManager.memorySignatureScanConfig_45.resolvedValue, characterAccountConfig.int_137);
					if (num77 < num12)
					{
						long_8 = CommonUtility.GetCurrentTicks();
						num12 = num77;
					}
					else
					{
						long num78 = CommonUtility.GetElapsedMilliseconds(long_8);
						if (num78 >= 7000L)
						{
							if (num19 > 0)
							{
								WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
							}
							num19 = 0;
							CommonUtility.AppendIntIfMissing(ref int_3, num3);
							num4 = -1;
							num5 = 0;
							num3 = -1;
							if (WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_44.resolvedValue, characterAccountConfig.int_137) == 0)
							{
								GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig, "Switch([[sit]])");
								Thread.Sleep(600);
							}
							long_8 = CommonUtility.GetCurrentTicks();
							long_7 = CommonUtility.GetCurrentTicks();
						}
					}
				}
				else
				{
					num3 = num66;
					num12 = WindowsInteropHelper.ReadProcessUInt32(num67 + GameConfigurationManager.memorySignatureScanConfig_45.resolvedValue, characterAccountConfig.int_137);
					long_8 = CommonUtility.GetCurrentTicks();
				}
			}
			goto IL_1d06;
			IL_2128:
			if (flag12)
			{
				array3 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates;
			}
			else
			{
				if (characterAccountConfig.uint_0 == null || num37 <= 0)
				{
					array3 = array9;
					flag6 = true;
					flag9 = false;
					goto IL_24dc;
				}
				if (array3 == null || num4 < 0 || num37 <= num4 || num5 == 0)
				{
					num4 = Class64.FindNearestCoordinateIndex(characterAccountConfig.uint_0, array9);
					if (num4 < 0 || num37 == 1)
					{
						num4 = 0;
					}
					array3 = new uint[2]
					{
						characterAccountConfig.uint_0[num4, 0],
						characterAccountConfig.uint_0[num4, 1]
					};
					num5 = 1;
				}
			}
			if (Class64.GetSquaredCoordinateDistance(array9, array3) <= 8100L)
			{
				num18 = 0;
				num10 = 0L;
				flag6 = true;
				flag9 = false;
				if (flag12)
				{
					goto IL_2483;
				}
				num4 += num5;
				if (characterAccountConfig.int_29 > 0)
				{
					if (num4 < 0 || num37 <= num4)
					{
						num4 = 0;
					}
					num5 = 1;
				}
				else if (num4 < 0)
				{
					num4 = ((num37 != 1) ? 1 : 0);
					num5 = 1;
				}
				else if (num37 <= num4)
				{
					num4 = ((num37 != 1) ? (num37 - 2) : 0);
					num5 = -1;
				}
				array3 = new uint[2]
				{
					characterAccountConfig.uint_0[num4, 0],
					characterAccountConfig.uint_0[num4, 1]
				};
			}
			if (num19 > 0)
			{
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num25 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, byte_, 4, ref int_4);
			}
			num19 = 0;
			array9 = new uint[2]
			{
				WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
				WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
			};
			long num79 = Class64.GetSquaredCoordinateDistance(array9, array3);
			if (num79 > 1500000L)
			{
				goto IL_23ec;
			}
			flag6 = true;
			flag9 = false;
			CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
			if (num10 == 0L)
			{
				num10 = CommonUtility.GetCurrentTicks();
			}
			if (num18 > 6)
			{
				num4 = -1;
				num18 = 0;
				num10 = 0L;
				flag9 = characterAccountConfig.int_30 <= 0;
				continue;
			}
			if (CommonUtility.GetElapsedMilliseconds(num10) > 6000L)
			{
				num18++;
				if (num18 > 2)
				{
					if (num18 == 3)
					{
						Class64.MoveToApproachCoordinateAndWaitForMovementState(characterAccountConfig, array9, array3, 800);
					}
					num6 = 0;
					goto IL_23ec;
				}
				if (WindowsInteropHelper.ReadProcessUInt32(num25 + GameConfigurationManager.memorySignatureScanConfig_44.resolvedValue, characterAccountConfig.int_137) == 0)
				{
					GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig, "Switch([[sit]])");
					Thread.Sleep(600);
					num10 = CommonUtility.GetCurrentTicks();
				}
				else
				{
					Class64.SwitchHorseStateIfNeeded(characterAccountConfig, bool_0: true);
				}
			}
			GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array3);
			Thread.Sleep(100);
			goto IL_24dc;
		}
		return -1;
	}

	public static bool EnsureHorseStateForTrainingMode(CharacterAccountConfig characterAccountConfig_0, uint uint_0, ref long long_0, bool bool_0)
	{
		if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_20, 4) != 0 && CommonUtility.GetElapsedMilliseconds(long_0) >= 800L)
		{
			bool flag;
			if (((flag = WindowsInteropHelper.ReadProcessUInt32(uint_0 + GameConfigurationManager.memorySignatureScanConfig_44.resolvedValue, characterAccountConfig_0.int_137) != 0) && !bool_0) || (!flag && bool_0))
			{
				GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig_0, "Switch([[horse]])");
				long_0 = CommonUtility.GetCurrentTicks();
				return false;
			}
			return true;
		}
		return true;
	}

	public static void MoveConfiguredItemsToStorageContainers(CharacterAccountConfig characterAccountConfig_0)
	{
		int num = 0;
		int int_ = characterAccountConfig_0.int_136;
		int num2 = 0;
		string[] array = null;
		string[] array2 = new string[7] { "ThÇn Hµnh Phï", "Håi thµnh phï", "LÖnh Bµi ADMIN", "Tiªn Th¶o Lé", "TiÒn ®ång", "TiÒn §ång", "Thæ ®Þa phï" };
		bool flag = false;
		int int_2 = 0;
		while (true)
		{
			IL_06e5:
			Thread.Sleep(300);
			num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
			if (CommonUtility.bool_0 || num < 0 || !Form1.characterAccountConfig_1[num].bool_25 || Form1.characterAccountConfig_1[num].int_53 == null)
			{
				break;
			}
			byte[] byte_ = new byte[1] { 1 };
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_34 * 4, byte_, 1, ref int_2);
			characterAccountConfig_0 = Form1.characterAccountConfig_1[num];
			array = characterAccountConfig_0.string_5;
			if (characterAccountConfig_0.int_53[0] <= 0 && characterAccountConfig_0.int_53[1] <= 0 && characterAccountConfig_0.int_53[2] <= 0 && characterAccountConfig_0.int_53[3] <= 0 && characterAccountConfig_0.int_53[4] <= 0)
			{
				break;
			}
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
			uint num4 = WindowsInteropHelper.ReadProcessUInt32(num3 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137);
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
			uint num6 = num5 + num4 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			WindowsInteropHelper.ReadProcessUInt32(num6, characterAccountConfig_0.int_137);
			int num7 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig_0.int_137);
			int num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_0.int_137);
			if (num8 != 0 && num7 != 0 && num7 != 10 && num7 != 21)
			{
				int num9 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig_0.int_137);
				if (num9 > 0)
				{
					break;
				}
				int int_3 = 0;
				byte[] array3 = new byte[80];
				byte[] array4 = new byte[4];
				uint num10 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
				uint num11 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, characterAccountConfig_0.int_137);
				int num12 = Class85.GetInventoryEntryCount(characterAccountConfig_0);
				int num13 = 0;
				for (uint num14 = 1u; num14 < GameConfigurationManager.int_1; num14++)
				{
					if (num12 <= num13)
					{
						break;
					}
					uint num15 = num11 + num14 * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num15 + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, array4, 4, ref int_2);
					if (BitConverter.ToInt32(array4, 0) != 0)
					{
						continue;
					}
					uint uint_ = num15 + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue;
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array4, 1, ref int_2);
					if (array4[0] == 0)
					{
						continue;
					}
					uint num16 = Class85.FindInventoryEntryIndexByItemRecordIndex(characterAccountConfig_0, num14);
					if ((int)num16 <= 0)
					{
						continue;
					}
					num13++;
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num15 + GameConfigurationManager.memorySignatureScanConfig_108.resolvedValue, array4, 4, ref int_3);
					int num17 = BitConverter.ToInt32(array4, 0);
					if (num17 == 1 || num17 == 5)
					{
						continue;
					}
					uint num18 = num10 + num16 * 20;
					uint num19 = WindowsInteropHelper.ReadProcessUInt32(num18 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, characterAccountConfig_0.int_137);
					if (num19 != 3)
					{
						continue;
					}
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array3, array3.Length, ref int_3);
					string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array3).Trim();
					if (text == null || text == string.Empty)
					{
						continue;
					}
					bool flag2 = false;
					if (array != null)
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (CommonUtility.MatchesGameTextPattern(text, array[i].Trim()))
							{
								flag2 = true;
								break;
							}
						}
					}
					if (flag2)
					{
						continue;
					}
					if (array2 != null)
					{
						for (int j = 0; j < array2.Length; j++)
						{
							if (CommonUtility.MatchesGameTextPattern(text, array2[j].Trim()))
							{
								flag2 = true;
								break;
							}
						}
					}
					if (flag2)
					{
						continue;
					}
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num15 + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue, array4, 4, ref int_3);
					int num20 = BitConverter.ToInt32(array4, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num15 + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue + 4, array4, 4, ref int_3);
					int num21 = BitConverter.ToInt32(array4, 0);
					if (num17 == 6 && num20 < num21)
					{
						continue;
					}
					uint uint_2 = WindowsInteropHelper.ReadProcessUInt32(num18 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, characterAccountConfig_0.int_137);
					uint uint_3 = WindowsInteropHelper.ReadProcessUInt32(num18 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, characterAccountConfig_0.int_137);
					uint num22 = WindowsInteropHelper.ReadProcessUInt32(num15 + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, characterAccountConfig_0.int_137);
					uint num23 = WindowsInteropHelper.ReadProcessUInt32(num15 + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, characterAccountConfig_0.int_137);
					uint uint_4 = 4u;
					uint[] array5 = null;
					if (characterAccountConfig_0.int_53[0] > 0)
					{
						uint_4 = 4u;
						array5 = Class85.FindFreeItemGridPosition(characterAccountConfig_0, 4u, num22, num23);
					}
					if (array5 == null && characterAccountConfig_0.int_53[1] > 0)
					{
						uint_4 = 9u;
						array5 = Class85.FindFreeItemGridPosition(characterAccountConfig_0, 9u, num22, num23);
					}
					if (array5 == null && characterAccountConfig_0.int_53[2] > 0)
					{
						uint_4 = 10u;
						array5 = Class85.FindFreeItemGridPosition(characterAccountConfig_0, 10u, num22, num23);
					}
					if (array5 == null && characterAccountConfig_0.int_53[3] > 0)
					{
						uint_4 = 11u;
						array5 = Class85.FindFreeItemGridPosition(characterAccountConfig_0, 11u, num22, num23);
					}
					if (array5 == null && characterAccountConfig_0.int_53[4] > 0)
					{
						uint_4 = 23u;
						array5 = Class85.FindFreeItemGridPosition(characterAccountConfig_0, 23u, num22, num23);
					}
					if (array5 == null)
					{
						if (num22 <= 1 && num23 <= 1)
						{
							break;
						}
						continue;
					}
					if (num2 <= 0)
					{
						num2 = StorageChestAccessHelper.OpenStorageChest(characterAccountConfig_0);
						if (num2 < 0)
						{
							Class64.TryRecoverStuckMovement(characterAccountConfig_0);
						}
					}
					if (!InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig_0))
					{
						goto IL_06e5;
					}
					if (!flag && characterAccountConfig_0.string_15 != null && characterAccountConfig_0.string_15 != string.Empty)
					{
						uint num24 = CommonUtility.ParseUInt32OrZero(characterAccountConfig_0.string_15);
						if (num24 != 0)
						{
							GameProcessInteractionHelper.UnlockInventoryBoxWithPasswordCode(characterAccountConfig_0, num24);
							flag = true;
							Thread.Sleep(300);
						}
					}
					int k = 0;
					GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, uint_2, uint_3, num19, array5[0], array5[1], uint_4);
					for (; k < 30; k++)
					{
						uint num25 = WindowsInteropHelper.ReadProcessUInt32(num18 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, characterAccountConfig_0.int_137);
						if (num25 != num19)
						{
							break;
						}
						Thread.Sleep(10);
					}
				}
				break;
			}
			int num26 = 0;
			while (num8 == 0 && num26 < 10)
			{
				num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_0.int_137);
				if (num8 != 0)
				{
					break;
				}
				Thread.Sleep(80);
				num26++;
			}
			num7 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig_0.int_137);
		}
		GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_33, 0, 4);
		GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_34, 0, 4);
		if (InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig_0))
		{
			InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_0);
		}
	}

	public static void ProcessConfiguredInventoryItemList(CharacterAccountConfig characterAccountConfig_0)
	{
		int int_ = characterAccountConfig_0.int_136;
		int num = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
		if (num >= 0)
		{
			int int_2 = 0;
			byte[] byte_ = new byte[1] { 1 };
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_35 * 4, byte_, 1, ref int_2);
			characterAccountConfig_0 = Form1.characterAccountConfig_1[num];
			string[] string_ = characterAccountConfig_0.string_4;
			int int_3 = 0;
			byte[] array = new byte[80];
			byte[] array2 = new byte[4];
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, characterAccountConfig_0.int_137);
			uint num4 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137);
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
			uint num7 = num6 + num5 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			for (uint num8 = 1u; num8 < 210; num8++)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, array2, 4, ref int_3);
				if (BitConverter.ToInt32(array2, 0) > 0)
				{
					break;
				}
				if (num8 != 0 && num8 % 10 == 0)
				{
					Thread.Sleep(15);
				}
				if (!Class85.IsItemRecordValid(characterAccountConfig_0, num8))
				{
					continue;
				}
				uint num9 = num3 + num8 * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
				uint uint_ = num9 + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue;
				if (!WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 1, ref int_3) || array[0] == 0)
				{
					continue;
				}
				uint num10 = Class85.FindInventoryEntryIndexByItemRecordIndex(characterAccountConfig_0, num8);
				uint num11 = WindowsInteropHelper.ReadProcessUInt32(num2 + num10 * 20 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, characterAccountConfig_0.int_137);
				if ((int)num10 <= 0 || num11 != 3)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_108.resolvedValue, array2, 4, ref int_3);
				int num12 = BitConverter.ToInt32(array2, 0);
				if (num12 > 0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_109.resolvedValue, array2, 4, ref int_3);
				int num13 = BitConverter.ToInt32(array2, 0);
				if (num13 == 1 || num13 == 4)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_120.resolvedValue, array2, 4, ref int_3);
				if (BitConverter.ToInt32(array2, 0) != 0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue, array2, 4, ref int_3);
				int num14 = BitConverter.ToInt32(array2, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue + 4, array2, 4, ref int_3);
				int num15 = BitConverter.ToInt32(array2, 0);
				if (num14 == 0 && num15 > 0)
				{
					continue;
				}
				if (characterAccountConfig_0.int_46[1] <= 0)
				{
					string text = null;
					if (string_ != null)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, array.Length, ref int_3);
						text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array).Trim();
						if (text == null || text == string.Empty)
						{
							continue;
						}
						int num16 = 0;
						while (num16 < string_.Length)
						{
							if (0 > CommonUtility.FindSubstringIndex(text, string_[num16]))
							{
								num16++;
								continue;
							}
							goto IL_072a;
						}
					}
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_110.resolvedValue, array2, 4, ref int_3);
					int num17 = BitConverter.ToInt32(array2, 0);
					if (num17 > 9)
					{
						continue;
					}
					if (characterAccountConfig_0.int_43[0] > 0 && num17 == 3)
					{
						if (characterAccountConfig_0.int_43[1] <= 0)
						{
							continue;
						}
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_118.resolvedValue + (uint)((characterAccountConfig_0.int_43[1] - 1) * 16), array2, 4, ref int_3);
						if (BitConverter.ToInt32(array2, 0) != 0)
						{
							continue;
						}
					}
					else if (characterAccountConfig_0.int_44[0] > 0 && num17 == 4)
					{
						if (characterAccountConfig_0.int_44[1] <= 0)
						{
							continue;
						}
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_118.resolvedValue + (uint)((characterAccountConfig_0.int_44[1] - 1) * 16), array2, 4, ref int_3);
						if (BitConverter.ToInt32(array2, 0) != 0)
						{
							continue;
						}
					}
					else if (characterAccountConfig_0.int_45[0] > 0 && num17 == 9)
					{
						if (characterAccountConfig_0.int_45[1] <= 0)
						{
							continue;
						}
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_118.resolvedValue + (uint)((characterAccountConfig_0.int_45[1] - 1) * 16), array2, 4, ref int_3);
						if (BitConverter.ToInt32(array2, 0) != 0)
						{
							continue;
						}
					}
					if (characterAccountConfig_0.int_49 > 0 && num13 == 2)
					{
						continue;
					}
					if (characterAccountConfig_0.int_47[0] > 0)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_114.resolvedValue, array2, 4, ref int_3);
						if (characterAccountConfig_0.int_47[1] <= BitConverter.ToInt32(array2, 0))
						{
							continue;
						}
					}
					if (characterAccountConfig_0.int_48[0] > 0)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_115.resolvedValue, array2, 4, ref int_3);
						if (characterAccountConfig_0.int_48[1] == BitConverter.ToInt32(array2, 0))
						{
							continue;
						}
					}
					if (characterAccountConfig_0.int_50 > 0)
					{
						int num18 = 0;
						int num19 = 0;
						bool flag = false;
						for (int i = 0; i < characterAccountConfig_0.itemAttributeFilterRule_0.Length; i++)
						{
							if (characterAccountConfig_0.itemAttributeFilterRule_0[i].int_0 <= 0)
							{
								continue;
							}
							num19++;
							flag = false;
							for (uint num20 = 0u; num20 < 6; num20++)
							{
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_118.resolvedValue + num20 * 16, array2, 4, ref int_3);
								int num21 = BitConverter.ToInt32(array2, 0);
								if (characterAccountConfig_0.itemAttributeFilterRule_0[i].int_1 == num21)
								{
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_118.resolvedValue + num20 * 16 + 4, array2, 4, ref int_3);
									int num22 = BitConverter.ToInt32(array2, 0);
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_118.resolvedValue + num20 * 16 + 12, array2, 4, ref int_3);
									int num23 = BitConverter.ToInt32(array2, 0);
									bool flag2 = characterAccountConfig_0.itemAttributeFilterRule_0[i].int_2 <= num22 && num22 > 0;
									bool flag3 = characterAccountConfig_0.itemAttributeFilterRule_0[i].int_2 <= num23 && num23 > 0;
									bool flag4 = characterAccountConfig_0.itemAttributeFilterRule_0[i].int_2 <= 0;
									if (flag2 || flag3 || flag4)
									{
										num18++;
										flag = true;
										break;
									}
								}
							}
							if (flag || characterAccountConfig_0.int_41 <= 0)
							{
								continue;
							}
							goto IL_072a;
						}
						if (flag = num19 == 0 || (characterAccountConfig_0.int_41 > 0 && num19 <= num18) || (characterAccountConfig_0.int_41 <= 0 && num18 > 0))
						{
							continue;
						}
					}
				}
				goto IL_072a;
				IL_072a:
				int num24 = 0;
				while (!CommonUtility.bool_0 && num24 < 150)
				{
					if (num24 % 30 == 0)
					{
						GameProcessInteractionHelper.PurchaseShopItemByRecordIndex(characterAccountConfig_0, num8);
					}
					Thread.Sleep(10);
					if (num24 % 10 == 0)
					{
						string string_2 = GameInterfaceMemoryHelper.ReadLatestTopChannelText(characterAccountConfig_0);
						if (CommonUtility.FindSubstringIndex(string_2, "hÊt b¹i") > 0)
						{
							GameInterfaceMemoryHelper.WriteLatestTopChannelText(characterAccountConfig_0, "0K..");
							break;
						}
					}
					if (WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 1, ref int_3) && array[0] != 0)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, array2, 4, ref int_3);
						if (BitConverter.ToInt32(array2, 0) <= 0)
						{
							num24++;
							continue;
						}
						num24 = 0;
						break;
					}
					num24 = 0;
					break;
				}
			}
		}
		GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_35, 0, 4);
	}

	public static void RunContainerThreeInventoryCompactionLoop()
	{
		int num = int_0;
		int_0 = 0;
		int num2 = 0;
		int num3 = 0;
		int int_ = 0;
		byte[] array = new byte[1];
		while (true)
		{
			IL_044a:
			Thread.Sleep(300);
			num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
			if (CommonUtility.bool_0 || num2 < 0 || !Form1.characterAccountConfig_1[num2].bool_25 || Form1.characterAccountConfig_1[num2].int_37 <= 0)
			{
				break;
			}
			Form1.characterAccountConfig_1[num2].bool_7 = true;
			CharacterAccountConfig characterAccountConfig_ = Form1.characterAccountConfig_1[num2];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, characterAccountConfig_.uint_16 + GameProcessInteractionHelper.uint_35 * 4, array, 1, ref int_);
			if (array[0] > 0)
			{
				continue;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, characterAccountConfig_.uint_16 + GameProcessInteractionHelper.uint_34 * 4, array, 1, ref int_);
			if (array[0] > 0)
			{
				continue;
			}
			uint num4 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_.int_137);
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_.int_137);
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_.int_137);
			uint num7 = num6 + num5 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			WindowsInteropHelper.ReadProcessUInt32(num7, characterAccountConfig_.int_137);
			if (WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_.int_137) != 0)
			{
				if (InventoryItemHelper.PlaceHeldItemInInventory(characterAccountConfig_) < 0)
				{
					break;
				}
				byte[] array2 = new byte[80];
				byte[] array3 = new byte[4];
				uint num8 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_.int_137) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
				uint num9 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, characterAccountConfig_.int_137);
				int num10 = Class85.GetInventoryEntryCount(characterAccountConfig_);
				int num11 = 0;
				uint num12 = 1u;
				while (num12 < GameConfigurationManager.int_1)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, characterAccountConfig_.uint_16 + GameProcessInteractionHelper.uint_35 * 4, array, 1, ref int_);
					if (array[0] <= 0)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, characterAccountConfig_.uint_16 + GameProcessInteractionHelper.uint_34 * 4, array, 1, ref int_);
						if (array[0] <= 0)
						{
							if (num12 != 0 && num12 % 50 == 0)
							{
								Thread.Sleep(10);
							}
							if (num10 <= num11)
							{
								break;
							}
							uint num13 = num9 + num12 * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, num13 + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, array3, 4, ref int_);
							if (BitConverter.ToInt32(array3, 0) == 0)
							{
								uint uint_ = num13 + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue;
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, uint_, array3, 1, ref int_);
								if (array3[0] != 0)
								{
									uint num14 = Class85.FindInventoryEntryIndexByItemRecordIndex(characterAccountConfig_, num12);
									if ((int)num14 > 0)
									{
										num11++;
										uint num15 = num8 + num14 * 20;
										uint num16 = WindowsInteropHelper.ReadProcessUInt32(num15 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, characterAccountConfig_.int_137);
										if (num16 == 3)
										{
											uint num17 = WindowsInteropHelper.ReadProcessUInt32(num15 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, characterAccountConfig_.int_137);
											uint num18 = WindowsInteropHelper.ReadProcessUInt32(num15 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, characterAccountConfig_.int_137);
											uint uint_2 = WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, characterAccountConfig_.int_137);
											uint uint_3 = WindowsInteropHelper.ReadProcessUInt32(num13 + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, characterAccountConfig_.int_137);
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_.int_137, uint_, array2, array2.Length, ref int_);
											GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2).Trim();
											uint uint_4 = 3u;
											uint[] array4 = Class85.FindFreeItemGridPosition(characterAccountConfig_, 3u, uint_2, uint_3);
											if (array4 != null && array4[1] <= num18 && (array4[1] != num18 || num17 >= array4[0]))
											{
												GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_, num17, num18, num16, array4[0], array4[1], uint_4);
												for (int i = 0; i < 30; i++)
												{
													uint num19 = WindowsInteropHelper.ReadProcessUInt32(num15 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, characterAccountConfig_.int_137);
													if (num16 != num19)
													{
														break;
													}
													Thread.Sleep(10);
												}
											}
										}
									}
								}
							}
							num12++;
							continue;
						}
					}
					goto IL_044a;
				}
				break;
			}
			num3++;
			if (num3 > 3)
			{
				break;
			}
		}
		num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, num);
		if (0 <= num2)
		{
			Form1.characterAccountConfig_1[num2].bool_7 = false;
			InventoryItemHelper.PlaceHeldItemInInventory(Form1.characterAccountConfig_1[num2]);
		}
	}

	private static void LogDosatEventAndOptionallySendGuildAlert(CharacterAccountConfig characterAccountConfig_0, string string_0, int int_1, uint[] uint_0)
	{
		try
		{
			string path = "dosat.txt";
			string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			string text2 = GetTrainingModeNameByIndex(int_1);
			string text3 = CurrentCharacterMemoryHelper.GetCharacterName(characterAccountConfig_0);
			string contents = "[" + text + "] Player: " + text3 + " | Đồ Sát: " + string_0 + " | Status: " + text2 + "\n";
			string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
			File.AppendAllText(path2, contents, Encoding.UTF8);
			if (Form1.guildChannelListAlertEnabled > 0)
			{
				string string_1 = "Cøu T«i AE, §ang BÞ §å S\u00b8t ! :L (" + CurrentCharacterMemoryHelper.GetCurrentCharacterPosition(characterAccountConfig_0)[0] / 256 + "," + CurrentCharacterMemoryHelper.GetCurrentCharacterPosition(characterAccountConfig_0)[1] / 512 + ") " + GameMapCatalog.ReadCurrentMapName(characterAccountConfig_0);
				GameProcessInteractionHelper.SendChatMessage(characterAccountConfig_0, string_1, "CH_TONG");
				Thread.Sleep(300);
			}
		}
		catch
		{
		}
	}

	private static string GetTrainingModeNameByIndex(int int_1)
	{
		if (int_1 >= 0 && int_1 < GameConfigurationManager.string_24.Length)
		{
			return GameConfigurationManager.string_24[int_1];
		}
		return $"Unknown({int_1})";
	}
}
