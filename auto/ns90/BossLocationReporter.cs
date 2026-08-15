using System;
using System.Threading;
using ns1;
using ns100;
using ns11;
using ns23;
using ns53;
using ns61;
using ns63;
using ns71;
using ns83;

namespace ns90;

internal class BossLocationReporter
{
	private struct DirectionHintEntry
	{
		public uint[] coordinates;

		public string description;
	}

	private struct MapDirectionHintGroup
	{
		public int mapId;

		public DirectionHintEntry[] directionHints;
	}

	private static MapDirectionHintGroup[] directionHintGroups = null;

	public static int[] ReportOptions = new int[4]
	{
		WindowsRegistryHelper.ReadApplicationRegistryInt32("KenhKhac", 0, "1"),
		WindowsRegistryHelper.ReadApplicationRegistryInt32("PhongTan", 0, "1"),
		WindowsRegistryHelper.ReadApplicationRegistryInt32("KenhBang", 0, "0"),
		WindowsRegistryHelper.ReadApplicationRegistryInt32("BaoTime", 0, "6")
	};

	public static int IncludeDirectionDetails = WindowsRegistryHelper.ReadApplicationRegistryInt32("Chitiet", 0, "1");

	public static int ActiveCharacterId = 0;

	private static void InitializeDirectionHints()
	{
		directionHintGroups = new MapDirectionHintGroup[20]
		{
			new MapDirectionHintGroup
			{
				mapId = 11,
				directionHints = new DirectionHintEntry[5]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 104331u, 168956u },
						description = "h\u00adíng §«ng 3h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 95117u, 156468u },
						description = "h\u00adíng T©y 9h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 105984u, 156160u },
						description = "h\u00adíng B¾c 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 93185u, 167606u },
						description = "h\u00adíng Nam 6h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 95864u, 169290u },
						description = "h\u00adíng Nam 6h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 78,
				directionHints = new DirectionHintEntry[4]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 52944u, 110528u },
						description = "h\u00adíng §«ng 3h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 44781u, 100252u },
						description = "h\u00adíng T©y 9h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 44107u, 108478u },
						description = "h\u00adíng Nam 6h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 56183u, 99832u },
						description = "h\u00adíng B¾c 12h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 1,
				directionHints = new DirectionHintEntry[4]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 56614u, 107990u },
						description = "h\u00adíng §«ng 3h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 45682u, 97230u },
						description = "h\u00adíng T©y 9h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 45480u, 105060u },
						description = "h\u00adíng Nam 6h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 57213u, 100338u },
						description = "h\u00adíng B¾c 12h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 176,
				directionHints = new DirectionHintEntry[4]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 56406u, 108168u },
						description = "h\u00adíng §«ng 3h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 38075u, 89742u },
						description = "h\u00adíng T©y, th\u00b8p 9h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 40348u, 106798u },
						description = "h\u00adíng Nam 6h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 54400u, 89670u },
						description = "h\u00adíng B¾c 12h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 37,
				directionHints = new DirectionHintEntry[4]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 56790u, 108850u },
						description = "h\u00adíng §«ng 3h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 50946u, 90646u },
						description = "h\u00adíng T©y 9h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 48043u, 105904u },
						description = "h\u00adíng Nam 6h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 63221u, 89086u },
						description = "h\u00adíng B¾c 12h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 80,
				directionHints = new DirectionHintEntry[4]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 56380u, 106646u },
						description = "h\u00adíng §«ng 3h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 50917u, 92768u },
						description = "h\u00adíng T©y 9h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 48429u, 104024u },
						description = "h\u00adíng Nam 6h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 62131u, 93666u },
						description = "h\u00adíng B¾c 12h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 162,
				directionHints = new DirectionHintEntry[4]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 56839u, 107064u },
						description = "h\u00adíng §«ng 3h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 43559u, 100304u },
						description = "h\u00adíng T©y 9h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 45153u, 108673u },
						description = "h\u00adíng Nam 6h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 54425u, 95510u },
						description = "h\u00adíng B¾c 12h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 202,
				directionHints = new DirectionHintEntry[3]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 54716u, 94681u },
						description = "cöa vµo rÏ tr\u00b8i ch¹y h\u00adíng nam"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 48950u, 88552u },
						description = "cöa vµo rÏ ph¶i ch¹y h\u00adíng b¾c 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 48896u, 97056u },
						description = "ch¹y h\u00adíng 9h xuèng cuèi ®éng"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 204,
				directionHints = new DirectionHintEntry[3]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 57958u, 110566u },
						description = "cæng vµo rÏ tr\u00b8i ch¹y h\u00adíng nam"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 48160u, 112371u },
						description = "ë trung t©m ®éng"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 45066u, 109081u },
						description = "ë cuèi ®éng"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 198,
				directionHints = new DirectionHintEntry[2]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 49547u, 90264u },
						description = "gÇn cæng vµo"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 52053u, 98092u },
						description = "cæng vµo rÏ ph¶i ®Õn trung t©m"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 199,
				directionHints = new DirectionHintEntry[4]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 57289u, 95424u },
						description = "h\u00adíng ®«ng"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 46190u, 93965u },
						description = "h\u00adíng 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 51624u, 103140u },
						description = "h\u00adíng 6h ë cuèi ®éng"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 54092u, 97144u },
						description = "trung t©m"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 181,
				directionHints = new DirectionHintEntry[3]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 51331u, 94268u },
						description = "gÇn cæng vµo ch¹y lªn h\u00adíng 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 48624u, 98846u },
						description = "ë trung t©m ®éng"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 45286u, 96712u },
						description = "cuèi ®éng gÇn cæng Vò Di s¬n"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 205,
				directionHints = new DirectionHintEntry[4]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 53649u, 108120u },
						description = "gÇn cæng vµo"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 50342u, 102822u },
						description = "ë gÇn t©m ®éng"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 47928u, 99394u },
						description = "ë kháang gi÷a t©m vµ cuèi ®éng"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 41450u, 98906u },
						description = "cuèi ®éng"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 224,
				directionHints = new DirectionHintEntry[5]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 55232u, 90952u },
						description = "ch¹y lªn h\u00adíng 12h ®iÓm trªn cïng"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 58192u, 97258u },
						description = "cöa KHL lªn cÇu 2 rÏ ph¶i h\u00adíng 3h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 46911u, 96784u },
						description = "cöa KHL lªn cÇu 1 rÏ tr\u00b8i h\u00adíng 9h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 51892u, 95128u },
						description = "cöa KHL lªn cÇu ®Õn gÇn trung t©m"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 53794u, 103654u },
						description = "cöa KHL lªn cÇu 2 rÏ ph¶i"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 336,
				directionHints = new DirectionHintEntry[3]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 38781u, 100227u },
						description = "gÇn bÕn 1"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 44935u, 97010u },
						description = "gÇn bÕn 2"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 49826u, 93790u },
						description = "gÇn bÕn 3"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 225,
				directionHints = new DirectionHintEntry[6]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 49972u, 105038u },
						description = "gÇn Cam ChÝnh C«, cöa gi÷a ch¹y h\u00adíng 3h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 45906u, 107350u },
						description = "gÇn D\u00ad¬ng Phong DËt, cöa gi÷a rÏ tr\u00b8i"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 45520u, 111178u },
						description = "cöa gi÷a rÏ tr\u00b8i ch¹y ®Õn cuèi ®\u00adêng rÏ tr\u00b8i 6h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 40840u, 104004u },
						description = "gÇn Vò NhÊt ThÕ, cöa gi÷a rÏ tr\u00b8i ch¹y 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 45642u, 100100u },
						description = "gÇn Hµ Sinh Vong, cöa gi÷a rÏ ph¶i ch¹y 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 51283u, 103064u },
						description = "gÇn cöa ®éng ngßai biªn cïng h\u00adíng 3h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 226,
				directionHints = new DirectionHintEntry[3]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 51034u, 101218u },
						description = "gÇn trªn cïng h\u00adíng 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 55614u, 103074u },
						description = "gÇn trung t©m"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 60145u, 102942u },
						description = "gÇn gãc d\u00adíi h\u00adíng 3h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 227,
				directionHints = new DirectionHintEntry[3]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 43388u, 101212u },
						description = "gÇn trªn cïng h\u00adíng 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 50872u, 103450u },
						description = "gÇn trung t©m"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 53596u, 97876u },
						description = "ngßai biªn h\u00adíng 3h cña trung t©m"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 321,
				directionHints = new DirectionHintEntry[3]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 40558u, 74636u },
						description = "thuéc cæng trªn h\u00adíng 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 40558u, 87112u },
						description = "khu vùc gÇn trung t©m"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 40558u, 99588u },
						description = "thuéc cæng d\u00adíi h\u00adíng 6h"
					}
				}
			},
			new MapDirectionHintGroup
			{
				mapId = 321,
				directionHints = new DirectionHintEntry[3]
				{
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 57741u, 100794u },
						description = "thuéc cæng trªn h\u00adíng 12h"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 57741u, 116013u },
						description = "khu vùc gÇn trung t©m"
					},
					new DirectionHintEntry
					{
						coordinates = new uint[2] { 57741u, 131232u },
						description = "thuéc cæng d\u00adíi h\u00adíng 6h"
					}
				}
			}
		};
	}

	public static string GetNearestDirectionHint(int int_3, uint[] uint_0)
	{
		if (directionHintGroups == null)
		{
			InitializeDirectionHints();
		}
		int num = 0;
		int num2;
		while (true)
		{
			if (num < directionHintGroups.Length)
			{
				if (int_3 != directionHintGroups[num].mapId)
				{
					num++;
					continue;
				}
				num2 = -1;
				long num3 = 0L;
				for (int i = 0; i < directionHintGroups[num].directionHints.Length; i++)
				{
					long num4 = Class64.GetSquaredCoordinateDistance(uint_0, directionHintGroups[num].directionHints[i].coordinates);
					if (num2 < 0 || num4 < num3)
					{
						num2 = i;
						num3 = num4;
					}
				}
				if (0 <= num2)
				{
					break;
				}
			}
			return string.Empty;
		}
		return " " + directionHintGroups[num].directionHints[num2].description;
	}

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
						Form1.characterAccountConfig_1[num].bool_46 = false;
					}
					break;
				}
				if (!flag)
				{
					if (Form1.characterAccountConfig_1[num].bool_46)
					{
						break;
					}
					Form1.characterAccountConfig_1[num].bool_46 = true;
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

	private static void RunForCharacter(int int_3)
	{
		int int_4 = 0;
		byte[] array = new byte[4];
		byte[] array2 = new byte[40];
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		uint num = 0u;
		int num2 = 0;
		string[] array3 = new string[5] { " (Kim) ", " (Méc) ", " (Thñy) ", " (Háa) ", " (Thæ) " };
		long long_ = 0L;
		int num3 = 0;
		uint[] array4 = null;
		string text = string.Empty;
		while (true)
		{
			Thread.Sleep(800);
			int num4 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_3);
			if (CommonUtility.bool_0 || num4 < 0 || !Form1.characterAccountConfig_1[num4].bool_25)
			{
				break;
			}
			characterAccountConfig = Form1.characterAccountConfig_1[num4];
			if (characterAccountConfig.int_1 > 0 && characterAccountConfig.int_20[0] <= 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, array, 4, ref int_4);
				int num5 = BitConverter.ToInt32(array, 0);
				if (num2 == num5)
				{
					uint uint_ = characterAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, uint_, array, 4, ref int_4);
					int num6 = BitConverter.ToInt32(array, 0);
					if (num6 > 1)
					{
						uint num7 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig.int_137);
						uint num8 = WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
						uint num9 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig.int_137);
						uint num10 = num9 + num8;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num10 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, array, 4, ref int_4);
						int num11 = BitConverter.ToInt32(array, 0);
						if (num11 > 0)
						{
							if (CommonUtility.GetElapsedMilliseconds(long_) < ReportOptions[3] * 1000)
							{
								continue;
							}
							uint[] array5 = new uint[2]
							{
								WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig.int_137),
								WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig.int_137)
							};
							uint[] array6 = new uint[2];
							int num12 = 0;
							for (uint num13 = 1u; num13 < 256; num13++)
							{
								if (num13 % 50 == 0)
								{
									Thread.Sleep(100);
								}
								if (num != 0)
								{
									num13 = num;
								}
								if (num6 <= num12)
								{
									break;
								}
								uint num14 = num9 + num13 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array, 4, ref int_4);
								if (array[0] != 0)
								{
									num12++;
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, array, 4, ref int_4);
									if (BitConverter.ToInt32(array, 0) > 0)
									{
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, array, 4, ref int_4);
										if (BitConverter.ToInt32(array, 0) == 0)
										{
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, array, 4, ref int_4);
											int num15 = BitConverter.ToInt32(array, 0);
											if (num15 != 10 && num15 != 21)
											{
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14, array, 4, ref int_4);
												int num16 = BitConverter.ToInt32(array, 0);
												if (num16 > 0)
												{
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_26.resolvedValue + 8, array, 4, ref int_4);
													int num17 = BitConverter.ToInt32(array, 0);
													if (num17 > 0)
													{
														WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_26.resolvedValue + 12, array, 4, ref int_4);
														int num18 = BitConverter.ToInt32(array, 0);
														if (num18 >= 16)
														{
															WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_51.resolvedValue, array, 4, ref int_4);
															int num19 = BitConverter.ToInt32(array, 0);
															if (num19 > 0)
															{
																WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_53.resolvedValue, array, 4, ref int_4);
																int num20 = BitConverter.ToInt32(array, 0);
																if (num20 >= 0 && num20 <= 4)
																{
																	WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, array, 4, ref int_4);
																	array6[0] = BitConverter.ToUInt32(array, 0);
																	WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, array, 4, ref int_4);
																	array6[1] = BitConverter.ToUInt32(array, 0);
																	WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_45.resolvedValue, array, 4, ref int_4);
																	long num21 = BitConverter.ToInt32(array, 0);
																	WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_47.resolvedValue, array, 4, ref int_4);
																	long num22 = BitConverter.ToInt32(array, 0);
																	WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, array2, array2.Length, ref int_4);
																	string text2 = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2);
																	WindowsInteropHelper.ReadProcessMemory(characterAccountConfig.int_137, characterAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_28.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_29.resolvedValue, array2, array2.Length, ref int_4);
																	string text3 = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2);
																	Class64.GetSquaredCoordinateDistance(array5, array6);
																	num = num13;
																	double num23 = 0.0;
																	if ((ulong)num22 > 0uL)
																	{
																		num23 = 100L * num21 / num22;
																	}
																	string text4 = text2 + array3[num20] + num23 + "% (" + num21 + " )" + text3 + " (" + array6[0] / 256 + "," + array6[1] / 512 + ")";
																	if (IncludeDirectionDetails > 0)
																	{
																		if (num3 != num16 || array4 == null || Class64.GetSquaredCoordinateDistance(array4, array5) > 1500000L)
																		{
																			num3 = num16;
																			array4 = new uint[2]
																			{
																				array5[0],
																				array5[1]
																			};
																			text = GetNearestDirectionHint(num5, array6);
																		}
																		if (text != null)
																		{
																			text4 += text;
																		}
																	}
																	if (ReportOptions[0] > 0)
																	{
																		GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "* " + text4);
																		Thread.Sleep(300);
																	}
																	if (ReportOptions[1] > 0)
																	{
																		GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig, "Chat('CH_CHATROOM', '(lvd)" + text4 + "')");
																		Thread.Sleep(300);
																	}
																	if (ReportOptions[2] > 0)
																	{
																		GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig, "Chat('CH_TONG', '(lvd)" + text4 + "')");
																		Thread.Sleep(300);
																	}
																	long_ = CommonUtility.GetCurrentTicks();
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
								if (num != 0)
								{
									num = 0u;
									num13 = 0u;
									num12 = 0;
								}
							}
						}
						else
						{
							num = 0u;
							long_ = 0L;
						}
					}
					else
					{
						num = 0u;
						long_ = 0L;
					}
				}
				else
				{
					num2 = num5;
					num = 0u;
					long_ = 0L;
				}
			}
			else
			{
				num = 0u;
				long_ = 0L;
			}
		}
	}
}
