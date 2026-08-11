using System;
using System.Threading;
using ns10;
using ns100;
using ns11;
using ns13;
using ns23;
using ns28;
using ns3;
using ns44;
using ns53;
using ns61;
using ns71;
using ns81;
using ns83;
using ns85;
using ns88;

namespace ns40;

internal class PhongLangDoBoardingAutomation
{
	public static int[] int_0;

	public static bool bool_0;

	private static int int_1;

	public static uint[,] uint_0;

	public static uint[,] uint_1;

	static PhongLangDoBoardingAutomation()
	{
		int_0 = null;
		bool_0 = false;
		int_1 = 0;
		uint[,] array_ = new uint[22, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_, 186533);
		uint_0 = array_;
		uint[,] array_2 = new uint[26, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_2, 186719);
		uint_1 = array_2;
	}

	public static void RunQueue()
	{
		bool_0 = true;
		long long_ = CommonUtility.smethod_27();
		while (!CommonUtility.bool_0 && int_0 != null)
		{
			if (int_0 != null && (int_1 == 0 || CommonUtility.smethod_28(long_) > 3000L))
			{
				int_1 = int_0[0];
				CommonUtility.smethod_39(ref int_0, int_1);
				new Thread(RunQueuedCharacter).Start();
				Thread.Sleep(150);
				long_ = CommonUtility.smethod_27();
			}
			Thread.Sleep(300);
		}
		bool_0 = false;
	}

	public static void RunQueuedCharacter()
	{
		int int_ = int_1;
		int_1 = 0;
		while (true)
		{
			try
			{
				RunForCharacter(int_);
				break;
			}
			catch
			{
			}
		}
	}

	private static void RunForCharacter(int int_2)
	{
		uint[] array = null;
		uint[] array2 = null;
		uint[,] array3 = new uint[3, 4];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array3, 185668);
		uint[,] array4 = array3;
		string string_ = "ThuyÒn phu";
		string text = "MËt ®å thÇn bÝ";
		bool flag = false;
		int num = 0;
		int num2 = 0;
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		uint num3 = 0u;
		bool flag2 = false;
		long long_ = 0L;
		long long_2 = 0L;
		while (true)
		{
			Thread.Sleep(100);
			int num4 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
			if (CommonUtility.bool_0 || num4 < 0 || !Form1.characterAccountConfig_1[num4].bool_25)
			{
				break;
			}
			characterAccountConfig = Form1.characterAccountConfig_1[num4];
			if (!flag2)
			{
				if (characterAccountConfig.bool_15)
				{
					break;
				}
				flag2 = true;
				Form1.characterAccountConfig_1[num4].bool_15 = true;
				GameProcessInteractionHelper.smethod_52(characterAccountConfig, "<bclr=blue><color=green>Lªn thuyÒn PL§: Tù ®éng nép lÖnh bµi PL§, lÖnh bµi Thuû tÆc, hoÆc MËt ®å ThÇn bÝ.");
			}
			else if (!characterAccountConfig.bool_15)
			{
				break;
			}
			uint num5 = WindowsInteropHelper.smethod_30(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig.int_137);
			uint num6 = WindowsInteropHelper.smethod_30(num5 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			uint num7 = WindowsInteropHelper.smethod_30(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig.int_137);
			num3 = num7 + num6;
			int num8 = (int)WindowsInteropHelper.smethod_30(num3 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig.int_137);
			int num9 = (int)WindowsInteropHelper.smethod_30(num3 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig.int_137);
			int num10 = (int)WindowsInteropHelper.smethod_30(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
			string string_2 = WindowsInteropHelper.smethod_28(characterAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_28.uint_0 + GameConfigurationManager.memorySignatureScanConfig_29.uint_0, characterAccountConfig.int_137, 60);
			uint[] array5 = new uint[2]
			{
				WindowsInteropHelper.smethod_30(num3 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
				WindowsInteropHelper.smethod_30(num3 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
			};
			if (array5[0] == 0 || array5[1] == 0)
			{
				continue;
			}
			int num11 = GameInterfaceMemoryHelper.smethod_39(characterAccountConfig);
			if (num9 != 0 && num8 != 0 && num8 != 10 && num8 != 21 && num10 != 0 && (int)array5[0] > 0 && (int)array5[1] > 0 && num11 > 1)
			{
				if (num10 == 337 || num10 == 338 || num10 == 339 || CommonUtility.smethod_1(string_2, "BÕn thuyÒn") == 0)
				{
					break;
				}
				if (num10 != 336)
				{
					if (!MapNavigationHelper.smethod_7(characterAccountConfig, 336))
					{
						break;
					}
					Thread.Sleep(300);
					continue;
				}
				array = new uint[2]
				{
					array4[Form1.int_111, 0],
					array4[Form1.int_111, 1]
				};
				array2 = new uint[2]
				{
					array4[Form1.int_111, 2],
					array4[Form1.int_111, 3]
				};
				long num12 = Class64.GetSquaredCoordinateDistance(array5, array);
				long num13 = Class64.GetSquaredCoordinateDistance(array5, array2);
				uint num14 = 90000u;
				if (num12 > 90000L && num13 > num14)
				{
					if (!CharacterMovementHelper.IsMovementActive(characterAccountConfig) || CommonUtility.smethod_28(long_2) > 4000L)
					{
						CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array2);
						long_2 = CommonUtility.smethod_27();
					}
					continue;
				}
				CharacterMovementHelper.SetMovementActive(characterAccountConfig, bool_0: false);
				if (num12 > num14)
				{
					GameProcessInteractionHelper.smethod_61(characterAccountConfig, array);
					Thread.Sleep(300);
				}
				uint[] uint_ = null;
				if (num2 <= 0 || CommonUtility.smethod_28(long_) > 3000L)
				{
					num2 = GameEntityMemoryHelper.FindNearestEntityIndexByNameAndType(characterAccountConfig, string_, ref uint_, 3, bool_0: false);
					if (num2 <= 0)
					{
						goto IL_0899;
					}
					long_ = CommonUtility.smethod_27();
				}
				array5 = new uint[2]
				{
					WindowsInteropHelper.smethod_30(num3 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
					WindowsInteropHelper.smethod_30(num3 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
				};
				num12 = Class64.GetSquaredCoordinateDistance(array5, uint_);
				if (num12 > 10500L)
				{
					GameProcessInteractionHelper.smethod_61(characterAccountConfig, uint_);
					Thread.Sleep(300);
				}
				NpcDialogHelper.smethod_8(characterAccountConfig);
				NpcDialogHelper.SecondaryMenuLayoutHelper.smethod_2(characterAccountConfig);
				int int_3 = 0;
				byte[] bytes = BitConverter.GetBytes(num2);
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num3 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, bytes, bytes.Length, ref int_3);
				int_3 = 0;
				while (NpcDialogHelper.smethod_0(characterAccountConfig) < 0 && int_3 < 100)
				{
					Thread.Sleep(10);
					int_3++;
				}
				int num15 = NpcDialogHelper.smethod_1(characterAccountConfig);
				switch (num15)
				{
				default:
				{
					if (!flag)
					{
						string text2 = "tham gia ho¹t ®éng|hËn nhiÖm vô Tiªu diÖt|bµi häc ®Ých ®\u00b8ng";
						if (!(flag = NpcDialogHelper.smethod_6(characterAccountConfig, text2 + "|KÕt thóc") > 0))
						{
							string[] array6 = text2.Split('|');
							for (int i = 0; i < num15; i++)
							{
								string string_3 = NpcDialogHelper.smethod_3(characterAccountConfig, i, -1, 128);
								int num16 = 0;
								while (num16 < array6.Length)
								{
									if (0 > CommonUtility.smethod_1(string_3, array6[num16]))
									{
										num16++;
										continue;
									}
									goto IL_057b;
								}
							}
						}
						Thread.Sleep(300);
						flag = true;
					}
					string[] array7 = new string[4] { "Lªn thuyÒn", "cã lÖnh bµi", "nép lÖnh bµi", "ng lÖnh bµi" };
					int num17 = Class85.CountInventoryItemQuantityByName(characterAccountConfig, text, 3, bool_3: true);
					if (num17 > 199)
					{
						array7 = new string[5] { "Lªn thuyÒn", "200", "cã lÖnh bµi", "nép lÖnh bµi", "ng lÖnh bµi" };
					}
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					int num18 = 0;
					do
					{
						int_3 = 0;
						while (int_3 < 10 && NpcDialogHelper.smethod_0(characterAccountConfig) < 0)
						{
							int_3++;
							Thread.Sleep(30);
						}
						int num19 = NpcDialogHelper.smethod_1(characterAccountConfig);
						if (num19 == 0 || array7 == null || array7.Length == 0)
						{
							break;
						}
						int j;
						string text3;
						int num20;
						string text4;
						string text5;
						for (j = 0; j < array7.Length; j++)
						{
							if (array7[j] == null || array7[j] == string.Empty)
							{
								continue;
							}
							text3 = array7[j].ToLower();
							num20 = 0;
							while (num20 < num19)
							{
								text4 = NpcDialogHelper.smethod_3(characterAccountConfig, num20, -1, 128);
								text5 = text4.ToLower();
								if (text5.IndexOf(text3) < 0)
								{
									num20++;
									continue;
								}
								goto IL_06d1;
							}
						}
						break;
						IL_06d1:
						if (!flag5)
						{
							flag5 = text3 == "200";
						}
						if (!flag4)
						{
							flag4 = 0 <= text5.IndexOf("Thñy TÆc".ToLower());
						}
						array7[j] = null;
						NpcDialogHelper.smethod_5(characterAccountConfig, num20);
						int_3 = 0;
						while (int_3 < 100)
						{
							int_3++;
							Thread.Sleep(10);
							if (NpcDialogHelper.smethod_0(characterAccountConfig) < 0)
							{
								break;
							}
							string text6 = NpcDialogHelper.smethod_3(characterAccountConfig, num20, -1, 128);
							if (text6 != null && text6 != string.Empty && text6 != text4)
							{
								break;
							}
						}
						flag3 = true;
						Thread.Sleep(10 + NpcDialogHelper.int_0);
					}
					while (!InventoryItemHelper.smethod_8(characterAccountConfig));
					while (true)
					{
						if (flag3)
						{
							if (!InventoryItemHelper.smethod_8(characterAccountConfig))
							{
								break;
							}
							uint num21 = 3u;
							uint num22 = 12u;
							string string_4 = "LÖnh bµi Phong L\u00a8ng §é";
							if (!flag5)
							{
								if (flag4)
								{
									string_4 = "LÖnh Bµi Thñy TÆc";
								}
							}
							else
							{
								string_4 = text;
							}
							InventoryItemHelper.smethod_15(characterAccountConfig, num21, num22, string_4, 1, bool_0: false, bool_1: false, !flag5);
							if (flag5)
							{
								num17 = Class85.CountInventoryItemQuantityByName(characterAccountConfig, text, (int)num22, bool_3: true);
								if (num17 < 200)
								{
									num18++;
									if (num18 < 20)
									{
										continue;
									}
								}
							}
							GameProcessInteractionHelper.smethod_110(characterAccountConfig);
							Thread.Sleep(100);
							int_3 = 0;
							while (int_3 < 10)
							{
								int num23 = NpcDialogHelper.smethod_0(characterAccountConfig);
								if (0 > num23)
								{
									int_3++;
									Thread.Sleep(30);
									continue;
								}
								NpcDialogHelper.smethod_5(characterAccountConfig, NpcDialogHelper.smethod_1(characterAccountConfig, num23) - 1);
								break;
							}
						}
						else
						{
							Thread.Sleep(300);
							NpcDialogHelper.smethod_8(characterAccountConfig);
							if (InventoryItemHelper.smethod_8(characterAccountConfig))
							{
								InventoryItemHelper.smethod_11(characterAccountConfig);
							}
						}
						break;
					}
					continue;
				}
				case 1:
					NpcDialogHelper.smethod_5(characterAccountConfig, 0);
					Thread.Sleep(10 + NpcDialogHelper.int_0);
					continue;
				case 0:
					break;
					IL_057b:
					Thread.Sleep(100);
					continue;
				}
				goto IL_0899;
			}
			Thread.Sleep(300);
			continue;
			IL_0899:
			Thread.Sleep(300);
			num++;
			if (num > 15)
			{
				Class64.smethod_12(characterAccountConfig);
			}
		}
		if (flag2)
		{
			NpcDialogHelper.smethod_8(characterAccountConfig);
			GameProcessInteractionHelper.smethod_52(characterAccountConfig, "<bclr=blue><color=green>KÕt thóc lªn thuyÒn Phong L\u00a8ng ®é!");
			int num24 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
			if (0 <= num24)
			{
				Form1.characterAccountConfig_1[num24].bool_15 = false;
			}
		}
	}
}
