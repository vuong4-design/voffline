using System;
using System.Threading;
using ns10;
using ns100;
using ns11;
using ns23;
using ns28;
using ns3;
using ns34;
using ns50;
using ns53;
using ns56;
using ns61;
using ns63;
using ns71;
using ns83;
using ns85;
using ns88;

namespace ns19;

internal class ChienLongDongNavigationHelper
{
	private static string teleportNpcName;

	public static string[] string_1;

	public static int int_0;

	public static int int_1;

	private static string[] configuredGateRouteLabels;

	private static Random gateRouteRandom;

	private static uint[,] gateThreeRouteCoordinates;

	private static uint[,] gateTwoRouteCoordinates;

	private static uint[,] gateOneRouteCoordinates;

	private static uint[,] uint_3;

	static ChienLongDongNavigationHelper()
	{
		teleportNpcName = "truyÒn tèng";
		string_1 = new string[4] { "Bất kỳ", "La tiêu sơn", "Vũ di sơn", "Tường vân động" };
		int_0 = WindowsRegistryHelper.ReadApplicationRegistryInt32("IndexChienlongdong", 0, "0");
		int_1 = -1;
		configuredGateRouteLabels = null;
		gateRouteRandom = new Random();
		uint[,] array_ = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_, 43953);
		gateThreeRouteCoordinates = array_;
		uint[,] array_2 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_2, 43994);
		gateTwoRouteCoordinates = array_2;
		uint[,] array_3 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_3, 44035);
		gateOneRouteCoordinates = array_3;
		uint[,] array_4 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_4, 44068);
		uint_3 = array_4;
	}

	public static bool IsChienLongDongMap(int int_2)
	{
		return int_2 == 959 || int_2 == 991 || int_2 == 990;
	}

	public static int NavigateChienLongDong(CharacterAccountConfig characterAccountConfig_0, bool bool_0 = false, bool bool_1 = false)
	{
		int result = 0;
		int int_ = characterAccountConfig_0.int_136;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		long long_ = 0L;
		string object_ = teleportNpcName.ToUpper();
		string text = "ChiÕn Long|H\u00b8i-Qu¶|H\u00b8i Qu¶ H|L\u00adìng Thñy |nhÆt H¹t-Hoµng|H\u00b8iQu¶";
		int num5 = 0;
		while (true)
		{
			Thread.Sleep(200);
			int num6 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
			uint num10;
			if (!CommonUtility.bool_0 && num6 >= 0 && GameInterfaceMemoryHelper.ReadEngineStateByte(characterAccountConfig_0) <= 0 && GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0) > 1)
			{
				if (bool_1 || Form1.chienLongDongCombatEnabled > 0)
				{
					characterAccountConfig_0 = Form1.characterAccountConfig_1[num6];
					if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.clickNpcAutomationActiveSlot, 4) > 0 || !characterAccountConfig_0.bool_25 || characterAccountConfig_0.int_20[0] > 0 || characterAccountConfig_0.int_133[0] > 0 || characterAccountConfig_0.bool_54 || characterAccountConfig_0.int_25 > 0 || characterAccountConfig_0.bool_15)
					{
						break;
					}
					if (bool_0 || Form1.pkModeIndex == 0)
					{
						uint num7 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
						if (num7 == 0)
						{
							continue;
						}
						uint num8 = WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137);
						uint num9 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
						if (num9 == 0)
						{
							continue;
						}
						num10 = num9 + num8 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
						int num11 = (int)WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig_0.int_137);
						int num12 = (int)WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_0.int_137);
						int num13 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
						int num14 = (int)WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig_0.int_137);
						if (num11 != 10 && num11 != 21 && num12 != 0 && num11 != 0 && num13 != 0)
						{
							num4 = 0;
							uint[] array = new uint[2]
							{
								WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
								WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
							};
							if (array[0] == 0 || array[1] == 0)
							{
								continue;
							}
							if (!IsChienLongDongMap(num13))
							{
								if (num14 <= 0)
								{
									string text2 = null;
									if (int_0 != 1)
									{
										if (int_0 != 2)
										{
											if (int_0 == 3)
											{
												text2 = "T\u00adêng V©n|Cæng 3";
											}
										}
										else
										{
											text2 = "Vò Di|Cæng 2";
										}
									}
									else
									{
										text2 = "La Tiªu|Cæng 1";
									}
									if (int_1 < 0)
									{
										int_1 = 0;
										configuredGateRouteLabels = null;
										if (MapNavigationProfileProvider.mapNavigationEntry_0 != null)
										{
											for (int i = 0; i < MapNavigationProfileProvider.mapNavigationEntry_0.Length; i++)
											{
												if (!IsChienLongDongMap(MapNavigationProfileProvider.mapNavigationEntry_0[i].int_0))
												{
													continue;
												}
												int_1 = MapNavigationProfileProvider.mapNavigationEntry_0[i].int_0;
												if (MapNavigationProfileProvider.mapNavigationEntry_0[i].string_2 == null || !(MapNavigationProfileProvider.mapNavigationEntry_0[i].string_2 != string.Empty))
												{
													break;
												}
												string[] array2 = MapNavigationProfileProvider.mapNavigationEntry_0[i].string_2.Split('|');
												configuredGateRouteLabels = new string[3];
												for (int j = 0; j < configuredGateRouteLabels.Length; j++)
												{
													if (j < array2.Length)
													{
														configuredGateRouteLabels[j] = array2[j];
													}
													else
													{
														configuredGateRouteLabels[j] = array2[array2.Length - 1];
													}
												}
												break;
											}
										}
									}
									if ((Form1.chienLongDongTownPortalEnabled <= 0 || Form1.chienLongDongTravelMethodIndex <= 0) && (num5 < 3 || (Form1.chienLongDongTownPortalEnabled > 0 && Form1.chienLongDongTravelMethodIndex == 0)) && int_1 > 0)
									{
										if (configuredGateRouteLabels != null)
										{
											if (text2 != null)
											{
												text2 += "|";
											}
											text2 = ((int_0 > 0) ? (text2 + configuredGateRouteLabels[int_0 - 1]) : (text2 + configuredGateRouteLabels[gateRouteRandom.Next(0, 2)]));
										}
										MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, int_1, text2);
										Thread.Sleep(100);
										NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
										num5++;
									}
									else
									{
										int[] array3 = GameAutomationUtility.FindTravelHubGroupPosition(num13);
										if (array3 != null && array3[1] != 0)
										{
											InterMapTravelHelper.ReturnToPrimaryRouteMap(characterAccountConfig_0);
											result = -2;
											break;
										}
										InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig_0, text + "|" + text2);
										NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
									}
									continue;
								}
							}
							else if (num5 > 0)
							{
								num5 = 0;
							}
							if (IsChienLongDongMap(num13) && int_0 != 0)
							{
								long num15 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(gateTwoRouteCoordinates, array);
								long num16 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(gateThreeRouteCoordinates, array);
								long num17 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(gateOneRouteCoordinates, array);
								if ((int_0 != 1 || num17 > num15 || num17 > num16) && (int_0 != 2 || num15 > num17 || num15 > num16) && (int_0 != 3 || num16 > num17 || num16 > num15))
								{
									if (CommonUtility.GetElapsedMilliseconds(long_) > 3000L)
									{
										GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig_0, "§ang chän l¹i cæng lªn cl®...");
										long_ = CommonUtility.GetCurrentTicks();
									}
									if (Form1.chienLongDongTownPortalEnabled > 0 && Form1.chienLongDongTravelMethodIndex == 0 && int_1 > 0)
									{
										string text3 = null;
										if (int_0 != 1)
										{
											if (int_0 != 2)
											{
												if (int_0 == 3)
												{
													text3 = "T\u00adêng V©n|Cæng 3";
												}
											}
											else
											{
												text3 = "Vò Di|Cæng 2";
											}
										}
										else
										{
											text3 = "La Tiªu|Cæng 1";
										}
										if (configuredGateRouteLabels != null)
										{
											if (text3 != null)
											{
												text3 += "|";
											}
											text3 = ((int_0 <= 0) ? (text3 + configuredGateRouteLabels[gateRouteRandom.Next(0, 2)]) : (text3 + configuredGateRouteLabels[int_0 - 1]));
										}
										if (MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, int_1, text3 + configuredGateRouteLabels))
										{
											NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
											num5++;
										}
										continue;
									}
									uint[,] array4 = null;
									array4 = ((num17 <= num16 && num17 <= num15) ? gateOneRouteCoordinates : ((num15 > num16 || num15 > num17) ? gateThreeRouteCoordinates : gateTwoRouteCoordinates));
									int length = array4.GetLength(0);
									uint[] array5 = new uint[2]
									{
										array4[length - 1, 0],
										array4[length - 1, 1]
									};
									long num18 = GameAutomationUtility.GetSquaredCoordinateDistance(array, array5);
									if (num18 > 90000L)
									{
										num++;
										if (num < 3)
										{
											TongKimBattlefieldHelper.TraverseCoordinateRoute(characterAccountConfig_0, array4, array5, bool_0: true, 10000);
											continue;
										}
									}
									for (num = 0; num < 10; num++)
									{
										array = new uint[2]
										{
											WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
											WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
										};
										if (GameAutomationUtility.GetSquaredCoordinateDistance(array, array5) <= 11500L)
										{
											break;
										}
										GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig_0, array5);
										Thread.Sleep(300);
									}
									num = 0;
									if (num2 > 0)
									{
										string text4 = GameEntityMemoryHelper.GetEntityNameAndPositionByIndex(characterAccountConfig_0, num2, ref array5, 32);
										if (text4 != null && 0 <= CommonUtility.FindSubstringIndex(text4.ToUpper(), object_))
										{
											goto IL_07e6;
										}
									}
									num2 = GameEntityMemoryHelper.FindNearestEntityIndexByNameAndType(characterAccountConfig_0, teleportNpcName, ref array5, 3, bool_0: false);
									if (num2 > 0)
									{
										goto IL_07e6;
									}
									goto IL_0848;
								}
								result = 1;
								break;
							}
							result = 1;
							break;
						}
						if (num12 == 0 || num11 == 0)
						{
							num4++;
							if (num4 < 10)
							{
								Thread.Sleep(100);
								continue;
							}
						}
						result = -1;
						break;
					}
					result = 1;
					break;
				}
				result = -1;
				break;
			}
			result = -1;
			break;
			IL_07e6:
			int int_2 = 0;
			byte[] bytes = BitConverter.GetBytes(num2);
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num10 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, bytes, 4, ref int_2);
			Thread.Sleep(100);
			num = 0;
			while (NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig_0) < 0)
			{
				num++;
				Thread.Sleep(100);
				if (num <= 10)
				{
					continue;
				}
				goto IL_0848;
			}
			num = 0;
			NpcDialogHelper.SelectMenuOption(characterAccountConfig_0, 0);
			num2 = 0;
			continue;
			IL_0848:
			num3++;
			Thread.Sleep(100);
			if (num3 > 10)
			{
				GameAutomationUtility.SwitchHorseStateIfNeeded(characterAccountConfig_0, bool_0: true);
				Thread.Sleep(300);
				GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig_0, "Switch([[sit]])");
				Thread.Sleep(300);
				num3 = 0;
			}
		}
		return result;
	}

	public static uint[] NavigateToChienLongDongTeleportAnchor(CharacterAccountConfig characterAccountConfig_0)
	{
		uint[,] array = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array, 43708);
		uint[,] array2 = array;
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2;
		WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig_0.int_137);
		WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_0.int_137);
		int num5 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
		if (!IsChienLongDongMap(num5))
		{
			return null;
		}
		uint[] array3 = new uint[2]
		{
			WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
			WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
		};
		int num6 = GameAutomationUtility.FindNearestCoordinateIndex(array2, array3);
		if (num6 >= 0)
		{
			uint[] array4 = new uint[2]
			{
				array2[num6, 0],
				array2[num6, 1]
			};
			long num7 = GameAutomationUtility.GetSquaredCoordinateDistance(array3, array4);
			if (num7 <= 90000L)
			{
				long long_ = CommonUtility.GetCurrentTicks();
				while (!CommonUtility.bool_0)
				{
					array3 = new uint[2]
					{
						WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
						WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
					};
					num7 = GameAutomationUtility.GetSquaredCoordinateDistance(array3, array4);
					if (num7 < 22500L)
					{
						break;
					}
					if (CommonUtility.GetElapsedMilliseconds(long_) <= 6000L)
					{
						uint num8 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
						if (num8 == num5)
						{
							GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig_0, array4);
							Thread.Sleep(300);
							continue;
						}
						return null;
					}
					return null;
				}
				string text = "ruyÒn tèng";
				int num9 = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig_0, text, 3);
				if (num9 <= 0)
				{
					return null;
				}
				bool flag = false;
				while (true)
				{
					NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
					Thread.Sleep(100);
					int int_ = 0;
					byte[] bytes = BitConverter.GetBytes(num9);
					WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num4 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, bytes, 4, ref int_);
					Thread.Sleep(100);
					for (int i = 0; i < 10; i++)
					{
						Thread.Sleep(150);
						if (0 <= NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig_0) && NpcDialogHelper.GetMenuOptionCount(characterAccountConfig_0) > 0)
						{
							GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig_0, 0, 0);
							return null;
						}
					}
					if (flag)
					{
						break;
					}
					flag = true;
				}
				return null;
			}
			return array4;
		}
		return null;
	}
}
