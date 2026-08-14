using System;
using System.Threading;
using ns1;
using ns10;
using ns100;
using ns11;
using ns121;
using ns13;
using ns18;
using ns23;
using ns28;
using ns3;
using ns33;
using ns34;
using ns35;
using ns40;
using ns41;
using ns42;
using ns43;
using ns44;
using ns50;
using ns53;
using ns61;
using ns63;
using ns71;
using ns81;
using ns83;
using ns85;
using ns88;

namespace ns56;

internal class TongKimBattlefieldHelper
{
	public static int int_0;

	public static long long_0;

	public static uint[] uint_0;

	public static uint[] uint_1;

	public static int int_1;

	public static string string_0;

	public static uint[] uint_2;

	public static int[] int_2;

	private static int[,] battlefieldMapGroups;

	private static int[,] battlefieldMapMatrix;

	public static uint[,] uint_3;

	public static uint[,] uint_4;

	public static uint[,] uint_5;

	public static GStruct54[] gstruct54_0;

	public static int int_5;

	static TongKimBattlefieldHelper()
	{
		int_0 = 0;
		long_0 = 0L;
		uint_0 = new uint[2]
		{
			(uint)WindowsRegistryHelper.ReadApplicationRegistryInt32("CongHauDoanhNgoai_0", 0, "0"),
			(uint)WindowsRegistryHelper.ReadApplicationRegistryInt32("CongHauDoanhNgoai_1", 0, "0")
		};
		uint_1 = new uint[2]
		{
			(uint)WindowsRegistryHelper.ReadApplicationRegistryInt32("CongHauDoanhTrong_0", 0, "0"),
			(uint)WindowsRegistryHelper.ReadApplicationRegistryInt32("CongHauDoanhTrong_1", 0, "0")
		};
		int_1 = WindowsRegistryHelper.ReadApplicationRegistryInt32("MapIDCongTongKim", 0, "0");
		string_0 = null;
		uint_2 = null;
		int_2 = new int[3] { 580, 581, 581 };
		battlefieldMapGroups = new int[20, 3]
		{
			{ 326, 327, 328 },
			{ 329, 330, 331 },
			{ 344, 345, 346 },
			{ 347, 348, 349 },
			{ 350, 351, 352 },
			{ 353, 354, 355 },
			{ 375, 376, 377 },
			{ 378, 379, 380 },
			{ 381, 382, 383 },
			{ 384, 385, 386 },
			{ 580, -1, -1 },
			{ 605, 606, -1 },
			{ 878, -1, -1 },
			{ 881, -1, -1 },
			{ 900, -1, -1 },
			{ 901, -1, -1 },
			{ 902, 903, 904 },
			{ 977, -1, -1 },
			{ 989, -1, -1 },
			{ 990, -1, -1 }
		};
		battlefieldMapMatrix = new int[3, 3]
		{
			{ 323, 324, 325 },
			{ 326, 327, 328 },
			{ 329, 330, 331 }
		};
		uint_3 = new uint[6, 2]
		{
			{ 49740u, 106630u },
			{ 49985u, 106347u },
			{ 50350u, 105697u },
			{ 50752u, 105119u },
			{ 51116u, 104829u },
			{ 51486u, 104462u }
		};
		uint_4 = new uint[9, 2]
		{
			{ 49872u, 102394u },
			{ 49664u, 102179u },
			{ 49572u, 102070u },
			{ 49426u, 101850u },
			{ 49350u, 101729u },
			{ 49308u, 101488u },
			{ 49274u, 101284u },
			{ 49176u, 101087u },
			{ 48980u, 100936u }
		};
		uint_5 = new uint[11, 2]
		{
			{ 50979u, 99700u },
			{ 50930u, 99447u },
			{ 50869u, 99248u },
			{ 50781u, 98964u },
			{ 50709u, 98688u },
			{ 50552u, 98722u },
			{ 50321u, 98780u },
			{ 50180u, 98814u },
			{ 49868u, 98886u },
			{ 50041u, 98712u },
			{ 50207u, 98502u }
		};
		gstruct54_0 = new GStruct54[32]
		{
			new GStruct54
			{
				int_0 = new int[3] { 378, 379, 380 },
				uint_3 = new uint[2] { 53274u, 97690u },
				uint_2 = new uint[2] { 53943u, 97608u },
				uint_1 = new uint[2] { 53334u, 99022u },
				int_1 = 230,
				uint_0 = new uint[5, 2]
				{
					{ 53274u, 97690u },
					{ 53589u, 97554u },
					{ 53943u, 97608u },
					{ 54011u, 98426u },
					{ 53334u, 99022u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 378, 379, 380 },
				uint_3 = new uint[2] { 39564u, 114268u },
				uint_2 = new uint[2] { 40024u, 113810u },
				uint_1 = new uint[2] { 40118u, 113176u },
				int_1 = 60,
				uint_0 = new uint[5, 2]
				{
					{ 39282u, 114036u },
					{ 39747u, 113658u },
					{ 40024u, 113810u },
					{ 39991u, 113404u },
					{ 40118u, 113176u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 381, 382, 383 },
				uint_3 = new uint[2] { 51936u, 101024u },
				uint_2 = new uint[2] { 52896u, 100928u },
				uint_1 = new uint[2] { 53168u, 100268u },
				int_1 = 60,
				uint_0 = new uint[3, 2]
				{
					{ 51936u, 101024u },
					{ 52896u, 100928u },
					{ 53168u, 100268u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 381, 382, 383 },
				uint_3 = new uint[2] { 65505u, 83302u },
				uint_2 = new uint[2] { 65704u, 82730u },
				uint_1 = new uint[2] { 65113u, 83556u },
				int_1 = 230,
				uint_0 = new uint[3, 2]
				{
					{ 65704u, 82730u },
					{ 65505u, 83302u },
					{ 65113u, 83556u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 381, -1, -1 },
				uint_3 = new uint[2] { 39616u, 114368u },
				uint_2 = new uint[2] { 40064u, 113952u },
				uint_1 = new uint[2] { 40195u, 113152u },
				int_1 = 45,
				uint_0 = new uint[4, 2]
				{
					{ 39274u, 114076u },
					{ 39515u, 113798u },
					{ 39873u, 113564u },
					{ 40195u, 113152u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 381, -1, -1 },
				uint_3 = new uint[2] { 53184u, 97792u },
				uint_2 = new uint[2] { 53984u, 97568u },
				uint_1 = new uint[2] { 53385u, 99204u },
				int_1 = 230,
				uint_0 = new uint[5, 2]
				{
					{ 53529u, 97630u },
					{ 53946u, 97696u },
					{ 54036u, 98206u },
					{ 53903u, 98622u },
					{ 53385u, 99204u }
				}
			},
			new GStruct54
			{
				int_0 = new int[1] { 383 },
				uint_3 = new uint[2] { 39616u, 114368u },
				uint_2 = new uint[2] { 40064u, 113952u },
				uint_1 = new uint[2] { 40139u, 113076u },
				int_1 = 60,
				uint_0 = new uint[4, 2]
				{
					{ 39040u, 114272u },
					{ 39318u, 114034u },
					{ 39913u, 113616u },
					{ 40171u, 113152u }
				}
			},
			new GStruct54
			{
				int_0 = new int[1] { 383 },
				uint_3 = new uint[2] { 53248u, 97816u },
				uint_2 = new uint[2] { 53984u, 97568u },
				uint_1 = new uint[2] { 53325u, 99230u },
				int_1 = 230,
				uint_0 = new uint[4, 2]
				{
					{ 53248u, 97816u },
					{ 53968u, 97622u },
					{ 54076u, 98366u },
					{ 53477u, 98984u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 384, 385, 386 },
				uint_3 = null,
				uint_2 = new uint[2] { 46432u, 73088u },
				uint_1 = new uint[2] { 45974u, 73600u },
				int_1 = 230,
				uint_0 = new uint[5, 2]
				{
					{ 47654u, 72844u },
					{ 47393u, 72542u },
					{ 46936u, 73072u },
					{ 46569u, 73322u },
					{ 45974u, 73600u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 384, 385, 386 },
				uint_3 = null,
				uint_2 = new uint[2] { 47168u, 99360u },
				uint_1 = new uint[2] { 47812u, 99598u },
				int_1 = 60,
				uint_0 = new uint[3, 2]
				{
					{ 46598u, 100330u },
					{ 47317u, 99710u },
					{ 47812u, 99598u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 580, 581, 581 },
				uint_2 = new uint[2] { 49280u, 106080u },
				uint_1 = new uint[2] { 65113u, 83556u },
				int_1 = 230,
				uint_0 = new uint[8, 2]
				{
					{ 48802u, 105952u },
					{ 49244u, 106270u },
					{ 49659u, 106548u },
					{ 50167u, 107196u },
					{ 49618u, 107680u },
					{ 49211u, 107988u },
					{ 48798u, 108438u },
					{ 48662u, 108504u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 900, -1, -1 },
				uint_3 = new uint[2] { 53274u, 97690u },
				uint_2 = new uint[2] { 53984u, 97568u },
				uint_1 = new uint[2] { 53334u, 99022u },
				int_1 = 230,
				uint_0 = new uint[5, 2]
				{
					{ 53274u, 97690u },
					{ 53589u, 97554u },
					{ 53943u, 97608u },
					{ 54011u, 98426u },
					{ 53334u, 99022u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 900, -1, -1 },
				uint_3 = null,
				uint_2 = new uint[2] { 40064u, 113952u },
				uint_1 = new uint[2] { 40133u, 113186u },
				int_1 = 60,
				uint_0 = new uint[4, 2]
				{
					{ 39241u, 114106u },
					{ 39432u, 113888u },
					{ 39826u, 113508u },
					{ 40076u, 113256u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 901, -1, -1 },
				uint_3 = new uint[2] { 53274u, 97690u },
				uint_2 = new uint[2] { 53984u, 97568u },
				uint_1 = new uint[2] { 53334u, 99022u },
				int_1 = 230,
				uint_0 = new uint[5, 2]
				{
					{ 53274u, 97690u },
					{ 53589u, 97554u },
					{ 53943u, 97608u },
					{ 54011u, 98426u },
					{ 53334u, 99022u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 901, -1, -1 },
				uint_3 = null,
				uint_2 = new uint[2] { 40064u, 113952u },
				uint_1 = new uint[2] { 40133u, 113186u },
				int_1 = 60,
				uint_0 = new uint[4, 2]
				{
					{ 39241u, 114106u },
					{ 39432u, 113888u },
					{ 39826u, 113508u },
					{ 40076u, 113256u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 881, -1, -1 },
				uint_3 = new uint[2] { 56768u, 127200u },
				uint_2 = new uint[2] { 56864u, 128960u },
				uint_1 = new uint[2] { 57664u, 127264u },
				int_1 = 60,
				uint_0 = new uint[3, 2]
				{
					{ 56768u, 127200u },
					{ 56864u, 128960u },
					{ 57664u, 127264u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 881, -1, -1 },
				uint_3 = new uint[2] { 75104u, 124992u },
				uint_2 = new uint[2] { 76928u, 106688u },
				uint_1 = new uint[2] { 75200u, 107680u },
				int_1 = 230,
				uint_0 = new uint[3, 2]
				{
					{ 75104u, 124992u },
					{ 76928u, 106688u },
					{ 75200u, 107680u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 353, 354, 355 },
				uint_3 = new uint[2] { 38752u, 100320u },
				uint_2 = new uint[2] { 38432u, 100704u },
				uint_1 = new uint[2] { 39274u, 100294u },
				int_1 = 90,
				uint_0 = new uint[3, 2]
				{
					{ 38693u, 100976u },
					{ 38930u, 100638u },
					{ 39274u, 100294u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 353, 354, 355 },
				uint_3 = new uint[2] { 39552u, 78240u },
				uint_2 = new uint[2] { 38752u, 78208u },
				uint_1 = new uint[2] { 39204u, 77372u },
				int_1 = 45,
				uint_0 = new uint[4, 2]
				{
					{ 39398u, 78316u },
					{ 38974u, 78210u },
					{ 38873u, 77656u },
					{ 39204u, 77372u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 353, 354, 355 },
				uint_3 = new uint[2] { 50656u, 78176u },
				uint_2 = new uint[2] { 50496u, 78304u },
				uint_1 = new uint[2] { 51400u, 77466u },
				int_1 = 60,
				uint_0 = new uint[5, 2]
				{
					{ 50665u, 76774u },
					{ 50468u, 77362u },
					{ 50539u, 78112u },
					{ 50956u, 77814u },
					{ 51400u, 77466u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 353, 354, 355 },
				uint_3 = new uint[2] { 49728u, 98496u },
				uint_2 = new uint[2] { 49408u, 98560u },
				uint_1 = new uint[2] { 50027u, 98682u },
				int_1 = 60,
				uint_0 = new uint[4, 2]
				{
					{ 49038u, 100018u },
					{ 49374u, 99586u },
					{ 49687u, 98930u },
					{ 50027u, 98682u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 902, 903, -1 },
				uint_3 = new uint[2] { 65568u, 83616u },
				uint_2 = new uint[2] { 65536u, 83264u },
				uint_1 = new uint[2] { 65124u, 83604u },
				int_1 = 230,
				uint_0 = new uint[2, 2]
				{
					{ 65405u, 83208u },
					{ 65124u, 83604u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 902, 903, -1 },
				uint_3 = new uint[2] { 52320u, 101568u },
				uint_2 = new uint[2] { 52800u, 100896u },
				uint_1 = new uint[2] { 53155u, 100298u },
				int_1 = 60,
				uint_0 = new uint[3, 2]
				{
					{ 52049u, 101258u },
					{ 52706u, 100688u },
					{ 53155u, 100298u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 904, -1, -1 },
				uint_3 = new uint[2] { 65120u, 82528u },
				uint_2 = new uint[2] { 65536u, 83264u },
				uint_1 = new uint[2] { 65086u, 83578u },
				int_1 = 250,
				uint_0 = new uint[3, 2]
				{
					{ 65362u, 82822u },
					{ 65330u, 83180u },
					{ 65086u, 83578u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 904, -1, -1 },
				uint_3 = new uint[2] { 52320u, 101568u },
				uint_2 = new uint[2] { 52800u, 100896u },
				uint_1 = new uint[2] { 53154u, 100294u },
				int_1 = 45,
				uint_0 = new uint[4, 2]
				{
					{ 52350u, 101078u },
					{ 52621u, 100766u },
					{ 52864u, 100546u },
					{ 53154u, 100294u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 989, -1, -1 },
				int_1 = 45,
				uint_2 = new uint[2] { 49536u, 98528u },
				uint_1 = new uint[2] { 50041u, 98494u },
				uint_0 = new uint[5, 2]
				{
					{ 48935u, 100048u },
					{ 49303u, 99686u },
					{ 49619u, 99244u },
					{ 49806u, 98736u },
					{ 50041u, 98494u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 989, -1, -1 },
				int_1 = 45,
				uint_2 = new uint[2] { 38656u, 100320u },
				uint_1 = new uint[2] { 39220u, 100216u },
				uint_0 = new uint[5, 2]
				{
					{ 38322u, 101596u },
					{ 38561u, 101112u },
					{ 38806u, 100824u },
					{ 39044u, 100494u },
					{ 39220u, 100216u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 989, -1, -1 },
				int_1 = 45,
				uint_2 = new uint[2] { 38912u, 78016u },
				uint_1 = new uint[2] { 39249u, 77342u },
				uint_0 = new uint[5, 2]
				{
					{ 38718u, 78888u },
					{ 38988u, 78502u },
					{ 39003u, 77968u },
					{ 39108u, 77500u },
					{ 39249u, 77342u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 989, -1, -1 },
				int_1 = 45,
				uint_2 = new uint[2] { 50144u, 77824u },
				uint_1 = new uint[2] { 51394u, 77416u },
				uint_0 = new uint[4, 2]
				{
					{ 50230u, 77836u },
					{ 50566u, 77896u },
					{ 50915u, 78016u },
					{ 51394u, 77416u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 990, -1, -1 },
				uint_3 = new uint[2] { 64224u, 87139u },
				uint_2 = new uint[2] { 64608u, 86784u },
				uint_1 = new uint[2] { 64256u, 87936u },
				int_1 = 250,
				uint_0 = new uint[2, 2]
				{
					{ 64480u, 87456u },
					{ 64256u, 87936u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 990, -1, -1 },
				uint_3 = new uint[2] { 50880u, 101312u },
				uint_2 = new uint[2] { 50304u, 101664u },
				uint_1 = new uint[2] { 51456u, 101376u },
				int_1 = 250,
				uint_0 = new uint[2, 2]
				{
					{ 51232u, 101600u },
					{ 51456u, 101376u }
				}
			},
			new GStruct54
			{
				int_0 = new int[3] { 977, -1, -1 },
				uint_2 = new uint[2]
				{
					MapTravelDataHelper.uint_0[0, 0],
					MapTravelDataHelper.uint_0[0, 1]
				}
			}
		};
		int_5 = 0;
	}

	public static int[] FindBattlefieldMapGroupPosition(int int_6)
	{
		for (int i = 0; i < battlefieldMapGroups.GetLength(0); i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (battlefieldMapGroups[i, j] == int_6)
				{
					return new int[2] { i, j };
				}
			}
		}
		return null;
	}

	public static int[] FindBattlefieldMapMatrixPosition(int int_6)
	{
		for (int i = 0; i < battlefieldMapMatrix.GetLength(0); i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (battlefieldMapMatrix[i, j] == int_6)
				{
					return new int[2] { i, j };
				}
			}
		}
		return null;
	}

	public static int FindConfiguredBattlefieldMapIndex(int int_6)
	{
		int num = 0;
		while (true)
		{
			if (num < int_2.GetLength(0))
			{
				if (int_2[num] == int_6)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	public static int FindNearestBattlefieldRouteIndex(uint[] uint_6, int int_6 = -1)
	{
		int num = -1;
		long num2 = -1L;
		if (int_6 > 0)
		{
			for (int i = 0; i < gstruct54_0.Length; i++)
			{
				if (gstruct54_0[i].int_0 == null)
				{
					continue;
				}
				bool flag = false;
				for (int j = 0; j < gstruct54_0[i].int_0.Length; j++)
				{
					if (int_6 == gstruct54_0[i].int_0[j])
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					long num3 = Class64.GetNearestCoordinateSquaredDistance(gstruct54_0[i].uint_0, uint_6);
					if (num2 < 0L || num < 0 || num3 < num2)
					{
						num2 = num3;
						num = i;
					}
				}
			}
			if (0 <= num)
			{
				return num;
			}
			return -1;
		}
		num2 = -1L;
		for (int k = 0; k < gstruct54_0.Length; k++)
		{
			long num4 = Class64.GetNearestCoordinateSquaredDistance(gstruct54_0[k].uint_0, uint_6);
			if ((num < 0 && num4 < 4000000L) || (0 <= num && num4 < num2))
			{
				num2 = num4;
				num = k;
			}
		}
		return num;
	}

	public static int ExitBattlefieldViaScoutNpc(CharacterAccountConfig characterAccountConfig_0, string string_1 = null, string string_2 = null)
	{
		long long_ = 0L;
		int num = -1;
		while (true)
		{
			Thread.Sleep(200);
			int num2 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig_0.int_137);
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
			uint num4 = WindowsInteropHelper.ReadProcessUInt32(num3 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
			uint num6 = num5 + num4;
			int num7 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig_0.int_137);
			int num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig_0.int_137);
			int num9 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
			if (num8 == 0 || num7 == 0 || num9 <= 1)
			{
				break;
			}
			int num10 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
			if (num < 0)
			{
				num = num10;
			}
			if (num == num10)
			{
				uint[] array = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
				};
				string text = "inh s\u00b8t";
				if (string_2 != null && string_2 != string.Empty)
				{
					text = string_2 + "|" + text;
				}
				if (string_0 != null && string_0 != string.Empty)
				{
					text = text + "|" + string_0;
				}
				int num11 = 0;
				uint[] array2 = null;
				array = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
				};
				int num12 = FindNearestBattlefieldRouteIndex(array, num2);
				if (num12 >= 0 && gstruct54_0[num12].uint_3 != null)
				{
					array2 = gstruct54_0[num12].uint_3;
					if (array2 != null)
					{
						num11 = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig_0, text, 3);
						if (num11 > 0)
						{
							array2 = GameEntityMemoryHelper.GetEntityPositionByIndex(characterAccountConfig_0, num11);
						}
					}
					else if (string_0 != null && !(string_0 == string.Empty) && uint_2 != null)
					{
						array2 = new uint[2]
						{
							uint_2[0],
							uint_2[1]
						};
					}
					else
					{
						num11 = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig_0, text, 3);
						if (num11 > 0)
						{
							array2 = GameEntityMemoryHelper.GetEntityPositionByIndex(characterAccountConfig_0, num11);
						}
						if (array2 == null)
						{
							return -1;
						}
					}
				}
				else
				{
					num11 = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig_0, text, 3);
					if (num11 <= 0)
					{
						return 0;
					}
					array2 = GameEntityMemoryHelper.GetEntityPositionByIndex(characterAccountConfig_0, num11);
				}
				long num13 = Class64.GetSquaredCoordinateDistance(array, array2);
				if (num13 > 120000L)
				{
					if (num10 > 0 && num11 <= 0 && num13 > 6011100L)
					{
						return -10;
					}
					if (num12 < 0 || gstruct54_0.GetLength(0) <= num12 || gstruct54_0[num12].uint_0 == null)
					{
						if (CommonUtility.GetElapsedMilliseconds(long_) > 4000L)
						{
							CharacterMovementHelper.MoveToCoordinates(characterAccountConfig_0, array2);
							long_ = CommonUtility.GetCurrentTicks();
						}
						continue;
					}
					TraverseCoordinateRoute(characterAccountConfig_0, gstruct54_0[num12].uint_0, array2, bool_0: true, 6000);
				}
				long_ = CommonUtility.GetCurrentTicks();
				while (!CommonUtility.bool_0)
				{
					GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig_0, array2);
					Thread.Sleep(300);
					array = new uint[2]
					{
						WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
						WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
					};
					num13 = Class64.GetSquaredCoordinateDistance(array, array2);
					if (num13 < 22500L || CommonUtility.GetElapsedMilliseconds(long_) > 3000L)
					{
						break;
					}
					int num14 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig_0.int_137);
					num10 = (int)WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
					if (num14 != num2 || num10 != num)
					{
						return 1;
					}
				}
				if (Form1.auxiliaryAccountsWaitForMainAccountEnabled > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 != characterAccountConfig_0.int_136 && (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 == 0 || (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 == 0)))
				{
					return 0;
				}
				if ((!AuxiliaryMachineManager.bool_7 && !AuxiliaryMachineManager.bool_6) || (characterAccountConfig_0.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == num2))
				{
					if (num11 <= 0)
					{
						num11 = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig_0, text, 3);
						if (num11 <= 0)
						{
							return 0;
						}
					}
					NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
					Thread.Sleep(100);
					CurrentCharacterMemoryHelper.SetCurrentTargetEntityIndex(characterAccountConfig_0, (uint)num11);
					Thread.Sleep(800);
					array = new uint[2]
					{
						WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
						WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
					};
					if (Form1.customScoutMenuSelectionEnabled > 0 && string_1 != null && string_1 != string.Empty)
					{
						NpcDialogHelper.SelectMatchingMenuOptions(characterAccountConfig_0, string_1.Replace("_", "|"), bool_0: false, bool_1: true);
						Thread.Sleep(800);
					}
					if (Form1.scoutMenuSelectionIndices != null && Form1.scoutMenuSelectionIndices != string.Empty)
					{
						string[] array3 = Form1.scoutMenuSelectionIndices.Split(',', ';', '.', '-', '/');
						for (int i = 0; i < array3.Length; i++)
						{
							if (NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig_0) < 0)
							{
								break;
							}
							int num15 = CommonUtility.ParseInt32OrZero(array3[i]) - 1;
							int num16 = NpcDialogHelper.GetMenuOptionCount(characterAccountConfig_0);
							if (0 <= num15 && num15 < num16)
							{
								NpcDialogHelper.SelectMenuOption(characterAccountConfig_0, num15);
								Thread.Sleep(250 + NpcDialogHelper.int_0);
							}
						}
					}
					for (int j = 0; j < 3; j++)
					{
						if (NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig_0) < 0)
						{
							break;
						}
						NpcDialogHelper.SelectMenuOption(characterAccountConfig_0, 0);
						Thread.Sleep(300);
					}
					int num17 = 0;
					int int_ = 0;
					byte[] array4 = new byte[4];
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array4, 4, ref int_);
					num2 = BitConverter.ToInt32(array4, 0);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_);
					num = BitConverter.ToInt32(array4, 0);
					int num18 = num2;
					while (true)
					{
						if (num17 < 15)
						{
							num17++;
							Thread.Sleep(100);
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array4, 4, ref int_);
							num3 = BitConverter.ToUInt32(array4, 0);
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num3 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array4, 4, ref int_);
							uint num19 = BitConverter.ToUInt32(array4, 0) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array4, 4, ref int_);
							num6 = BitConverter.ToUInt32(array4, 0) + num19;
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array4, 4, ref int_);
							num8 = BitConverter.ToInt32(array4, 0);
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array4, 4, ref int_);
							num2 = BitConverter.ToInt32(array4, 0);
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array4, 4, ref int_);
							num10 = BitConverter.ToInt32(array4, 0);
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array4, 4, ref int_);
							num7 = BitConverter.ToInt32(array4, 0);
							if (num9 <= 1 || num8 <= 0 || num2 <= 0 || num2 != num18 || num7 <= 0 || num != num10)
							{
								break;
							}
							uint[] array5 = new uint[2]
							{
								WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
								WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
							};
							long num20 = Class64.GetSquaredCoordinateDistance(array, array5);
							if (num20 > 200000L)
							{
								return 1;
							}
							continue;
						}
						return 0;
					}
					return 1;
				}
				return 2;
			}
			return 1;
		}
		return -1;
	}

	public static string[] GetNearestBattlefieldScoutExitSelection(int int_6, uint[] uint_6)
	{
		string[] array = null;
		uint[,] array2 = null;
		string text = null;
		string text2 = null;
		for (int i = 0; i < MapNavigationProfileProvider.mapNavigationEntry_0.Length; i++)
		{
			if (int_6 != MapNavigationProfileProvider.mapNavigationEntry_0[i].int_0)
			{
				continue;
			}
			if (MapNavigationProfileProvider.mapNavigationEntry_0[i].string_7 == null || MapNavigationProfileProvider.mapNavigationEntry_0[i].string_7 == string.Empty)
			{
				break;
			}
			text2 = MapNavigationProfileProvider.mapNavigationEntry_0[i].string_6;
			string[] array3 = MapNavigationProfileProvider.mapNavigationEntry_0[i].string_7.Split('|');
			uint[] array4 = null;
			uint[] array5 = null;
			for (int j = 0; j < array3.Length; j++)
			{
				if (array3[j] == null || array3[j] == string.Empty)
				{
					continue;
				}
				string[] array6 = array3[j].Split(',', ';');
				if (array6.Length < 3)
				{
					continue;
				}
				string text3 = array6[2];
				uint num = CommonUtility.ParseUInt32OrZero(array6[0]);
				uint num2 = CommonUtility.ParseUInt32OrZero(array6[1]);
				if (text3 == null || text3 == string.Empty || num == 0 || num2 == 0)
				{
					text3 = array6[0];
					num = CommonUtility.ParseUInt32OrZero(array6[1]);
					num2 = CommonUtility.ParseUInt32OrZero(array6[2]);
					if (text3 == null || text3 == string.Empty || num == 0 || num2 == 0)
					{
						continue;
					}
				}
				if (array == null)
				{
					array = new string[1];
					array4 = new uint[1];
					array5 = new uint[1];
				}
				else
				{
					Array.Resize(ref array, array.Length + 1);
					Array.Resize(ref array4, array4.Length + 1);
					Array.Resize(ref array5, array5.Length + 1);
				}
				array[array.Length - 1] = text3;
				array4[array4.Length - 1] = num;
				array5[array5.Length - 1] = num2;
			}
			if (array == null || array.Length == 0)
			{
				continue;
			}
			array2 = new uint[array.Length, 2];
			for (int k = 0; k < array2.GetLength(0); k++)
			{
				if (k < array4.Length && k < array5.Length)
				{
					array2[k, 0] = array4[k];
					array2[k, 1] = array5[k];
				}
			}
			break;
		}
		if (array2 != null)
		{
			int num3 = Class64.FindNearestCoordinateIndex(array2, uint_6);
			if (0 <= num3 && array[num3] != null)
			{
				text = array[num3];
			}
		}
		return new string[2] { text, text2 };
	}

	public static int ExitBattlefieldThroughGate(CharacterAccountConfig characterAccountConfig_0)
	{
		int int_ = characterAccountConfig_0.int_136;
		int num = 1;
		Thread.Sleep(100);
		int num2 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
		if (!CommonUtility.bool_0 && num2 >= 0 && !WindowsInteropHelper.IsProcessExitedOrUnavailable(Form1.characterAccountConfig_1[num2].process_0))
		{
			characterAccountConfig_0 = Form1.characterAccountConfig_1[num2];
			int num3 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig_0.int_137);
			uint num4 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
			uint num7 = num6 + num5;
			int num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig_0.int_137);
			int num9 = (int)WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig_0.int_137);
			int num10 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
			if (num9 != 0 && num8 != 0 && num10 > 1)
			{
				int num11 = (int)WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
				if (num11 > 0)
				{
					return 1;
				}
				uint[] uint_ = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
				};
				int num12 = FindNearestBattlefieldRouteIndex(uint_, num3);
				if (num12 >= 0)
				{
					if (gstruct54_0[num12].uint_1 == null)
					{
						return 0;
					}
					int num13 = gstruct54_0[num12].int_1;
					uint[] array = gstruct54_0[num12].uint_1;
					long num14 = Class64.GetSquaredCoordinateDistance(uint_, array);
					if (num14 > 60000L)
					{
						TraverseCoordinateRoute(characterAccountConfig_0, gstruct54_0[num12].uint_0, array, bool_0: true, 6000);
					}
					long long_ = CommonUtility.GetCurrentTicks();
					while (!CommonUtility.bool_0)
					{
						int num15 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig_0.int_137);
						num11 = (int)WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
						if (num3 == num15 && num11 <= 0)
						{
							uint_ = new uint[2]
							{
								WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
								WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
							};
							num14 = Class64.GetSquaredCoordinateDistance(uint_, array);
							if (num14 < 22500L || CommonUtility.GetElapsedMilliseconds(long_) > 6000L)
							{
								break;
							}
							GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig_0, array);
							Thread.Sleep(300);
							continue;
						}
						return 1;
					}
					long_ = CommonUtility.GetCurrentTicks();
					while (WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig_0.int_137) > 1 && CommonUtility.GetElapsedMilliseconds(long_) < 3000L)
					{
						Thread.Sleep(100);
					}
					bool flag = Form1.auxiliaryAccountsWaitForMainAccountEnabled > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 != characterAccountConfig_0.int_136 && (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 == 0 || (CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 == 0));
					num11 = (int)WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
					if (!flag && num11 <= 0)
					{
						if ((!AuxiliaryMachineManager.bool_7 && !AuxiliaryMachineManager.bool_6) || (characterAccountConfig_0.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4 == num3))
						{
							int num16 = 0;
							while (true)
							{
								Class64.Move200UnitsAtAngle(characterAccountConfig_0, num13);
								Thread.Sleep(350);
								num = 2;
								if (Form1.int_100[0] > 0)
								{
									int num17 = 0;
									int int_2 = 0;
									byte[] array2 = null;
									bool flag2 = false;
									while (num17 < 40)
									{
										int num18 = InventoryItemHelper.GetCollectionBoxProgressValue(characterAccountConfig_0);
										array2 = CommonUtility.ConvertStringToSingleByteArray(num18.ToString());
										WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_89.uint_0, array2, array2.Length, ref int_2);
										if (num18 <= 0)
										{
											num17++;
											Thread.Sleep(10);
											continue;
										}
										flag2 = true;
										break;
									}
									num17 = 0;
									int num19 = Form1.int_100[1];
									if (num19 < 100)
									{
										num19 = 100;
									}
									while (flag2 && num17 < 1200)
									{
										int num20 = (int)WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
										if (num20 > 0)
										{
											break;
										}
										int num21 = InventoryItemHelper.GetCollectionBoxProgressValue(characterAccountConfig_0);
										flag2 = 0 < num21 && num21 < num19;
										array2 = CommonUtility.ConvertStringToSingleByteArray((num21 + 11).ToString());
										WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_89.uint_0, array2, array2.Length, ref int_2);
										num17++;
										Thread.Sleep(10);
									}
								}
								int num22 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig_0.int_137);
								num11 = (int)WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
								if (num22 != num3 || num11 > 0 || num16 >= 3)
								{
									break;
								}
								num16++;
							}
							if (num11 > 0 && num16 > 0)
							{
								uint_ = new uint[2]
								{
									WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
									WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
								};
								GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig_0, uint_);
							}
							return num;
						}
						return 2;
					}
					return 1;
				}
				GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig_0, "<color=green>Ban do TK chua dinh nghia !");
				Thread.Sleep(600);
				return -1;
			}
			return -1;
		}
		return -1;
	}

	public static int RestockBattlefieldSupplies(CharacterAccountConfig characterAccountConfig_0)
	{
		while (true)
		{
			try
			{
				if (characterAccountConfig_0.int_77 <= 0)
				{
					return RestockBattlefieldSuppliesCore(characterAccountConfig_0);
				}
				MedicineRestockAutomation.RestockFromKtc(characterAccountConfig_0);
				return 1;
			}
			catch
			{
				GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_32, 0, 4);
			}
		}
	}

	private static int RestockBattlefieldSuppliesCore(CharacterAccountConfig characterAccountConfig_0)
	{
		int int_ = characterAccountConfig_0.int_136;
		int result = 0;
		int num = 0;
		int num2 = -1;
		string text = "hu quan|Ëu CÇn|huèc|u doanh q|Chñ d\u00adîc|D\u00adîc §iÕm";
		string string_ = "ua d\u00adîc p|rao ®æi|ua th|Shop|Giao d";
		string string_2 = "Mua M\u00b8u";
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		int num11 = 0;
		int num12 = 0;
		int num13 = 0;
		long long_ = 0L;
		int int_2 = 0;
		int num14 = 0;
		int[] array = new int[10];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 4;
		}
		byte[] array2 = new byte[4];
		byte[] byte_ = new byte[4];
		GStruct1[] array3 = null;
		string[] array4 = text.Split('|');
		bool flag = false;
		bool flag2 = false;
		if (characterAccountConfig_0.int_79 > 0 && Form1.transferMedicineBeforePurchaseEnabled > 0)
		{
			string text2 = Form1.freeMedicineName;
			if (characterAccountConfig_0.string_11 != null && characterAccountConfig_0.string_11 != string.Empty)
			{
				if (text2 != null && text2 != string.Empty)
				{
					text2 += "|";
				}
				text2 += characterAccountConfig_0.string_11;
			}
			if (text2 != null && text2 != string.Empty)
			{
				Thread.Sleep(1000);
				if (MedicineRestockAutomation.MoveMatchingInventoryItemsToContainer23(characterAccountConfig_0, text2) != 1)
				{
					num11 = 2;
				}
			}
		}
		while (true)
		{
			IL_0b66:
			Thread.Sleep(300);
			int num15 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
			if (CommonUtility.bool_0 || num15 < 0 || !Form1.characterAccountConfig_1[num15].bool_25)
			{
				break;
			}
			characterAccountConfig_0 = Form1.characterAccountConfig_1[num15];
			if ((characterAccountConfig_0.int_71[0] > 0 && characterAccountConfig_0.int_71[2] > 0) || (characterAccountConfig_0.int_72[0] > 0 && characterAccountConfig_0.int_72[2] > 0) || (characterAccountConfig_0.int_73[0] > 0 && characterAccountConfig_0.int_73[2] > 0) || characterAccountConfig_0.int_78 > 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array2, 4, ref int_2);
				uint num16 = BitConverter.ToUInt32(array2, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num16 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array2, 4, ref array[0]);
				uint num17 = BitConverter.ToUInt32(array2, 0) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array2, 4, ref int_2);
				uint num18 = BitConverter.ToUInt32(array2, 0);
				uint num19 = num18 + num17;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num19 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array2, 4, ref array[1]);
				int num20 = BitConverter.ToInt32(array2, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num19 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array2, 4, ref array[2]);
				int num21 = BitConverter.ToInt32(array2, 0);
				if (num21 != 10 && num21 != 21)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array2, 4, ref array[3]);
					int num22 = BitConverter.ToInt32(array2, 0);
					int num23 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
					if (num20 != 0 && num21 != 0 && num22 != 0 && num23 > 1)
					{
						num14 = 3;
						int num24 = 0;
						while (num24 <= num14)
						{
							if (array[num24] != 0)
							{
								num24++;
								continue;
							}
							goto IL_0b66;
						}
						uint[] array5 = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num19 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num19 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
						};
						if (array5[0] == 0 || array5[1] == 0)
						{
							continue;
						}
						int num25 = Class85.GetFreeItemGridCellCount(characterAccountConfig_0);
						if (num25 != 0)
						{
							int num26 = (int)WindowsInteropHelper.ReadProcessUInt32(num19 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
							if (num26 <= 0)
							{
								if (num3 == 0)
								{
									array2[0] = 1;
									WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_32 * 4, array2, 1, ref int_2);
									WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num19 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_2);
									num3 = 1;
								}
								WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_105.uint_0, characterAccountConfig_0.int_137);
								int num27 = FindNearestBattlefieldRouteIndex(array5, num22);
								if (num27 < 0 || gstruct54_0.GetLength(0) <= num27)
								{
									result = -2;
									goto IL_10c2;
								}
								if (!flag)
								{
									int num28 = Class64.FindNearestCoordinateIndex(gstruct54_0[num27].uint_0, gstruct54_0[num27].uint_2);
									if (num28 < 0)
									{
										flag = true;
										num2 = 0;
									}
									else
									{
										uint[] uint_ = new uint[2]
										{
											gstruct54_0[num27].uint_0[num28, 0],
											gstruct54_0[num27].uint_0[num28, 1]
										};
										long num29 = Class64.GetSquaredCoordinateDistance(array5, uint_);
										if (num29 > 300000L)
										{
											num12++;
											if (num12 >= 3)
											{
												if (CommonUtility.GetElapsedMilliseconds(long_) > 4000L)
												{
													CharacterMovementHelper.MoveToCoordinates(characterAccountConfig_0, uint_);
													long_ = CommonUtility.GetCurrentTicks();
												}
											}
											else
											{
												TraverseCoordinateRoute(characterAccountConfig_0, gstruct54_0[num27].uint_0, uint_, bool_0: true, 8000);
											}
											continue;
										}
										flag = true;
										num2 = 0;
									}
								}
							}
							uint[] array6 = null;
							if (num2 > 0)
							{
								string text3 = GameEntityMemoryHelper.GetEntityNameAndPositionByIndex(characterAccountConfig_0, num2, ref array6, 30);
								if (text3 != null)
								{
									bool flag3 = false;
									for (int j = 0; j < array4.Length; j++)
									{
										if (0 <= CommonUtility.FindSubstringIndex(text3, array4[j]))
										{
											flag3 = true;
											break;
										}
									}
									if (!flag3)
									{
										num2 = 0;
										array6 = null;
									}
								}
								else
								{
									num2 = 0;
									array6 = null;
								}
							}
							if (num2 <= 0)
							{
								num2 = GameEntityMemoryHelper.FindNearestEntityIndexByNameAndType(characterAccountConfig_0, text, ref array6, 3, bool_0: false);
								if (num2 <= 0)
								{
									result = -4;
									Class64.TryRecoverStuckMovement(characterAccountConfig_0);
									goto IL_10c2;
								}
							}
							if (num2 > 0 && array6 != null)
							{
								for (num13 = 0; num13 < 10; num13++)
								{
									array5 = new uint[2]
									{
										WindowsInteropHelper.ReadProcessUInt32(num19 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
										WindowsInteropHelper.ReadProcessUInt32(num19 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
									};
									long num30 = Class64.GetSquaredCoordinateDistance(array5, array6);
									if (num30 < 11250L)
									{
										break;
									}
									GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig_0, array6);
									Thread.Sleep(300);
								}
							}
							while (true)
							{
								NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
								Thread.Sleep(100);
								CurrentCharacterMemoryHelper.SetCurrentTargetEntityIndex(characterAccountConfig_0, (uint)num2);
								Thread.Sleep(600);
								if (NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig_0) >= 0)
								{
									num4 = 0;
									num5 = 0;
									if (num26 == 0 && num6 == 0)
									{
										if (characterAccountConfig_0.string_15 != null && characterAccountConfig_0.string_15 != string.Empty)
										{
											uint num31 = CommonUtility.ParseUInt32OrZero(characterAccountConfig_0.string_15);
											if (num31 != 0)
											{
												GameProcessInteractionHelper.UnlockInventoryBoxWithPasswordCode(characterAccountConfig_0, num31);
												Thread.Sleep(150);
											}
										}
										uint num32 = num16 + GameConfigurationManager.memorySignatureScanConfig_12.uint_0 + GameConfigurationManager.memorySignatureScanConfig_75.uint_0;
										long num33 = WindowsInteropHelper.ReadProcessUInt32(num32 + GameConfigurationManager.memorySignatureScanConfig_74.uint_0, characterAccountConfig_0.int_137);
										if (num33 > 0L)
										{
											if (Form1.int_67[0] <= 0)
											{
												if (num33 > 6000000L)
												{
													num33 = 6000000L;
												}
											}
											else if (num33 > Form1.int_67[1] * 10000)
											{
												num33 = Form1.int_67[1] * 10000;
											}
											long num34 = WindowsInteropHelper.ReadProcessUInt32(num32 + GameConfigurationManager.memorySignatureScanConfig_73.uint_0, characterAccountConfig_0.int_137);
											if (num34 < num33)
											{
												long num35 = num33 - num34;
												GameProcessInteractionHelper.TransferStoredMoneyToCharacter(characterAccountConfig_0, (uint)num35);
												Thread.Sleep(150);
											}
										}
										num6 = 1;
									}
									if (characterAccountConfig_0.int_78 > 0 && !flag2)
									{
										int num36 = Class85.GetInventoryEntryCount(characterAccountConfig_0);
										if (Form1.int_134 == null)
										{
											NpcDialogHelper.SelectMenuOption(characterAccountConfig_0, 0);
											Thread.Sleep(450);
										}
										else
										{
											for (int k = 0; k < Form1.int_134.Length; k++)
											{
												if (Form1.int_134[k] > 0)
												{
													NpcDialogHelper.SelectMenuOption(characterAccountConfig_0, Form1.int_134[k] - 1);
													Thread.Sleep(450);
												}
											}
										}
										int l = 0;
										int num37 = 0;
										int num38;
										for (num38 = 12; l < num38; l++)
										{
											if (WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_172.uint_0, characterAccountConfig_0.int_137) != 0 && !InventoryItemHelper.SubmitDetectedDialogResponse(characterAccountConfig_0))
											{
												if (Form1.skipPurchaseQuantityInputEnabled <= 0 && CommonUtility.ParseDigitsOnlyOrMinusOne(InventoryItemHelper.GetDialogInputText(characterAccountConfig_0)) != num25)
												{
													InventoryItemHelper.SetDialogInputText(characterAccountConfig_0, num25.ToString(), bool_0: true);
												}
												else
												{
													WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig_0.uint_4, 13u);
												}
												num37 = 1;
											}
											if (Class85.GetInventoryEntryCount(characterAccountConfig_0) <= num36)
											{
												if (num37 > 0)
												{
													num37++;
													if (num37 > 10)
													{
														break;
													}
												}
												Thread.Sleep(100 + NpcDialogHelper.int_0);
												continue;
											}
											num36 = -1;
											Thread.Sleep(300);
											if (0 <= NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig_0))
											{
												int num39 = NpcDialogHelper.GetMenuOptionCount(characterAccountConfig_0);
												NpcDialogHelper.SelectMenuOption(characterAccountConfig_0, num39 - 1);
											}
											break;
										}
										if (l == num38)
										{
											NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
										}
										if (num36 == -1 && characterAccountConfig_0.int_79 > 0 && num11 < 2)
										{
											string text4 = Form1.freeMedicineName;
											if (characterAccountConfig_0.string_11 != null && characterAccountConfig_0.string_11 != string.Empty)
											{
												if (text4 != null && text4 != string.Empty)
												{
													text4 += "|";
												}
												text4 += characterAccountConfig_0.string_11;
											}
											if (text4 != null && text4 != string.Empty)
											{
												num11 = MedicineRestockAutomation.MoveMatchingInventoryItemsToContainer23(characterAccountConfig_0, text4);
											}
											if (num11 == 1)
											{
												continue;
											}
										}
										goto IL_0afc;
									}
									if (NpcDialogHelper.SelectMatchingMenuOptions(characterAccountConfig_0, string_) <= 0 && NpcDialogHelper.SelectMatchingMenuOptions(characterAccountConfig_0, string_2, bool_0: true) <= 0)
									{
										goto IL_0b01;
									}
									num13 = 0;
									while (!InventoryItemHelper.IsInventoryBoxOpen(characterAccountConfig_0))
									{
										num13++;
										Thread.Sleep(100);
										if (WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_172.uint_0, characterAccountConfig_0.int_137) == 0 || InventoryItemHelper.SubmitDetectedDialogResponse(characterAccountConfig_0))
										{
											if (num13 <= 6)
											{
												continue;
											}
											goto IL_0a68;
										}
										if (Form1.skipPurchaseQuantityInputEnabled <= 0 && CommonUtility.ParseDigitsOnlyOrMinusOne(InventoryItemHelper.GetDialogInputText(characterAccountConfig_0)) != num25)
										{
											InventoryItemHelper.SetDialogInputText(characterAccountConfig_0, num25.ToString(), bool_0: true);
										}
										else
										{
											WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig_0.uint_4, 13u);
										}
										Thread.Sleep(250 + NpcDialogHelper.int_0);
										break;
									}
									goto IL_0bfe;
								}
								num4++;
								if (num4 >= 2)
								{
									break;
								}
								Thread.Sleep(300);
								if (NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig_0) >= 0)
								{
									break;
								}
								continue;
								IL_0a68:
								num8++;
								if (num8 < 2)
								{
									continue;
								}
								goto IL_0b1c;
							}
							num4 = 0;
							num5++;
							Thread.Sleep(100);
							if (num5 <= 3)
							{
								if (num5 == 3)
								{
									Class64.TryRecoverStuckMovement(characterAccountConfig_0);
								}
								num2 = 0;
								continue;
							}
							result = -5;
						}
						else
						{
							result = 1;
						}
					}
					else
					{
						Thread.Sleep(300);
						num++;
						if (num <= 3)
						{
							continue;
						}
						result = -1;
					}
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				result = 1;
			}
			goto IL_10c2;
			IL_0bfe:
			num8 = 0;
			num9 = 0;
			num10 = 2;
			if (array3 == null)
			{
				Thread.Sleep(100);
				array3 = ShopItemMemoryReader.ReadOpenShopItems(characterAccountConfig_0);
				if (array3 == null)
				{
					result = -7;
					goto IL_10c2;
				}
			}
			int num40 = 0;
			while (true)
			{
				IL_1078:
				num15 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
				if (CommonUtility.bool_0 || num15 < 0 || !Form1.characterAccountConfig_1[num15].bool_25)
				{
					break;
				}
				characterAccountConfig_0 = Form1.characterAccountConfig_1[num15];
				int num41 = -1;
				int num42 = 0;
				int num43 = 0;
				string text5 = null;
				string text6 = null;
				string text7 = null;
				int[] array7 = null;
				if (num40 != 0)
				{
					if (num40 != 1)
					{
						if (num40 != 2)
						{
							result = 1;
							break;
						}
						array7 = characterAccountConfig_0.int_73;
						text6 = characterAccountConfig_0.string_13;
					}
					else
					{
						array7 = characterAccountConfig_0.int_72;
						text6 = characterAccountConfig_0.string_12;
					}
				}
				else
				{
					array7 = characterAccountConfig_0.int_71;
					text6 = characterAccountConfig_0.string_11;
				}
				if (array7[0] > 0 && array7[2] > 0 && text6 != null && text6 != string.Empty)
				{
					text6 = text6.Trim();
					text7 = text6.ToUpper();
					int num44 = -1;
					if (array3 != null)
					{
						for (int m = 0; m < array3.Length; m++)
						{
							if (0 <= CommonUtility.FindSubstringIndex(array3[m].string_0.ToUpper(), text7))
							{
								num44 = array3[m].int_0;
							}
							if (text6 == array3[m].string_0.Trim())
							{
								num41 = array3[m].int_0;
								break;
							}
						}
					}
					if (num41 < 0)
					{
						num41 = num44;
						if (num41 < 0)
						{
							num40++;
							continue;
						}
					}
					num43 = Class85.CountInventoryItemQuantityByName(characterAccountConfig_0, text6);
					num42 = array7[2] - num43;
					if (num42 > 0)
					{
						if (num40 == 0)
						{
							text5 = text6;
						}
						int n = 0;
						uint num45 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_165.uint_0, characterAccountConfig_0.int_137);
						for (; n < 6; n++)
						{
							uint num46 = WindowsInteropHelper.ReadProcessUInt32(num45 + GameConfigurationManager.memorySignatureScanConfig_167.uint_0, characterAccountConfig_0.int_137);
							if (num46 != 0)
							{
								uint num47 = WindowsInteropHelper.ReadProcessUInt32(num46 + (uint)(n * 4), characterAccountConfig_0.int_137);
								if (num47 != 0 && WindowsInteropHelper.ReadProcessUInt32(num47, characterAccountConfig_0.int_137) != 0)
								{
									GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_56);
									Thread.Sleep(100);
								}
							}
						}
						bool flag4 = false;
						byte[] array8 = new byte[20];
						int num48 = 0;
						int num49 = 0;
						while (true)
						{
							if (num49 < num42)
							{
								int num50 = Class85.GetInventoryEntryCount(characterAccountConfig_0);
								GameProcessInteractionHelper.PurchaseSpecialFunctionItemByIndex(characterAccountConfig_0, num41);
								for (num13 = 0; num13 < 30; num13++)
								{
									if (Class85.GetInventoryEntryCount(characterAccountConfig_0) == num50)
									{
										Thread.Sleep(10);
										continue;
									}
									num13 = -1;
									num48 = 0;
									break;
								}
								if (num13 != -1)
								{
									num48++;
									if (num48 > 3)
									{
										result = 1;
										break;
									}
									num15 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_);
									if (CommonUtility.bool_0 || num15 < 0 || !Form1.characterAccountConfig_1[num15].bool_25)
									{
										break;
									}
									uint num51 = WindowsInteropHelper.ReadProcessUInt32(num45 + GameConfigurationManager.memorySignatureScanConfig_167.uint_0, characterAccountConfig_0.int_137);
									if (num51 != 0)
									{
										uint num52 = WindowsInteropHelper.ReadProcessUInt32(num51, characterAccountConfig_0.int_137);
										if (num52 != 0)
										{
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num52, array8, array8.Length, ref int_2);
											string text8 = GameTextEncodingHelper.DecodeNullTerminatedUtf7(array8);
											if (text8 != string.Empty)
											{
												if (CommonUtility.FindSubstringIndex(text8, "tói kh«ng") > 0 || CommonUtility.FindSubstringIndex(text8, "ho¶ng trèng") > 0)
												{
													flag4 = true;
													GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_56);
													goto IL_0ff5;
												}
												if (CommonUtility.FindSubstringIndex(text8, "µng kh") > 0 || (CommonUtility.FindSubstringIndex(text8, "iÒn") > 0 && CommonUtility.FindSubstringIndex(text8, "kh«ng") > 0))
												{
													result = 1;
													GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_56);
													break;
												}
											}
											Thread.Sleep(10);
										}
									}
								}
								num49++;
								continue;
							}
							goto IL_0ff5;
							IL_0ff5:
							if (characterAccountConfig_0.int_79 > 0 && num11 < 2)
							{
								string text9 = Form1.freeMedicineName;
								if (text5 != null && text5 != string.Empty)
								{
									if (text9 != null && text9 != string.Empty)
									{
										text9 += "|";
									}
									text9 += text5;
								}
								if (text9 != null && text9 != string.Empty)
								{
									num11 = MedicineRestockAutomation.MoveMatchingInventoryItemsToContainer23(characterAccountConfig_0, text9);
								}
								if (num11 > 0)
								{
									goto IL_1078;
								}
							}
							if (flag4)
							{
								break;
							}
							goto IL_1078;
						}
						break;
					}
				}
				num40++;
			}
			goto IL_10c2;
			IL_10c2:
			GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_32, 0, 4);
			if (num10 > 0)
			{
				InventoryItemHelper.CloseInventoryBoxAndPrimaryMenu(characterAccountConfig_0);
				if (Form1.repairAtCurrentLocationEnabled > 0 && Form1.skipTongKimRepairEnabled <= 0)
				{
					Class85.RepairAndCollectLowDurabilityEquipment(characterAccountConfig_0, 0, 0, num10 < 2);
				}
			}
			return result;
			IL_0b1c:
			Thread.Sleep(100);
			num8 = 0;
			num9++;
			if (num9 <= 3)
			{
				if (num9 == 3)
				{
					Class64.TryRecoverStuckMovement(characterAccountConfig_0);
				}
				num2 = 0;
				continue;
			}
			result = -6;
			goto IL_10c2;
			IL_0b01:
			NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
			num7++;
			if (num7 < 2)
			{
				num2 = 0;
				continue;
			}
			result = -6;
			goto IL_10c2;
			IL_0afc:
			flag2 = true;
		}
		return 0;
	}

	public static void RunTongKimRegistration(int int_6)
	{
		try
		{
			RunTongKimRegistrationCore(int_6);
		}
		catch
		{
		}
	}

	public static void RunTongKimRegistrationCore(int int_6)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string[] array = new string[5] { "\u00b8o danh", " gia", "\u00b8c nhËn", "§ång ý", "Õt thóc" };
		uint[,] array2 = new uint[2, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array2, 267741);
		uint[,] array3 = array2;
		uint[,] array4 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array4, 267766);
		uint[,] array5 = array4;
		uint[,] array6 = new uint[9, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array6, 267799);
		uint[,] array7 = array6;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		uint num9 = 0u;
		long long_ = 0L;
		long long_2 = 0L;
		CharacterAccountConfig characterAccountConfig = default(CharacterAccountConfig);
		uint[] array8 = new uint[2] { 54772u, 103056u };
		uint[] array9 = null;
		while (true)
		{
			Thread.Sleep(100);
			int num10 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_6);
			if (CommonUtility.bool_0 || num10 < 0 || (Form1.pkModeIndex != 1 && Form1.pkModeIndex != 3) || Form1.int_48[0] <= 0 || !Form1.characterAccountConfig_1[num10].bool_25)
			{
				break;
			}
			characterAccountConfig = Form1.characterAccountConfig_1[num10];
			if (!flag)
			{
				GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "<color=yellow>B¾t ®Çu b\u00b8o danh Tèng Kim !");
				flag = true;
			}
			uint num11 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig.int_137);
			uint num12 = WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			uint num13 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig.int_137);
			num9 = num13 + num12;
			int num14 = (int)WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig.int_137);
			int num15 = (int)WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig.int_137);
			int num16 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
			string object_ = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(characterAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_28.uint_0 + GameConfigurationManager.memorySignatureScanConfig_29.uint_0, characterAccountConfig.int_137, 60);
			uint[] array10 = new uint[2]
			{
				WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
				WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
			};
			if (array10[0] == 0 || array10[1] == 0)
			{
				continue;
			}
			int num17 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig);
			if (num15 == 0 || num14 == 0 || num14 == 10 || num14 == 21 || num16 == 0 || num17 <= 1 || (int)array10[0] <= 0 || (int)array10[1] <= 0)
			{
				continue;
			}
			if (num2 != 0)
			{
				if (FindBattlefieldMapGroupPosition(num16) != null)
				{
					break;
				}
				if (FindBattlefieldMapMatrixPosition(num16) == null)
				{
					if (!flag3)
					{
						flag3 = true;
						uint[] array11 = Class85.FindInventoryItemInfoByName(characterAccountConfig, "Tèng Kim Chiªu\u00ad");
						if (array11 == null)
						{
							array11 = Class85.FindInventoryItemInfoByName(characterAccountConfig, "Phong V©n Chiªu");
						}
						if (array11 != null)
						{
							GameProcessInteractionHelper.UseInventoryItemByRecordIndexAndPosition(characterAccountConfig, array11[0], (int)array11[1], (int)array11[2], (int)array11[3]);
							Thread.Sleep(1000);
							int num18 = NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig);
							GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig, Form1.int_48[1], Convert.ToByte(num18 != 0));
							Thread.Sleep(600);
							NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
							continue;
						}
					}
					if (num4 < 3 && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
					{
						int num19 = 323;
						int num20 = MapNavigationHelper.FindNavigationEntryIndex(323);
						if (0 <= num20 && MapNavigationHelper.NavigateToDestination(characterAccountConfig, num19))
						{
							num4++;
							Thread.Sleep(300);
							continue;
						}
						num4 = 3;
					}
					Class64.SwitchHorseStateIfNeeded(characterAccountConfig, bool_0: false);
					int num21 = (int)WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig.int_137);
					int num22 = 78;
					if (num16 == 78)
					{
						if (num21 <= 0 && Class64.GetSquaredCoordinateDistance(array10, array8) > 90000L)
						{
							if (num7 < 3)
							{
								uint[,] array12 = MapRouteCatalog.FindRoute(num16, array10, array8);
								if (array12 != null)
								{
									array9 = new uint[2]
									{
										array10[0],
										array10[1]
									};
									Class64.FollowCoordinateRoute(characterAccountConfig, array12, array10, array8, num16, bool_0: false, 16000);
									array10 = new uint[2]
									{
										WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
										WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
									};
									if (Class64.GetSquaredCoordinateDistance(array10, array9) < 90000L)
									{
										num7++;
										Class64.TryRecoverStuckMovement(characterAccountConfig);
									}
									array9 = null;
									continue;
								}
								num7 = 3;
								array9 = null;
							}
							if (CommonUtility.GetElapsedMilliseconds(long_) > 6000L)
							{
								if (array9 != null && Class64.GetSquaredCoordinateDistance(array10, array9) < 90000L)
								{
									Class64.TryRecoverStuckMovement(characterAccountConfig);
								}
								array9 = new uint[2]
								{
									array10[0],
									array10[1]
								};
								CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array8);
								long_ = CommonUtility.GetCurrentTicks();
							}
							continue;
						}
						int length = array7.GetLength(0);
						uint[] array13 = new uint[2]
						{
							array7[length - 1, 0],
							array7[length - 1, 1]
						};
						if (Class64.GetSquaredCoordinateDistance(array10, array13) <= 250000L)
						{
							Class64.TriggerMapTransitionAtCoordinate(characterAccountConfig, array13, 60);
							goto IL_08bc;
						}
						if (num8 >= 3)
						{
							if (CommonUtility.GetElapsedMilliseconds(long_) > 6000L)
							{
								if (array9 != null && Class64.GetSquaredCoordinateDistance(array10, array9) < 90000L)
								{
									Class64.TryRecoverStuckMovement(characterAccountConfig);
								}
								array9 = new uint[2]
								{
									array10[0],
									array10[1]
								};
								CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array13);
								long_ = CommonUtility.GetCurrentTicks();
							}
							continue;
						}
						array9 = new uint[2]
						{
							array10[0],
							array10[1]
						};
						Class64.FollowCoordinateRoute(characterAccountConfig, array7, array10, array13, num22, bool_0: false, 16000);
						array10 = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
						};
						if (Class64.GetSquaredCoordinateDistance(array10, array9) < 90000L)
						{
							num8++;
							Class64.TryRecoverStuckMovement(characterAccountConfig);
						}
						array9 = null;
						continue;
					}
					if (num5 < 3 && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig, GameProcessInteractionHelper.uint_19, 4) > 0)
					{
						int num23 = MapNavigationHelper.FindNavigationEntryIndex(num22);
						if (0 <= num23 && MapNavigationHelper.NavigateToDestination(characterAccountConfig, num22))
						{
							num5++;
							Thread.Sleep(600);
							continue;
						}
						num5 = 3;
					}
					if (num21 <= 0)
					{
						InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig, 78);
						continue;
					}
					if (num6 < 3 && Class64.TryUseTownTeleportItem(characterAccountConfig))
					{
						num6++;
						Thread.Sleep(600);
						continue;
					}
					num6 = 3;
					uint[] array14 = MapTravelDataHelper.FindNearestNamedMapPointCoordinates(array10, object_, "Xa phu");
					if (array14 == null)
					{
						if (num16 == 336)
						{
							long num24 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_0, array10);
							long num25 = Class64.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_1, array10);
							if (num24 > num25)
							{
								uint[] array15 = new uint[2] { 35574u, 102298u };
								if (Class64.GetSquaredCoordinateDistance(array10, array15) >= 90000L)
								{
									int int_7 = 0;
									byte[] byte_ = new byte[4];
									WindowsInteropHelper.WriteProcessMemory(characterAccountConfig.int_137, num9 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_7);
									if (CommonUtility.GetElapsedMilliseconds(long_) > 6000L)
									{
										if (array9 != null && Class64.GetSquaredCoordinateDistance(array10, array9) < 90000L)
										{
											Class64.TryRecoverStuckMovement(characterAccountConfig);
										}
										array9 = new uint[2]
										{
											array10[0],
											array10[1]
										};
										CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array15);
										long_ = CommonUtility.GetCurrentTicks();
									}
									continue;
								}
								Class64.TriggerMapTransitionAtCoordinate(characterAccountConfig, array15, 210);
								array9 = null;
								goto IL_08bc;
							}
						}
						if (CommonUtility.GetElapsedMilliseconds(long_2) > 15000L)
						{
							GameProcessInteractionHelper.PrintGameMessage(characterAccountConfig, "<color=yellow>Khong the ve Tuong duong !...");
							long_2 = CommonUtility.GetCurrentTicks();
						}
					}
					else if (CommonUtility.GetElapsedMilliseconds(long_) > 6000L)
					{
						CharacterMovementHelper.MoveToCoordinates(characterAccountConfig, array14);
						long_ = CommonUtility.GetCurrentTicks();
					}
					continue;
				}
				if (WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_66.uint_0, characterAccountConfig.int_137) == 0)
				{
					GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig, "Switch([[trade]])");
				}
				uint num26 = num11 + GameConfigurationManager.memorySignatureScanConfig_12.uint_0 + GameConfigurationManager.memorySignatureScanConfig_75.uint_0;
				uint num27 = WindowsInteropHelper.ReadProcessUInt32(num26 + GameConfigurationManager.memorySignatureScanConfig_73.uint_0, characterAccountConfig.int_137);
				int num28 = characterAccountConfig.int_66;
				if (num28 < 1000000)
				{
					num28 = 1000000;
				}
				uint num29 = WindowsInteropHelper.ReadProcessUInt32(num26 + GameConfigurationManager.memorySignatureScanConfig_74.uint_0, characterAccountConfig.int_137);
				if (!flag2 && num27 < num28 && num29 != 0)
				{
					int num30 = num28 - (int)num27;
					if (num30 > num29)
					{
						num30 = (int)num29;
					}
					if (characterAccountConfig.int_65 > 0 && characterAccountConfig.string_15 != null && characterAccountConfig.string_15 != string.Empty)
					{
						uint num31 = CommonUtility.ParseUInt32OrZero(characterAccountConfig.string_15);
						if (num31 != 0)
						{
							GameProcessInteractionHelper.UnlockInventoryBoxWithPasswordCode(characterAccountConfig, num31);
							Thread.Sleep(300);
						}
					}
					GameProcessInteractionHelper.TransferStoredMoneyToCharacter(characterAccountConfig, (uint)num30);
					flag2 = true;
				}
				long num32 = Class64.GetNearestCoordinateSquaredDistance(uint_4, array10);
				long num33 = Class64.GetNearestCoordinateSquaredDistance(uint_5, array10);
				uint[,] array16 = null;
				uint[] array17 = null;
				string text = null;
				uint[,] array18 = null;
				if (0L <= num32 && num32 < num33)
				{
					array16 = uint_4;
					array17 = new uint[2] { 49536u, 101696u };
					text = "binh quan";
					array18 = array3;
					num3 = 0;
				}
				else
				{
					array16 = uint_5;
					array17 = new uint[2] { 49728u, 98688u };
					text = "binh quan";
					array18 = array5;
					num3 = 1;
				}
				if (Form1.int_48[1] != num3)
				{
					int length2 = array18.GetLength(0);
					uint[] uint_ = new uint[2]
					{
						array18[length2 - 1, 0],
						array18[length2 - 1, 1]
					};
					if (Class64.GetSquaredCoordinateDistance(array10, uint_) <= 40000L)
					{
						GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, uint_);
						Thread.Sleep(300);
						int num34 = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig, "Xa phu", 3);
						if (num34 > 0)
						{
							CurrentCharacterMemoryHelper.SetCurrentTargetEntityIndex(characterAccountConfig, (uint)num34);
							Thread.Sleep(1000);
							int num35 = NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig);
							GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig, 3, Convert.ToByte(num35 != 0));
							Thread.Sleep(600);
							if (NpcDialogHelper.PopupMessageHelper.IsActive(characterAccountConfig))
							{
								NpcDialogHelper.PopupMessageHelper.Dismiss(characterAccountConfig);
							}
						}
					}
					else
					{
						Class64.FollowCoordinateRoute(characterAccountConfig, array18, array10, uint_, num16);
					}
					continue;
				}
				long num36 = Class64.GetSquaredCoordinateDistance(array10, array17);
				if (num36 > 60000L)
				{
					TraverseCoordinateRoute(characterAccountConfig, array16, array17, bool_0: true, 10000);
				}
				long long_3 = CommonUtility.GetCurrentTicks();
				while (!CommonUtility.bool_0)
				{
					array10 = new uint[2]
					{
						WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig.int_137),
						WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig.int_137)
					};
					long num37 = Class64.GetSquaredCoordinateDistance(array10, array17);
					if (num37 < 6000L || CommonUtility.GetElapsedMilliseconds(long_3) > 6000L)
					{
						break;
					}
					GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, array17);
					Thread.Sleep(300);
				}
				if (num > 0)
				{
					string text2 = GameEntityMemoryHelper.GetEntityNameByIndex(characterAccountConfig, num, 3);
					if (text2 == string.Empty || CommonUtility.FindSubstringIndex(text2, text) != 0)
					{
						num = 0;
					}
				}
				if (num <= 0)
				{
					num = GameEntityMemoryHelper.FindMatchingEntityIndexByNameAndType(characterAccountConfig, text, 3);
					if (num <= 0)
					{
						continue;
					}
				}
				int num38 = 0;
				while (true)
				{
					WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig.uint_4, 32u);
					Thread.Sleep(100);
					if (NpcDialogHelper.GetMenuOptionCount(characterAccountConfig) <= 0)
					{
						num16 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig.int_137);
						if (FindBattlefieldMapMatrixPosition(num16) == null)
						{
							break;
						}
						CurrentCharacterMemoryHelper.SetCurrentTargetEntityIndex(characterAccountConfig, (uint)num);
						Thread.Sleep(30 + Form1.tongKimTargetSelectionDelayMilliseconds);
					}
					while (true)
					{
						int num39 = NpcDialogHelper.GetMenuOptionCount(characterAccountConfig);
						if (num39 <= 0)
						{
							break;
						}
						int i;
						for (i = 0; i < num39; i++)
						{
							string string_ = NpcDialogHelper.GetMenuOptionText(characterAccountConfig, i, -1, 128);
							int num40 = 0;
							while (num40 < array.Length)
							{
								if (0 > CommonUtility.FindSubstringIndex(string_, array[num40]))
								{
									num40++;
									continue;
								}
								goto IL_0d66;
							}
						}
						goto end_IL_0dd9;
						IL_0d66:
						NpcDialogHelper.SelectMenuOption(characterAccountConfig, i);
						Thread.Sleep(100);
					}
					num38++;
					if (num38 > 5)
					{
						if (NpcDialogHelper.PopupMessageHelper.IsActive(characterAccountConfig))
						{
							WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig.uint_4, 27u);
						}
						break;
					}
					continue;
					end_IL_0dd9:
					break;
				}
				continue;
			}
			num2 = 1;
			GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig, new uint[2]
			{
				array10[0] + 100,
				array10[1] + 100
			});
			Thread.Sleep(300);
			continue;
			IL_08bc:
			num8 = 0;
			num7 = 0;
			num4 = 0;
			num5 = 0;
			array9 = null;
			Thread.Sleep(300);
		}
		if (flag)
		{
			NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig);
			uint num41 = WindowsInteropHelper.ReadProcessUInt32(num9 + GameConfigurationManager.memorySignatureScanConfig_66.uint_0, characterAccountConfig.int_137);
			if (num41 == 2)
			{
				GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig, "Switch([[trade]])");
			}
		}
	}

	public static int TraverseCoordinateRoute(CharacterAccountConfig characterAccountConfig_0, uint[,] uint_6, uint[] uint_7, bool bool_0 = true, int int_6 = -1, bool bool_1 = false)
	{
		int int_7 = characterAccountConfig_0.int_136;
		int result = 0;
		int num = 0;
		int num2 = -1;
		long num3 = 0L;
		bool flag = false;
		int int_8 = 0;
		byte[] array = new byte[4];
		byte[] byte_ = array;
		int num4 = -1;
		int num5 = -1;
		int num6 = -1;
		int num7 = 0;
		int num8 = 0;
		uint[] uint_8 = null;
		while (true)
		{
			Thread.Sleep(300);
			int num9 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_7);
			if (CommonUtility.bool_0 || num9 < 0 || WindowsInteropHelper.IsProcessExitedOrUnavailable(Form1.characterAccountConfig_1[num9].process_0) || !Form1.characterAccountConfig_1[num9].bool_25)
			{
				break;
			}
			characterAccountConfig_0 = Form1.characterAccountConfig_1[num9];
			int num10 = GameInterfaceMemoryHelper.ReadEngineStateByte(characterAccountConfig_0);
			if (num10 != 1)
			{
				uint num11 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137);
				uint num12 = WindowsInteropHelper.ReadProcessUInt32(num11 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, characterAccountConfig_0.int_137) * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
				uint num13 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
				uint num14 = num13 + num12;
				int num15 = (int)WindowsInteropHelper.ReadProcessUInt32(num14 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig_0.int_137);
				int num16 = (int)WindowsInteropHelper.ReadProcessUInt32(num14 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig_0.int_137);
				int num17 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.uint_0, characterAccountConfig_0.int_137);
				int num18 = (int)WindowsInteropHelper.ReadProcessUInt32(num14 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
				if ((num > 0 && num17 != num) || (bool_0 && num2 != -1 && num2 != num18))
				{
					result = 1;
					break;
				}
				int num19 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
				if (num16 != 0 && num15 != 0 && num19 > 1)
				{
					if (num15 == 10 || num15 == 21)
					{
						result = -2;
						break;
					}
					uint[] array2 = new uint[2]
					{
						WindowsInteropHelper.ReadProcessUInt32(num14 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
						WindowsInteropHelper.ReadProcessUInt32(num14 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
					};
					if (array2[0] == 0 || array2[1] == 0)
					{
						continue;
					}
					if (int_6 > 0 && num3 > 0L && CommonUtility.GetElapsedMilliseconds(num3) > int_6)
					{
						result = 101;
						break;
					}
					if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_17, 4) > 0)
					{
						GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.uint_17, 0, 4);
						result = 0;
						break;
					}
					long num20;
					if (!flag)
					{
						flag = true;
						WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num14 + GameConfigurationManager.memorySignatureScanConfig_72.uint_0, byte_, 4, ref int_8);
						num = num17;
						num2 = num18;
						num3 = CommonUtility.GetCurrentTicks();
						num6 = uint_6.GetLength(0);
						num4 = Class64.FindNearestCoordinateIndex(uint_6, array2);
						uint_8 = new uint[2]
						{
							uint_6[num4, 0],
							uint_6[num4, 1]
						};
						if (uint_7 != null)
						{
							num5 = Class64.FindNearestCoordinateIndex(uint_6, uint_7);
						}
						else
						{
							num5 = num6 - 1;
							uint_7 = new uint[2]
							{
								uint_6[num5, 0],
								uint_6[num5, 1]
							};
						}
						num7 = ((num4 <= num5) ? 1 : (-1));
						if (!bool_1 && Class64.GetSquaredCoordinateDistance(array2, uint_8) >= 250000L)
						{
							CharacterMovementHelper.MoveToCoordinates(characterAccountConfig_0, uint_8);
							num20 = CommonUtility.GetCurrentTicks();
							long long_ = num20;
							while (!CommonUtility.bool_0 && CommonUtility.GetElapsedMilliseconds(num20) < 15000L)
							{
								long num21 = CommonUtility.GetElapsedMilliseconds(num20);
								if (num21 > 15000L)
								{
									break;
								}
								if (int_6 <= 0 || num21 <= int_6)
								{
									Thread.Sleep(30);
									num15 = (int)WindowsInteropHelper.ReadProcessUInt32(num14 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, characterAccountConfig_0.int_137);
									if (num15 == 3)
									{
										long_ = CommonUtility.GetCurrentTicks();
									}
									else if (CommonUtility.GetElapsedMilliseconds(long_) > 600L)
									{
										break;
									}
									continue;
								}
								goto IL_05d0;
							}
							CharacterMovementHelper.SetMovementActive(characterAccountConfig_0, bool_0: false);
						}
					}
					Class64.SwitchHorseStateIfNeeded(characterAccountConfig_0, bool_0: false);
					int num22 = 0;
					int num23 = 0;
					num20 = CommonUtility.GetCurrentTicks();
					while (!CommonUtility.bool_0)
					{
						if (int_6 > 0 && CommonUtility.GetElapsedMilliseconds(num20) > int_6)
						{
							goto IL_05d5;
						}
						array2 = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num14 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num14 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
						};
						if (Class64.GetSquaredCoordinateDistance(array2, uint_8) < 22500L)
						{
							break;
						}
						num18 = (int)WindowsInteropHelper.ReadProcessUInt32(num14 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, characterAccountConfig_0.int_137);
						if ((num > 0 && num17 != num) || (bool_0 && num2 != -1 && num2 != num18))
						{
							goto IL_05da;
						}
						GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig_0, uint_8);
						Thread.Sleep(300);
						num22++;
						if (num22 % 3 == 0)
						{
							num9 = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_7);
							if (num9 < 0 || !Form1.characterAccountConfig_1[num9].bool_25)
							{
								goto IL_05de;
							}
						}
						if (num22 % 16 != 0)
						{
							continue;
						}
						Class64.TryRecoverStuckMovement(characterAccountConfig_0);
						num23++;
						if (num23 <= 3)
						{
							continue;
						}
						goto IL_05e3;
					}
					num4 += num7;
					if (num4 < 0 || num6 <= num4 || (num7 < 0 && num4 < num5) || (num7 > 0 && num4 > num5))
					{
						result = 1;
						break;
					}
					uint_8 = new uint[2]
					{
						uint_6[num4, 0],
						uint_6[num4, 1]
					};
				}
				else
				{
					num8++;
					if (num8 >= 6)
					{
						result = -1;
						break;
					}
					Thread.Sleep(100);
				}
			}
			else
			{
				Thread.Sleep(200);
			}
			continue;
			IL_05d5:
			result = 101;
			break;
			IL_05de:
			result = -3;
			break;
			IL_05d0:
			result = 101;
			break;
			IL_05e3:
			result = -3;
			break;
			IL_05da:
			result = 1;
			break;
		}
		return result;
	}
}
