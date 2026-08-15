using ns10;
using ns11;
using ns53;
using ns61;
using ns63;

namespace ns6;

internal class CongThanhQuanTransportCatalog
{
	public struct CityTransportRoute
	{
		public int int_0;

		public uint[,] uint_0;

		public int int_1;
	}

	public struct CityTransportData
	{
		public string string_0;

		public uint[] uint_0;

		public int int_0;

		public int int_1;

		public string string_1;

		public string string_2;
	}

	public static CityTransportRoute[] TransportRoutes;

	public static CityTransportData[] CityEntries;

	static CongThanhQuanTransportCatalog()
	{
		CityTransportRoute[] array = new CityTransportRoute[20];
		ref CityTransportRoute reference = ref array[0];
		CityTransportRoute cityTransportRoute = new CityTransportRoute
		{
			int_0 = 926,
			int_1 = 931
		};
		uint[,] array2 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array2, 397660);
		cityTransportRoute.uint_0 = array2;
		reference = cityTransportRoute;
		ref CityTransportRoute reference2 = ref array[1];
		CityTransportRoute cityTransportRoute2 = new CityTransportRoute
		{
			int_0 = 926,
			int_1 = 929
		};
		uint[,] array3 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array3, 397701);
		cityTransportRoute2.uint_0 = array3;
		reference2 = cityTransportRoute2;
		ref CityTransportRoute reference3 = ref array[2];
		CityTransportRoute cityTransportRoute3 = new CityTransportRoute
		{
			int_0 = 926,
			int_1 = 928
		};
		uint[,] array4 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array4, 397742);
		cityTransportRoute3.uint_0 = array4;
		reference3 = cityTransportRoute3;
		ref CityTransportRoute reference4 = ref array[3];
		CityTransportRoute cityTransportRoute4 = new CityTransportRoute
		{
			int_0 = 931,
			int_1 = 928
		};
		uint[,] array5 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array5, 397783);
		cityTransportRoute4.uint_0 = array5;
		reference4 = cityTransportRoute4;
		ref CityTransportRoute reference5 = ref array[4];
		CityTransportRoute cityTransportRoute5 = new CityTransportRoute
		{
			int_0 = 931,
			int_1 = 932
		};
		uint[,] array6 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array6, 397824);
		cityTransportRoute5.uint_0 = array6;
		reference5 = cityTransportRoute5;
		ref CityTransportRoute reference6 = ref array[5];
		CityTransportRoute cityTransportRoute6 = new CityTransportRoute
		{
			int_0 = 931,
			int_1 = 929
		};
		uint[,] array7 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array7, 397865);
		cityTransportRoute6.uint_0 = array7;
		reference6 = cityTransportRoute6;
		ref CityTransportRoute reference7 = ref array[6];
		CityTransportRoute cityTransportRoute7 = new CityTransportRoute
		{
			int_0 = 931,
			int_1 = 926
		};
		uint[,] array8 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array8, 397906);
		cityTransportRoute7.uint_0 = array8;
		reference7 = cityTransportRoute7;
		ref CityTransportRoute reference8 = ref array[7];
		CityTransportRoute cityTransportRoute8 = new CityTransportRoute
		{
			int_0 = 929,
			int_1 = 931
		};
		uint[,] array9 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array9, 397947);
		cityTransportRoute8.uint_0 = array9;
		reference8 = cityTransportRoute8;
		ref CityTransportRoute reference9 = ref array[8];
		CityTransportRoute cityTransportRoute9 = new CityTransportRoute
		{
			int_0 = 929,
			int_1 = 926
		};
		uint[,] array10 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array10, 397988);
		cityTransportRoute9.uint_0 = array10;
		reference9 = cityTransportRoute9;
		ref CityTransportRoute reference10 = ref array[9];
		CityTransportRoute cityTransportRoute10 = new CityTransportRoute
		{
			int_0 = 929,
			int_1 = 927
		};
		uint[,] array11 = new uint[2, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array11, 398029);
		cityTransportRoute10.uint_0 = array11;
		reference10 = cityTransportRoute10;
		ref CityTransportRoute reference11 = ref array[10];
		CityTransportRoute cityTransportRoute11 = new CityTransportRoute
		{
			int_0 = 927,
			int_1 = 929
		};
		uint[,] array12 = new uint[2, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array12, 398090);
		cityTransportRoute11.uint_0 = array12;
		reference11 = cityTransportRoute11;
		ref CityTransportRoute reference12 = ref array[11];
		CityTransportRoute cityTransportRoute12 = new CityTransportRoute
		{
			int_0 = 927,
			int_1 = 932
		};
		uint[,] array13 = new uint[2, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array13, 398151);
		cityTransportRoute12.uint_0 = array13;
		reference12 = cityTransportRoute12;
		ref CityTransportRoute reference13 = ref array[12];
		CityTransportRoute cityTransportRoute13 = new CityTransportRoute
		{
			int_0 = 932,
			int_1 = 931
		};
		uint[,] array14 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array14, 398212);
		cityTransportRoute13.uint_0 = array14;
		reference13 = cityTransportRoute13;
		ref CityTransportRoute reference14 = ref array[13];
		CityTransportRoute cityTransportRoute14 = new CityTransportRoute
		{
			int_0 = 932,
			int_1 = 927
		};
		uint[,] array15 = new uint[2, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array15, 398253);
		cityTransportRoute14.uint_0 = array15;
		reference14 = cityTransportRoute14;
		ref CityTransportRoute reference15 = ref array[14];
		CityTransportRoute cityTransportRoute15 = new CityTransportRoute
		{
			int_0 = 932,
			int_1 = 930
		};
		uint[,] array16 = new uint[2, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array16, 398314);
		cityTransportRoute15.uint_0 = array16;
		reference15 = cityTransportRoute15;
		ref CityTransportRoute reference16 = ref array[15];
		CityTransportRoute cityTransportRoute16 = new CityTransportRoute
		{
			int_0 = 930,
			int_1 = 932
		};
		uint[,] array17 = new uint[2, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array17, 398375);
		cityTransportRoute16.uint_0 = array17;
		reference16 = cityTransportRoute16;
		ref CityTransportRoute reference17 = ref array[16];
		CityTransportRoute cityTransportRoute17 = new CityTransportRoute
		{
			int_0 = 930,
			int_1 = 928
		};
		uint[,] array18 = new uint[2, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array18, 398436);
		cityTransportRoute17.uint_0 = array18;
		reference17 = cityTransportRoute17;
		ref CityTransportRoute reference18 = ref array[17];
		CityTransportRoute cityTransportRoute18 = new CityTransportRoute
		{
			int_0 = 928,
			int_1 = 931
		};
		uint[,] array19 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array19, 398497);
		cityTransportRoute18.uint_0 = array19;
		reference18 = cityTransportRoute18;
		ref CityTransportRoute reference19 = ref array[18];
		CityTransportRoute cityTransportRoute19 = new CityTransportRoute
		{
			int_0 = 928,
			int_1 = 930
		};
		uint[,] array20 = new uint[2, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array20, 398538);
		cityTransportRoute19.uint_0 = array20;
		reference19 = cityTransportRoute19;
		ref CityTransportRoute reference20 = ref array[19];
		CityTransportRoute cityTransportRoute20 = new CityTransportRoute
		{
			int_0 = 928,
			int_1 = 926
		};
		uint[,] array21 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array21, 398599);
		cityTransportRoute20.uint_0 = array21;
		reference20 = cityTransportRoute20;
		TransportRoutes = array;
		CityEntries = new CityTransportData[7]
		{
			new CityTransportData
			{
				int_0 = 78,
				int_1 = 931,
				string_2 = "Tương Dương",
				string_1 = "T\u00ad¬ng D\u00ad¬ng"
			},
			new CityTransportData
			{
				int_0 = 80,
				int_1 = 932,
				string_2 = "Dương Châu",
				string_1 = "D\u00ad¬ng Ch©u"
			},
			new CityTransportData
			{
				int_0 = 1,
				int_1 = 929,
				string_2 = "Phượng Tường",
				string_1 = "Ph\u00adîng T\u00adêng"
			},
			new CityTransportData
			{
				int_0 = 162,
				int_1 = 928,
				string_2 = "Đại Lý",
				string_1 = "§¹i Lý"
			},
			new CityTransportData
			{
				int_0 = 11,
				int_1 = 926,
				string_2 = "Thành Đô",
				string_1 = "Thµnh §«"
			},
			new CityTransportData
			{
				int_0 = 176,
				int_1 = 930,
				string_2 = "Lâm An",
				string_1 = "L©m An"
			},
			new CityTransportData
			{
				int_0 = 37,
				int_1 = 927,
				string_2 = "Biện Kinh",
				string_1 = "BiÖn Kinh"
			}
		};
	}

	public static bool IsTransportMap(int int_0)
	{
		for (int i = 0; i < TransportRoutes.Length; i++)
		{
			if (int_0 == TransportRoutes[i].int_0)
			{
				return true;
			}
		}
		return false;
	}

	public static uint[] GetRouteWaypoint(int int_0, uint[] uint_0, int int_1, uint[] uint_1)
	{
		if (IsTransportMap(int_0) && IsTransportMap(int_1))
		{
			bool flag = false;
			int num = -1;
			int num2 = 0;
			while (true)
			{
				if (num2 < TransportRoutes.Length)
				{
					if (TransportRoutes[num2].int_0 != int_0 || TransportRoutes[num2].int_1 != int_1)
					{
						num2++;
						continue;
					}
					num = num2;
					break;
				}
				int[] int_2 = null;
				for (num2 = 0; num2 < TransportRoutes.Length; num2++)
				{
					if (TransportRoutes[num2].int_0 == int_1)
					{
						CommonUtility.AppendIntIfMissing(ref int_2, TransportRoutes[num2].int_1);
					}
				}
				if (int_2 == null)
				{
					return null;
				}
				num = -1;
				flag = true;
				int num3 = 0;
				while (true)
				{
					if (num3 < int_2.Length)
					{
						int num4 = int_2[num3];
						num2 = 0;
						while (num2 < TransportRoutes.Length)
						{
							if (TransportRoutes[num2].int_0 != int_0 || TransportRoutes[num2].int_1 != num4)
							{
								num2++;
								continue;
							}
							goto IL_0116;
						}
						num3++;
						continue;
					}
					int_1 = ((int_0 == 927 || int_0 == 930) ? 932 : 931);
					num2 = 0;
					while (true)
					{
						if (num2 < TransportRoutes.Length)
						{
							if (TransportRoutes[num2].int_0 == int_0 && TransportRoutes[num2].int_1 == int_1)
							{
								break;
							}
							num2++;
							continue;
						}
						return null;
					}
					num = num2;
					break;
					IL_0116:
					num = num2;
					break;
				}
				break;
			}
			int length = TransportRoutes[num].uint_0.GetLength(0);
			if (length == 1)
			{
				return new uint[3]
				{
					TransportRoutes[num].uint_0[0, 0],
					TransportRoutes[num].uint_0[0, 1],
					TransportRoutes[num].uint_0[0, 2]
				};
			}
			int num5 = -1;
			long num6 = -1L;
			long num7 = -1L;
			for (num2 = 0; num2 < length; num2++)
			{
				if (!flag)
				{
					uint[] uint_2 = new uint[2]
					{
						TransportRoutes[num].uint_0[num2, 3],
						TransportRoutes[num].uint_0[num2, 4]
					};
					num7 = Class64.GetSquaredCoordinateDistance(uint_2, uint_1);
				}
				else
				{
					uint[] uint_3 = new uint[2]
					{
						TransportRoutes[num].uint_0[num2, 0],
						TransportRoutes[num].uint_0[num2, 1]
					};
					num7 = Class64.GetSquaredCoordinateDistance(uint_0, uint_3);
				}
				if (num5 < 0 || num7 < num6)
				{
					num6 = num7;
					num5 = num2;
				}
			}
			return new uint[3]
			{
				TransportRoutes[num].uint_0[num5, 0],
				TransportRoutes[num].uint_0[num5, 1],
				TransportRoutes[num].uint_0[num5, 2]
			};
		}
		return null;
	}

	public static int FindCityEntryIndex(int int_0, int int_1 = 0)
	{
		int num = 0;
		while (true)
		{
			if (num < CityEntries.Length)
			{
				if ((int_1 == 0 && int_0 == CityEntries[num].int_0) || int_0 == CityEntries[num].int_1)
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

	public static void LoadTransportOverrides()
	{
		string text = CommonUtility.DecodeBase64Utf8(WindowsRegistryHelper.ReadApplicationRegistryString("tbXpCongthanh", 0, "0"));
		if (text == null || text == string.Empty)
		{
			text = CommonUtility.DecodeBase64Utf8(CommonUtility.ReadAllTextWithEncodingOption(GameConfigurationManager.configDirectory + "\\XaphuCT.txt", 1, 1, 1));
		}
		if (text == null || text == string.Empty)
		{
			return;
		}
		string[] array = text.Split('|');
		if (array.Length != 7)
		{
			return;
		}
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(';');
			if (array2.Length != 4)
			{
				continue;
			}
			int num = CommonUtility.ParseInt32OrZero(array2[0]);
			for (int j = 0; j < CityEntries.Length; j++)
			{
				if (num == CityEntries[j].int_0)
				{
					CityEntries[j].string_0 = array2[1];
					CityEntries[j].uint_0 = new uint[2]
					{
						CommonUtility.ParseUInt32OrZero(array2[2]),
						CommonUtility.ParseUInt32OrZero(array2[3])
					};
					break;
				}
			}
		}
	}

	public static void SaveTransportOverrides()
	{
		string text = null;
		for (int i = 0; i < CityEntries.Length; i++)
		{
			string text2 = string.Empty;
			string text3 = string.Empty;
			if (CityEntries[i].string_0 != null)
			{
				text2 = CityEntries[i].string_0;
			}
			if (CityEntries[i].uint_0 != null)
			{
				text3 = CityEntries[i].uint_0[0] + ";" + CityEntries[i].uint_0[1];
			}
			if (text != null)
			{
				text += "|";
			}
			object obj = text;
			text = string.Concat(obj, CityEntries[i].int_0, ";", text2, ";", text3);
		}
		string text4 = CommonUtility.EncodeBase64Utf8(text);
		WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "tbXpCongthanh", text4, "", 0);
		CommonUtility.WriteAllTextWithEncodingOption(GameConfigurationManager.configDirectory + "\\XaphuCT.txt", text4, 1);
	}
}
